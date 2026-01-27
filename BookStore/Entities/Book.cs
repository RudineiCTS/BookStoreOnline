namespace MyFirstApp.Entities
{
    public class Book
    {
        public  Guid Id { get; set; } = Guid.NewGuid();
        public required string  Title { get; set; }
        public required string Author { get; set; }
        public required string Genre { get; set; }
        public required decimal Price { get; set; }
        public required int Stock { get; set; }

    }
}

//id            GUID	
//title	 *      string	
//author *	    string	
//genre	        string	
//price	        decimal	
//stock	        int	    