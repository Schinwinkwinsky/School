﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using School.Data;

#nullable disable

namespace School.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CourseSubject", b =>
                {
                    b.Property<Guid>("CoursesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SubjectsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CoursesId", "SubjectsId");

                    b.HasIndex("SubjectsId");

                    b.ToTable("CourseSubject");
                });

            modelBuilder.Entity("KnowledgeAreaSubject", b =>
                {
                    b.Property<Guid>("KnowledgeAreasId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SubjectsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("KnowledgeAreasId", "SubjectsId");

                    b.HasIndex("SubjectsId");

                    b.ToTable("KnowledgeAreaSubject");
                });

            modelBuilder.Entity("KnowledgeAreaTeacher", b =>
                {
                    b.Property<Guid>("KnowledgeAreasId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TeachersId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("KnowledgeAreasId", "TeachersId");

                    b.HasIndex("TeachersId");

                    b.ToTable("KnowledgeAreaTeacher");
                });

            modelBuilder.Entity("School.Domain.Entities.Course", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("DeletedBy")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("UpdatedBy")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Course");
                });

            modelBuilder.Entity("School.Domain.Entities.KnowledgeArea", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("DeletedBy")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("UpdatedBy")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("KnowledgeAreas");
                });

            modelBuilder.Entity("School.Domain.Entities.Period", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("CourseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("DeletedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("End")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Start")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("SubjectId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("UpdatedBy")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("SubjectId");

                    b.ToTable("Period");
                });

            modelBuilder.Entity("School.Domain.Entities.Person", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Birth")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("DeletedBy")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("UpdatedBy")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("People");
                });

            modelBuilder.Entity("School.Domain.Entities.SchoolClass", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("DeletedBy")
                        .HasColumnType("int");

                    b.Property<Guid>("PeriodId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SubjectId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TeacherId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("UpdatedBy")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PeriodId");

                    b.HasIndex("SubjectId");

                    b.HasIndex("TeacherId");

                    b.ToTable("SchoolClasses");
                });

            modelBuilder.Entity("School.Domain.Entities.Student", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("DeletedBy")
                        .HasColumnType("int");

                    b.Property<Guid>("PersonId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("UpdatedBy")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("School.Domain.Entities.Subject", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("DeletedBy")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("UpdatedBy")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("School.Domain.Entities.Teacher", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("DeletedBy")
                        .HasColumnType("int");

                    b.Property<Guid>("PersonId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("UpdatedBy")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("SchoolClassStudent", b =>
                {
                    b.Property<Guid>("SchoolClassesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("StudentsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("SchoolClassesId", "StudentsId");

                    b.HasIndex("StudentsId");

                    b.ToTable("SchoolClassStudent");
                });

            modelBuilder.Entity("CourseSubject", b =>
                {
                    b.HasOne("School.Domain.Entities.Course", null)
                        .WithMany()
                        .HasForeignKey("CoursesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("School.Domain.Entities.Subject", null)
                        .WithMany()
                        .HasForeignKey("SubjectsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("KnowledgeAreaSubject", b =>
                {
                    b.HasOne("School.Domain.Entities.KnowledgeArea", null)
                        .WithMany()
                        .HasForeignKey("KnowledgeAreasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("School.Domain.Entities.Subject", null)
                        .WithMany()
                        .HasForeignKey("SubjectsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("KnowledgeAreaTeacher", b =>
                {
                    b.HasOne("School.Domain.Entities.KnowledgeArea", null)
                        .WithMany()
                        .HasForeignKey("KnowledgeAreasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("School.Domain.Entities.Teacher", null)
                        .WithMany()
                        .HasForeignKey("TeachersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("School.Domain.Entities.Period", b =>
                {
                    b.HasOne("School.Domain.Entities.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("School.Domain.Entities.Subject", null)
                        .WithMany("Periods")
                        .HasForeignKey("SubjectId");

                    b.Navigation("Course");
                });

            modelBuilder.Entity("School.Domain.Entities.Person", b =>
                {
                    b.OwnsMany("School.Domain.ValueObjects.Address", "Addresses", b1 =>
                        {
                            b1.Property<Guid>("PersonId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b1.Property<int>("Id"), 1L, 1);

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Complement")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Country")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Description")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("District")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<long>("Latitude")
                                .HasColumnType("bigint");

                            b1.Property<long>("Longitude")
                                .HasColumnType("bigint");

                            b1.Property<string>("Number")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("PostCode")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("State")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Street")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("PersonId", "Id");

                            b1.ToTable("PersonAddresses", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("PersonId");
                        });

                    b.OwnsMany("School.Domain.ValueObjects.Email", "Emails", b1 =>
                        {
                            b1.Property<Guid>("PersonId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b1.Property<int>("Id"), 1L, 1);

                            b1.Property<string>("Address")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Description")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("PersonId", "Id");

                            b1.ToTable("PersonEmails", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("PersonId");
                        });

                    b.OwnsMany("School.Domain.ValueObjects.Phone", "Phones", b1 =>
                        {
                            b1.Property<Guid>("PersonId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b1.Property<int>("Id"), 1L, 1);

                            b1.Property<string>("Description")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("GlobalCode")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("LocalCode")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Number")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("PersonId", "Id");

                            b1.ToTable("PersonPhones", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("PersonId");
                        });

                    b.Navigation("Addresses");

                    b.Navigation("Emails");

                    b.Navigation("Phones");
                });

            modelBuilder.Entity("School.Domain.Entities.SchoolClass", b =>
                {
                    b.HasOne("School.Domain.Entities.Period", "Period")
                        .WithMany("SchoolClasses")
                        .HasForeignKey("PeriodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("School.Domain.Entities.Subject", "Subject")
                        .WithMany()
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("School.Domain.Entities.Teacher", "Teacher")
                        .WithMany("SchoolClasses")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Period");

                    b.Navigation("Subject");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("School.Domain.Entities.Student", b =>
                {
                    b.HasOne("School.Domain.Entities.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("School.Domain.Entities.Teacher", b =>
                {
                    b.HasOne("School.Domain.Entities.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("SchoolClassStudent", b =>
                {
                    b.HasOne("School.Domain.Entities.SchoolClass", null)
                        .WithMany()
                        .HasForeignKey("SchoolClassesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("School.Domain.Entities.Student", null)
                        .WithMany()
                        .HasForeignKey("StudentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("School.Domain.Entities.Period", b =>
                {
                    b.Navigation("SchoolClasses");
                });

            modelBuilder.Entity("School.Domain.Entities.Subject", b =>
                {
                    b.Navigation("Periods");
                });

            modelBuilder.Entity("School.Domain.Entities.Teacher", b =>
                {
                    b.Navigation("SchoolClasses");
                });
#pragma warning restore 612, 618
        }
    }
}
