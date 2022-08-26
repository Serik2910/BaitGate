﻿// <auto-generated />
using System;
using BaitGate.Models.EFContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BaitGate.Migrations
{
    [DbContext(typeof(SEDContext))]
    [Migration("20220804132709_changes3")]
    partial class changes3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("BaitGate.Models.EFContext.Client", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("longblob");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("longblob");

                    b.Property<string>("URLDocument")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("URLState")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("clients");
                });

            modelBuilder.Entity("BaitGate.Models.EFContext.Document", b =>
                {
                    b.Property<string>("Href")
                        .HasColumnType("varchar(255)");

                    b.Property<long>("Client")
                        .HasColumnType("bigint");

                    b.Property<string>("AppendCount")
                        .HasColumnType("longtext");

                    b.Property<string>("Attachments")
                        .HasColumnType("longtext");

                    b.Property<string>("AuthorName")
                        .HasColumnType("longtext");

                    b.Property<string>("ControlTypeOuterName")
                        .HasColumnType("longtext");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<string>("DocDate")
                        .HasColumnType("longtext");

                    b.Property<string>("DocLang")
                        .HasColumnType("longtext");

                    b.Property<string>("DocNo")
                        .HasColumnType("longtext");

                    b.Property<string>("DocToNumber")
                        .HasColumnType("longtext");

                    b.Property<string>("EmployeePhone")
                        .HasColumnType("longtext");

                    b.Property<string>("ExecutionDate")
                        .HasColumnType("longtext");

                    b.Property<string>("Executor")
                        .HasColumnType("longtext");

                    b.Property<long>("From")
                        .HasColumnType("bigint");

                    b.Property<string>("OutTime")
                        .HasColumnType("longtext");

                    b.Property<string>("ResolutionText")
                        .HasColumnType("longtext");

                    b.Property<string>("SheetCount")
                        .HasColumnType("longtext");

                    b.Property<string>("SignerName")
                        .HasColumnType("longtext");

                    b.Property<string>("error")
                        .HasColumnType("longtext");

                    b.Property<string>("hrefAssigned")
                        .HasColumnType("longtext");

                    b.Property<bool?>("isSent")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Href", "Client");

                    b.ToTable("Documents");
                });

            modelBuilder.Entity("BaitGate.Models.EFContext.DocumentState", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Author")
                        .HasColumnType("longtext");

                    b.Property<long>("Client")
                        .HasColumnType("bigint");

                    b.Property<string>("ExecDate")
                        .HasColumnType("longtext");

                    b.Property<string>("Executive")
                        .HasColumnType("longtext");

                    b.Property<string>("ExecutivePhone")
                        .HasColumnType("longtext");

                    b.Property<string>("FinishDate")
                        .HasColumnType("longtext");

                    b.Property<long?>("From")
                        .HasColumnType("bigint");

                    b.Property<string>("Href")
                        .HasColumnType("longtext");

                    b.Property<string>("RegNo")
                        .HasColumnType("longtext");

                    b.Property<string>("StateDate")
                        .HasColumnType("longtext");

                    b.Property<int?>("StateType")
                        .HasColumnType("int");

                    b.Property<string>("error")
                        .HasColumnType("longtext");

                    b.Property<bool?>("isSent")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("isValidReason")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("DocumentStates");
                });

            modelBuilder.Entity("BaitGate.Models.EFContext.FileHED", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(36)
                        .HasColumnType("varchar(36)");

                    b.Property<byte[]>("Content")
                        .HasColumnType("longblob");

                    b.Property<DateTime?>("Created")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Href")
                        .HasColumnType("longtext");

                    b.Property<long?>("LifeTime")
                        .HasColumnType("bigint");

                    b.Property<string>("MediaType")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("fileHED");
                });

            modelBuilder.Entity("BaitGate.Models.EFContext.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("BaitGate.Models.EFContext.User", b =>
                {
                    b.Property<string>("UserName")
                        .HasColumnType("varchar(255)")
                        .HasColumnName("UserName");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("longblob");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("longblob");

                    b.HasKey("UserName");

                    b.ToTable("users");
                });

            modelBuilder.Entity("RoleUser", b =>
                {
                    b.Property<int>("RolesId")
                        .HasColumnType("int");

                    b.Property<string>("UsersUserName")
                        .HasColumnType("varchar(255)");

                    b.HasKey("RolesId", "UsersUserName");

                    b.HasIndex("UsersUserName");

                    b.ToTable("RoleUser");
                });

            modelBuilder.Entity("RoleUser", b =>
                {
                    b.HasOne("BaitGate.Models.EFContext.Role", null)
                        .WithMany()
                        .HasForeignKey("RolesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BaitGate.Models.EFContext.User", null)
                        .WithMany()
                        .HasForeignKey("UsersUserName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
