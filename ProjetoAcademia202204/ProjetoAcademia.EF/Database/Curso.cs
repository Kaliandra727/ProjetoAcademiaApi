using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProjetoAcademia.EF.Database
{
    [Table("Curso")]
    public partial class Curso
    {
        [Key]
        public int IdCurso { get; set; }
        [Unicode(false)]
        public string NomeCurso { get; set; } = null!;
        public bool? Situacao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataInclusao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataAlteracao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataExclusao { get; set; }
        
        //Adicionado pelo programador - 29/07/2022 - 16:39.
        public int IdPeriodo { get; set; }
    }
}
