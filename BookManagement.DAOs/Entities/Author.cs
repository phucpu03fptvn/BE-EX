using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace BookManagement.DAOs.Entities
{
    public class Author
    {
        [Key]
        public int AuthorId { get; set; }

        [Required] 
        [MaxLength(100)] 
        public string Name { get; set; }

        [MaxLength(500)] 
        public string Bio { get; set; }

        [JsonIgnore]
        public virtual ICollection<Book> Books { get; set; }
    }
}
