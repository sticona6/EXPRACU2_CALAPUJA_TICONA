namespace EXPRACU2_CALAPUJA_TICONA.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;
    using System.Data.Entity;
    public partial class Control_Horario
    {
        [Key]
        public int id_horario { get; set; }

        public DateTime hora_entrada { get; set; }

        public DateTime? hora_salida { get; set; }

        public DateTime? horas_normales { get; set; }

        public DateTime? horas_extras { get; set; }

        public DateTime? horas_totales { get; set; }

        public DateTime? horas_incompletas { get; set; }

        public DateTime fecha_hora { get; set; }

        public DateTime? id_permiso { get; set; }

        public int? conte_horas_extras { get; set; }

        public int? id_personal { get; set; }

        public virtual Personal Personal { get; set; }


        //crear el metodo listado
        public List<Control_Horario> Listar()//retornar una collection
        {
            var control_horario = new List<Control_Horario>();

            try
            {
                //conexion con la mfuente de datos
                using (var db = new Model_Personal())
                {
                    control_horario = db.Control_Horario.Include("Personal").ToList();
                }

            }
            catch (Exception ex)
            {
                throw;
            }
            return control_horario;
        }

        //mnetodo obtener
        public Control_Horario Obtener(int id)//retorna un solo objeto
        {
            var control_horario = new Control_Horario();

            try
            {
                //conexion con la mfuente de datos
                using (var db = new Model_Personal())
                {
                    control_horario = db.Control_Horario.Include("Personal")
                        .Where(x => x.id_horario == id)
                        .SingleOrDefault();
                }

            }
            catch (Exception ex)
            {
                throw;
            }
            return control_horario;
        }


        //crear el metodo Buscar
        public List<Control_Horario> Buscar(string criterio)//retornar una collection
        {
            var control_horario = new List<Control_Horario>();


            try
            {
                //conexion con la mfuente de datos
                using (var db = new Model_Personal())
                {

                    control_horario = db.Control_Horario.Include("Personal")
                        .Where(x => x.Personal.apellidos_personal.Contains(criterio))
                                    .ToList();
                }

            }
            catch (Exception ex)
            {
                throw;
            }
            return control_horario;
        }

        //metodo guardar
        public void Guardar()
        {
            try
            {
                using (var db = new Model_Personal())
                {
                    if (this.id_horario > 0)
                    {
                        db.Entry(this).State = EntityState.Modified;
                    }
                    else
                    {
                        db.Entry(this).State = EntityState.Added;
                    }
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //metodo eliminar
        public void Eliminar()
        {
            try
            {
                using (var db = new Model_Personal())
                {
                    db.Entry(this).State = EntityState.Deleted;
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
