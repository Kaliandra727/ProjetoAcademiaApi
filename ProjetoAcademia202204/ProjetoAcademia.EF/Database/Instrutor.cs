using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProjetoAcademia.EF.Database
{
    [Table("Instrutor")]
    public partial class Instrutor
    {
        [Key]
        public int IdInstrutor { get; set; }
        [StringLength(14)]
        [Unicode(false)]
        public string InstrutorCpf { get; set; }
        [Unicode(false)]
        public string InstrutorNome { get; set; } = null!;
        [StringLength(2)]
        [Unicode(false)]
        public string InstrutorSexo { get; set; } = null!;
        [Column(TypeName = "date")]
        public DateTime InstrutorDataNasc { get; set; }
        [Unicode(false)]
        public string InstrutorEmail { get; set; } = null!;
        public int IdUsuario { get; set; }
        public bool? Situacao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataInclusao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataAlteracao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataExclusao { get; set; }

        // Adicionado pelo Programador.
        public int IdEndereco { get; set; }
    }
}
