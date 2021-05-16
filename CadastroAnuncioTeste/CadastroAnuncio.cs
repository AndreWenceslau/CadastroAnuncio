using CadastroAnuncio.Models;
using CadastroAnuncio.RegraDeNegocio;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CadastroAnuncioTeste
{
    [TestClass]
    public class CadastroAnuncio
    {
        [TestMethod]
        public void CadastraAnuncio_QuandoReceberTodosValores_DeveRetornarValorTotalInvestido()
        {
            //Arrange
            CadastroAnuncioModel cadastroAnuncioModel = new CadastroAnuncioModel();
            cadastroAnuncioModel.NomeAnuncio = "Nome Anuncio";
            cadastroAnuncioModel.NomeCliente = "Nome Cliente";
            cadastroAnuncioModel.DataInicio = DateTime.Now;
            cadastroAnuncioModel.DataTermino = DateTime.Now.AddDays(1);
            cadastroAnuncioModel.InvestimentoDia = 10;

            var resultadoEsperado = 10;

            //Act
            var investimentoDia = cadastroAnuncioModel.InvestimentoDia;
            var tempoAnuncio = TempoDoAnuncio.GetTempoDoAnuncio(cadastroAnuncioModel.DataInicio, cadastroAnuncioModel.DataTermino);
            cadastroAnuncioModel.ValorTotalInvestido = investimentoDia * tempoAnuncio;

            //Assert
            Assert.AreEqual(resultadoEsperado, cadastroAnuncioModel.ValorTotalInvestido);
        }
        [TestMethod]
        public void CadastraAnuncio_QuandoReceberTodosValores_DeveRetornarQuantidadeMaximaVisualizacoes()
        {
            //Arrange
            CadastroAnuncioModel cadastroAnuncioModel = new CadastroAnuncioModel();
            cadastroAnuncioModel.NomeAnuncio = "Nome Anuncio";
            cadastroAnuncioModel.NomeCliente = "Nome Cliente";
            cadastroAnuncioModel.DataInicio = DateTime.Now;
            cadastroAnuncioModel.DataTermino = DateTime.Now.AddDays(1);
            cadastroAnuncioModel.InvestimentoDia = 10;

            var resultadoEsperado = 460;

            //Act
            var qtdViewDia = (int)QtdViewDia.GetQtdViewDia(cadastroAnuncioModel.InvestimentoDia);
            var tempoAnuncio = TempoDoAnuncio.GetTempoDoAnuncio(cadastroAnuncioModel.DataInicio, cadastroAnuncioModel.DataTermino);
            var tempoDoAnuncio = TempoDoAnuncio.GetTempoDoAnuncio(cadastroAnuncioModel.DataInicio, cadastroAnuncioModel.DataTermino);
            cadastroAnuncioModel.QtdMaxClique = qtdViewDia * tempoAnuncio / (int)VariavelFixa.ViewClique;
            var compartilhamentos = TotalCompartilhamento.GetCompartilhamentos(cadastroAnuncioModel.QtdMaxClique, VariavelFixa.CliqueCompartilhamento);
            var viewAdicionais = ViewAdicional.GetViewAdicionais(compartilhamentos);
            cadastroAnuncioModel.QtdMaxVizualizacao = qtdViewDia * tempoDoAnuncio + viewAdicionais;

            //Assert
            Assert.AreEqual(resultadoEsperado, cadastroAnuncioModel.QtdMaxVizualizacao);
        }
        [TestMethod]
        public void CadastraAnuncio_QuandoReceberTodosValores_DeveRetornarQuantidadeMaximaCliques()
        {
            //Arrange
            CadastroAnuncioModel cadastroAnuncioModel = new CadastroAnuncioModel();
            cadastroAnuncioModel.NomeAnuncio = "Nome Anuncio";
            cadastroAnuncioModel.NomeCliente = "Nome Cliente";
            cadastroAnuncioModel.DataInicio = DateTime.Now;
            cadastroAnuncioModel.DataTermino = DateTime.Now.AddDays(1);
            cadastroAnuncioModel.InvestimentoDia = 10;

            var resultadoEsperado = 37;

            //Act
            var qtdViewDia = (int)QtdViewDia.GetQtdViewDia(cadastroAnuncioModel.InvestimentoDia);
            var tempoAnuncio = TempoDoAnuncio.GetTempoDoAnuncio(cadastroAnuncioModel.DataInicio, cadastroAnuncioModel.DataTermino);
            var tempoDoAnuncio = TempoDoAnuncio.GetTempoDoAnuncio(cadastroAnuncioModel.DataInicio, cadastroAnuncioModel.DataTermino);
            cadastroAnuncioModel.QtdMaxClique = qtdViewDia * tempoAnuncio / (int)VariavelFixa.ViewClique;
            var compartilhamentos = TotalCompartilhamento.GetCompartilhamentos(cadastroAnuncioModel.QtdMaxClique, VariavelFixa.CliqueCompartilhamento);
            var viewAdicionais = ViewAdicional.GetViewAdicionais(compartilhamentos);
            cadastroAnuncioModel.QtdMaxVizualizacao = qtdViewDia * tempoDoAnuncio + viewAdicionais;

            //Assert
            Assert.AreEqual(resultadoEsperado, cadastroAnuncioModel.QtdMaxClique);
        }
        [TestMethod]
        public void CadastraAnuncio_QuandoReceberTodosValores_DeveRetornarQuantidadeMaximaCompartilhamentos()
        {
            //Arrange
            CadastroAnuncioModel cadastroAnuncioModel = new CadastroAnuncioModel();
            cadastroAnuncioModel.NomeAnuncio = "Nome Anuncio";
            cadastroAnuncioModel.NomeCliente = "Nome Cliente";
            cadastroAnuncioModel.DataInicio = DateTime.Now;
            cadastroAnuncioModel.DataTermino = DateTime.Now.AddDays(1);
            cadastroAnuncioModel.InvestimentoDia = 10;

            var resultadoEsperado = 4;

            //Act
            var qtdViewDia = (int)QtdViewDia.GetQtdViewDia(cadastroAnuncioModel.InvestimentoDia);
            var tempoAnuncio = TempoDoAnuncio.GetTempoDoAnuncio(cadastroAnuncioModel.DataInicio, cadastroAnuncioModel.DataTermino);
            var tempoDoAnuncio = TempoDoAnuncio.GetTempoDoAnuncio(cadastroAnuncioModel.DataInicio, cadastroAnuncioModel.DataTermino);
            cadastroAnuncioModel.QtdMaxClique = qtdViewDia * tempoAnuncio / (int)VariavelFixa.ViewClique;
            var compartilhamentos = TotalCompartilhamento.GetCompartilhamentos(cadastroAnuncioModel.QtdMaxClique, VariavelFixa.CliqueCompartilhamento);
            var viewAdicionais = ViewAdicional.GetViewAdicionais(compartilhamentos);
            cadastroAnuncioModel.QtdMaxVizualizacao = qtdViewDia * tempoDoAnuncio + viewAdicionais;
            cadastroAnuncioModel.QtdMaxCompartilhamento = compartilhamentos;

            //Assert
            Assert.AreEqual(resultadoEsperado, cadastroAnuncioModel.QtdMaxCompartilhamento);
        }
    }
}
