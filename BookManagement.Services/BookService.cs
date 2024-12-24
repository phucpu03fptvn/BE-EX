using AutoMapper;
using BookManagement.BusinessObject;
using BookManagement.BusinessObject.Book;
using BookManagement.DAOs;
using BookManagement.DAOs.Entities;
using BookManagement.DAOs.Model;
using BookManagement.Repositories.Interface;
using BookManagement.Services.Interface;
using BookManagement.Utils;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;
        public BookService(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<ApplicationResponse> AddNewBook(BookDTO newBook)
        {
            try
            {
                var book = _mapper.Map<Book>(newBook);
                await _bookRepository.AddNewBook(book);
                return new ApplicationResponse
                {
                    Success = true,
                    Message = "Book was added successfully",
                    Data = book,
                    StatusCode = HttpStatusCode.OK
                };
            }
            catch (ApiException)
            {
                throw;
            }
            catch (Exception ex)
            {

                throw new ApiException(ex.Message, HttpStatusCode.InternalServerError);
            }
        }

        public async Task<ApplicationResponse> DeleteBook(int bookId)
        {
            try
            {
                var book = await _bookRepository.GetBookById(bookId);
                if (book == null)
                {
                    throw new ApiException("Book not found!", HttpStatusCode.NotFound);
                }
                await _bookRepository.DeleteBook(bookId);
                return new ApplicationResponse
                {
                    Message = "Book was deleted successfully",
                    Success = true,
                    Data = book,
                    StatusCode = HttpStatusCode.OK
                };
            }
            catch (ApiException)
            {
                throw;

            }
            catch (Exception ex)
            {

                throw new ApiException(ex.Message, HttpStatusCode.InternalServerError);
            }
        }

        public async Task<ApplicationResponse> GetAllBooks()
        {
            try
            {
                var books = await _bookRepository.GetAllBooks();
                if (!books.Any())
                {
                    throw new ApiException("Book not found!", HttpStatusCode.InternalServerError);
                }
                return new ApplicationResponse
                {
                    Success = true,
                    Message = "Books query successfully",
                    Data = books,
                    StatusCode = HttpStatusCode.OK
                };
            }
            catch (ApiException)
            {
                throw;
            }
            catch (Exception ex)
            {

                throw new ApiException(ex.Message, HttpStatusCode.InternalServerError);
            }
        }

        public async Task<ApplicationResponse> GetBookById(int bookId)
        {
            try
            {
                var book = await _bookRepository.GetBookById(bookId);
                if (book == null)
                {
                    throw new ApiException("Book not found!", HttpStatusCode.NotFound);
                }

                return new ApplicationResponse
                {
                    Success = true,
                    Message = "Book retrieved successfully",
                    Data = book,
                    StatusCode = HttpStatusCode.OK
                };
            }
            catch (ApiException)
            {
                throw;

            }
            catch (Exception ex)
            {

                throw new ApiException(ex.Message, HttpStatusCode.InternalServerError);
            }
        }

        public async Task<ApplicationResponse> GetPaginatedBooksAsync(string searchKey, int? authorId, DateTime? fromPublishedDate, DateTime? toPublishedDate, int pageSize, int pageIndex)
        {
            try
            {
                var booksPagedList = await _bookRepository.GetPaginatedBooksAsync(searchKey, authorId, fromPublishedDate, toPublishedDate, pageSize, pageIndex);

                var bookDTOs = _mapper.Map<List<BookDTO>>(booksPagedList);

                var responseData = new PaginatedResult<BookDTO>
                {
                    Items = bookDTOs,
                    TotalCount = booksPagedList.TotalItemCount,
                    PageIndex = booksPagedList.PageNumber,
                    PageSize = booksPagedList.PageSize
                };


                return new ApplicationResponse
                {
                    Message = "Books query successfully",
                    Data = responseData,
                    Success = true,
                    StatusCode = System.Net.HttpStatusCode.OK
                };
            }
            catch (ApiException)
            {
                throw;

            }
            catch (Exception ex)
            {
                throw new ApiException(ex.Message, System.Net.HttpStatusCode.InternalServerError);
            }
        }

        public async Task<ApplicationResponse> UpdateBook(BookDTO updatedBook)
        {
            try
            {
                var bookExist = await _bookRepository.GetBookById(updatedBook.BookId);
                if (bookExist == null)
                {
                    throw new ApiException("Book not found!", HttpStatusCode.NotFound);
                }
                var result = _mapper.Map(updatedBook, bookExist);
                await _bookRepository.UpdateBook(result);

                return new ApplicationResponse
                {
                    Success = true,
                    Message = "Book retrieved successfully",
                    Data = result,
                    StatusCode = HttpStatusCode.OK
                };
            }
            catch (ApiException)
            {
                throw;

            }
            catch (Exception ex)
            {

                throw new ApiException(ex.Message, HttpStatusCode.InternalServerError);
            }
        }
    }
}

