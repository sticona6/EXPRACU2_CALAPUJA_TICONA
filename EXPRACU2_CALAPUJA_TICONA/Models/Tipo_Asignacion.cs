namespace EXPRACU2_CALAPUJA_TICONA.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tipo_Asignacion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tipo_Asignacion()
        {
            Asingacion_Escolar = new HashSet<Asingacion_Escolar>();
        }

        [Key]
        public int id_tipo_asignacion { get; set; }

        [StringLength(50)]
        public string discapacidad { get; set; }

        public decimal? monto_mensual { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Asingacion_Escolar> Asingacion_Escolar { get; set; }
    }
}
