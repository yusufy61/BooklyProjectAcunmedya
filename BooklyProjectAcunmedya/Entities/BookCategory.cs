using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BooklyProjectAcunmedya.Entities
{
    public class BookCategory
    {
        public int BookCategoryId { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public int BookId { get; set; }
        public virtual Book Book { get; set; }
    }
}