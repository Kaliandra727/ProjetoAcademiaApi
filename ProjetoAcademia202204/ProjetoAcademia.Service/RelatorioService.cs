using ProjetoAcademia.EF.Database;
using ProjetoAcademia.Poco;

namespace ProjetoAcademia.Service
{
    public class RelatorioService
    {
		private ProjetoAcademiaContext contexto;

        public RelatorioService(ProjetoAcademiaContext contexto)
        {
            this.contexto = contexto;
        }

        public List<RelatorioPorTurmaPoco> FichaPorTurma(int id)
        {
            List<RelatorioPorTurmaPoco> lista = 
		        (from tur in contexto.Turmas
		        join alut in contexto.AlunosPorTurmas on tur.IdTurma equals alut.IdTurma
		        join inst in contexto.InstrutoresPorTurmas on tur.IdTurma equals inst.IdTurma
		        join curt in contexto.CursosPorTurmas on tur.IdTurma equals curt.IdTurma
		        join alu in contexto.Alunos on alut.IdAluno equals alu.IdAluno
		        join ins in contexto.Instrutors on inst.IdInstrutor equals ins.IdInstrutor
		        join cur in contexto.Cursos on curt.IdCurso equals cur.IdCurso
		        join per in contexto.Periodos on cur.IdPeriodo equals per.IdPeriodo
		        where tur.IdTurma == id
		        select new RelatorioPorTurmaPoco()
		        {
			        TurmaTag = tur.TurmaTag,
			        IdAluno = alu.IdAluno,
			        NomeAluno = alu.AlunoNome,
			        IdInstrutor = ins.IdInstrutor,
			        InstrutorNome = ins.InstrutorNome,
			        IdCurso = cur.IdCurso,
			        NomeCurso = cur.NomeCurso,
                    IdPeriodo = cur.IdPeriodo,
			        PeriodoDescricao = per.PeriodoDescricao
		        }).ToList();
		        return lista;
        }
    }
}