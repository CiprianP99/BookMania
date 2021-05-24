using BookMania.Interfaces;
using BookMania.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookMania.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(BookContext bookContext)
            : base(bookContext)
        {

        }
    }
}
