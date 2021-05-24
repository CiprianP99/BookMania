using BookMania.Interfaces;
using BookMania.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookMania.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private BookContext _bookContext;
        private IBookRepository _bookRepository;
        private IAuthorRepository _authorRepository;
        private ICategoryRepository _categoryRepository;
        private IUserRepository _userRepository;
        private IReviewRepository _reviewRepository;
        private IBookAuthorRepository _bookauthorRepository;

        public IBookRepository BookRepository
        {
            get
            {
                if (_bookRepository == null)
                {
                    _bookRepository = new BookRepository(_bookContext);
                }
                return _bookRepository;
            }
        }

        public IAuthorRepository AuthorRepository
        {
            get
            {
                if (_authorRepository == null)
                {
                    _authorRepository = new AuthorRepository(_bookContext);
                }
                return _authorRepository;
            }
        }

        public ICategoryRepository CategoryRepository
        {
            get
            {
                if (_categoryRepository == null)
                {
                    _categoryRepository = new CategoryRepository(_bookContext);
                }
                return _categoryRepository;
            }
        }

        public IUserRepository UserRepository
        {
            get
            {
                if (_userRepository == null)
                {
                    _userRepository = new UserRepository(_bookContext);
                }
                return _userRepository;
            }
        }

        public IReviewRepository ReviewRepository
        {
            get
            {
                if (_reviewRepository == null)
                {
                    _reviewRepository = new ReviewRepository(_bookContext);
                }
                return _reviewRepository;
            }
        }

        public IBookAuthorRepository BookAuthorRepository
        {
            get
            {
                if (_bookauthorRepository == null)
                {
                    _bookauthorRepository = new BookAuthorRepository(_bookContext);
                }
                return _bookauthorRepository;
            }
        }

        public RepositoryWrapper(BookContext bookContext)
        {
            _bookContext = bookContext;
        }

        public void Save()
        {
            _bookContext.SaveChanges();
        }
    }
}
