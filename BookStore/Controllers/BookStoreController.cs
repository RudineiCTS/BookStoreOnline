using Microsoft.AspNetCore.Mvc;
using MyFirstApp.Application.UseCases.Books.FindUnique;
using MyFirstApp.Application.UseCases.Books.Register;
using MyFirstApp.Application.UseCases.Books.Update;
using MyFirstApp.Communication.Request;
using MyFirstApp.Communication.Response;

namespace MyFirstApp.Controllers
{
    
    public class BookStoreController : ControllerBaseApi
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseRegisterBookJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status400BadRequest)]
        public IActionResult Create([FromBody] RequestRegisterBookJson book)
        {          
            var retorno = new RegisterBook().Execute(book);
            return Ok(retorno);
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<RequestRegisterBookJson>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status400BadRequest)]
        public IActionResult GetAll()
        {
            var books = GetBooksFromStore();

            return Ok(books);
        
        }
        [HttpGet]        
        [ProducesResponseType(typeof(RequestRegisterBookJson), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status404NotFound)]
        public IActionResult GetBookById([FromRoute] Guid id)
        {

            var retorno = new FindUnique().Execute(id);
            return Ok();

        }
        [HttpPut]        
        [ProducesResponseType(typeof(RequestRegisterBookJson), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status400BadRequest)]
        public IActionResult UpdateBook([FromRoute] Guid id, [FromBody] RequestRegisterBookJson book)
        {
            var retorno = new UpdateBook().Execute(id, book);
            return Ok(retorno);
        }
        [HttpDelete]        
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status400BadRequest)]
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