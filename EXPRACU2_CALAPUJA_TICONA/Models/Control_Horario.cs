namespace EXPRACU2_CALAPUJA_TICONA.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Control_Horario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Control_Horario()
        {
            Personal = new HashSet<Personal>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_horario { get; set; }

        public DateTime hora_entrada { get; set; }

        public DateTime? hora_salida { get; set; }

        public DateTime? horas_normales { get; set; }

        public DateTime? horas_extras { get; set; }

        public DateTime? horas_totales { get; set; }

        public DateTime? horas_incompletas { get; set; }

        public DateTime fecha_hora { get; set; }

        public DateTime? id_permiso { get; set; }

        public int? conte_horas_extras { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Personal> Personal { get; set; }
    }
}
