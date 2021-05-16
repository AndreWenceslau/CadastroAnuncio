using CadastroAnuncio.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CadastroAnuncio.BancoDados
{
    public class CadastroAnuncioInit : CreateDatabaseIfNotExists<CadastroAnuncioContexto>
    {
        protected override void Seed(CadastroAnuncioContexto context)
        {
            List<CadastroAnuncioModel> cadastroAnuncios = new List<CadastroAnuncioModel>()
            {
                new CadastroAnuncioModel()
                {
                    NomeAnuncio = "Teste Anuncio",
                    NomeCliente = "Teste Cliente",
                    DataInicio = DateTime.Now,
                    DataTermino = DateTime.Now.AddDays(10),
                    InvestimentoDia = 10,
                    ValorTotalInvestido = 100,
                    QtdMaxVizualizacao = 3160,
                    QtdMaxClique = 360,
                    QtdMaxCompartilhamento = 54

                } ,

                new CadastroAnuncioModel()
                {
                    NomeAnuncio = "Teste Anuncio 02",
                    NomeCliente = "Teste Cliente 02",
                    DataInicio = DateTime.Now,
                    DataTermino = DateTime.Now.AddDays(10),
                    InvestimentoDia = 10,
                    ValorTotalInvestido = 100,
                    QtdMaxVizualizacao = 3160,
                    QtdMaxClique = 360,
                    QtdMaxCompartilhamento = 54

                },
                 new CadastroAnuncioModel()
                {
                    NomeAnuncio = "Teste Anuncio 03",
                    NomeCliente = "Teste Cliente 03",
                    DataInicio = DateTime.Now,
                    DataTermino = DateTime.Now.AddDays(10),
                    InvestimentoDia = 10,
                    ValorTotalInvestido = 100,
                    QtdMaxVizualizacao = 3160,
                    QtdMaxClique = 360,
                    QtdMaxCompartilhamento = 54

                }
            };

            cadastroAnuncios.ForEach(c => context.CadastroAnuncio.Add(c));
            context.SaveChanges();
        }
    }
}
