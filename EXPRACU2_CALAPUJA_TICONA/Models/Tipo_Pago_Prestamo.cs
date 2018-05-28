namespace EXPRACU2_CALAPUJA_TICONA.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

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
    }
}
