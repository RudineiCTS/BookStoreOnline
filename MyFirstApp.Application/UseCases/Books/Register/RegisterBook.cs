using MyFirstApp.Application.Mock;
using MyFirstApp.Communication.Request;
using MyFirstApp.Communication.Response;
using MyFirstApp.Entities.Book;

namespace MyFirstApp.Application.UseCases.Books.Register
{
    public class RegisterBook
    {
        public ResponseRegisterBookJson Execute(RequestRegisterBookJson bookJson)
        {
            var ExistsBookSameTitleAndAuthor = MockBooks.BooksToStore.Find(b => b.Title == bookJson.Title && b.Author == bookJson.Author);
            if(ExistsBookSameTitleAndAuthor != null)
            {
                throw new Exception("A book with the same title and author already exists.");
            }

            var newBook = new BookEntity
            {
                Title = bookJson.Title,
                Author = bookJson.Author,
                Genre = bookJson.Genre.ToString(),
                Price = bookJson.Price,
                Stock = bookJson.Stock
            };

            MockBooks.BooksToStore.Add(newBook);

            return new ResponseRegisterBookJson
            {
                Id = newBook.Id,
                Title = newBook.Title,
                Author = newBook.Author,
                Genre = newBook.Genre,
                Price = newBook.Price,
                Stock = newBook.Stock
            };
        }
    }
}
