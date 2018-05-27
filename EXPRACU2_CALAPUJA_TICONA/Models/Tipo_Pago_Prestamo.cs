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

        [StringLength(18)]
        public string nombre_tipo_pago { get; set; }

        [StringLength(18)]
        public string interes { get; set; }

        [StringLength(18)]
        public string fecha_utlimo_dia_pago { get; set; }

        [StringLength(18)]
        public string morosidad { get; set; }

        [Key]
        [StringLength(18)]
        public string id_tipo_pago_prestamo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Prestamo> Prestamo { get; set; }
    }
}
