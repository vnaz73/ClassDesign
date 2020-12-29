﻿// <auto-generated />
using System;
using EFCoreClassDesignTechEg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ClassDesign.Migrations
{
    [DbContext(typeof(SchoolDbContext))]
    [Migration("20201229090416_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("EFCoreClassDesignTechEg.ClassStandard", b =>
                {
                    b.Property<int>("ClassId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("ClassName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClassId");

                    b.ToTable("ClassStandards");
                });

            modelBuilder.Entity("EFCoreClassDesignTechEg.Course", b =>
                {
                    b.Property<int>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("CourseName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CourseId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("EFCoreClassDesignTechEg.Exam", b =>
                {
                    b.Property<int>("ExamId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DOE")
                        .HasColumnType("datetime2");

                    b.Property<double>("Marks")
                        .HasColumnType("float");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("ExamId");

                    b.HasIndex("CourseId");

                    b.HasIndex("StudentId");

                    b.ToTable("Exams");
                });

            modelBuilder.Entity("EFCoreClassDesignTechEg.Student", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("ClassId")
                        .HasColumnType("int");

                    b.Property<int?>("ClassStandardClassId")
                        .HasColumnType("int");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StudentName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StudentId");

                    b.HasIndex("ClassStandardClassId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("EFCoreClassDesignTechEg.Student_Course", b =>
                {
                    b.Property<int>("SCid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("SCid");

                    b.HasIndex("CourseId");

                    b.HasIndex("StudentId");

                    b.ToTable("Student_Courses");
                });

            modelBuilder.Entity("EFCoreClassDesignTechEg.Exam", b =>
                {
                    b.HasOne("EFCoreClassDesignTechEg.Course", "Course")
                        .WithMany("Exams")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EFCoreClassDesignTechEg.Student", "Student")
                        .WithMany("Exams")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("EFCoreClassDesignTechEg.Student", b =>
                {
                    b.HasOne("EFCoreClassDesignTechEg.ClassStandard", "ClassStandard")
                        .WithMany("Students")
                        .HasForeignKey("ClassStandardClassId");

                    b.Navigation("ClassStandard");
                });

            modelBuilder.Entity("EFCoreClassDesignTechEg.Student_Course", b =>
                {
                    b.HasOne("EFCoreClassDesignTechEg.Course", "Course")
                        .WithMany("Student_Courses")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EFCoreClassDesignTechEg.Student", "Student")
                        .WithMany("Student_Courses")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("EFCoreClassDesignTechEg.ClassStandard", b =>
                {
                    b.Navigation("Students");
                });

            modelBuilder.Entity("EFCoreClassDesignTechEg.Course", b =>
                {
                    b.Navigation("Exams");

                    b.Navigation("Student_Courses");
                });

            modelBuilder.Entity("EFCoreClassDesignTechEg.Student", b =>
                {
                    b.Navigation("Exams");

                    b.Navigation("Student_Courses");
                });
#pragma warning restore 612, 618
        }
    }
}
