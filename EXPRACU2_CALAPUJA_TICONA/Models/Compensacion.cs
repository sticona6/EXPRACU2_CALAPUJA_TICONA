namespace EXPRACU2_CALAPUJA_TICONA.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Compensacion")]
    public partial class Compensacion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_compensacion { get; set; }

        [StringLength(150)]
        public string motivo { get; set; }

        public DateTime fecha { get; set; }

        [Required]
        [StringLength(18)]
        public string id_tipo_compensacion { get; set; }

        public int? id_personal { get; set; }

        public virtual Personal Personal { get; set; }

        public virtual Tipo_Compensacion Tipo_Compensacion { get; set; }
    }
}
