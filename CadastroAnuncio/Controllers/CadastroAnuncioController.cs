using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CadastroAnuncio.BancoDados;
using CadastroAnuncio.Models;
using CadastroAnuncio.RegraDeNegocio;
using Rotativa;

namespace CadastroAnuncio.Controllers
{
    public class CadastroAnuncioController : Controller
    {
        private CadastroAnuncioContext db = new CadastroAnuncioContext();

        // GET: CadastroAnuncio
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult Listar(int pagina = 1, int registros = 5)
        {
            var anuncios = db.CadastroAnuncio;
            var anunciosPaginado = anuncios.OrderBy(x => x.NomeAnuncio).Skip((pagina - 1)* registros).Take(registros);
            int quantidadePaginasAnuncios = anunciosPaginado.Count();
            return PartialView("_Listar", anunciosPaginado.ToList());
        }



        public ActionResult Relatorio()
        {
            return new ViewAsPdf(db.CadastroAnuncio.ToList());
        }

        // GET: CadastroAnuncio/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CadastroAnuncioModel cadastroAnuncioModel = db.CadastroAnuncio.Find(id);
            if (cadastroAnuncioModel == null)
            {
                return HttpNotFound();
            }
            return View(cadastroAnuncioModel);
        }

        // GET: CadastroAnuncio/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CadastroAnuncio/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NomeAnuncio,NomeCliente,DataInicio,DataTermino,InvestimentoDia,ValorTotalInvestido,QtdMaxVizualizacao,QtdMaxClique,QtdMaxCompartilhamento")] CadastroAnuncioModel cadastroAnuncioModel)
        {
            if (ModelState.IsValid)
            {
               
                if (cadastroAnuncioModel.DataInicio < DateTime.Now.Date)
                {
                    TempData["mensagemErroDataInicio"] = "Não é possível cadastrar data inferior a de hoje";
                    return View(cadastroAnuncioModel);
                }
                if (cadastroAnuncioModel.DataTermino < cadastroAnuncioModel.DataInicio)
                {
                    TempData["mensagemErroDataFIm"] = "Não é possível cadastrar a Data de Termino menor que a de início";
                    return View(cadastroAnuncioModel);
                }
                var qtdViewDia = (int)QtdViewDia.GetQtdViewDia(cadastroAnuncioModel.InvestimentoDia);
                var tempoAnuncio = TempoDoAnuncio.GetTempoDoAnuncio(cadastroAnuncioModel.DataInicio, cadastroAnuncioModel.DataTermino);
                cadastroAnuncioModel.QtdMaxClique = qtdViewDia * tempoAnuncio / (int)VariaveiFixas.ViewClique;
                var investimentoDia = cadastroAnuncioModel.InvestimentoDia;
                var compartilhamentos = TotalCompartilhamento.GetCompartilhamentos(cadastroAnuncioModel.QtdMaxClique, VariaveiFixas.CliqueCompartilhamento);
                var tempoDoAnuncio = TempoDoAnuncio.GetTempoDoAnuncio(cadastroAnuncioModel.DataInicio, cadastroAnuncioModel.DataTermino);
                var viewAdicionais = ViewAdicional.GetViewAdicionais(compartilhamentos);
                cadastroAnuncioModel.ValorTotalInvestido = investimentoDia * tempoAnuncio; 
                cadastroAnuncioModel.QtdMaxVizualizacao = qtdViewDia * tempoDoAnuncio + viewAdicionais;
                cadastroAnuncioModel.QtdMaxCompartilhamento = compartilhamentos;
                db.CadastroAnuncio.Add(cadastroAnuncioModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }                                                                   

            return View(cadastroAnuncioModel);
        }

        // GET: CadastroAnuncio/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CadastroAnuncioModel cadastroAnuncioModel = db.CadastroAnuncio.Find(id);
            if (cadastroAnuncioModel == null)
            {
                return HttpNotFound();
            }
            //var dataFormatada = cadastroAnuncioModel.
            return View(cadastroAnuncioModel);
        }

        // POST: CadastroAnuncio/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NomeAnuncio,NomeCliente,DataInicio,DataTermino,InvestimentoDia,ValorTotalInvestido,QtdMaxVizualizacao,QtdMaxClique,QtdMaxCompartilhamento")] CadastroAnuncioModel cadastroAnuncioModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cadastroAnuncioModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cadastroAnuncioModel);
        }

        // GET: CadastroAnuncio/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CadastroAnuncioModel cadastroAnuncioModel = db.CadastroAnuncio.Find(id);
            if (cadastroAnuncioModel == null)
            {
                return HttpNotFound();
            }
            return View(cadastroAnuncioModel);
        }

        // POST: CadastroAnuncio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CadastroAnuncioModel cadastroAnuncioModel = db.CadastroAnuncio.Find(id);
            db.CadastroAnuncio.Remove(cadastroAnuncioModel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
