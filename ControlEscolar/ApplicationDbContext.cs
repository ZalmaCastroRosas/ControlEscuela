using System.Data.Entity;

namespace ControlEscolar.Models
{
    public class ApplicationDbContext : DbContext
    {
        // Constructor que usa la cadena de conexión por defecto
        public ApplicationDbContext()
         : base(@"Data Source=HP\SQLEXPRESS;Initial Catalog=EscuelaDB;Integrated Security=True")
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Alumno>().ToTable("Alumnos");
            modelBuilder.Entity<Carrera>().ToTable("Carreras");
            modelBuilder.Entity<Pago>().ToTable("Pagos");

        }

        public DbSet<Carrera> Carreras { get; set; }
        public DbSet<Alumno> Alumnos { get; set; }
        public DbSet<Pago> Pagos { get; set; }
        public DbSet<ConceptoPago> ConceptosPago { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

    }
}
