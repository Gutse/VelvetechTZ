﻿using Microsoft.EntityFrameworkCore;
using VelvetechTZ.DAL.Models.Group;
using VelvetechTZ.DAL.Models.Student;
using VelvetechTZ.DAL.Models.StudentGroupRelation;

namespace VelvetechTZ.DAL.Repository
{
    public class DockerDbContext: DbContext
    {
        public DbSet<GroupModel>? groups { get; set; }
        public DbSet<StudentModel>? students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies().UseSqlServer("Server=localhost,5434;Database=velvetech;User Id=sa;Password=Qwerty@18;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentModel>().HasIndex(nameof(StudentModel.StudentId)).IsUnique(true);

            /*Many-to-many relationships without an entity class to represent the join table are not yet supported 
             * https://docs.microsoft.com/ru-ru/ef/core/modeling/relationships?tabs=fluent-api%2Cfluent-api-simple-key%2Csimple-key
             */
            // modelBuilder.Entity<StudentModel>().HasMany<GroupModel>();
            // modelBuilder.Entity<GroupModel>().HasMany<StudentModel>();

            modelBuilder.Entity<StudentGroup>()
                .HasKey(t => new { t.GroupId, t.StudentId});

            modelBuilder.Entity<StudentGroup>()
                .HasOne(g => g.Group)
                .WithMany(p => p!.Students)
                .HasForeignKey(sg => sg.GroupId);

            modelBuilder.Entity<StudentGroup>()
                .HasOne(pt => pt.Student)
                .WithMany(t => t!.Groups)
                .HasForeignKey(pt => pt.StudentId);
        }
    }
}
