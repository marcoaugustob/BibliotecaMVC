using Biblioteca.Models;
using DataBiblioteca;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Biblioteca.Controllers
{
    public class PrateleirasController : BaseController
    {
        public ActionResult Index()
        {

            return View(db.Prateleiras.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prateleira prateleira = db.Prateleiras.Find(id);
            if (prateleira == null)
            {
                return HttpNotFound();
            }
            return View(prateleira);
        }

        public ActionResult Delete(int?id)
        {
            if ( id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prateleira prat = db.Prateleiras.Find(id);
            if (prat == null)
            {
                return HttpNotFound();
            }
            return View(prat);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prateleira prateleira = db.Prateleiras.Find(id);
            if (prateleira == null)
            {
                return HttpNotFound();
            }
            return View(prateleira);

        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "PrateleiraID, Localizacao")] Prateleira prateleira)
        {
            if (ModelState.IsValid)
            {//continuar a partir daqui
                if (db.Prateleiras.FirstOrDefault(x => x.Localizacao.Equals(prateleira.Localizacao))== null)
                {
                    db.Prateleiras.Add(prateleira);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("Mensagem", "Esta prateleira já foi cadastrada :(");
                }
            }
            return View(prateleira);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PrateleiraID, Localizacao")] Prateleira prateleira)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prateleira).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(prateleira);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Prateleira prat = db.Prateleiras.Find(id);
            db.Prateleiras.Remove(prat);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}