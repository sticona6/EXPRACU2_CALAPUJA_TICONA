using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EXPRACU2_CALAPUJA_TICONA.Models;

namespace EXPRACU2_CALAPUJA_TICONA.Controllers
{
    public class AsistenciaController : Controller
    {
        private Control_Horario control_horario = new Control_Horario();
        private Personal personal = new Personal();
        // GET: Asistencia
        public ActionResult Index(string criterio)
        {

            if (criterio == null || criterio == "")
            {
                return View(control_horario.Listar());
            }
            else
            {
                return View(control_horario.Buscar(criterio));
            }

            return View();
        }
        //action ver
        public ActionResult Ver(int id)
        {
            return View(control_horario.Obtener(id));
        }

        public ActionResult Buscar(string criterio)
        {
            return View(
                criterio == null || criterio == "" ? control_horario.Listar()
                : control_horario.Buscar(criterio)
                );
        }

        //accion agregar editar

        public ActionResult Agregar_Editar(int id = 0)
        {
            ViewBag.Personal = personal.Listar();
            
            return View(

                    id == 0 ? new Control_Horario() //para asiganar una categoria nueva
                            : control_horario.Obtener(id)

                );
        }

        //Guardar
        public ActionResult Guardar(Control_Horario control_horario1)
        {
            //ViewBag.Personal = Personal.Listar();
            //ViewBag.Tipo_Pago_Prestamo = Tipo_Pago_Prestamo.Listar();
            if (ModelState.IsValid)
            {
                control_horario1.Guardar();
                return Redirect("~/Asistencia");
            }
            else
            {
                return View("~/Views/Asistencia/Agregar_Editar.cshtml", control_horario1);
            }

        }
        //accion eliminar
        public ActionResult Eliminar(int id)
        {
            control_horario.id_horario = id;
            control_horario.Eliminar();
            return Redirect("~/control_horario");

        }
    }
}