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
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime?  DataInicio { get ; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DataTermino { get; set;}
        public double InvestimentoDia { get; set; }
        public double ValorTotalInvestido { get; set; }
        public double? QtdMaxVizualizacao { get; set; }
        public double? QtdMaxClique { get; set; }
        public double? QtdMaxCompartilhamento { get; set; }
        public string FiltroNomeCliente { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? FIltroDataTermino { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? FiltroDataInicio { get; set; }

    }
}