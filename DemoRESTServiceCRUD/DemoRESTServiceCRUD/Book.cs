using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace DemoRESTServiceCRUD
{
    [DataContract]
    public class Book
    {
        [DataMember]
        public int BookId { get; set; }
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public string ISBN { get; set; }
    }
    public interface IBookRepository
    {
        List<Book> GetAllBooks();
        Book GetBookById(int id);
        Book AddNewBook(Book item);
        bool DeleteABook(int id);
        bool UpdateABook(Book item);
    }
    public class BookRepository : IBookRepository
    {
        private List<Book> books = new List<Book>();
        private int counter = 1;

        public BookRepository()
        {
            AddNewBook(new Book { Title = "C# Programming", ISBN = "23422342343" });
            AddNewBook(new Book { Title = "Java Programming", ISBN = "123123123543" });
            AddNewBook(new Book { Title = "WCF Programming", ISBN = "231324234" });
        }

        public Book AddNewBook(Book newBook)
        {
            if (newBook == null) throw new ArgumentNullException("newBook");
            newBook.BookId = counter++;
            books.Add(newBook);
            return newBook;
        }

        public bool DeleteABook(int bookid)
        {
            int idx = books.FindIndex(b => b.BookId == bookid);
            if (idx == -1) return false;
            books.RemoveAll(b => b.BookId == bookid);
            return true;
        }

        public List<Book> GetAllBooks()
        {
            return books;
        }

        public Book GetBookById(int bookId)
        {
            return books.Find(b => b.BookId == bookId);
        }

        public bool UpdateABook(Book UpdatedBook)
        {
            if (UpdatedBook == null) throw new ArgumentNullException("updatedBook");
            int idx = books.FindIndex(b => b.BookId == UpdatedBook.BookId);
            if (idx == -1) return false;
            books.RemoveAt(idx);
            books.Add(UpdatedBook);
            return true;
        }
    }
}