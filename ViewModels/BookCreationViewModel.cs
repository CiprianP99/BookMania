using BookMania.Models;
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


        //public List<SelectListItem> AuthorItems
        //{
        //    get
        //    {
        //        List<SelectListItem> listItems = new List<SelectListItem>();
        //        if (BookAuthors != null)
        //            listItems.AddRange(BookAuthors.Select(Item => new SelectListItem { Value = Item.AuthorId + "", Text = Item.FirstName }));
        //        return listItems;
        //    }
        //}

        //public List<SelectListItem>CategoryItems
        //{
        //    get
        //    {
        //        List<SelectListItem> listItemsC = new List<SelectListItem>();
        //        if (Categories != null)
        //            listItemsC.AddRange(Categories.Select(Item => new SelectListItem { Value = Item.CategoryId + "", Text = Item.CategoryName }));
        //        return listItemsC;
        //    }
        //}



        public ICollection<Category> Categories { get; set; }

        public int CategoryId { get; set; }

        public ICollection<Author> BookAuthors { get; set; }

        [Display(Name="Author")]
        public int[] SelectedAuthor { get; set; }

        [Display(Name="Category")]
        public int SelectedCategory { get; set; }

        



        //[Display(Name="Category")]
        //public int SelectedCategory { get; set; }
    }
}
