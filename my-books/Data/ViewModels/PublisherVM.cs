using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_books.Data.ViewModels
{
    public class PublisherVM
    {
        public string Name { get; set; }
    }
    // Creating This View Model to get the Publisher Name with ID Then get All The Books with Authors 
    public class PublisherwithBookandAuthorVM
    {
        public string Name { get; set; }
        public List<BookAuthorsVM> BookAuthors { get; set; }

    }
    // Creating this View Model to Get All Book Titles Related to Specific Publisher Then Get The Book Authors
    public class BookAuthorsVM
    {
        public string BookTitle { get; set; }
        public List<string> BookAuthors { get; set; }
    }
}
