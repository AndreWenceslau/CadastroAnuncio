using CadastroAnuncio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CadastroAnuncio.Interfaces
{
    public interface ICadastroAnuncioController
    {

        ActionResult Create(CadastroAnuncioModel cadastroAnuncio, string nomeAnuncio, string nomeCliente, DateTime dataInicio, DateTime dataTermino, double investimentoDia);
        ActionResult Edit(CadastroAnuncioModel cadastroAnuncio);
        ActionResult Delete(int id, CadastroAnuncioModel cadastroAnuncio);


    }
}
