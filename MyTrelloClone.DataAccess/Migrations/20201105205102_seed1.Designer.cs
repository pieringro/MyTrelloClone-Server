﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyTrelloClone.DataAccess;

namespace MyTrelloClone.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20201105115102_seed1")]
    partial class seed1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MyTrelloClone.Models.Board", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Board");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Descrizione board 1",
                            Name = "Nome board 1"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Descrizione board 2",
                            Name = "Nome board 2"
                        });
                });

            modelBuilder.Entity("MyTrelloClone.Models.Task", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TaskListId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TaskListId");

                    b.ToTable("Task");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Descrizione task 1",
                            Name = "task 1",
                            TaskListId = 1
                        });
                });

            modelBuilder.Entity("MyTrelloClone.Models.TaskList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BoardId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BoardId");

                    b.ToTable("TaskList");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BoardId = 1,
                            Description = "Descrizione lista task 1",
                            Name = "Lista di task 1"
                        });
                });

            modelBuilder.Entity("MyTrelloClone.Models.Task", b =>
                {
                    b.HasOne("MyTrelloClone.Models.TaskList", "TaskList")
                        .WithMany()
                        .HasForeignKey("TaskListId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MyTrelloClone.Models.TaskList", b =>
                {
                    b.HasOne("MyTrelloClone.Models.Board", "Board")
                        .WithMany("TaskList")
                        .HasForeignKey("BoardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
