using BookMania.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookMania.ViewModels
{
    public class BookCreationViewModel
    {
        public int BookId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int Pages { get; set; }

        public int Year { get; set; }

        public string bookImg { get; set; }

        public IFormFile Photo { get; set; }

        public ICollection<Category> Categories { get; set; }

        public int CategoryId { get; set; }

        public ICollection<Author> BookAuthors { get; set; }

        [Display(Name="Author")]
        public int[] SelectedAuthor { get; set; }

        [Display(Name="Category")]
        public int SelectedCategory { get; set; }

        
    }
}
