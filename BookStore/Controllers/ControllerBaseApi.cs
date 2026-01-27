using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyFirstApp.Comunication;
using MyFirstApp.Entities;

namespace MyFirstApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ControllerBaseApi : ControllerBase
    {
        public List<Book> Books = new List<Book>();

        protected void AddBookToStore(Book book)
        {
            var isExistBookSame  = Books.Find(r => r.Author == book.Author && r.Title == book.Title);

            if(isExistBookSame != null)
            {                          
                return;
            }

            Books.Add(book);            

        }
        protected List<Book> GetBooksFromStore()
        {
            return Books;
        }
        protected RequestRegisterBook GetUniqueBookInStore(Guid id)  
        {
            var book = Books.Find(r => r.Id == id);
            if(book == null)
            {
                return null;
            }
            RequestRegisterBook bookRetorno = new RequestRegisterBook
            {
                Title = book.Title,
                Author = book.Author,
                Genre = book.Genre,
                Price = book.Price,
                Stock = book.Stock
            };

            return bookRetorno;
        }

        protected void EditBookInStore(Guid id, RequestRegisterBook book)
        {
            var bookToEdit = Books.Find(r => r.Id == id);

            if (bookToEdit != null)
            {
                bookToEdit.Title = book.Title;
                bookToEdit.Author = book.Author;    
                bookToEdit.Genre = book.Genre;
                bookToEdit.Price = book.Price;
                bookToEdit.Stock = book.Stock;
            }
            return;
           


        }

        protected void DeleteBookInStore(Guid id)
        {
            var bookToDelete = Books.Find(Books => Books.Id == id);

            if (bookToDelete != null)
            {
                Books.Remove(bookToDelete);
            }

        }
    }
}

