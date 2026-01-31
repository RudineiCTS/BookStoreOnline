using MyFirstApp.Application.Mock;
using MyFirstApp.Communication.Response;
using MyFirstApp.Middleware;

namespace MyFirstApp.Application.UseCases.Books.FindUnique
{
    public class FindUnique
    {
        public ResponseRegisterBookJson Execute(Guid id)
        {
            var existsIsBook = MockBooks.BooksToStore.Find(r => r.Id == id);

            if (existsIsBook == null)
            {
                ResponseErrorsJson errorsJson = new ResponseErrorsJson
                {
                    Errors = new List<string> { "Book found." }
                };
                throw new NotFoundException(errorsJson.Errors[0]);
            }

            ResponseRegisterBookJson responseRegisterBookJson = new ResponseRegisterBookJson
            {
                Id = existsIsBook.Id,
                Title = existsIsBook.Title,
                Author = existsIsBook.Author,
                Genre = existsIsBook.Genre,
                Price = existsIsBook.Price,
                Stock = existsIsBook.Stock
            };
            return responseRegisterBookJson;


        }
    }
}
