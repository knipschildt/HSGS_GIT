using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HsgsGsu.Models;

namespace HsgsGsu.Controllers
{
    public class QuizListesController : Controller
    {
        private GSUContext db = new GSUContext();

        // GET: QuizListes
        public ActionResult Index()
        {
            return View(db.QuizLister.ToList());
        }

        // GET: QuizListes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuizListe quizListe = db.QuizLister.Find(id);
            if (quizListe == null)
            {
                return HttpNotFound();
            }
            return View(quizListe);
        }

        // GET: QuizListes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: QuizListes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "QuizId,Titel,Beskrivelse,Kategori,Førdag,Lektion,Oprettet,AntalGange")] QuizListe quizListe)
        {
            if (ModelState.IsValid)
            {
                db.QuizLister.Add(quizListe);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(quizListe);
        }

        // GET: QuizListes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuizListe quizListe = db.QuizLister.Find(id);
            if (quizListe == null)
            {
                return HttpNotFound();
            }
            return View(quizListe);
        }

        // POST: QuizListes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "QuizId,Titel,Beskrivelse,Kategori,Førdag,Lektion,Oprettet,AntalGange")] QuizListe quizListe)
        {
            if (ModelState.IsValid)
            {
                db.Entry(quizListe).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(quizListe);
        }

        // GET: QuizListes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuizListe quizListe = db.QuizLister.Find(id);
            if (quizListe == null)
            {
                return HttpNotFound();
            }
            return View(quizListe);
        }

        // POST: QuizListes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            QuizListe quizListe = db.QuizLister.Find(id);
            db.QuizLister.Remove(quizListe);
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
