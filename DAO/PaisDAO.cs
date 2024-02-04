using ArquitecturaG1.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

/*namespace ArquitecturaG1.DAO
{
    public class PaisDAO : Controller
    {
        // GET: p1
        public ActionResult Index()
        {
            return View();
        }

        // GET: p1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: p1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: p1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: p1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: p1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: p1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: p1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}*/
using System.Collections.Generic;

public class PaisDAO
{
    public static List<PaisDTO> ObtenerPaises()
    {
        return new List<PaisDTO>
        {
            new PaisDTO { Id = 1, Nombre = "País A" },
            new PaisDTO { Id = 2, Nombre = "País B" }
            // Agrega más países según necesites
        };
    }
}

