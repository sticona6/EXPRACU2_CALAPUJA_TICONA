namespace EXPRACU2_CALAPUJA_TICONA.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tipo_Compensacion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tipo_Compensacion()
        {
            Compensacion = new HashSet<Compensacion>();
        }

        [Key]
        [StringLength(18)]
        public string id_tipo_compensacion { get; set; }

        [Required]
        [StringLength(50)]
        public string tipo { get; set; }

        public decimal monto_compensacion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Compensacion> Compensacion { get; set; }
    }
}
