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

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AutocompleteSearch(string term)
        {
            var paisesDao = _databaseFactory.CreatePaisesDao();
            var paises = paisesDao.BuscarPaisesPorNombreParcial(term);
            return Json(paises.Select(p => p.Name).ToList());
        }

        [HttpPost]
        public IActionResult BuscarIdiomasPorPais(string nombrePais)
        {
            var idiomasDao = _databaseFactory.CreateIdiomasDao();
            var idiomas = idiomasDao.VerIdiomasPorCodigoPais(nombrePais); // Suponiendo que este método exista
            return Json(idiomas);
        }
    }
}
