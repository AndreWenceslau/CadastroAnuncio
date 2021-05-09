using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CadastroAnuncio.Models
{
    public class CadastroAnuncioModel
    {
        public int Id { get; set; }
        public string NomeAnuncio { get; set; }
        public string NomeCliente { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataTermino { get; set; }
        public double InvestimentoDia { get; set; }
        public double ValorTotalInvestido { get; set; }
        public decimal QtdMaxVizualizacao { get; set; }
        public decimal QtdMaxClique { get; set; }
        public decimal QtdMaxCompartilhamento { get; set; }
    }
}