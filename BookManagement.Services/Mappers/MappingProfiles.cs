using AutoMapper;
using BookManagement.BusinessObject;
using BookManagement.BusinessObject.Author;
using BookManagement.BusinessObject.Book;
using BookManagement.DAOs;
using BookManagement.DAOs.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Services.Mappers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            //Book
            CreateMap<Book, BookDTO>().ReverseMap();
            CreateMap<BookDTO, Book>().ReverseMap();

            //Author
            CreateMap<Author, AuthorDTO>().ReverseMap();
            CreateMap<AuthorDTO, Author>().ReverseMap();
            CreateMap<CreateAuthorDTO, Author>().ReverseMap();
            CreateMap<UpdateAuthorDTO, Author>().ReverseMap();

        }
    }
}
