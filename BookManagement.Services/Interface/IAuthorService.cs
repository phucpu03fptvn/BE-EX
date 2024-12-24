using BookManagement.BusinessObject;
using BookManagement.BusinessObject.Author;
using BookManagement.DAOs.Entities;
using BookManagement.DAOs.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Services.Interface
{
    public interface IAuthorService
    {
        Task<ApplicationResponse> GetAllAuthors();

        Task<ApplicationResponse> GetAuthorById(int authorId);

        Task<ApplicationResponse> AddNewAuthor(CreateAuthorDTO newAuthor);

        Task<ApplicationResponse> UpdateAuthor(UpdateAuthorDTO newAuthor);

        Task<ApplicationResponse> DeleteAuthor(int authorId);
    }
}
