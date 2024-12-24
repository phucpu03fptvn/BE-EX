using BookManagement.DAOs;
using BookManagement.DAOs.Entities;
using BookManagement.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace BookManagement.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly BookDAO _bookDAO;
        public BookRepository(BookDAO bookDAO)
        {
            _bookDAO = bookDAO;
        }

        public Task<Book> AddNewBook(Book newBook) => _bookDAO.AddNewBook(newBook);

        public Task DeleteBook(int bookId) => _bookDAO.DeleteBook(bookId);

        public Task<List<Book>> GetAllBooks() => _bookDAO.GetAllBooks();

        public Task<Book> GetBookById(int bookId) => _bookDAO.GetBookById(bookId);

        public Task<IPagedList<Book>> GetPaginatedBooksAsync(string searchKey, int? authorId, DateTime? fromPublishedDate, DateTime? toPublishedDate, int pageSize, int pageIndex) => _bookDAO.GetPaginatedBooksAsync(searchKey, authorId, fromPublishedDate, toPublishedDate, pageSize, pageIndex);

        public Task UpdateBook(Book updatedBook) => _bookDAO.UpdateBook(updatedBook);
    }
}
