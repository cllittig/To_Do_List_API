﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ToDoList.API.Persistence;

#nullable disable

namespace ToDoList.API.Persistence.Migrations
{
    [DbContext(typeof(ToDoListDbContext))]
    [Migration("20240421042738_Migration_1")]
    partial class Migration_1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("TagTasks", b =>
                {
                    b.Property<int>("TagsTagId")
                        .HasColumnType("int");

                    b.Property<int>("TaskId")
                        .HasColumnType("int");

                    b.HasKey("TagsTagId", "TaskId");

                    b.HasIndex("TaskId");

                    b.ToTable("TagTasks");
                });

            modelBuilder.Entity("ToDoList.API.Entities.Address", b =>
                {
                    b.Property<int>("AddressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("AddressId"));

                    b.Property<string>("AddressCity")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("AddressComplement")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("AddressNumber")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("AddressPostalCode")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("AddressState")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("AddressStreet")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("AddressId");

                    b.HasIndex("UserId");

                    b.ToTable("address");
                });

            modelBuilder.Entity("ToDoList.API.Entities.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("CategoryId"));

                    b.Property<string>("CategoryDescription")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("CategoryId");

                    b.HasIndex("UserId");

                    b.ToTable("category");
                });

            modelBuilder.Entity("ToDoList.API.Entities.Tag", b =>
                {
                    b.Property<int>("TagId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("TagId"));

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("TagDescription")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("TagName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("TagId");

                    b.HasIndex("UserId");

                    b.ToTable("tag");
                });

            modelBuilder.Entity("ToDoList.API.Entities.TaskTag", b =>
                {
                    b.Property<int>("TagId")
                        .HasColumnType("int");

                    b.Property<int>("TaskId")
                        .HasColumnType("int");

                    b.HasKey("TagId", "TaskId");

                    b.HasIndex("TaskId");

                    b.ToTable("task_tag");
                });

            modelBuilder.Entity("ToDoList.API.Entities.Tasks", b =>
                {
                    b.Property<int>("TaskId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("TaskId"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("TaskCreationDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("TaskDescription")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("TaskDueDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("TaskPriority")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("TaskStatus")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("TaskTitle")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("TaskId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("UserId");

                    b.ToTable("task");
                });

            modelBuilder.Entity("ToDoList.API.Entities.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("UserId"));

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("UserAge")
                        .HasColumnType("int");

                    b.Property<string>("UserEmail")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("UserFirstName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("UserPassword")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("UserSecondName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("UserStartDate")
                        .HasColumnType("datetime(6)");

                    b.HasKey("UserId");

                    b.ToTable("user");
                });

            modelBuilder.Entity("TagTasks", b =>
                {
                    b.HasOne("ToDoList.API.Entities.Tag", null)
                        .WithMany()
                        .HasForeignKey("TagsTagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ToDoList.API.Entities.Tasks", null)
                        .WithMany()
                        .HasForeignKey("TaskId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ToDoList.API.Entities.Address", b =>
                {
                    b.HasOne("ToDoList.API.Entities.User", null)
                        .WithMany("UserAddress")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ToDoList.API.Entities.Category", b =>
                {
                    b.HasOne("ToDoList.API.Entities.User", null)
                        .WithMany("UserCategory")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ToDoList.API.Entities.Tag", b =>
                {
                    b.HasOne("ToDoList.API.Entities.User", null)
                        .WithMany("UserTags")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ToDoList.API.Entities.TaskTag", b =>
                {
                    b.HasOne("ToDoList.API.Entities.Tag", "Tag")
                        .WithMany("TaskTag")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ToDoList.API.Entities.Tasks", "Task")
                        .WithMany("TaskTags")
                        .HasForeignKey("TaskId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tag");

                    b.Navigation("Task");
                });

            modelBuilder.Entity("ToDoList.API.Entities.Tasks", b =>
                {
                    b.HasOne("ToDoList.API.Entities.Category", null)
                        .WithMany("CategoryTasks")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ToDoList.API.Entities.User", null)
                        .WithMany("UserTasks")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ToDoList.API.Entities.Category", b =>
                {
                    b.Navigation("CategoryTasks");
                });

            modelBuilder.Entity("ToDoList.API.Entities.Tag", b =>
                {
                    b.Navigation("TaskTag");
                });

            modelBuilder.Entity("ToDoList.API.Entities.Tasks", b =>
                {
                    b.Navigation("TaskTags");
                });

            modelBuilder.Entity("ToDoList.API.Entities.User", b =>
                {
                    b.Navigation("UserAddress");

                    b.Navigation("UserCategory");

                    b.Navigation("UserTags");

                    b.Navigation("UserTasks");
                });
#pragma warning restore 612, 618
        }
    }
}