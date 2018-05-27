namespace EXPRACU2_CALAPUJA_TICONA.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

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
    }
}
