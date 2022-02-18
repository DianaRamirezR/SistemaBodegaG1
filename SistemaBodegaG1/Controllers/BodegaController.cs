using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaBodegaG1.Controllers
{
    public class BodegaController : Controller
    {
        private BodegasWS.BodegaBCServiceClient proxy = new BodegasWS.BodegaBCServiceClient();
        // GET: Bodega
        public ActionResult EncontrarBod()
        {
            BodegasWS.Bodega[] bodegasUbicadas = proxy.ListarBodegas();
            ViewData["Message"] = "Listado de Bodegas Cercanas";
            ViewBag.Titulo1 = "Codigo Bodega";
            ViewBag.Titulo2 = "Nombre de la Bodega";
            ViewBag.Titulo3 = "Direccion de la Bodega";
            ViewBag.Titulo4 = "Contacto de la Bodega";
            ViewBag.Titulo5 = "Telefono de la Bodega";
            ViewBag.Titulo6 = "Opción";
            return View(bodegasUbicadas);
        }
    }
}