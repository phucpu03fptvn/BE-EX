using BookManagement.DAOs.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Repositories.Interface
{
    public interface IAuthorRepository
    {
        Task<List<Author>> GetAllAuthors();

        Task<Author> GetAuthorById(int authorId);

        Task<Author> AddNewAuthor(Author newAuthor);

        Task UpdateAuthor(Author newAuthor);

        Task DeleteAuthor(int authorId);
    }
}
