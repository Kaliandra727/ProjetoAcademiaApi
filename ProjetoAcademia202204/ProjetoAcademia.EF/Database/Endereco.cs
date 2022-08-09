using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProjetoAcademia.EF.Database
{
    [Table("Endereco")]
    public partial class Endereco
    {
        [Key]
        public int IdEndereco { get; set; }
        public int EnderecoCep { get; set; }
        public int EnderecoIdUf { get; set; }
        [StringLength(2)]
        [Unicode(false)]
        public string EnderecoUf { get; set; } = null!;
        public int EnderecoIdCidade { get; set; }
        [Unicode(false)]
        public string EnderecoCidade { get; set; } = null!;
        [Unicode(false)]
        public string EnderecoBairro { get; set; } = null!;
        [Unicode(false)]
        public string EnderecoRua { get; set; } = null!;
        public int EnderecoNumero { get; set; }
        [Unicode(false)]
        public string? EnderecoComplemento { get; set; }
        public bool? Situacao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataInclusao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataAlteracao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataExclusao { get; set; }
    }
}
