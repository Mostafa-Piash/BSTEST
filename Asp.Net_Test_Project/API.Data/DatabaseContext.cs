using API.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;


namespace API.Data
{
    public partial class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }
        public virtual DbSet<Posts> Posts { get; set; }
        public virtual DbSet<Comments> Comments { get; set; }
        public virtual DbSet<Votes> Votes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Posts>(entity =>
            {

                entity.ToTable("Posts", schema: "Post");
            });

            modelBuilder.Entity<Comments>(entity =>
            {

                entity.ToTable("Comments", schema: "Post");
            });

            modelBuilder.Entity<Votes>(entity =>
            {

                entity.ToTable("Votes", schema: "Post");
            });
            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
