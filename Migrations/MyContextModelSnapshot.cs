﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using School.Context;

#nullable disable

namespace School.Migrations
{
    [DbContext(typeof(MyContext))]
    partial class MyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("School.Models.Room", b =>
                {
                    b.Property<int>("RoomId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoomId"));

                    b.Property<string>("RoomName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("RoomId");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("School.Models.Student", b =>
                {
                    b.Property<int>("studentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("studentId"));

                    b.Property<string>("PhotoName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isActive")
                        .HasColumnType("bit");

                    b.Property<int>("studentAge")
                        .HasColumnType("int");

                    b.Property<string>("studentName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("studentId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("School.Models.StudentCourse", b =>
                {
                    b.Property<int>("StudentCourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StudentCourseId"));

                    b.Property<int>("studentId")
                        .HasColumnType("int");

                    b.Property<int>("subjectId")
                        .HasColumnType("int");

                    b.HasKey("StudentCourseId");

                    b.HasIndex("studentId");

                    b.HasIndex("subjectId");

                    b.ToTable("Registrations");
                });

            modelBuilder.Entity("School.Models.Subject", b =>
                {
                    b.Property<int>("subjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("subjectId"));

                    b.Property<int>("subjectCapacity")
                        .HasColumnType("int");

                    b.Property<string>("subjectName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("teacherId")
                        .HasColumnType("int");

                    b.HasKey("subjectId");

                    b.HasIndex("teacherId");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("School.Models.Teacher", b =>
                {
                    b.Property<int>("teacherId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("teacherId"));

                    b.Property<int>("teacherAge")
                        .HasColumnType("int");

                    b.Property<string>("teacherName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("teacherId");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("School.Models.StudentCourse", b =>
                {
                    b.HasOne("School.Models.Student", "Student")
                        .WithMany()
                        .HasForeignKey("studentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("School.Models.Subject", "Subject")
                        .WithMany()
                        .HasForeignKey("subjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("School.Models.Subject", b =>
                {
                    b.HasOne("School.Models.Teacher", "Teacher")
                        .WithMany()
                        .HasForeignKey("teacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Teacher");
                });
#pragma warning restore 612, 618
        }
    }
}
