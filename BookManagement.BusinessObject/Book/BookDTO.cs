using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.BusinessObject.Book
{
    public class BookDTO
    {
        public int BookId { get; set; }

        public string Title { get; set; }

        public decimal Price { get; set; }
        public int AuthorId { get; set; }
        public DateTime? PublishedDate { get; set; }
    }
}
