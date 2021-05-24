using BookMania.Interfaces;
using BookMania.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookMania.Repositories
{
    public class BookAuthorRepository : RepositoryBase<BookAuthor>, IBookAuthorRepository
    {
        public BookAuthorRepository(BookContext bookContext)
            : base(bookContext)
        {

        }
    }
}
