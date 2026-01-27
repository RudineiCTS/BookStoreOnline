using Microsoft.AspNetCore.Mvc;
using MyFirstApp.Communication.Request;
using MyFirstApp.Communication.Response;
using MyFirstApp.Entities;

namespace MyFirstApp.Controllers
{
    
    public class BookStoreController : ControllerBaseApi
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseRegisterBookJson), StatusCodes.Status201Created)]
        public IActionResult Create([FromBody] RequestRegisterBookJson book)
        {
            var newBook = new Book
            {
                Title = book.Title,
                Author = book.Author,
                //Genre = book.Genre,
                Price = book.Price,
                Stock = book.Stock
            };

            AddBookToStore(newBook);

            return Ok(newBook);
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<RequestRegisterBookJson>), StatusCodes.Status200OK)]
        public IActionResult GetAll()
        {
            var books = GetBooksFromStore();

            return Ok(books);
        
        }
        [HttpGet]        
        [ProducesResponseType(typeof(RequestRegisterBookJson), StatusCodes.Status200OK)]
        public IActionResult GetBookById([FromRoute] Guid id)
        {
            RequestRegisterBook book = GetUniqueBookInStore(id);
            return Ok(book);
        }
        [HttpPut]        
        [ProducesResponseType(typeof(RequestRegisterBookJson), StatusCodes.Status200OK)]
        public IActionResult UpdateBook([FromRoute] Guid id, [FromBody] RequestRegisterBookJson book)
        {
            EditBookInStore(id, book);
            return Ok();
        }
        [HttpDelete]        
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult DeleteBook([FromRoute] Guid id)
        {

            DeleteBookInStore(id);
            return Ok("Book" + id + "Deletado");
        }
    }
}


//Deve ser possível criar um livro;
//id            GUID	    Sim	    Gerado automaticamente pelo sistema.
//title	 *      string	    Sim	    Deve ter entre 2 e 120 caracteres.
//author *	    string	    Sim	    Deve ter entre 2 e 120 caracteres.
//genre	        string	    Sim	    Deve ser um dos valores válidos: ficção, romance, mistério, ....
//price	        decimal	    Sim	    Deve ser maior ou igual a 0.
//stock	        int	        Sim	    Deve ser maior ou igual a 0.


//Deve ser possível visualizar todos os livros que foram criados;

//Deve ser possível visualizar um livro em específico;

//Deve ser possível editar informações de um livro;

//Deve ser possível excluir um livro.