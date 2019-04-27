using System.Data.Entity;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using ServiciosProfesionales.DataContext;
using ServiciosProfesionales.Entities;

namespace ServiciosProfesionales.Controllers
{
    public class FacturaController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Factura
        public async Task<ActionResult> Index()
        {
            var facturas = db.Facturas.Include(f => f.Cliente).Include(f => f.Contribuyente);
            return View(await facturas.ToListAsync());
        }

        // GET: Factura/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var factura = await db.Facturas.FindAsync(id);
            if (factura == null)
            {
                return HttpNotFound();
            }

            return View(factura);
        }

        // GET: Factura/Create
        public ActionResult Create()
        {
            ViewBag.ClienteId = new SelectList(db.Clientes, "Id", "RazonSocial");
            ViewBag.ContribuyenteId = new SelectList(db.Contribuyentes, "Id", "Rfc");
            return View();
        }

        // POST: Factura/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,FolioFiscal,Numero,Fecha,ContribuyenteId,ClienteId")]
            Factura factura)
        {
            if (ModelState.IsValid)
            {
                db.Facturas.Add(factura);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ClienteId = new SelectList(db.Clientes, "Id", "RazonSocial", factura.ClienteId);
            ViewBag.ContribuyenteId = new SelectList(db.Contribuyentes, "Id", "Rfc", factura.ContribuyenteId);
            return View(factura);
        }

        // GET: Factura/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var factura = await db.Facturas.FindAsync(id);
            if (factura == null)
            {
                return HttpNotFound();
            }

            ViewBag.ClienteId = new SelectList(db.Clientes, "Id", "RazonSocial", factura.ClienteId);
            ViewBag.ContribuyenteId = new SelectList(db.Contribuyentes, "Id", "Rfc", factura.ContribuyenteId);
            return View(factura);
        }

        // POST: Factura/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,FolioFiscal,Numero,Fecha,ContribuyenteId,ClienteId")]
            Factura factura)
        {
            if (ModelState.IsValid)
            {
                db.Entry(factura).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ClienteId = new SelectList(db.Clientes, "Id", "RazonSocial", factura.ClienteId);
            ViewBag.ContribuyenteId = new SelectList(db.Contribuyentes, "Id", "Rfc", factura.ContribuyenteId);
            return View(factura);
        }

        // GET: Factura/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var factura = await db.Facturas.FindAsync(id);
            if (factura == null)
            {
                return HttpNotFound();
            }

            return View(factura);
        }

        // POST: Factura/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var factura = await db.Facturas.FindAsync(id);
            db.Facturas.Remove(factura);
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