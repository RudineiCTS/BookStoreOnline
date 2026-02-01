using MyFirstApp.Application.Mock;
using MyFirstApp.Communication.Response;
using MyFirstApp.Middleware;

namespace MyFirstApp.Application.UseCases.Books.Delete
{
    public class DeleteBookInStore
    {
        public bool Execute(Guid id)
        {
            var isExistsBook = MockBooks.BooksToStore.Find(b => b.Id == id);
            if(isExistsBook == null)
            {
                ResponseErrorsJson errorsJson = new ResponseErrorsJson
                {
                    Errors = new List<string> { new string("Book not found.") }
                };
                throw new NotFoundException(System.Text.Json.JsonSerializer.Serialize(errorsJson));
            }
            var retorno = MockBooks.BooksToStore.RemoveAll(b => b.Id == id);
            return retorno > 0 ? true : false;
        }
    }
}
