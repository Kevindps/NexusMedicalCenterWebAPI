using Microsoft.EntityFrameworkCore;

namespace WebAPI.Models
{
    public class NexosMedicalCenterContext : DbContext
    {
        public NexosMedicalCenterContext(DbContextOptions<NexosMedicalCenterContext> options) : base(options) { }

        public DbSet<NexosMedicalCenterDoctor> Doctors { get; set; }
        public DbSet<NexosMedicalCenterPatient> Patients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NexosMedicalCenterDoctor>()
                .HasIndex(d => d.DoctorCredentialNumber)
                .IsUnique();

            modelBuilder.Entity<NexosMedicalCenterPatient>()
                .HasIndex(p => p.PatientSocialSecurityNumber)
                .IsUnique();
        }
    }
}
