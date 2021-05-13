using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CadastroAnuncio.RegraDeNegocio
{
    public static class TotalCompartilhamento
    {
        public static double GetCompartilhamentos(double? qtdMaxClique, double cliqueCompartilhamento)
        {
            var compartilhamentos = (int)qtdMaxClique / (int)cliqueCompartilhamento;

            if (qtdMaxClique < cliqueCompartilhamento)
            {
                compartilhamentos = 0;
            }
            if (compartilhamentos > 4)
            {
                compartilhamentos = 4;
            }
            return compartilhamentos;
        }
    }
}