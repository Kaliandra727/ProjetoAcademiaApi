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
        
    public class AlunosPorTurmaController : ControllerBase
    {
        private AlunosPorTurmaService servico;

        /// <summary>
        /// </summary>
        public AlunosPorTurmaController(ProjetoAcademiaContext contexto) : base()
        {
            this.servico = new AlunosPorTurmaService(contexto);
        }
        /// <summary>
        /// Busca todos os registros de Alunos Por Turma, filtrando onde inicia(skip) e a quantidade(take), caso queira trazer todos use skip (0) e take(0).
        /// </summary>
        /// <param name="skip">Onde inicia os resultados da pesquisa.</param>
        /// <param name="take"> Quantos registros serão retornados.</param>
        /// <returns>Coleção de dados.</returns>

        [HttpGet("{skip:int}/{take:int}")]
        public ActionResult<List<AlunosPorTurmaEnvelopeJSON>> GetAll(int skip, int take)
        {
            try
            {
                List<AlunosPorTurmaEnvelopeJSON> lista = this.servico.Listar(skip, take);
                return Ok(lista);
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
        public ActionResult<AlunosPorTurmaEnvelopeJSON> Get(int id)
        {
            try
            {
                AlunosPorTurmaEnvelopeJSON envelope = this.servico.Selecionar(id);
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
        public ActionResult<AlunosPorTurmaEnvelopeJSON> Post([FromBody] AlunosPorTurmaPoco poco)
        {
            try
            {
                AlunosPorTurmaEnvelopeJSON envelope = this.servico.Criar(poco);
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
        public ActionResult<AlunosPorTurmaEnvelopeJSON> Put([FromBody]AlunosPorTurmaPoco poco)
        {
            try
            {
                AlunosPorTurmaEnvelopeJSON envelope = this.servico.Atualizar(poco);
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
        public ActionResult<AlunosPorTurmaEnvelopeJSON> Delete([FromBody] AlunosPorTurmaPoco poco)
        {
            try
            {
                AlunosPorTurmaEnvelopeJSON envelope = this.servico.Excluir(poco);
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
        public ActionResult<AlunosPorTurmaEnvelopeJSON> Delete(int id)
        {
            try
            {
                AlunosPorTurmaEnvelopeJSON envelope = this.servico.Excluir(id);
                return Ok(envelope);
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.Message, statusCode: StatusCodes.Status500InternalServerError);
            }

        }
    }
}
