using Microsoft.AspNetCore.Mvc;
using ProjetoAcademia.EF.Database;
using ProjetoAcademia.Poco;
using ProjetoAcademia.Service;

namespace ProjetoAcademiaWebAPI.Controllers
{
    [Route("api/Academia/[controller]")]
    [ApiController]
    public class CadastroController : ControllerBase
    {
        private CadastroService servico;

        public CadastroController(ProjetoAcademiaContext contexto) : base()
        {
            this.servico = new CadastroService(contexto);
        }

        [HttpPost]
        public ActionResult<CadastroPoco> Post([FromBody] CadastroPoco poco)
        {
            try
            {
                if (this.servico.Persistir(poco) == true)
                {
                    return Ok("OK");
                }
                else
                {
                    return Problem(detail: this.servico.MensagensProcessamento.ToString(), statusCode: StatusCodes.Status500InternalServerError, title: "Ocorreu um erro no cadastramento.");    
                }
            }
            catch(Exception ex)
            {
                return Problem(detail: ex.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }
    }
}