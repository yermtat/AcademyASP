﻿// <auto-generated />
using AcademyAPI.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AcademyAPI.Migrations
{
    [DbContext(typeof(AcademyContext))]
    [Migration("20240828170314_Second")]
    partial class Second
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AcademyAPI.Data.Models.Department", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("AcademyAPI.Data.Models.Faculty", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("DepartmentsNumber")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Faculties", t =>
                        {
                            t.HasCheckConstraint("DepartmentsNumberCheck", "DepartmentsNumber > 0");
                        });
                });

            modelBuilder.Entity("AcademyAPI.Data.Models.Group", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FacultyId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("TeacherId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FacultyId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.HasIndex("TeacherId");

                    b.ToTable("Groups", t =>
                        {
                            t.HasCheckConstraint("YearConstraint", "Year > 0 AND Year < 7");
                        });
                });

            modelBuilder.Entity("AcademyAPI.Data.Models.Student", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("GroupId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.ToTable("Students", t =>
                        {
                            t.HasCheckConstraint("AgeCheck", "Age > 15");
                        });
                });

            modelBuilder.Entity("AcademyAPI.Data.Models.Teacher", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("DepartmentId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("WorkHours")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Teachers", t =>
                        {
                            t.HasCheckConstraint("WorkHoursCheck", "WorkHours > 0");
                        });
                });

            modelBuilder.Entity("AcademyAPI.Data.Models.Group", b =>
                {
                    b.HasOne("AcademyAPI.Data.Models.Faculty", "Faculty")
                        .WithMany("Groups")
                        .HasForeignKey("FacultyId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("AcademyAPI.Data.Models.Teacher", "Teacher")
                        .WithMany("Groups")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Faculty");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("AcademyAPI.Data.Models.Student", b =>
                {
                    b.HasOne("AcademyAPI.Data.Models.Group", "Group")
                        .WithMany("Students")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Group");
                });

            modelBuilder.Entity("AcademyAPI.Data.Models.Teacher", b =>
                {
                    b.HasOne("AcademyAPI.Data.Models.Department", "Department")
                        .WithMany("Teachers")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Department");
                });

            modelBuilder.Entity("AcademyAPI.Data.Models.Department", b =>
                {
                    b.Navigation("Teachers");
                });

            modelBuilder.Entity("AcademyAPI.Data.Models.Faculty", b =>
                {
                    b.Navigation("Groups");
                });

            modelBuilder.Entity("AcademyAPI.Data.Models.Group", b =>
                {
                    b.Navigation("Students");
                });

            modelBuilder.Entity("AcademyAPI.Data.Models.Teacher", b =>
                {
                    b.Navigation("Groups");
                });
#pragma warning restore 612, 618
        }
    }
}
