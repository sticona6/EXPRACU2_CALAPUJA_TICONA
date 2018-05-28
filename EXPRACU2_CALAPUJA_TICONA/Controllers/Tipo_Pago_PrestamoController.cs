using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EXPRACU2_CALAPUJA_TICONA.Models;

namespace EXPRACU2_CALAPUJA_TICONA.Controllers
{
    public class Tipo_Pago_PrestamoController : Controller
    {
        private Tipo_Pago_Prestamo Tipo_Pago_Prestamo = new Tipo_Pago_Prestamo();
        // GET: Tipo_Pago_Prestamo
        public ActionResult Index(string criterio)
        {

            if (criterio == null || criterio == "")
            {
                return View(Tipo_Pago_Prestamo.Listar());
            }
            else
            {
                return View(Tipo_Pago_Prestamo.Buscar(criterio));
            }

            return View();
        }
        //action ver
        public ActionResult Ver(int id)
        {
            return View(Tipo_Pago_Prestamo.Obtener(id));
        }

        public ActionResult Buscar(string criterio)
        {
            return View(
                criterio == null || criterio == "" ? Tipo_Pago_Prestamo.Listar()
                : Tipo_Pago_Prestamo.Buscar(criterio)
                );
        }

        //accion agregar editar

        public ActionResult Agregar_Editar(int id = 0)
        {
            // ViewBag.Personal = Personal.Listar();
            return View(

                    id == 0 ? new Tipo_Pago_Prestamo() //para asiganar una categoria nueva
                            : Tipo_Pago_Prestamo.Obtener(id)

                );
        }

        //Guardar
        public ActionResult Guardar(Tipo_Pago_Prestamo prestamo)
        {

            if (ModelState.IsValid)
            {
                prestamo.Guardar();
                return Redirect("~/Tipo_Pago_Prestamo");
            }
            else
            {
                return View("~/Views/Tipo_Pago_Prestamo/Agregar_Editar.cshtml", prestamo);
            }

        }
        //accion eliminar
        public ActionResult Eliminar(int id)
        {
            Tipo_Pago_Prestamo.id_tipo_pago_prestamo = id;
            Tipo_Pago_Prestamo.Eliminar();
            return Redirect("~/Tipo_Pago_Prestamo");

        }
    }
}