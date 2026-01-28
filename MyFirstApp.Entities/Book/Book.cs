namespace MyFirstApp.Entities.Book
{
    public class BookEntity
    {
        public  Guid Id { get; set; } = new Guid();
        public  string Title { get; set; }
        public  string Author { get; set; }
        public  string Genre { get; set; }
        public  decimal Price { get; set; }        
        public  int Stock { get; set; }

    }
    
}
