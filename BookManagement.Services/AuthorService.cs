using AutoMapper;
using BookManagement.BusinessObject;
using BookManagement.BusinessObject.Author;
using BookManagement.DAOs.Entities;
using BookManagement.DAOs.Model;
using BookManagement.Repositories;
using BookManagement.Repositories.Interface;
using BookManagement.Services.Interface;
using BookManagement.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;
        public AuthorService(IAuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }
        public async Task<ApplicationResponse> AddNewAuthor(CreateAuthorDTO newAuthor)
        {
            try
            {
                var author = _mapper.Map<Author>(newAuthor);
                if (author == null) {
                    throw new ApiException("Author does not exist!");
                }
                await _authorRepository.AddNewAuthor(author);
                return new ApplicationResponse
                {
                    Success = true,
                    Message = "Author was added successfully",
                    Data = author,
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

        public async Task<ApplicationResponse> DeleteAuthor(int authorId)
        {
            try
            {
                var author = await _authorRepository.GetAuthorById(authorId);
                if (author == null)
                {
                    throw new ApiException("Author was not found!", HttpStatusCode.NotFound);
                }
                await _authorRepository.DeleteAuthor(authorId);
                return new ApplicationResponse
                {
                    Message = "Author was deleted successfully",
                    Success = true,
                    Data = null,
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

        public async Task<ApplicationResponse> GetAllAuthors()
        {

            try
            {
                var authors = await _authorRepository.GetAllAuthors();
                if (!authors.Any())
                {
                    throw new ApiException("Authors were not found!", HttpStatusCode.InternalServerError);
                }
                var result = _mapper.Map<List<AuthorDTO>>(authors);
                return new ApplicationResponse
                {
                    Success = true,
                    Message = "Authors query successfully",
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

        public async Task<ApplicationResponse> GetAuthorById(int authorId)
        {
            try
            {
                var author = await _authorRepository.GetAuthorById(authorId);
                if (author == null)
                {
                    throw new ApiException("Author was not found!", HttpStatusCode.NotFound);
                }
                var result = _mapper.Map<AuthorDTO>(author);
                return new ApplicationResponse
                {
                    Success = true,
                    Message = "Author retrieved successfully",
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

        public async Task<ApplicationResponse> UpdateAuthor(UpdateAuthorDTO updatedAuthor)
        {
            try
            {
                var authorExist = await _authorRepository.GetAuthorById(updatedAuthor.AuthorId);
                if (authorExist == null)
                {
                    throw new ApiException("Author was not found!", HttpStatusCode.NotFound);
                }
                var result = _mapper.Map(updatedAuthor, authorExist);
                await _authorRepository.UpdateAuthor(result);

                return new ApplicationResponse
                {
                    Success = true,
                    Message = "Author retrieved successfully",
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
