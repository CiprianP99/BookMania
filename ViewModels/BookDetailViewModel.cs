using BookMania.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookMania.ViewModels
{
    public class BookDetailViewModel
    {
        public int BookId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int Pages { get; set; }

        public int Year { get; set; }

        [Display(Name = "Category")]
        public string CategoryId { get; set; }
        public Category Category { get; set; }


        public string Authors { get; set; }
    }
}
