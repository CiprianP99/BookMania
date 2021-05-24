using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookMania.Models
{
    public class Book
    {
        public int BookId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int Pages { get; set; }

        public int Year { get; set; }

        public byte[] bookImg { get; set; }

        public int? CategoryId { get; set; }

        public Category Category { get; set; }

        public ICollection<Review> Reviews { get; set; }

        public ICollection<BookAuthor> BookAuthors { get; set; }


    }
}
