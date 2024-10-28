﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WebApplication1.Model;

#nullable disable

namespace WebApplication1.Migrations
{
    [DbContext(typeof(ToDoContext))]
    [Migration("20241028184838_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("WebApplication1.Model.ToDoItem", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime?>("DueDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsComplete")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Priority")
                        .HasColumnType("integer");

                    b.Property<int?>("RecurrenceInterval")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("ToDoItems");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            DueDate = new DateTime(2024, 11, 4, 18, 48, 37, 823, DateTimeKind.Utc).AddTicks(1856),
                            IsComplete = false,
                            Name = "Learn C#",
                            Priority = 2
                        },
                        new
                        {
                            Id = 2L,
                            DueDate = new DateTime(2024, 11, 7, 18, 48, 37, 823, DateTimeKind.Utc).AddTicks(1868),
                            IsComplete = false,
                            Name = "Build a Web API",
                            Priority = 1
                        },
                        new
                        {
                            Id = 3L,
                            DueDate = new DateTime(2024, 11, 12, 18, 48, 37, 823, DateTimeKind.Utc).AddTicks(1870),
                            IsComplete = false,
                            Name = "Test the API",
                            Priority = 2
                        },
                        new
                        {
                            Id = 4L,
                            DueDate = new DateTime(2024, 11, 17, 18, 48, 37, 823, DateTimeKind.Utc).AddTicks(1872),
                            IsComplete = false,
                            Name = "Deploy to Production",
                            Priority = 2
                        },
                        new
                        {
                            Id = 5L,
                            IsComplete = true,
                            Name = "Celebrate",
                            Priority = 0
                        },
                        new
                        {
                            Id = 6L,
                            DueDate = new DateTime(2024, 11, 2, 18, 48, 37, 823, DateTimeKind.Utc).AddTicks(1874),
                            IsComplete = false,
                            Name = "Write Documentation",
                            Priority = 1
                        },
                        new
                        {
                            Id = 7L,
                            IsComplete = true,
                            Name = "Update GitHub Repository",
                            Priority = 1
                        },
                        new
                        {
                            Id = 8L,
                            DueDate = new DateTime(2024, 10, 31, 18, 48, 37, 823, DateTimeKind.Utc).AddTicks(1877),
                            IsComplete = false,
                            Name = "Research Unit Testing",
                            Priority = 0,
                            RecurrenceInterval = 1
                        },
                        new
                        {
                            Id = 9L,
                            DueDate = new DateTime(2024, 10, 30, 18, 48, 37, 823, DateTimeKind.Utc).AddTicks(1879),
                            IsComplete = false,
                            Name = "Refactor Code",
                            Priority = 1
                        },
                        new
                        {
                            Id = 10L,
                            IsComplete = false,
                            Name = "Optimize Performance",
                            Priority = 2,
                            RecurrenceInterval = 2
                        },
                        new
                        {
                            Id = 11L,
                            IsComplete = true,
                            Name = "Add Logging",
                            Priority = 0
                        },
                        new
                        {
                            Id = 12L,
                            IsComplete = true,
                            Name = "Set Up CI/CD Pipeline",
                            Priority = 2
                        },
                        new
                        {
                            Id = 13L,
                            DueDate = new DateTime(2024, 11, 9, 18, 48, 37, 823, DateTimeKind.Utc).AddTicks(1883),
                            IsComplete = false,
                            Name = "Create Backup Strategy",
                            Priority = 1
                        },
                        new
                        {
                            Id = 14L,
                            DueDate = new DateTime(2024, 11, 5, 18, 48, 37, 823, DateTimeKind.Utc).AddTicks(1884),
                            IsComplete = false,
                            Name = "Conduct Code Review",
                            Priority = 2
                        },
                        new
                        {
                            Id = 15L,
                            IsComplete = true,
                            Name = "Plan Next Sprint",
                            Priority = 1
                        },
                        new
                        {
                            Id = 16L,
                            DueDate = new DateTime(2024, 10, 29, 18, 48, 37, 823, DateTimeKind.Utc).AddTicks(1887),
                            IsComplete = false,
                            Name = "Fix Bugs",
                            Priority = 2
                        },
                        new
                        {
                            Id = 17L,
                            DueDate = new DateTime(2024, 11, 11, 18, 48, 37, 823, DateTimeKind.Utc).AddTicks(1888),
                            IsComplete = false,
                            Name = "Prepare for Presentation",
                            Priority = 1
                        },
                        new
                        {
                            Id = 18L,
                            IsComplete = true,
                            Name = "Clean Up Codebase",
                            Priority = 0
                        },
                        new
                        {
                            Id = 19L,
                            IsComplete = true,
                            Name = "Archive Old Projects",
                            Priority = 0
                        },
                        new
                        {
                            Id = 20L,
                            DueDate = new DateTime(2024, 11, 3, 18, 48, 37, 823, DateTimeKind.Utc).AddTicks(1891),
                            IsComplete = false,
                            Name = "Analyze User Feedback",
                            Priority = 1
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
