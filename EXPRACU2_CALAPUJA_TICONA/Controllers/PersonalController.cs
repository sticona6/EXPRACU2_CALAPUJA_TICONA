using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using EXPRACU2_CALAPUJA_TICONA.Models;

namespace EXPRACU2_CALAPUJA_TICONA.Controllers
{
    public class PersonalController : Controller
    {
        private Personal personal = new Personal();
        // GET: Personal
        public ActionResult Index(string criterio)
        {
            if (criterio == null || criterio == "")
            {
                return View(personal.Listar());
            }
            else
            {
                return View(personal.Buscar(criterio));
            }
        }

        //Accion Ver
        public ActionResult Ver(int id)
        {
            return View(personal.Obtener(id));
        }
        //Accion Buscar
        public ActionResult Buscar(string criterio)
        {
            return View(
                criterio == null || criterio == ""
                ? personal.Listar()
                : personal.Buscar(criterio)
                );
        }
        //Accion AgregarEditar
        public ActionResult AgregarEditar(int id = 0)
        {
            return View(
                    id == 0 ? new Personal() // Sirve para agregar una categoria nueva
                            : personal.Obtener(id)//devuelve un objeto
                );
        }
        //Accion Guardar
        public ActionResult Guardar(Personal persona)
        {
            if (ModelState.IsValid)
            {
                persona.Guardar();
                return Redirect("~/Personal");
            }
            else
            {
                return View("~/Views/Personal/AgregarEditar.cshtml", persona);
            }
        }
        //Accion eliminar
        public ActionResult Eliminar(int id)
        {
            personal.id_personal = id;
            personal.Eliminar();
            return Redirect("~/Personal");
        }

    }
}