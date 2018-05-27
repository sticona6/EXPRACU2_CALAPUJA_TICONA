namespace EXPRACU2_CALAPUJA_TICONA.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Asingacion_Escolar
    {
        [Key]
        public int id_asignacion_escolar { get; set; }

        public int numero_hijos { get; set; }

        public decimal monto_total { get; set; }

        public int id_tipo_asignacion { get; set; }

        [StringLength(100)]
        public string descripcion { get; set; }

        [StringLength(18)]
        public string fecha_emision { get; set; }

        public int? id_personal { get; set; }

        public virtual Personal Personal { get; set; }

        public virtual Tipo_Asignacion Tipo_Asignacion { get; set; }
    }
}
