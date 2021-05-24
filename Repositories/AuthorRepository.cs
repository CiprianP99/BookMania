using BookMania.Interfaces;
using BookMania.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookMania.Repositories
{
    public class AuthorRepository : RepositoryBase<Author>, IAuthorRepository
    {
        public AuthorRepository(BookContext bookContext)
            :base(bookContext)
        {

        }
    }
}
