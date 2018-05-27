namespace EXPRACU2_CALAPUJA_TICONA.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Permiso")]
    public partial class Permiso
    {
        [Key]
        public int id_permiso { get; set; }

        public DateTime? fecha_permiso { get; set; }

        public DateTime? fecha_solicitud { get; set; }

        [StringLength(1)]
        public string gose_salario { get; set; }

        public int? id_personal { get; set; }

        [StringLength(50)]
        public string tipo_personal { get; set; }

        public int? numero_permiso { get; set; }

        [StringLength(1)]
        public string estado_permiso { get; set; }

        [StringLength(1)]
        public string tipo_permisos { get; set; }

        [StringLength(250)]
        public string motivo { get; set; }

        [StringLength(250)]
        public string obervacion { get; set; }

        public int? id_tipo_licencia { get; set; }

        public virtual tipo_Licencia tipo_Licencia { get; set; }
    }
}
