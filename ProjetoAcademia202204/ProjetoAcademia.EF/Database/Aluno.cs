using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProjetoAcademia.EF.Database
{
    [Table("Aluno")]
    public partial class Aluno
    {
        [Key]
        public int IdAluno { get; set; }
        public long AlunoMatricula { get; set; }
        [StringLength(14)]
        [Unicode(false)]
        public string AlunoCpf { get; set; }
        [Unicode(false)]
        public string AlunoNome { get; set; } = null!;
        [StringLength(1)]
        [Unicode(false)]
        public string AlunoSexo { get; set; } = null!;
        [Column(TypeName = "date")]
        public DateTime AlunoDataNasc { get; set; }
        [Unicode(false)]
        public string AlunoEmail { get; set; } = null!;
        public int IdEndereco { get; set; }
        public int IdUsuario { get; set; }
        public bool? Situacao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataInclusao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataAlteracao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataExclusao { get; set; }
    }
}
