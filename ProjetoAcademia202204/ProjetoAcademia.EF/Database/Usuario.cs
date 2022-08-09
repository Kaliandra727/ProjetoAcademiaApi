using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProjetoAcademia.EF.Database
{
    [Table("Usuario")]
    public partial class Usuario
    {
        [Key]
        public int IdUsuario { get; set; }
        public bool UsuarioAtivo { get; set; }
        [Unicode(false)]
        public string NomeUsuario { get; set; } = null!;
        [Unicode(false)]
        public string EmailUsuario { get; set; } = null!;
        [Unicode(false)]
        public string SenhaUsuario { get; set; } = null!;
        public bool? Situacao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataInclusao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataAlteracao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataExclusao { get; set; }

        // Adicionado pelo Programador
        [Unicode(false)]
        [StringLength(1)]
        public string TipoUsuario { get; set; } = null!;
    }
}
