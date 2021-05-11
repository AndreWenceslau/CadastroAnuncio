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

namespace CadastroAnuncio.Controllers
{
    public class CadastroAnuncioController : Controller
    {
        private CadastroAnuncioContext db = new CadastroAnuncioContext();

        // GET: CadastroAnuncio
        public ActionResult Index()
        {
            return View(db.CadastroAnuncio.ToList());
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

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
