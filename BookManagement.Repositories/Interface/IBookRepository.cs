using BookManagement.DAOs.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace BookManagement.Repositories.Interface
{
    public interface IBookRepository
    {
        Task<List<Book>> GetAllBooks();

        Task<Book> GetBookById(int bookId);

        Task<Book> AddNewBook(Book newBook);

        Task UpdateBook(Book updatedBook);

        Task DeleteBook(int bookId);

        Task<IPagedList<Book>> GetPaginatedBooksAsync
            (string searchKey,
            int? authorId,
            DateTime? fromPublishedDate,
            DateTime? toPublishedDate,
            int pageSize,
            int pageIndex);

    }
}
