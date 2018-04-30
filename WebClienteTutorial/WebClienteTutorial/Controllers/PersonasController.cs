using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebClienteTutorial.Models;

namespace WebClienteTutorial.Controllers
{
    public class PersonasController : Controller
    {
        ModeloPersona modelo;

        public PersonasController()
        {
            modelo = new ModeloPersona();
        }

        // GET: Personas
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> Personas()
        {
            List<Persona> personas = await modelo.GetPersonas();

            return View(personas);
        }

        public async Task<ActionResult> DetallesPersona(int id)
        {
            Persona persona = await modelo.BuscarPersona(id);

            return View(persona);
        }
    }
}