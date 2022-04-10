using my_books.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_books.Data.Services
{
    public class AuthorsService
    {
        private AppDbContext _context;
        public AuthorsService(AppDbContext context)
        {
            _context = context;
        }

        // Add New Author to DB
        public void AddAuthor(AuthorVM author)
        {
            var _author = new Author()
            {
                FullName = author.FullName,
            };
            _context.Authors.Add(_author);
            _context.SaveChanges();
        }

        // Get All Author from DB
        public List<AuthorwithBooksVM> GetAllAuthorwithBooks()
        {
            var _authorwitBooks = _context.Authors.Select(auth => new AuthorwithBooksVM()
            {
                FullName = auth.FullName,
                BookTitles = auth.Book_Authors.Select(n => n.Book.Title).ToList()
            }).ToList();

            return _authorwitBooks;
        }

        // Get Author By ID from DB
        public AuthorwithBooksVM GetAuthorwithBooksById(int authorId)
        {
            var _authorwitBooks = _context.Authors.Where(n => n.Id == authorId).Select(auth => new AuthorwithBooksVM()
            {
                FullName = auth.FullName,
                BookTitles = auth.Book_Authors.Select(n => n.Book.Title).ToList()
            }).FirstOrDefault();

            return _authorwitBooks;
        }

        // Delete Author By ID from DB
        public void DeleteAuthorById(int authorId)
        {
            var _author = _context.Authors.FirstOrDefault(n => n.Id == authorId);
            if (_author != null)
            {
                _context.Authors.Remove(_author);
                _context.SaveChanges();
            }

        }

        // Update Author By ID into DB
        public Author UpdateAuthorById(int authorrId, AuthorVM author)
        {
            var _author = _context.Authors.FirstOrDefault(n => n.Id == authorrId);
            if (_author != null)
            {
                _author.FullName = author.FullName;
                _context.SaveChanges();
            }
            return _author;
        }

    }
}
