using Microsoft.EntityFrameworkCore;
using MyTrelloClone.Models;
using System;

namespace MyTrelloClone.DataAccess
{
    public class ApplicationContext : DbContext, IApplicationContext
    {

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }


        public DbSet<Board> Boards { get; set; }
        public DbSet<TaskList> TaskLists { get; set; }
        public DbSet<Task> Task { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // table - entity mapping
            modelBuilder.Entity<Board>().ToTable("Board");
            modelBuilder.Entity<TaskList>().ToTable("TaskList");
            modelBuilder.Entity<Task>().ToTable("Task");

            // model seeding
            modelBuilder.Entity<Board>().HasData(new Board[]
            {
                new Board()
                {
                    Id = 1,
                    Name="Nome board 1",
                    Description="Descrizione board 1",
                },
                new Board()
                {
                    Id = 2,
                    Name="Nome board 2",
                    Description="Descrizione board 2",
                }
            });

            modelBuilder.Entity<TaskList>().HasData(new TaskList[]
            {
                new TaskList()
                {
                    Id = 1,
                    BoardId = 1,
                    Name = "Lista di task 1",
                    Description = "Descrizione lista task 1"
                }
            });

            modelBuilder.Entity<Task>().HasData(new Task[]
            {
                new Task()
                {
                    Id = 1,
                    TaskListId = 1,
                    Name = "task 1",
                    Description = "Descrizione task 1"
                }
            });

        }
    }
}
