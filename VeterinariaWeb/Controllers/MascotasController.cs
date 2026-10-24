using Microsoft.AspNetCore.Mvc;
using VeterinariaWeb.Models;

namespace VeterinariaWeb.Controllers
{
    public class MascotasController : Controller
    {
        // Simulación de datos (equivale a RecuperaEstudiante de la guía 13).
        // [NonAction]: no es accesible desde el navegador, solo desde el controlador.
        [NonAction]
        public List<Mascota> RecuperarMascotas()
        {
            return new List<Mascota>
            {
                new Mascota
                {
                    IdMascota = 1, Nombre = "Max", Especie = "Perro", Raza = "Labrador Retriever",
                    Sexo = "M", PesoKg = 30.5m, Propietario = "Carlos Hernández",
                    FechaIngreso = DateTime.Today.AddDays(-30)
                },
                new Mascota
                {
                    IdMascota = 2, Nombre = "Luna", Especie = "Gato", Raza = "Siamés",
                    Sexo = "H", PesoKg = 4.2m, Propietario = "María López",
                    FechaIngreso = DateTime.Today.AddDays(-21)
                },
                new Mascota
                {
                    IdMascota = 3, Nombre = "Rocky", Especie = "Perro", Raza = "Bulldog Francés",
                    Sexo = "M", PesoKg = 12.8m, Propietario = "Ana Martínez",
                    FechaIngreso = DateTime.Today.AddDays(-14)
                },
                new Mascota
                {
                    IdMascota = 4, Nombre = "Nala", Especie = "Gato", Raza = "Persa",
                    Sexo = "H", PesoKg = 3.9m, Propietario = "José Ramírez",
                    FechaIngreso = DateTime.Today.AddDays(-10)
                },
                new Mascota
                {
                    IdMascota = 5, Nombre = "Coco", Especie = "Ave", Raza = "Perico Australiano",
                    Sexo = "M", PesoKg = 0.04m, Propietario = "Laura Guzmán",
                    FechaIngreso = DateTime.Today.AddDays(-5)
                },
                new Mascota
                {
                    IdMascota = 6, Nombre = "Toby", Especie = "Conejo", Raza = "Cabeza de León",
                    Sexo = "M", PesoKg = 2.1m, Propietario = "Pedro Flores",
                    FechaIngreso = DateTime.Today.AddDays(-2)
                }
            };
        }

        // GET: Mascotas
        public ActionResult Index()
        {
            // Se ordenan los datos y se envían a la vista
            var mascotas = from m in RecuperarMascotas()
                           orderby m.Nombre
                           select m;

            return View(mascotas);
        }

        // GET: Mascotas/Details/5
        public ActionResult Details(int id)
        {
            Mascota? mascota = RecuperarMascotas().FirstOrDefault(m => m.IdMascota == id);
            if (mascota == null) return NotFound();

            return View(mascota);
        }

        // GET: Mascotas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Mascotas/Create  (simulado: no se guarda en ninguna parte)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Mascota mascota)
        {
            if (!ModelState.IsValid) return View(mascota);

            TempData["Mensaje"] = $"Simulación: la mascota \"{mascota.Nombre}\" se registraría aquí.";
            return RedirectToAction(nameof(Index));
        }

        // GET: Mascotas/Edit/5
        public ActionResult Edit(int id)
        {
            Mascota? mascota = RecuperarMascotas().FirstOrDefault(m => m.IdMascota == id);
            if (mascota == null) return NotFound();

            return View(mascota);
        }

        // POST: Mascotas/Edit  (simulado)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Mascota mascota)
        {
            if (!ModelState.IsValid) return View(mascota);

            TempData["Mensaje"] = $"Simulación: se actualizarían los datos de \"{mascota.Nombre}\".";
            return RedirectToAction(nameof(Index));
        }

        // GET: Mascotas/Delete/5
        public ActionResult Delete(int id)
        {
            Mascota? mascota = RecuperarMascotas().FirstOrDefault(m => m.IdMascota == id);
            if (mascota == null) return NotFound();

            return View(mascota);
        }

        // POST: Mascotas/Delete  (simulado)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Mascota mascota)
        {
            // Aquí no se valida el modelo: de la vista solo llega el IdMascota
            TempData["Mensaje"] = $"Simulación: se eliminaría la mascota con id {mascota.IdMascota}.";
            return RedirectToAction(nameof(Index));
        }
    }
}