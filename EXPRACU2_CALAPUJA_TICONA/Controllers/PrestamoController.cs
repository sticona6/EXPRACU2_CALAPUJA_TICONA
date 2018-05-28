using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EXPRACU2_CALAPUJA_TICONA.Models;

namespace EXPRACU2_CALAPUJA_TICONA.Controllers
{
    public class PrestamoController : Controller
    {
        private Personal Personal = new Personal();
        private Prestamo Prestamo = new Prestamo();
        private Tipo_Pago_Prestamo Tipo_Pago_Prestamo = new Tipo_Pago_Prestamo();
        // GET: Prestamo
        public ActionResult Index(string criterio)
        {

            if (criterio == null || criterio == "")
            {
                return View(Prestamo.Listar());
            }
            else
            {
                return View(Prestamo.Buscar(criterio));
            }

            return View();
        }
        //action ver
        public ActionResult Ver(int id)
        {
            return View(Prestamo.Obtener(id));
        }

        public ActionResult Buscar(string criterio)
        {
            return View(
                criterio == null || criterio == "" ? Prestamo.Listar()
                : Prestamo.Buscar(criterio)
                );
        }

        //accion agregar editar

        public ActionResult Agregar_Editar(int id = 0)
        {
            ViewBag.Personal = Personal.Listar();
            ViewBag.Tipo_Pago_Prestamo = Tipo_Pago_Prestamo.Listar();
            return View(

                    id == 0 ? new Prestamo() //para asiganar una categoria nueva
                            : Prestamo.Obtener(id)

                );
        }

        //Guardar
        public ActionResult Guardar(Prestamo prestamo)
        {
            ViewBag.Personal = Personal.Listar();
            ViewBag.Tipo_Pago_Prestamo = Tipo_Pago_Prestamo.Listar();
            if (ModelState.IsValid)
            {
                prestamo.Guardar();
                return Redirect("~/Prestamo");
            }
            else
            {
                return View("~/Views/Prestamo/Agregar_Editar.cshtml", prestamo);
            }

        }
        //accion eliminar
        public ActionResult Eliminar(int id)
        {
            Prestamo.id_prestamo = id;
            Prestamo.Eliminar();
            return Redirect("~/Prestamo");

        }
    }
}