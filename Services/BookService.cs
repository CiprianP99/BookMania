using BookMania.Interfaces;
using BookMania.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BookMania.Services
{
    public class BookService : BaseService
    {
        public BookService(IRepositoryWrapper repositoryWrapper)
            :base(repositoryWrapper)
        {
        }

        public List<Book> GetBooks()
        {
            return repositoryWrapper.BookRepository.FindAll().ToList();
        }

        public List<Book> GetBooksByCondition(Expression<Func<Book, bool>> expression)
        {
            return repositoryWrapper.BookRepository.FindByCondition(expression).ToList();
        }

        public void AddBook(Book book)
        {
            repositoryWrapper.BookRepository.Create(book);
        }

        public void UpdateBook(Book book)
        {
            repositoryWrapper.BookRepository.Update(book);
        }

        public void DeleteBook(Book book)
        {
            repositoryWrapper.BookRepository.Delete(book);
        }
    }
}
