using BookManagement.DAOs.Entities;
using BookManagement.DAOs.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace BookManagement.DAOs
{
    public class BookDAO
    {
        private readonly ApplicationDbContext _context;

        public BookDAO(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Book>> GetAllBooks()
        {
            var books = await _context.Books.ToListAsync();
            return books;
        }

        public async Task<IPagedList<Book>> GetPaginatedBooksAsync
            (string searchKey,
            int? authorId,
            DateTime? fromPublishedDate,
            DateTime? toPublishedDate,
            int pageSize,
            int pageIndex)
        {
            var query = _context.Books
                .Include(b => b.Author)
                .AsQueryable();

            if (!string.IsNullOrEmpty(searchKey))
                query = query.Where(b => b.Title.Contains(searchKey));

            if (authorId.HasValue)
                query = query.Where(b => b.AuthorId == authorId);

            if (fromPublishedDate.HasValue)
                query = query.Where(b => b.PublishedDate >= fromPublishedDate);

            if (toPublishedDate.HasValue)
                query = query.Where(b => b.PublishedDate <= toPublishedDate);

            var books = await query
                .OrderBy(b => b.Title)
                .Select(b => new Book
                {
                    BookId = b.BookId,
                    Title = b.Title,
                    Price = b.Price,
                    AuthorId = b.AuthorId,
                    Author = b.Author,
                    PublishedDate = b.PublishedDate
                })
                .ToPagedListAsync(pageIndex, pageSize);

            return books;
        }

        public async Task<Book> GetBookById(int bookId)
        {
            var book = await _context.Books.FirstOrDefaultAsync(b => b.BookId == bookId);
            return book;
        }

        public async Task<Book> AddNewBook(Book newBook)
        {
            _context.Books.Add(newBook);
            await _context.SaveChangesAsync();
            return newBook;
        }

        public async Task UpdateBook(Book updatedBook)
        {
            _context.Books.Update(updatedBook);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBook(int bookId)
        {
            var book = await _context.Books.FirstOrDefaultAsync(b => b.BookId == bookId);
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
        }
    }
}
