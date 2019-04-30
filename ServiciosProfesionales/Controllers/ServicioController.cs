using System.Data.Entity;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using ServiciosProfesionales.DataContext;
using ServiciosProfesionales.Entities;

namespace ServiciosProfesionales.Controllers
{
    public class ServicioController : Controller
    {
        private readonly ApplicationDbContext _db = new ApplicationDbContext();

        // GET: Servicio
        public async Task<ActionResult> Index()
        {
            return View(await _db.Servicios.ToListAsync());
        }

        // GET: Servicio/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var servicio = await _db.Servicios.FindAsync(id);
            if (servicio == null)
            {
                return HttpNotFound();
            }

            return View(servicio);
        }

        // GET: Servicio/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Servicio/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Clave,Nombre,Descripcion,Importe")]
            Servicio servicio)
        {
            if (ModelState.IsValid)
            {
                _db.Servicios.Add(servicio);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(servicio);
        }

        // GET: Servicio/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var servicio = await _db.Servicios.FindAsync(id);

            if (servicio == null)
            {
                return HttpNotFound();
            }

            return View(servicio);
        }

        // POST: Servicio/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Clave,Nombre,Descripcion,Importe")]
            Servicio servicio)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(servicio).State = EntityState.Modified;
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(servicio);
        }

        // GET: Servicio/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var servicio = await _db.Servicios.FindAsync(id);

            if (servicio == null)
            {
                return HttpNotFound();
            }

            return View(servicio);
        }

        // POST: Servicio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var servicio = await _db.Servicios.FindAsync(id);
            _db.Servicios.Remove(servicio);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}