using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookMania.Interfaces
{
    public interface IRepositoryWrapper
    {
        IBookRepository BookRepository { get; }
        IAuthorRepository AuthorRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        IUserRepository UserRepository { get; }
        IReviewRepository ReviewRepository { get; }
        IBookAuthorRepository BookAuthorRepository { get; }

        void Save();
    }
}
