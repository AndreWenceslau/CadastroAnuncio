﻿using CadastroAnuncio.Interfaces;
using CadastroAnuncio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CadastroAnuncio.Controllers
{
    public class CadastroAnuncioController : Controller, ICadastroAnuncioController
    {
        // GET: CadastroAnuncio
        public ActionResult Index()
        {
            return View();
        }


         
        // GET: CadastroAnuncio/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CadastroAnuncio/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CadastroAnuncio/Create
        [HttpPost]
        public ActionResult Create(CadastroAnuncioModel cadastroAnuncio)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CadastroAnuncio/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CadastroAnuncio/Edit/5
        [HttpPost]
        public ActionResult Edit(CadastroAnuncioModel cadastroAnuncion)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CadastroAnuncio/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CadastroAnuncio/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, CadastroAnuncioModel cadastroAnuncio)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
