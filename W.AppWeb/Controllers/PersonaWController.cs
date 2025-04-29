using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rotativa.AspNetCore;
using System.Threading.Tasks;
using W.BL;
using W.EN;
using W.DAL;

namespace W.AppWeb.Controllers
{
    public class PersonaWController : Controller
    {
        private readonly PersonaWBL _personawBL;
        public PersonaWController(PersonaWBL pPersonaWBl)
        {
            _personawBL = pPersonaWBl;
        }
        // GET: PersonaWController
        public async Task<ActionResult> Index()
        {
            var personasw = await _personawBL.ObtenerTodosAsync();
            return View(personasw);
        }

        // GET: PersonaWController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PersonaWController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PersonaWController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(PersonaW pPersonaW)
        {
            try
            {
                await _personawBL.CrearAsync(pPersonaW);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PersonaWController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var personaw = await _personawBL.ObtenerPorIdAsync(new PersonaW { Id = id });
            return View(personaw);
        }

        // POST: PersonaWController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(PersonaW pPersonaW)
        {
            try
            {
                await _personawBL.ModificarAsync(pPersonaW);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PersonaWController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var personaw = await _personawBL.ObtenerPorIdAsync(new PersonaW { Id = id });
            return View(personaw);
        }

        // POST: PersonaWController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(PersonaW pPersonaW)
        {
            try
            {
                await _personawBL.EliminarAsync(new PersonaW { Id = pPersonaW.Id });
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        //aqui 
        [HttpGet]
        public async Task<ActionResult> Index(string nombre, string apellido)
        {
            // Si no hay parámetros de búsqueda, mostrar todos
            if (string.IsNullOrEmpty(nombre) && string.IsNullOrEmpty(apellido))
            {
                var todos = await _personawBL.ObtenerTodosAsync();
                return View(todos);
            }

            // Búsqueda filtrada
            var resultados = await _personawBL.BuscarPorNombreApellidoAsync(nombre, apellido);
            return View(resultados);
        }
    }
}
