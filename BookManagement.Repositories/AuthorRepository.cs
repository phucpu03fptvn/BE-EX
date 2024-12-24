using BookManagement.DAOs;
using BookManagement.DAOs.Entities;
using BookManagement.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly AuthorDAO _authorDAO;
        public AuthorRepository(AuthorDAO authorDAO)
        {
            _authorDAO = authorDAO;
        }
        public Task<Author> AddNewAuthor(Author newAuthor) => _authorDAO.AddNewAuthor(newAuthor);

        public Task DeleteAuthor(int authorId) => _authorDAO.DeleteAuthor(authorId);

        public Task<List<Author>> GetAllAuthors() => _authorDAO.GetAllAuthors();

        public Task<Author> GetAuthorById(int authorId) => _authorDAO.GetAuthorById(authorId);

        public Task UpdateAuthor(Author newAuthor) => _authorDAO.UpdateAuthor(newAuthor);
    }
}
