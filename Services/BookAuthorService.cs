using BookMania.Interfaces;
using BookMania.Models;
using BookMania.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BookMania.Services
{
    public class BookAuthorService : BaseService
    {
        public BookAuthorService(IRepositoryWrapper repositoryWrapper)
            : base(repositoryWrapper)
        {
        }

        public List<BookAuthor> GetBookAuthors()
        {
            return repositoryWrapper.BookAuthorRepository.FindAll().ToList();
        }

        public List<BookAuthor> GetBookAuthorsByCondition(Expression<Func<BookAuthor, bool>> expression)
        {
            return repositoryWrapper.BookAuthorRepository.FindByCondition(expression).ToList();
        }

        public void AddBookAuthor(BookAuthor bookauthor)
        {
            repositoryWrapper.BookAuthorRepository.Create(bookauthor);
        }

        public void UpdateBookAuthor(BookAuthor bookauthor)
        {
            repositoryWrapper.BookAuthorRepository.Update(bookauthor);
        }

        public void DeleteBookAuthor(BookAuthor bookauthor)
        {
            repositoryWrapper.BookAuthorRepository.Delete(bookauthor);
        }
    }
}
