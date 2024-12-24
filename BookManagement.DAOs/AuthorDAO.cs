using BookManagement.DAOs.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.DAOs
{
    public class AuthorDAO
    {
        private readonly ApplicationDbContext _context;
        public AuthorDAO(ApplicationDbContext context) {
            _context = context;
        }

        public async Task<List<Author>> GetAllAuthors()
        {
            var authors = await _context.Authors.Include(a => a.Books).ToListAsync();
            return authors;
        }

        public async Task<Author> GetAuthorById(int authorId)
        {
            var author = await _context.Authors.Include(a => a.Books).FirstOrDefaultAsync(b => b.AuthorId == authorId);
            return author;
        }

        public async Task<Author> AddNewAuthor(Author newAuthor)
        {
            _context.Authors.Add(newAuthor);
            await _context.SaveChangesAsync();
            return newAuthor;
        }

        public async Task UpdateAuthor(Author newAuthor)
        {
            _context.Authors.Update(newAuthor);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAuthor(int authorId)
        {
            var author = await _context.Authors.FirstOrDefaultAsync(b => b.AuthorId == authorId);
            _context.Authors.Remove(author);
            await _context.SaveChangesAsync();
        }
    }
}
