using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using prueba.Models;
using System.Data.Entity;

namespace prueba.Controllers
{
    public class PersonaController : Controller
    {

        DBPRUEBAEntities db = new DBPRUEBAEntities();
        // GET: /Persona/
        public ActionResult Index()
        {
            return View(db.Persona.ToList<Persona>());
        }

        // GET: Persona/Details/5
        public ActionResult Details(int id)
        {
            var query = (from A in db.Persona
                         where A.Idpersona == id
                         select A).Single();
            return View((Persona)query);
        }

        // GET: Persona/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Persona/Create
        [HttpPost]
        public ActionResult Create([Bind(Exclude ="Idpersona")]Persona Objpersona)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }
                db.Entry(Objpersona).State = EntityState.Added;
                db.SaveChanges();              
                return RedirectToAction("Index");
            }
            catch
            { 
                return View();
            }
        }

        // GET: Persona/Edit/5
        public ActionResult Edit(int id)
        {
            var query = (from A in db.Persona
                         where A.Idpersona == id
                         select A).Single();
            return View((Persona)query);
        }

        // POST: Persona/Edit/5
        [HttpPost]
        public ActionResult Edit(Persona Objpersona)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }
                db.Entry(Objpersona).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");

                
            }
            catch
            {
                return View();
            }
        }

        // GET: Persona/Delete/5
        public ActionResult Delete(int id)
        {
            var query = (from A in db.Persona
                         where A.Idpersona == id
                         select A).Single();
            return View((Persona)query);
        }

        // POST: Persona/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Persona persona)
        {
            try
            {

                var query = (from A in db.Persona
                             where A.Idpersona == id
                             select A).Single();
                Persona Objpersona = (Persona)query;
                db.Entry(Objpersona).State = EntityState.Deleted;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
