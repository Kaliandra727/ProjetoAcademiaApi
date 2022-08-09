using Microsoft.AspNetCore.Mvc;
using ProjetoAcademia.EF.Database;
using ProjetoAcademia.Poco;
using ProjetoAcademia.Service;

namespace ProjetoAcademiaWebAPI.Controllers
{
    [Route("api/academia/[controller]")]
    [ApiController]
    public class RelatorioController : ControllerBase
    {
        private RelatorioService servico;

        ///<summary>
        ///</summary>
        public RelatorioController(ProjetoAcademiaContext contexto) : base()
        {
            this.servico = new RelatorioService(contexto);
        }

        /// <summary>
        /// Busca todos os registros de uma turma pelo seu ID.
        /// </summary>
        /// <param name="idTurma">Código a ser perquisado.</param>
        /// <returns>Retorna todos os dados de uma turma.</returns>
        /// 
        [HttpGet("porIdTurma/{idTurma:int}")]
        public ActionResult<List<RelatorioPorTurmaPoco>> GetPorTurma(int idTurma)
        {
            try
            {
                List<RelatorioPorTurmaPoco> retorno = this.servico.FichaPorTurma(idTurma);
                return Ok(retorno);
            }
            catch(Exception ex)
            {
                return Problem(detail: ex.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }
    }
}