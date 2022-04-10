using my_books.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_books.Data.Services
{
    public class PublishersService
    {
        private AppDbContext _context;
        public PublishersService(AppDbContext context)
        {
            _context = context;
        }

        // Add Publisher to DB
        public void AddPublisher(PublisherVM publisher)
        {
            var _publisher = new Publisher()
            {
                Name = publisher.Name,
            };
            _context.Publishers.Add(_publisher);
            _context.SaveChanges();
        }

        // Get Publisher By ID from DB
        public PublisherwithBookandAuthorVM GetPublisherwithBooksandAuthorsById(int publisherId)
        {
            // Get Publisher with Books and Authors from DB
            var _publisher = _context.Publishers.Where(n => n.Id == publisherId).Select(book => new PublisherwithBookandAuthorVM()
            {
                Name = book.Name,
                BookAuthors = book.Books.Select(n => new BookAuthorsVM()
                {
                    BookTitle = n.Title,
                    BookAuthors = n.Book_Authors.Select(n => n.Author.FullName).ToList()
                }).ToList()
            }).FirstOrDefault();
            return _publisher;
        }

        // Get All Publishers from DB
        public List<PublisherwithBookandAuthorVM> GetAllPublisherwithBooksandAuthors()
        {
            // Get Publisher with Books and Authors from DB
            var _publisher = _context.Publishers.Select(book => new PublisherwithBookandAuthorVM()
            {
                Name = book.Name,
                BookAuthors = book.Books.Select(n => new BookAuthorsVM()
                {
                    BookTitle = n.Title,
                    BookAuthors = n.Book_Authors.Select(n => n.Author.FullName).ToList()
                }).ToList()
            }).ToList();
            return _publisher;
        }

        // Delete Publisher By ID from DB
        public void DeletePublisherById (int publisherId)
        {
            var _publisher = _context.Publishers.FirstOrDefault(n => n.Id == publisherId);
            if(_publisher != null)
            {
                _context.Publishers.Remove(_publisher);
                _context.SaveChanges();
            }

        }

        // Update Publisher By ID into DB
        public Publisher UpdatePublisherById(int publisherId, PublisherVM publisher)
        {
            var _publisher = _context.Publishers.FirstOrDefault(n => n.Id == publisherId);
            if(_publisher != null)
            {
                _publisher.Name = publisher.Name;
                _context.SaveChanges();
            }
            return _publisher;
        }
    }
}
