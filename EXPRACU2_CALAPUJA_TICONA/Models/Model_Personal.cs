namespace EXPRACU2_CALAPUJA_TICONA.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model_Personal : DbContext
    {
        public Model_Personal()
            : base("name=Model_Personal4")
        {
        }

        public virtual DbSet<Asingacion_Escolar> Asingacion_Escolar { get; set; }
        public virtual DbSet<Compensacion> Compensacion { get; set; }
        public virtual DbSet<Control_Horario> Control_Horario { get; set; }
        public virtual DbSet<Permiso> Permiso { get; set; }
        public virtual DbSet<Personal> Personal { get; set; }
        public virtual DbSet<Prestamo> Prestamo { get; set; }
        public virtual DbSet<Tipo_Asignacion> Tipo_Asignacion { get; set; }
        public virtual DbSet<Tipo_Compensacion> Tipo_Compensacion { get; set; }
        public virtual DbSet<tipo_Licencia> tipo_Licencia { get; set; }
        public virtual DbSet<Tipo_Pago_Prestamo> Tipo_Pago_Prestamo { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Asingacion_Escolar>()
                .Property(e => e.monto_total)
                .HasPrecision(5, 2);

            modelBuilder.Entity<Asingacion_Escolar>()
                .Property(e => e.descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Compensacion>()
                .Property(e => e.motivo)
                .IsUnicode(false);

            modelBuilder.Entity<Permiso>()
                .Property(e => e.gose_salario)
                .IsUnicode(false);

            modelBuilder.Entity<Permiso>()
                .Property(e => e.tipo_personal)
                .IsUnicode(false);

            modelBuilder.Entity<Permiso>()
                .Property(e => e.estado_permiso)
                .IsUnicode(false);

            modelBuilder.Entity<Permiso>()
                .Property(e => e.tipo_permisos)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Permiso>()
                .Property(e => e.motivo)
                .IsUnicode(false);

            modelBuilder.Entity<Permiso>()
                .Property(e => e.obervacion)
                .IsUnicode(false);

            modelBuilder.Entity<Personal>()
                .Property(e => e.nombres_personal)
                .IsUnicode(false);

            modelBuilder.Entity<Personal>()
                .Property(e => e.apellidos_personal)
                .IsUnicode(false);

            modelBuilder.Entity<Personal>()
                .Property(e => e.DNI_personal)
                .IsUnicode(false);

            modelBuilder.Entity<Personal>()
                .Property(e => e.direccion_personal)
                .IsUnicode(false);

            modelBuilder.Entity<Personal>()
                .Property(e => e.tipo_personal)
                .IsUnicode(false);

            modelBuilder.Entity<Prestamo>()
                .Property(e => e.razon)
                .IsUnicode(false);

            modelBuilder.Entity<Prestamo>()
                .Property(e => e.descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Prestamo>()
                .Property(e => e.monto)
                .HasPrecision(6, 2);

            modelBuilder.Entity<Tipo_Asignacion>()
                .Property(e => e.discapacidad)
                .IsUnicode(false);

            modelBuilder.Entity<Tipo_Asignacion>()
                .Property(e => e.monto_mensual)
                .HasPrecision(5, 2);

            modelBuilder.Entity<Tipo_Asignacion>()
                .HasMany(e => e.Asingacion_Escolar)
                .WithRequired(e => e.Tipo_Asignacion)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tipo_Compensacion>()
                .Property(e => e.tipo)
                .IsUnicode(false);

            modelBuilder.Entity<Tipo_Compensacion>()
                .Property(e => e.monto_compensacion)
                .HasPrecision(5, 2);

            modelBuilder.Entity<tipo_Licencia>()
                .Property(e => e.tipo)
                .IsUnicode(false);

            modelBuilder.Entity<tipo_Licencia>()
                .Property(e => e.descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Tipo_Pago_Prestamo>()
                .Property(e => e.nombre_tipo_pago)
                .IsUnicode(false);
        }
    }
}
