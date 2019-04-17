using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ServiciosProfesionales.DataContext;
using ServiciosProfesionales.Entities;

namespace ServiciosProfesionales.Controllers
{
    public class ContribuyenteController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Contribuyente
        public async Task<ActionResult> Index()
        {
            return View(await db.Contribuyentes.ToListAsync());
        }

        // GET: Contribuyente/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contribuyente contribuyente = await db.Contribuyentes.FindAsync(id);
            if (contribuyente == null)
            {
                return HttpNotFound();
            }
            return View(contribuyente);
        }

        // GET: Contribuyente/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Contribuyente/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,UserId,Rfc,Nombre,Domicilio,Email")] Contribuyente contribuyente)
        {
            if (ModelState.IsValid)
            {
                db.Contribuyentes.Add(contribuyente);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(contribuyente);
        }

        // GET: Contribuyente/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contribuyente contribuyente = await db.Contribuyentes.FindAsync(id);
            if (contribuyente == null)
            {
                return HttpNotFound();
            }
            return View(contribuyente);
        }

        // POST: Contribuyente/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,UserId,Rfc,Nombre,Domicilio,Email")] Contribuyente contribuyente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contribuyente).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(contribuyente);
        }

        // GET: Contribuyente/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contribuyente contribuyente = await db.Contribuyentes.FindAsync(id);
            if (contribuyente == null)
            {
                return HttpNotFound();
            }
            return View(contribuyente);
        }

        // POST: Contribuyente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Contribuyente contribuyente = await db.Contribuyentes.FindAsync(id);
            db.Contribuyentes.Remove(contribuyente);
            await db.SaveChangesAsync();
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
