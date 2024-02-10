using ArquitecturaG1.Models;
using ArquitecturaG1.Models.AbstractFactory;
using ArquitecturaG1.Models.DAO;
using ArquitecturaG1.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ArquitecturaG1.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDatabaseFactory _databaseFactory;

        public HomeController(IDatabaseFactory databaseFactory)
        {
            _databaseFactory = databaseFactory;
        }

        // Acción para devolver la vista principal
        public IActionResult Index()
        {
            return View();
        }

       // Este método utiliza el Abstract Factory para obtener los idiomas de un país
       //[HttpPost]
        public IActionResult BuscarIdiomasPorPais(string nombrePais)
        {
            var paisesDao = _databaseFactory.CreatePaisesDao();
            var pais = paisesDao.BuscarPaisesPorNombreParcial(nombrePais).FirstOrDefault();

            if (pais != null)
            {
                var idiomasDao = _databaseFactory.CreateIdiomasDao();
                var idiomas = idiomasDao.VerIdiomasPorCodigoPais(pais.Code);
                return Json(idiomas);
            }

            return Json(new List<IdiomasDto>()); // Devuelve una lista vacía si no se encuentra el país
        }


        // Este método podría ser para el autocompletado de nombres de países
        [HttpGet]
        public IActionResult AutocompleteSearch(string term)
        {
            var paisesDao = _databaseFactory.CreatePaisesDao();
            var paises = paisesDao.BuscarPaisesPorNombreParcial(term);
            return Json(paises.Select(p => new { label = p.Name, value = p.Code }));
        }
    }
}
