using MyFirstApp.Communication.Enum;

namespace MyFirstApp.Communication.Request
{
    public class RequestRegisterBookJson
    {
        public required string Title { get; set; }
        public required string Author { get; set; }
        public required GenreType Genre { get; set; }
        public required decimal Price { get; set; }
        public required int Stock { get; set; }
    }
}
