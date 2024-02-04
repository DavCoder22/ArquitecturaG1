using Microsoft.AspNetCore.Mvc;
using ArquitecturaG1.DAO;
using ArquitecturaG1.Modelos;
using System.Collections.Generic;
using System.Linq;

namespace ArquitecturaG1.Controladores
{
    public class EstadisticaController : Controller
    {
        private readonly PaisDAO _paisDAO;
        private readonly EstadisticaIdiomaDAO _estadisticaIdiomaDAO;

        public EstadisticaController(PaisDAO paisDAO, EstadisticaIdiomaDAO estadisticaIdiomaDAO)
        {
            _paisDAO = paisDAO;
            _estadisticaIdiomaDAO = estadisticaIdiomaDAO;
        }

        public IActionResult Index()
        {
            // Obtener lista de países para la vista
            var paises = _paisDAO.ObtenerTodos();
            return View(paises);
        }

        public IActionResult VerEstadisticas(int paisId, string tipoGrafico = "barras")
        {
            // Obtener estadísticas del idioma para el país seleccionado
            var estadisticas = _estadisticaIdiomaDAO.ObtenerPorPais(paisId);

            // Pasar el tipo de gráfico a la vista para decidir qué gráfico mostrar
            ViewBag.TipoGrafico = tipoGrafico;

            return View("Estadisticas", estadisticas);
        }

        // Métodos adicionales según sea necesario
    }
}