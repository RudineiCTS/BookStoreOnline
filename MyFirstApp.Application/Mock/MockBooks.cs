using MyFirstApp.Entities.Book;

namespace MyFirstApp.Application.Mock
{
    public class MockBooks
    {
        public static List<BookEntity> BooksToStore = new List<BookEntity>
        {
            new BookEntity
            {
                Id = Guid.NewGuid(),
                Author = "George Orwell",
                Title = "1984",
                Genre = Communication.Enum.GenreType.romance.ToString(),
                Price = 9.99m,
                Stock = 100

            }
        };
    }
}
