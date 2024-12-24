﻿using BookManagement.BusinessObject.Book;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.BusinessObject.Author
{
    public class AuthorDTO
    {
        public int AuthorId { get; set; }

        public string Name { get; set; }

        public string Bio { get; set; }

        public List<BookDTO> Books { get; set; }

    }
}
