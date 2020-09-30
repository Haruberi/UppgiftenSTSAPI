using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UppgiftenSTSAPI.Entities;

namespace UppgiftenSTSAPI.Context
{
    public class STSApplicationDBContext : DbContext
    {
        public DbSet<Student> students { get; set; }
        public DbSet<Seminar> seminars { get; set; }
        public DbSet<Paymentmethod> paymentmethods { get; set; }
        public DbSet<StudentSeminar> studentSeminars { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=UppgiftenSTSAPIDatabas;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //one-to-one mellan payment och seminar
            modelBuilder.Entity<Paymentmethod>()
                .HasOne<Seminar>(o => o.seminar)
                .WithOne(c => c.Paymentmethod)
                .HasForeignKey<Seminar>(c => c.SeminarOfPaymentmethodId);

            //many-to-many mellan student och seminar 
            modelBuilder.Entity<StudentSeminar>().HasKey(sc => new { sc.studentId, sc.seminarId });

        }
    }
}
