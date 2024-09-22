using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ControlEscolar.Models;

namespace ControlEscolar.Controllers
{
    public class AlumnosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Alumnos
        public ActionResult Index()
        {
            var alumnos = db.Alumnos.Include(a => a.Carreras);
            return View(alumnos.ToList());
        }

        // GET: Alumnos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alumno alumno = db.Alumnos.Find(id);
            if (alumno == null)
            {
                return HttpNotFound();
            }
            return View(alumno);
        }

        // GET: Alumnos/Create
        public ActionResult Create()
        {
            ViewBag.CarreraId = new SelectList(db.Carreras, "CarreraId", "Nombre");
            return View();
        }

        // POST: Alumnos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Nombre,ApellidoPaterno,ApellidoMaterno,Direccion,Telefono,CorreoElectronico,FechaAlta,CarreraId")] Alumno alumno)
        {
            if (ModelState.IsValid)
            {
                var parameters = new[]
                {
                    new SqlParameter("@Nombre", alumno.Nombre),
                    new SqlParameter("@ApellidoPaterno", alumno.ApellidoPaterno),
                    new SqlParameter("@ApellidoMaterno", alumno.ApellidoMaterno),
                    new SqlParameter("@Direccion", alumno.Direccion),
                    new SqlParameter("@Telefono", alumno.Telefono),
                    new SqlParameter("@CorreoElectronico", alumno.CorreoElectronico),
                    new SqlParameter("@FechaAlta", alumno.FechaAlta),
                    new SqlParameter("@CarreraId", alumno.CarreraId)
                };

                db.Database.ExecuteSqlCommand("EXEC InsertarAlumno @Nombre, @ApellidoPaterno, @ApellidoMaterno, @Direccion, @Telefono,@CorreoElectronico, @FechaAlta, @CarreraId", parameters);
                return RedirectToAction("Index");
            }

            ViewBag.CarreraId = new SelectList(db.Carreras, "CarreraId", "Nombre", alumno.CarreraId);
            return View(alumno);
        }

        // GET: Alumnos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alumno alumno = db.Alumnos.Find(id);
            if (alumno == null)
            {
                return HttpNotFound();
            }
            ViewBag.CarreraId = new SelectList(db.Carreras, "CarreraId", "Nombre", alumno.CarreraId);
            return View(alumno);
        }

        // POST: Alumnos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AlumnoId,Nombre,ApellidoPaterno,ApellidoMaterno,Direccion,Telefono,CorreoElectronico,FechaAlta,CarreraId")] Alumno alumno)
        {
            if (ModelState.IsValid)
            {
                db.Entry(alumno).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CarreraId = new SelectList(db.Carreras, "CarreraId", "Nombre", alumno.CarreraId);
            return View(alumno);
        }

        // GET: Alumnos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alumno alumno = db.Alumnos.Find(id);
            if (alumno == null)
            {
                return HttpNotFound();
            }
            return View(alumno);
        }

        // POST: Alumnos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var parameter = new SqlParameter("@AlumnoId", id);
            db.Database.ExecuteSqlCommand("EXEC EliminarAlumno @AlumnoId", parameter);
            return RedirectToAction("Index");
        }


        public ActionResult AlumnosPorCarrera(int id)
        {
            var alumnos = db.Alumnos.Where(a => a.CarreraId == id).ToList();
            ViewBag.CarreraId = id; // Opcional: Puedes usar esto en la vista para mostrar el nombre de la carrera.
            return View(alumnos);
        }

        public class PagosController : Controller
        {
            private ApplicationDbContext db = new ApplicationDbContext();

            public ActionResult Pagos(int id)
            {
                var pagos = db.Pagos.Where(p => p.AlumnoId == id).ToList();
                return View(pagos);
            }
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
