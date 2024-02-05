//using ArquitecturaG1.DAO;
using ArquitecturaG1.Models;
using ArquitecturaG1.Models.AbstractFactory;
using ArquitecturaG1.Models.DAO;
using ArquitecturaG1.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ArquitecturaG1.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDatabaseFactory _databaseFactory;

        public HomeController(IDatabaseFactory databaseFactory)
        {
            _databaseFactory = databaseFactory;
        }

        // Vista principal
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Paises()
        {
            return View();
        }


        [HttpPost]
        public IActionResult BuscarPaises(string nombrePais)
        {
            var listaPaises = new List<PaisesDto>();
            PaisesDao paisesDao = null;

            try
            {
                paisesDao = (PaisesDao)_databaseFactory.CreatePaisesDao();
                listaPaises = paisesDao.VerPaises(nombrePais);

                // Pasa la lista de países a la vista usando ViewData
                ViewData["ListaPaises"] = listaPaises;

                // Puedes redirigir a la vista deseada o devolver la vista directamente
                return View("Index");
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción que pueda ocurrir durante la búsqueda
                ViewBag.ErrorMessage = ex.Message;
                return View("Index"); // Devolver la vista con el mensaje de error
            }
            finally
            {
                // Asignar null para liberar la referencia al objeto PaisesDao
                paisesDao = null;
            }
        }



    }
}
