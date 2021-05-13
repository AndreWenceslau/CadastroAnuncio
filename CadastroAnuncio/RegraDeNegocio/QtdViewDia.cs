using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CadastroAnuncio.RegraDeNegocio
{
    public static class QtdViewDia
    {
        public static double GetQtdViewDia(double investimentoDia)
        {
            return investimentoDia * VariaveiFixas.ViewPorUmReal;
        }
    }
}