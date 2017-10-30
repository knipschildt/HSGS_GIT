using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using HsgsGsu.Models;
using System.Collections.Generic;

namespace HsgsGsu.Controllers
{
    public class QuizListesController : Controller
    {
        private GSUContext db = new GSUContext();

        public ActionResult Index()
        {
            return View(db.QuizLister.ToList());
        }

        [HttpPost]
        public virtual JsonResult Details(QuizOrderList usr)
        {
            using (db = new GSUContext())
            {
                dynamic val = null;

                if (usr.DEL != "Alle DEL" && usr.HOLD != "Alle HOLD")
                {
                    var val1 = from b in db.QuizOrderLister
                         where (b.KursusID == usr.KursusID) && (b.HOLD == usr.HOLD) && (b.DEL == usr.DEL)
                               orderby b.Score descending
                               select new
                          {
                              KundeID = b.KursusID,
                              DEL = b.DEL,
                              HOLD = b.HOLD,
                              Score = b.Score,
                              Navn = b.Navn,
                          };
                    return Json(val1.ToList());
                }

                if (usr.DEL != "Alle DEL" && usr.HOLD == "Alle HOLD")
                {
                    var val2 = from b in db.QuizOrderLister
                          where (b.DEL == usr.DEL) && (b.KursusID == usr.KursusID)
                               orderby b.Score descending
                               select new
                          {
                              KundeID = b.KursusID,
                              DEL = b.DEL,
                              HOLD = b.HOLD,
                              Score = b.Score,
                              Navn = b.Navn,
                          };
                    return Json(val2.ToList());
                }

                if (usr.DEL == "Alle DEL" && usr.HOLD != "Alle HOLD")
                {
                    var val3 = from b in db.QuizOrderLister
                          where (b.HOLD == usr.HOLD) && (b.KursusID == usr.KursusID)
                               orderby b.Score descending
                               select new
                          {
                              KundeID = b.KursusID,
                              DEL = b.DEL,
                              HOLD = b.HOLD,
                              Score = b.Score,
                              Navn = b.Navn,
                          };
                    return Json(val3.ToList());
                }

                if (usr.DEL == "Alle DEL" && usr.HOLD == "Alle HOLD")
                {
                    var val4 = from b in db.QuizOrderLister
                               where (b.KursusID == usr.KursusID)
                               orderby b.Score descending
                               select new
                               {
                                   KundeID = b.KursusID,
                                   DEL = b.DEL,
                                   HOLD = b.HOLD,
                                   Score = b.Score,
                                   Navn = b.Navn,
                               };
                    return Json(val4.ToList());
                }
                return Json(val);
            }
        }

        [HttpPost]
        public virtual JsonResult GetComboDEL(QuizOrderList usr)
        {
            using (db = new GSUContext())
            {
                dynamic val1 = null;
                dynamic val2 = null;

                val1 = (from b in db.QuizOrderLister
                        where (b.KursusID == usr.KursusID)
                        group b by b.HOLD
                        into g
                        select g.FirstOrDefault()).ToList();

                if (usr.DEL == "Alle DEL" && usr.HOLD != "Alle HOLD")
                {
                    val2 = (from b in db.QuizOrderLister
                            where (b.HOLD == usr.HOLD) && (b.KursusID == usr.KursusID)
                            group b by b.DEL
                            into g
                            select g.FirstOrDefault()).ToList();
                }
                else if (usr.HOLD == "Alle HOLD" && usr.DEL == "Alle DEL")
                {
                    val2 = (from b in db.QuizOrderLister
                            where (b.KursusID == usr.KursusID)
                            group b by b.DEL
                            into g
                            select g.FirstOrDefault()).ToList();
                }
                else if (usr.DEL != "Alle DEL" && usr.HOLD == "Alle HOLD")
                {
                    val2 = (from b in db.QuizOrderLister
                            where (b.KursusID == usr.KursusID)
                            group b by b.DEL
                            into g
                            select g.FirstOrDefault()).ToList();
                }

                else
                {
                    var co = (from b in db.QuizOrderLister
                              where (b.HOLD == usr.HOLD) && (b.KursusID == usr.KursusID)
                              select b).Count();

                    if (co > 0)
                    {
                        val2 = (from b in db.QuizOrderLister
                                where (b.HOLD == usr.HOLD) && (b.KursusID == usr.KursusID)
                                group b by b.DEL
                            into g
                                select g.FirstOrDefault()).ToList();
                    }
                    else
                    {
                        val2 = (from b in db.QuizOrderLister
                                where (b.KursusID == usr.KursusID)
                                group b by b.DEL
                           into g
                                select g.FirstOrDefault()).ToList();
                    }


                }
                List<List<QuizOrderList>> list = new List<List<QuizOrderList>>();
                list.Add(val1);
                list.Add(val2);

                return Json(list);
            }
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

            QuizSamlingUser BCVM = new QuizSamlingUser();
            BCVM.User = new User();
            BCVM.Qliste = quizListe;
            BCVM.QOListe = (from b in db.QuizOrderLister
                            where b.KursusID == id
                            orderby b.Score descending
                            select b).ToList();

            ViewBag.query = ((from s in db.QuizOrderLister
                              where s.KursusID == id
                              select s.DEL).Distinct()).ToList();
            ViewBag.query2 = ((from s in db.QuizOrderLister
                               where s.KursusID == id
                               select s.HOLD).Distinct()).ToList();
            return View(BCVM);
        }

        // GET: QuizListes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: QuizListes/Create
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

