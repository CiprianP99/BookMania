using BookMania.Interfaces;
using BookMania.Models;
using BookMania.Services;
using BookMania.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Web;
using Microsoft.AspNetCore.Identity;
using PusherServer;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using cloudscribe.Pagination.Models;

namespace BookMania.Controllers
{
    [Authorize(Roles = "Administrator,User")]
    public class BookController : Controller
    {
        private readonly BookService _bookService;
        private readonly AuthorService _authorService;
        private readonly BookAuthorService _bookAuthorService;
        private readonly CategoryService _categoryService;
        private readonly ReviewService _reviewService;
        private readonly IHostingEnvironment _hostEnv;
        private readonly IUnitOfWork _unit;


        public BookController(BookService bookService, AuthorService authorService, BookAuthorService bookAuthorService, CategoryService categoryService, ReviewService reviewService, IHostingEnvironment hosting,IUnitOfWork unit)
        {
            _bookService = bookService;
            _authorService = authorService;
            _bookAuthorService = bookAuthorService;
            _categoryService = categoryService;
            _reviewService = reviewService;
            _hostEnv = hosting;
            _unit = unit;
        }

        //private readonly List<Category> _categories = new List<Category>()
        //{
        //    new Category() {CategoryId=3, CategoryName="Beletristica"}
        //};
        // GET: Books
        [Authorize(Roles = "Administrator,User")]
        public IActionResult Index(string SearchString, int pageNumber = 1, int pageSize = 2)
        {
            //int ExcludeRecords = (pageSize * pageNumber) - pageSize;
            //var books = _bookService.GetBooks().Skip(ExcludeRecords).Take(pageSize);
            var books = _bookService.GetBooks();
            //books = _bookService.GetBooksByCondition(a => a.Title == SearchString || a.Description == SearchString);
        //    var result = new PagedResult<Book>
        //    {
        //        Data = books.ToList(),
        //        TotalItems = books.ToList().Count(),
        //        PageNumber = pageNumber,
        //        PageSize = pageSize
        //};
            
            if (!String.IsNullOrEmpty(SearchString))
            {
                books = books.Where(s => s.Title.Contains(SearchString)).ToList();
                //return View(books);
            }
            return View(books);
           // return View(result);
        }

      

        // GET: Books/Details/5
        [Authorize(Roles = "Administrator,User")]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            
            var book = _bookService.GetBooks().FirstOrDefault(m => m.BookId == id);
            if (book == null)
            {
                return NotFound();
            }
            IEnumerable<BookAuthor> bookAuthors = _bookAuthorService.GetBookAuthors().Where(b => b.BookId == book.BookId);
            List<Author> authors = new List<Author>();
            foreach (var ba in bookAuthors)
            {
                authors.Add(_authorService.GetAuthors().FirstOrDefault(a => a.AuthorId == ba.AuthorId));
            }

            string auth = null;
            foreach (var currentAuthor in authors)
            {
                auth += currentAuthor.FirstName;
                auth += ", ";
            }


            var vm = new BookDetailViewModel
            {
                BookId = book.BookId,
                Title = book.Title,
                Year = book.Year,
                Pages = book.Pages,
                Description = book.Description,
                Category = _categoryService.GetCategories().FirstOrDefault(g => g.CategoryId == book.CategoryId),
                Authors = auth
            };


            return View(vm);
        }

        // GET: Books/Create
        [Authorize(Roles = "Administrator")]
        public IActionResult Create()
        {
            var addModel = new BookCreationViewModel
            {
                BookAuthors = _authorService.GetAuthors().ToList<Author>(),
               // Categories = _categoryService.GetCategories().ToList<Category>()
              //  Categories = _categoryService.GetCategories()

            };

            ViewBag.CategoryId = new SelectList(_categoryService.GetCategories(), "CategoryId", "CategoryName");
            return View(addModel);
        }
        // POST: Books/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([FromForm] BookCreationViewModel book)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;
                if (book.Photo != null)
                {
                    string uploadsFolder = Path.Combine(_hostEnv.WebRootPath, "images");
                    uniqueFileName = Guid.NewGuid().ToString() + "" + book.Photo.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    book.Photo.CopyTo(new FileStream(filePath, FileMode.Create));

                }
                //_unit.UploadImage(file);
                Category selectedCategory = _categoryService.GetCategories().SingleOrDefault(a => a.CategoryId == book.CategoryId);
                Book newBook = new Book
                {
                    Title = book.Title,
                    Description = book.Description,
                    Year = book.Year,
                    Pages = book.Pages,
                    BookAuthors = new List<BookAuthor>(),
                    CategoryId = selectedCategory.CategoryId,
                    bookImg = uniqueFileName,
                    //bookImg = file.Filename
                };
                var authorList = new List<Author>();
                //foreach(var items in authorList)
                for (int i = 0; i < book.SelectedAuthor.Length; i++)
                {
                    Author selectedAuthor = _authorService.GetAuthors().SingleOrDefault(author => author.AuthorId == book.SelectedAuthor[i]); 
                    authorList.Add(selectedAuthor);
                }

                
                
                //var authorList = new List<Author>();
                //book.BookAuthors = book.SelectedAuthor.Select(i => new BookAuthor { Book = , AuthorId = i }).ToList();
                //for (int i = 0; i <= book.SelectedAuthor.Length; i++)
                //{
                //    authorList = _authorService.GetAuthors()
                //        .SingleOrDefault(author => author.AuthorId == book.SelectedAuthor[i]);
                //}

                _bookService.AddBook(newBook);
                _bookService.Save();
                var myBook = _bookService.GetBooks().LastOrDefault();
                if(myBook != null)
                {
                    for(int i = 0; i < authorList.Count;i++)
                    {
                        _bookAuthorService.AddBookAuthor(new BookAuthor
                        {
                            BookId = myBook.BookId,
                            AuthorId = authorList[i].AuthorId
                        });
                    }
                    
                    _bookAuthorService.Save();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        public IActionResult Review(int? id)
        {
            var reviews = _reviewService.GetReviews().Where(x => x.Book.BookId == id).ToArray();
            return Json(reviews, System.Web.Mvc.JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public async Task<IActionResult> Review(Review data)
        {
            _reviewService.AddReview(data);
            _reviewService.Save();
            var options = new PusherOptions();
            options.Cluster = "XXX_APP_CLUSTER";
            var pusher = new Pusher("XXX_APP_ID", "XXX_APP_KEY", "XXX_APP_SECRET", options);
            ITriggerResult result = await pusher.TriggerAsync("asp_channel", "asp_event", data);
            return Content("ok");
        }

        // GET: Books/Edit/5
        [Authorize(Roles = "Administrator")]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = _bookService.GetBooks().FirstOrDefault(m => m.BookId == id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [FromForm] Book book)
        {
            if (id != book.BookId)
            {
                return NotFound();
            }
            
            if (ModelState.IsValid)
            {
                try
                {
                    
                    _bookService.UpdateBook(book);
                    _bookService.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookExists(book.BookId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        // GET: Books/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = _bookService.GetBooks().FirstOrDefault(m => m.BookId == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }
       
        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var book = _bookService.GetBooksByCondition(b => b.BookId == id).FirstOrDefault();
            _bookService.DeleteBook(book);
            _bookService.Save();
            return RedirectToAction(nameof(Index));
        }

        private bool BookExists(int id)
        {
            return _bookService.GetBooks().Any(e => e.BookId == id);
        }
    }
}
