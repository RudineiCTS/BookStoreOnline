using MyFirstApp.Application.Mock;
using MyFirstApp.Communication.Request;
using MyFirstApp.Communication.Response;
using MyFirstApp.Entities.Book;
using MyFirstApp.Middleware;

namespace MyFirstApp.Application.UseCases.Books.Update
{
    public class UpdateBook
    {
        public ResponseRegisterBookJson Execute(Guid bookId, RequestRegisterBookJson bookJson)
        {
            var book = MockBooks.BooksToStore.Find(r => r.Id == bookId);
            if (book == null)
            {
                ResponseErrorsJson errors = new ResponseErrorsJson();
                errors.Errors = new List<string>()
                {
                    "Book not found."
                };
                throw new NotFoundException("A book with the same title and author already exists.");
            }
            var index = MockBooks.BooksToStore.IndexOf(book);
            var BookToUpdate = new BookEntity
            {
                Title = bookJson.Title,
                Author = bookJson.Author,
                Genre = bookJson.Genre.ToString(),
                Price = bookJson.Price,
                Stock = bookJson.Stock

            };
            MockBooks.BooksToStore[index]= BookToUpdate;
            return new ResponseRegisterBookJson
            {
                Id = BookToUpdate.Id,
                Title = BookToUpdate.Title,
                Author = BookToUpdate.Author,
                Genre = BookToUpdate.Genre,
                Price = BookToUpdate.Price,
                Stock = BookToUpdate.Stock
            };

        }
    }
}
