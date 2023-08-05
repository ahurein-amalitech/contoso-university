﻿// <auto-generated />
using System;
using ContosoUniversity.Server.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ContosoUniversity.Server.Migrations
{
    [DbContext(typeof(SchoolContext))]
    partial class SchoolContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ContosoUniversity.Shared.Course", b =>
                {
                    b.Property<int>("CourseID")
                        .HasColumnType("int");

                    b.Property<int>("Credits")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CourseID");

                    b.ToTable("Course", (string)null);

                    b.HasData(
                        new
                        {
                            CourseID = 1050,
                            Credits = 3,
                            Title = "Chemistry"
                        },
                        new
                        {
                            CourseID = 4022,
                            Credits = 3,
                            Title = "Microeconomics"
                        },
                        new
                        {
                            CourseID = 4041,
                            Credits = 3,
                            Title = "Macroeconomics"
                        },
                        new
                        {
                            CourseID = 1045,
                            Credits = 4,
                            Title = "Calculus"
                        },
                        new
                        {
                            CourseID = 3141,
                            Credits = 4,
                            Title = "Trigonometry"
                        },
                        new
                        {
                            CourseID = 2021,
                            Credits = 3,
                            Title = "Composition"
                        },
                        new
                        {
                            CourseID = 2042,
                            Credits = 4,
                            Title = "Literature"
                        });
                });

            modelBuilder.Entity("ContosoUniversity.Shared.Enrollment", b =>
                {
                    b.Property<int>("EnrollmentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EnrollmentID"));

                    b.Property<int>("CourseID")
                        .HasColumnType("int");

                    b.Property<int?>("Grade")
                        .HasColumnType("int");

                    b.Property<int>("StudentID")
                        .HasColumnType("int");

                    b.HasKey("EnrollmentID");

                    b.HasIndex("CourseID");

                    b.HasIndex("StudentID");

                    b.ToTable("Enrollment", (string)null);

                    b.HasData(
                        new
                        {
                            EnrollmentID = 1,
                            CourseID = 1050,
                            Grade = 0,
                            StudentID = 1
                        },
                        new
                        {
                            EnrollmentID = 2,
                            CourseID = 4022,
                            Grade = 2,
                            StudentID = 1
                        },
                        new
                        {
                            EnrollmentID = 3,
                            CourseID = 4041,
                            Grade = 1,
                            StudentID = 1
                        },
                        new
                        {
                            EnrollmentID = 4,
                            CourseID = 1045,
                            Grade = 1,
                            StudentID = 2
                        },
                        new
                        {
                            EnrollmentID = 5,
                            CourseID = 3141,
                            Grade = 4,
                            StudentID = 2
                        },
                        new
                        {
                            EnrollmentID = 6,
                            CourseID = 2021,
                            Grade = 4,
                            StudentID = 2
                        },
                        new
                        {
                            EnrollmentID = 7,
                            CourseID = 1050,
                            StudentID = 3
                        },
                        new
                        {
                            EnrollmentID = 8,
                            CourseID = 1050,
                            StudentID = 4
                        },
                        new
                        {
                            EnrollmentID = 9,
                            CourseID = 4022,
                            Grade = 4,
                            StudentID = 4
                        },
                        new
                        {
                            EnrollmentID = 10,
                            CourseID = 4041,
                            Grade = 2,
                            StudentID = 5
                        },
                        new
                        {
                            EnrollmentID = 11,
                            CourseID = 1045,
                            StudentID = 6
                        },
                        new
                        {
                            EnrollmentID = 12,
                            CourseID = 3141,
                            Grade = 0,
                            StudentID = 7
                        });
                });

            modelBuilder.Entity("ContosoUniversity.Shared.Student", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTime>("EnrollmentDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstMidName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Student", (string)null);

                    b.HasData(
                        new
                        {
                            ID = 1,
                            EnrollmentDate = new DateTime(2019, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstMidName = "Carson",
                            LastName = "Alexander"
                        },
                        new
                        {
                            ID = 2,
                            EnrollmentDate = new DateTime(2017, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstMidName = "Meredith",
                            LastName = "Alonso"
                        },
                        new
                        {
                            ID = 3,
                            EnrollmentDate = new DateTime(2018, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstMidName = "Arturo",
                            LastName = "Anand"
                        },
                        new
                        {
                            ID = 4,
                            EnrollmentDate = new DateTime(2017, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstMidName = "Gytis",
                            LastName = "Barzdukas"
                        },
                        new
                        {
                            ID = 5,
                            EnrollmentDate = new DateTime(2017, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstMidName = "Yan",
                            LastName = "Li"
                        },
                        new
                        {
                            ID = 6,
                            EnrollmentDate = new DateTime(2016, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstMidName = "Peggy",
                            LastName = "Justice"
                        },
                        new
                        {
                            ID = 7,
                            EnrollmentDate = new DateTime(2018, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstMidName = "Laura",
                            LastName = "Norman"
                        },
                        new
                        {
                            ID = 8,
                            EnrollmentDate = new DateTime(2019, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstMidName = "Nino",
                            LastName = "Olivetto"
                        });
                });

            modelBuilder.Entity("ContosoUniversity.Shared.Enrollment", b =>
                {
                    b.HasOne("ContosoUniversity.Shared.Course", "Course")
                        .WithMany("Enrollments")
                        .HasForeignKey("CourseID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ContosoUniversity.Shared.Student", "Student")
                        .WithMany("Enrollments")
                        .HasForeignKey("StudentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("ContosoUniversity.Shared.Course", b =>
                {
                    b.Navigation("Enrollments");
                });

            modelBuilder.Entity("ContosoUniversity.Shared.Student", b =>
                {
                    b.Navigation("Enrollments");
                });
#pragma warning restore 612, 618
        }
    }
}
