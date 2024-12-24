using BookManagement.BusinessObject;
using BookManagement.BusinessObject.Book;
using BookManagement.DAOs.Entities;
using BookManagement.DAOs.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace BookManagement.Services.Interface
{
    public interface IBookService
    {
        Task<ApplicationResponse> GetAllBooks();

        Task<ApplicationResponse> GetBookById(int bookId);

        Task<ApplicationResponse> AddNewBook(BookDTO newBook);

        Task<ApplicationResponse> UpdateBook(BookDTO updatedBook);

        Task<ApplicationResponse> DeleteBook(int bookId);

        Task<ApplicationResponse> GetPaginatedBooksAsync
            (string searchKey,
            int? authorId,
            DateTime? fromPublishedDate,
            DateTime? toPublishedDate,
            int pageSize,
            int pageIndex);
    }
}
