using HomeCare.Models;
using Microsoft.EntityFrameworkCore;
namespace HomeCare.Data
{

    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(
        DbContextOptions<ApplicationDBContext> dbContextOptions)
        : base(dbContextOptions)
        {
        }

        public DbSet<Patients> Patients { get; set; }
        public DbSet<CareGivers> CareGivers { get; set; }
        public DbSet<PatientCareGiver> PatientCareGivers {  get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PatientCareGiver>()
                .HasKey(pc => new { pc.PatientId, pc.CareGiverId });

            modelBuilder.Entity<PatientCareGiver>()
                .HasOne(pc => pc.Patient)
                .WithMany()
                .HasForeignKey(pc => pc.PatientId);

            modelBuilder.Entity<PatientCareGiver>()
                .HasOne(pc => pc.CareGiver)
                .WithMany()
                .HasForeignKey(pc => pc.CareGiverId);
        }
    }
}