namespace EXPRACU2_CALAPUJA_TICONA.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    using System.Linq;
    using System.Data.Entity;

    [Table("Personal")]
    public partial class Personal
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Personal()
        {
            Asingacion_Escolar = new HashSet<Asingacion_Escolar>();
            Compensacion = new HashSet<Compensacion>();
            Control_Horario = new HashSet<Control_Horario>();
            Prestamo = new HashSet<Prestamo>();
        }

        [Key]
        public int id_personal { get; set; }

        [StringLength(100)]
        public string nombres_personal { get; set; }

        [StringLength(100)]
        public string apellidos_personal { get; set; }

        [StringLength(8)]
        public string DNI_personal { get; set; }

        [StringLength(100)]
        public string direccion_personal { get; set; }

        [StringLength(50)]
        public string tipo_personal { get; set; }

        public DateTime? fecha_nacimiento { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Asingacion_Escolar> Asingacion_Escolar { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Compensacion> Compensacion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Control_Horario> Control_Horario { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Prestamo> Prestamo { get; set; }

        //Crear el metodo Listar

        public List<Personal> Listar() //retorna una colleccion
        {
            var persona = new List<Personal>();
            try
            {
                //coneccion a la fuente de datos
                using (var db = new Model_Personal())
                {
                    persona = db.Personal.ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return persona;
        }
        //Metodo obtener 
        public Personal Obtener(int id)//retorna un solo objeto
        {
            var persona = new Personal();
            try
            {
                using (var db = new Model_Personal())
                {
                    persona = db.Personal.Where(x => x.id_personal == id)
                        .SingleOrDefault();
                }
            }
            catch (Exception ex)
            {

                throw;
            }

            return persona;
        }
        //Metodo Buscar
        public List<Personal> Buscar(string criterio)//retorna un solo objeto
        {
            var persona = new List<Personal>();
            try
            {
                using (var db = new Model_Personal())
                {
                    persona = db.Personal
                                .Where(x => x.nombres_personal.Contains(criterio) ||
                                       x.apellidos_personal.Contains(criterio))
                                       .ToList();
                }
            }
            catch (Exception ex)
            {

                throw;
            }

            return persona;
        }
        //Metodo guardar
        public void Guardar()
        {
            try
            {
                using (var db = new Model_Personal())
                {
                    if (this.id_personal > 0)//cuando la llave primaria es identity solamante
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
        //Metodo eliminar
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
