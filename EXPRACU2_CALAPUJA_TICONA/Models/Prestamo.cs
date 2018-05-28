namespace EXPRACU2_CALAPUJA_TICONA.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    using System.Linq;
    using System.Data.Entity;

    [Table("Prestamo")]
    public partial class Prestamo
    {
        [Key]
        public int id_prestamo { get; set; }

        [StringLength(250)]
        public string razon { get; set; }

        [StringLength(200)]
        public string descripcion { get; set; }

        public decimal? monto { get; set; }

        public DateTime? fecha_prestamo { get; set; }

        public DateTime? fecha_pago { get; set; }

        public int? id_tipo_pago_prestamo { get; set; }

        public int? id_personal { get; set; }

        public virtual Personal Personal { get; set; }

        public virtual Tipo_Pago_Prestamo Tipo_Pago_Prestamo { get; set; }




        //crear el metodo listado
        public List<Prestamo> Listar()//retornar una collection
        {
            var prestamo = new List<Prestamo>();

            try
            {
                //conexion con la mfuente de datos
                using (var db = new Model_Personal())
                {
                    prestamo = db.Prestamo.Include("Personal").Include("Tipo_Pago_Prestamo").ToList();
                }

            }
            catch (Exception ex)
            {
                throw;
            }
            return prestamo;
        }

        //mnetodo obtener
        public Prestamo Obtener(int id)//retorna un solo objeto
        {
            var prestamo = new Prestamo();

            try
            {
                //conexion con la mfuente de datos
                using (var db = new Model_Personal())
                {
                    prestamo = db.Prestamo.Include("Personal").Include("Tipo_Pago_Prestamo")
                        .Where(x => x.id_prestamo == id)
                        .SingleOrDefault();
                }

            }
            catch (Exception ex)
            {
                throw;
            }
            return prestamo;
        }


        //crear el metodo Buscar
        public List<Prestamo> Buscar(string criterio)//retornar una collection
        {
            var prestamo = new List<Prestamo>();
            

            try
            {
                //conexion con la mfuente de datos
                using (var db = new Model_Personal())
                {

                    prestamo = db.Prestamo.Include("Personal")
                        .Where(x => x.Personal.apellidos_personal.Contains(criterio))
                                    .ToList();
                }

            }
            catch (Exception ex)
            {
                throw;
            }
            return prestamo;
        }

        //metodo guardar
        public void Guardar()
        {
            try
            {
                using (var db = new Model_Personal())
                {
                    if (this.id_prestamo > 0)
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
