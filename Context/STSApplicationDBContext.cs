using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UppgiftenSTSAPI.Context
{
    public class STSApplicationDBContext : DbContext
    {
        public DbSet<Student> students { get; set; }
        public DbSet<Seminar> seminars { get; set; }
        public DbSet<Paymentmethod> paymentmethods { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=UppgiftenSTSAPIDatabas;Trusted_Connection=True;");
        }
    }
}
