using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CadastroAnuncio.RegraDeNegocio
{
    public static class ViewAdicional
    {
        public static double GetViewAdicionais (double compartilhamentos)
        {
            return compartilhamentos * VariaveiFixas.ViewPorCompartilhamneto;
        }
    }
}