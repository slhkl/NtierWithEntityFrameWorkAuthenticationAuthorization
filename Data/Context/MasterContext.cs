using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Context
{
    public class MasterContext : DbContext
    {
        public MasterContext()
        {

        }
        public MasterContext(DbContextOptions<MasterContext> options) : base(options)
        {

        }
        public DbSet<Writer> Writer { get; set; }
        public DbSet<Book> Book{ get; set; }
        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasKey(x => x.BookId);
            modelBuilder.Entity<Writer>().HasKey(x => x.WriterId);
            modelBuilder.Entity<User>().HasKey(x => x.UserId);

            //modelBuilder.Entity<Writer>() // kendisi otomatik foreign key yapıyormuş
            //    .HasMany<Book>()
            //    .WithOne(x => x.Writer)
            //    .HasForeignKey(x=>x.WriterId);

            //modelBuilder.Entity<Book>()  // Tersten Yapma 
            // .HasOne<Writer>()
            // .WithMany(x => x.Book)
            // .HasForeignKey(x=>x.WriterId);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseMySQL(Environment.GetEnvironmentVariable("MYSQL_URI"));
        }
    }
}
