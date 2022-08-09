using Microsoft.AspNetCore.Mvc;
using ProjetoAcademia.EF.Database;
using ProjetoAcademia.Envelope;
using ProjetoAcademia.Poco;
using ProjetoAcademia.Service;

namespace ProjetoAcademiaWebAPI.Controllers
{
    ///<summary>
    ///</summary>
    [Route("api/Academia/[controller]")]
    [ApiController]    
    public class UsuarioController : ControllerBase
    {
		
        private UsuarioService servico;
        ///<summary>
        ///</summary>
        public UsuarioController(ProjetoAcademiaContext contexto) : base()
        {
            this.servico = new UsuarioService(contexto);
        }
        /// <summary>
        /// Busca todos os registros de Usuario, filtrando onde inicia(skip) e a quantidade(take), caso queira trazer todos use skip (0) e take(0).
        /// </summary>
        /// <param name="skip">Onde inicia os resultados da pesquisa.</param>
        /// <param name="take"> Quantos registros serão retornados.</param>
        /// <returns>Coleção de dados.</returns>

        [HttpGet("{skip:int}/{take:int}")]
        public ActionResult<List<UsuarioEnvelopeJSON>> GetAll(int skip, int take)
        {
            try
            {
                List<UsuarioEnvelopeJSON> lista = this.servico.Listar(skip, take);
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.Message, statusCode: StatusCodes.Status500InternalServerError);
            }


        }
        /// <summary>
        /// Busca todos os registros de Usuario, filtrando email e senha.
        /// </summary>
        /// <param name="email">Adiciona email</param>
        /// <param name="senha">Adiciona senha</param>
        /// <returns></returns>

        [HttpGet("email/{email}/senha/{senha}")]
        public ActionResult<UsuarioPoco> GetValidarEmailSenha(string email, string senha)
        {
            try
            {
                UsuarioPoco poco = this.servico.ValidarEmaileSenha(email, senha);
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
        public ActionResult<UsuarioEnvelopeJSON> Get(int id)
        {
            try
            {
                UsuarioEnvelopeJSON envelope = this.servico.Selecionar(id);
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
        public ActionResult<UsuarioEnvelopeJSON> Post([FromBody] UsuarioPoco poco)
        {
            try
            {
                UsuarioEnvelopeJSON envelope = this.servico.Criar(poco);
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
        public ActionResult<UsuarioEnvelopeJSON> Put([FromBody]UsuarioPoco poco)
        {
            try
            {
                UsuarioEnvelopeJSON envelope = this.servico.Atualizar(poco);
                return Ok(envelope);
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.Message, statusCode: StatusCodes.Status500InternalServerError);
            }

        }
        /// <summary>
        /// Deletar Tabela.
        /// </summary>
        /// <param name="poco"></param>
        /// <returns></returns>
        [HttpDelete]
        public ActionResult<UsuarioEnvelopeJSON> Delete([FromBody] UsuarioPoco poco)
        {
            try
            {
                UsuarioEnvelopeJSON envelope = this.servico.Excluir(poco);
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
        public ActionResult<UsuarioEnvelopeJSON> Delete(int id)
        {
            try
            {
                UsuarioEnvelopeJSON envelope = this.servico.Excluir(id);
                return Ok(envelope);
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.Message, statusCode: StatusCodes.Status500InternalServerError);
            }

        }
    }
}
