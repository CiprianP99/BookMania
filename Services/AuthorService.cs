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
    public class AuthorService : BaseService
    {
        public AuthorService(IRepositoryWrapper repositoryWrapper)
            : base(repositoryWrapper)
        {
        }

        public List<Author> GetAuthors()
        {
            return repositoryWrapper.AuthorRepository.FindAll().ToList();
        }

        public List<Author> GetAuthorsByCondition(Expression<Func<Author, bool>> expression)
        {
            return repositoryWrapper.AuthorRepository.FindByCondition(expression).ToList();
        }

        public void AddAuthor(Author author)
        {
            repositoryWrapper.AuthorRepository.Create(author);
        }

        public void UpdateAuthor(Author author)
        {
            repositoryWrapper.AuthorRepository.Update(author);
        }

        public void DeleteAuthor(Author author)
        {
            repositoryWrapper.AuthorRepository.Delete(author);
        }
    }
}
