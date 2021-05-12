using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CadastroAnuncio.Models
{
    public class CadastroAnuncioModel
    {
        public int Id { get; set; }
        public string NomeAnuncio { get; set; }
        public string NomeCliente { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime  DataInicio { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataTermino { get; set; }
        public double InvestimentoDia { get; set; }
        public double ValorTotalInvestido { get; set; }
        public decimal? QtdMaxVizualizacao { get; set; }
        public decimal? QtdMaxClique { get; set; }
        public decimal? QtdMaxCompartilhamento { get; set; }
    }
}