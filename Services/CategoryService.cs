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
    public class CategoryService : BaseService
    {
        public CategoryService(IRepositoryWrapper repositoryWrapper)
            : base(repositoryWrapper)
        {
        }

        public List<Category> GetCategories()
        {
            return repositoryWrapper.CategoryRepository.FindAll().ToList();
        }

        public List<Category> GetCategorysByCondition(Expression<Func<Category, bool>> expression)
        {
            return repositoryWrapper.CategoryRepository.FindByCondition(expression).ToList();
        }

        public void AddCategory(Category category)
        {
            repositoryWrapper.CategoryRepository.Create(category);
        }

        public void UpdateCategory(Category category)
        {
            repositoryWrapper.CategoryRepository.Update(category);
        }

        public void DeleteCategory(Category category)
        {
            repositoryWrapper.CategoryRepository.Delete(category);
        }
    }
}
