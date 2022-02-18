using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SistemaBodegaG1.Controllers
{
    public class ClientesController : Controller
    {
        private BodegasWS.BodegaBCServiceClient proxy = new BodegasWS.BodegaBCServiceClient();
        // GET: Clientes
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include ="codCliente, nombre, direccion, referencia, telefono, email")]
        SistemaBodegaG1.BodegasWS.Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                proxy.CrearCliente(cliente);
                return RedirectToAction("EncontarBod");
            }
            return View(cliente);
        }

        public ActionResult Edit(string CodCliente)
        {
            if (CodCliente == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BodegasWS.Cliente cliente = proxy.ObtenerCliente(CodCliente);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            ViewData["Message"] = "Datos del Cliente";
            ViewBag.Cliente = cliente;
            return View(cliente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include ="codCliente, nombre, direccion, referencia, telefono, email")]
        SistemaBodegaG1.BodegasWS.Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                proxy.Modificarcliente(cliente);
                return RedirectToAction("Index");
            }
            return View(cliente);
        }
    }
}