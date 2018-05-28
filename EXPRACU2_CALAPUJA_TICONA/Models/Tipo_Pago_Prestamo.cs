namespace EXPRACU2_CALAPUJA_TICONA.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;
    using System.Data.Entity;

    public partial class Tipo_Pago_Prestamo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tipo_Pago_Prestamo()
        {
            Prestamo = new HashSet<Prestamo>();
        }

        [Required]
        [StringLength(100)]
        public string nombre_tipo_pago { get; set; }

        public int? interes { get; set; }

        public DateTime? fecha_utlimo_dia_pago { get; set; }

        public int? morosidad { get; set; }

        [Key]
        public int id_tipo_pago_prestamo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Prestamo> Prestamo { get; set; }





        //crear el metodo listado
        public List<Tipo_Pago_Prestamo> Listar()//retornar una collection
        {
            var tipo_pago_Prestamo = new List<Tipo_Pago_Prestamo>();

            try
            {
                //conexion con la mfuente de datos
                using (var db = new Model_Personal())
                {
                    tipo_pago_Prestamo = db.Tipo_Pago_Prestamo.ToList();
                }

            }
            catch (Exception ex)
            {
                throw;
            }
            return tipo_pago_Prestamo;
        }

        //mnetodo obtener
        public Tipo_Pago_Prestamo Obtener(int id)//retorna un solo objeto
        {
            var tipo_pago_prestamo = new Tipo_Pago_Prestamo();

            try
            {
                //conexion con la mfuente de datos
                using (var db = new Model_Personal())
                {
                    tipo_pago_prestamo = db.Tipo_Pago_Prestamo
                        .Where(x => x.id_tipo_pago_prestamo == id)
                        .SingleOrDefault();
                }

            }
            catch (Exception ex)
            {
                throw;
            }
            return tipo_pago_prestamo;
        }


        //crear el metodo Buscar
        public List<Tipo_Pago_Prestamo> Buscar(string criterio)//retornar una collection
        {
            var tipo_pago_prestamo = new List<Tipo_Pago_Prestamo>();

            try
            {
                //conexion con la mfuente de datos
                using (var db = new Model_Personal())
                {

                    tipo_pago_prestamo = db.Tipo_Pago_Prestamo
                        .Where(x => x.nombre_tipo_pago.Contains(criterio))
                                    .ToList();
                }

            }
            catch (Exception ex)
            {
                throw;
            }
            return tipo_pago_prestamo;
        }

        //metodo guardar
        public void Guardar()
        {
            try
            {
                using (var db = new Model_Personal())
                {
                    if (this.id_tipo_pago_prestamo > 0)
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
