using MyFirstApp.Application.Mock;
using MyFirstApp.Communication.Response;

namespace MyFirstApp.Application.UseCases.Books.FindAll
{
    public class FindAll
    {
        public List<ResponseResumeBookJson> Execute()
        {
            var ListBooks = MockBooks.BooksToStore;
            var listResult = new List<ResponseResumeBookJson>();

            foreach (var item in ListBooks)
            {
                var newBook = new ResponseResumeBookJson
                {
                    Id = item.Id,
                    Title = item.Title,
                    Author = item.Author
                };
                listResult.Add(newBook);
            }
            return listResult;
        }
    }
}
