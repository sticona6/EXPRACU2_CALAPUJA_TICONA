namespace EXPRACU2_CALAPUJA_TICONA.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Personal")]
    public partial class Personal
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Personal()
        {
            Asingacion_Escolar = new HashSet<Asingacion_Escolar>();
            Compensacion = new HashSet<Compensacion>();
            Prestamo = new HashSet<Prestamo>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_personal { get; set; }

        [StringLength(100)]
        public string nombres_personal { get; set; }

        [StringLength(100)]
        public string apellidos_personal { get; set; }

        [StringLength(8)]
        public string DNI_personal { get; set; }

        [StringLength(100)]
        public string direccion_personal { get; set; }

        [StringLength(1)]
        public string tipo_personal { get; set; }

        public DateTime? fecha_nacimiento { get; set; }

        public int? id_horario { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Asingacion_Escolar> Asingacion_Escolar { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Compensacion> Compensacion { get; set; }

        public virtual Control_Horario Control_Horario { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Prestamo> Prestamo { get; set; }
    }
}
