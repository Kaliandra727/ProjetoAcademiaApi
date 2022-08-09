using Microsoft.AspNetCore.Mvc;
using ProjetoAcademia.EF.Database;
using ProjetoAcademia.Envelope;
using ProjetoAcademia.Poco;
using ProjetoAcademia.Service;

namespace ProjetoAcademiaWebAPI.Controllers
{
    /// <summary>
    /// </summary>   
        [Route("api/Academia/[controller]")]
        [ApiController]
        public class AlunoController : ControllerBase
    {
        
        private AlunoService servico;

        /// <summary>
        /// </summary>
        public AlunoController(ProjetoAcademiaContext contexto) : base()
        {
            this.servico = new AlunoService(contexto);
        }
        /// <summary>
        /// Busca todos os registros de aluno, filtrando onde inicia(skip) e a quantidade(take).
        /// </summary>
        /// <param name="skip">Onde inicia os resultados da pesquisa.</param>
        /// <param name="take"> Quantos registros serão retornados.</param>
        /// <returns>Coleção de dados.</returns>

        [HttpGet("{skip:int}/{take:int}")]
        public ActionResult<List<AlunoEnvelopeJSON>> GetAll(int skip, int take)
        {
            try
            {
                List<AlunoEnvelopeJSON> lista = this.servico.Listar(skip, take);
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.Message, statusCode: StatusCodes.Status500InternalServerError);
            }


        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="IdUsuario"></param>
        /// <returns></returns>
        [HttpGet("porusuario/{IdUsuario:int}")]
         public ActionResult<AlunoPoco> GetIdUsuario(int IdUsuario){
            try
            {
                AlunoPoco poco = this.servico.SelecionarUsuario(IdUsuario);
                return Ok(poco);
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }
       
        /// <summary>
        /// Busca pelo Codigo(id).
        /// </summary>
        /// <param name="id">Codigo</param>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        public ActionResult<AlunoEnvelopeJSON> Get(int id)
        {
            try
            {
                AlunoEnvelopeJSON envelope = this.servico.Selecionar(id);
                return Ok(envelope);
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }
        /// <summary>
        /// Criar dados.
        /// </summary>
        /// <param name="poco"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<AlunoEnvelopeJSON> Post([FromBody] AlunoPoco poco)
        {
            try
            {
                AlunoEnvelopeJSON envelope = this.servico.Criar(poco);
                return Ok(envelope);
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }
        /// <summary>
        /// Atualizar dados.
        /// </summary>
        /// <param name="poco"></param>
        /// <returns></returns>
        [HttpPut]
        public ActionResult<AlunoEnvelopeJSON> Put([FromBody]AlunoPoco poco)
        {
            try
            {
                AlunoEnvelopeJSON envelope = this.servico.Atualizar(poco);
                return Ok(envelope);
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.Message, statusCode: StatusCodes.Status500InternalServerError);
            }

        }
        /// <summary>
        /// Deletar Relatorio.
        /// </summary>
        /// <param name="poco"></param>
        /// <returns></returns>
        [HttpDelete]
        public ActionResult<AlunoEnvelopeJSON> Delete([FromBody] AlunoPoco poco)
        {
            try
            {
                AlunoEnvelopeJSON envelope = this.servico.Excluir(poco);
                return Ok(envelope);
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.Message, statusCode: StatusCodes.Status500InternalServerError);
            }

        }
        /// <summary>
        /// Deletar dados pelo codigo(id).
        /// </summary>
        /// <param name="id">Codigo</param>
        /// <returns></returns>
        [HttpDelete("{id:int}")]
        public ActionResult<AlunoEnvelopeJSON> Delete(int id)
        {
            try
            {
                AlunoEnvelopeJSON envelope = this.servico.Excluir(id);
                return Ok(envelope);
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.Message, statusCode: StatusCodes.Status500InternalServerError);
            }

        }
    }
}
