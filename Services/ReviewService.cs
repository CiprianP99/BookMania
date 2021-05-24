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
    public class ReviewService : BaseService
    {
        public ReviewService(IRepositoryWrapper repositoryWrapper)
            : base(repositoryWrapper)
        {
        }

        public List<Review> GetReviews()
        {
            return repositoryWrapper.ReviewRepository.FindAll().ToList();
        }

        public List<Review> GetReviewsByCondition(Expression<Func<Review, bool>> expression)
        {
            return repositoryWrapper.ReviewRepository.FindByCondition(expression).ToList();
        }

        public void AddReview(Review review)
        {
            repositoryWrapper.ReviewRepository.Create(review);
        }

        public void UpdateReview(Review review)
        {
            repositoryWrapper.ReviewRepository.Update(review);
        }

        public void DeleteReview(Review review)
        {
            repositoryWrapper.ReviewRepository.Delete(review);
        }
    }
}
