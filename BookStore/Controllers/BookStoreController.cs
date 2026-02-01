using Microsoft.AspNetCore.Mvc;
using MyFirstApp.Application.UseCases.Books.Delete;
using MyFirstApp.Application.UseCases.Books.FindAll;
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
            var books = new FindAll().Execute();

            return Ok(books);
        
        }
        [HttpGet("{id}")]        
        [ProducesResponseType(typeof(RequestRegisterBookJson), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status404NotFound)]
        public IActionResult GetBookById([FromRoute] Guid id)
        {

            var retorno = new FindUnique().Execute(id);
            return Ok();

        }
        [HttpPut("{id}")]        
        [ProducesResponseType(typeof(RequestRegisterBookJson), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status400BadRequest)]
        public IActionResult UpdateBook([FromRoute] Guid id, [FromBody] RequestRegisterBookJson book)
        {
            var retorno = new UpdateBook().Execute(id, book);
            return Ok(retorno);
        }
        [HttpDelete("{id}")]        
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status400BadRequest)]
        public IActionResult DeleteBook([FromRoute] Guid id)
        {

            var retorno = new DeleteBookInStore().Execute(id);
            if(!retorno)
            {
                return BadRequest(new ResponseErrorsJson
                {
                    Errors = new List<string> { "Não foi possível deletar o livro." }
                });
            }
            return Ok("Book" + id + "Deletado");
        }
    }
}
