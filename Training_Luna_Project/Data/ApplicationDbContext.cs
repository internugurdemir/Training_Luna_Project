using Azure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Reflection.Metadata;
using Training_Luna_Project.Data.Models;

namespace Training_Luna_Project.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        { 
        }

        public DbSet<FormModel> FormModels { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Field> Fields { get; set; }
        public DbSet<FormField> FormFields { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {




            modelBuilder.Entity<FormModel>()
                 .HasMany(e => e.Fields)
                 .WithMany(e => e.FormModels)
                 .UsingEntity(
                     "FormField",
                     l => l.HasOne(typeof(Field)).WithMany().HasForeignKey("FieldsId").HasPrincipalKey(nameof(Field.Id)),
                     r => r.HasOne(typeof(FormModel)).WithMany().HasForeignKey("FormModelsId").HasPrincipalKey(nameof(FormModel.Id)),
                     j => j.HasKey("FormModelsId", "FieldsId"));



            modelBuilder.Entity<User>().HasData(
                    new User {Id = 1, UserName = "Admin", Password = "1234", Email = null, Role = "Admin" },
                    new User { Id = 2, UserName = "User", Password = "1234", Email = null, Role = "User", }
                );


            modelBuilder.Entity<User>()
                 .HasMany(e => e.FormModels)
                 .WithOne(e => e.User)
                 .HasForeignKey(e => e.UserId)
                 .IsRequired();



            modelBuilder.Entity<FormModel>().HasData(
                    new FormModel
                    {
                        Id = 1,
                        UserId = 1,
                        CreatedAt = DateTime.Now,
                        Description = "First Form Description",
                        Name = "FormName theFirst",
                    }
                );

    

            modelBuilder.Entity<Field>().HasData(
                    new Field { Id = 1, Required = true, Name = "Ad", DataType = "STRING"},
                    new Field { Id = 2, Required = true, Name = "Soyad", DataType = "STRING" },
                    new Field { Id = 3, Required = false, Name = "Yaş", DataType = "NUMBER" }
                );



            //modelBuilder.Entity<FormField>().HasData(
            //        new FormField { FieldsId = 1, FormsId = 1 },
            //        new FormField { FieldsId = 2, FormsId = 1 },
            //        new FormField { FieldsId = 3, FormsId = 1 }
            //    );

        }
    }
}
