using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookMania.Models
{
    public class Review
    {
        public int ReviewId { get; set; }

        public double Rating { get; set; }

        public string ReviewText { get; set; }

        public int? BookId { get; set; }

        public int? UserId { get; set; }

        public Book Book { get; set; }

        public User User { get; set; }
    }
}
