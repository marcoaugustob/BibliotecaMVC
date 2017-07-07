using Biblioteca.Models;
using DataBiblioteca;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Biblioteca.Controllers
{
    public class LivrosController : BaseController
    {
        public ActionResult Index()
        {

            return View(db.Livros.ToList());
        }

        //GET
        public ActionResult Create()
        {
          
            ViewBag.GeneroID = new SelectList(db.Generos.ToList(), "GeneroID", "Nome", "Nome");
            ViewBag.EditoraID = new SelectList(db.Editoras.ToList(), "EditoraID", "Nome", "Nome");
            ViewBag.PrateleiraID = new SelectList(db.Prateleiras.ToList(), "PrateleiraID", "Localizacao", "Localizacao");

            return View();
        }

        //GET
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Livro livro = db.Livros.Find(id);
            if (livro == null)
            {
                return HttpNotFound();
            }
            return View(livro);
        }

        //GET
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Livro livro = db.Livros.Find(id);
            if (livro == null)
            {
                return HttpNotFound();
            }
            return View(livro);
        }

        //GET
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Livro livro = db.Livros.Find(id);
            return View();
        }

        [HttpPost]
        public ActionResult Create(Livro livro)
        {
            //Verifica se a prateleira está cheia
            var prate = db.Prateleiras.FirstOrDefault(x => x.PrateleiraID.Equals(livro.PrateleiraID));
            if (prate.Livros.Count <= 3 )
            {
                db.Livros.Add(livro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("Mensagem", "Esta prateleira está cheia :(");
                ModelState.AddModelError("PrateleiraID","Mude para a próxima");
            }
            ViewBag.GeneroID = new SelectList(db.Generos.ToList(), "GeneroID", "Nome", "Nome");
            ViewBag.EditoraID = new SelectList(db.Editoras.ToList(), "EditoraID", "Nome", "Nome");
            ViewBag.PrateleiraID = new SelectList(db.Prateleiras.ToList(), "PrateleiraID", "Localizacao", "Localizacao");
            return View(livro);
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "LivroID, Nome")] Livro livro)
        {
            db.Entry(livro).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Livro livro = db.Livros.Find(id);
            db.Livros.Remove(livro);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}