﻿// <auto-generated />
using System;
using EfSample.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EfSample.Infrastructure.Migrations
{
    [DbContext(typeof(CourseDbContext))]
    [Migration("20231003072051_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("dbt")
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EfSample.Domain.Entities.Account", b =>
                {
                    b.Property<int>("AccountId")
                        .HasColumnType("int");

                    b.Property<string>("AccountType")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int?>("UserTeacherId")
                        .HasColumnType("int");

                    b.HasKey("AccountId");

                    b.HasIndex("UserTeacherId");

                    b.ToTable("Account", "dbt");
                });

            modelBuilder.Entity("EfSample.Domain.Entities.Comment", b =>
                {
                    b.Property<int>("CommentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CommentId"));

                    b.Property<string>("CommentBy")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("CommentText")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<bool>("IsApproved")
                        .HasColumnType("bit");

                    b.Property<int>("StarCount")
                        .HasColumnType("int");

                    b.HasKey("CommentId");

                    b.HasIndex("CourseId");

                    b.ToTable("Comment", "dbt");
                });

            modelBuilder.Entity("EfSample.Domain.Entities.Course", b =>
                {
                    b.Property<int>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CourseId"));

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("ModifiedBy")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.HasKey("CourseId");

                    b.HasIndex("Title");

                    b.ToTable("Course", "dbt");
                });

            modelBuilder.Entity("EfSample.Domain.Entities.CourseIncludingDiscount", b =>
                {
                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<string>("CourseTitle")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<int>("DiscountId")
                        .HasColumnType("int");

                    b.Property<decimal>("NewPrice")
                        .HasPrecision(14, 2)
                        .HasColumnType("decimal(14,2)");

                    b.ToTable("CourseIncludingDiscount", "view");
                });

            modelBuilder.Entity("EfSample.Domain.Entities.CourseTag", b =>
                {
                    b.Property<int>("TagId")
                        .HasColumnType("int");

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.HasKey("TagId");

                    b.ToTable("CourseTag", "dbt");
                });

            modelBuilder.Entity("EfSample.Domain.Entities.CourseTeachers", b =>
                {
                    b.Property<int>("CourseTeachersId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CourseTeachersId"));

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<int>("SortOrder")
                        .HasColumnType("int");

                    b.Property<int>("TeacherId")
                        .HasColumnType("int");

                    b.HasKey("CourseTeachersId");

                    b.HasIndex("CourseId");

                    b.HasIndex("TeacherId");

                    b.ToTable("CourseTeachers", "dbt");
                });

            modelBuilder.Entity("EfSample.Domain.Entities.Discount", b =>
                {
                    b.Property<int>("DiscountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DiscountId"));

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<decimal>("NewPrice")
                        .HasPrecision(14, 2)
                        .HasColumnType("decimal(14,2)");

                    b.Property<string>("Title")
                        .HasMaxLength(500)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("DiscountId");

                    b.HasIndex("CourseId")
                        .IsUnique();

                    b.ToTable("Discount", "dbt");
                });

            modelBuilder.Entity("EfSample.Domain.Entities.MyCourses", b =>
                {
                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<string>("CourseTitle")
                        .HasMaxLength(250)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.ToTable("MyCourses", "view");
                });

            modelBuilder.Entity("EfSample.Domain.Entities.Tag", b =>
                {
                    b.Property<int>("TagId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TagId"));

                    b.Property<string>("Title")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("TagId");

                    b.ToTable("Tag", "dbt");
                });

            modelBuilder.Entity("EfSample.Domain.Entities.Teacher", b =>
                {
                    b.Property<int>("TeacherId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TeacherId"));

                    b.Property<string>("FirstName")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("TeacherId");

                    b.HasIndex("LastName");

                    b.ToTable("Teacher", "dbt");
                });

            modelBuilder.Entity("EfSample.Domain.Entities.User", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .HasMaxLength(20)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Age")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)");

                    b.Property<string>("FirstName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("UserShipAge")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)");

                    b.Property<string>("UserType")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("UserId", "UserName");

                    b.ToTable("User", "dbt");
                });

            modelBuilder.Entity("EfSample.Domain.Entities.Account", b =>
                {
                    b.HasOne("EfSample.Domain.Entities.Teacher", null)
                        .WithOne("Account")
                        .HasForeignKey("EfSample.Domain.Entities.Account", "AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EfSample.Domain.Entities.Teacher", "User")
                        .WithMany()
                        .HasForeignKey("UserTeacherId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("EfSample.Domain.Entities.Comment", b =>
                {
                    b.HasOne("EfSample.Domain.Entities.Course", null)
                        .WithMany("Comments")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EfSample.Domain.Entities.CourseTag", b =>
                {
                    b.HasOne("EfSample.Domain.Entities.Course", "Course")
                        .WithMany()
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EfSample.Domain.Entities.Tag", "Tag")
                        .WithMany()
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("EfSample.Domain.Entities.CourseTeachers", b =>
                {
                    b.HasOne("EfSample.Domain.Entities.Course", "Course")
                        .WithMany("CourseTeachers")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EfSample.Domain.Entities.Teacher", "Teacher")
                        .WithMany()
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("EfSample.Domain.Entities.Discount", b =>
                {
                    b.HasOne("EfSample.Domain.Entities.Course", "Course")
                        .WithOne("Discount")
                        .HasForeignKey("EfSample.Domain.Entities.Discount", "CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("EfSample.Domain.Entities.Course", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("CourseTeachers");

                    b.Navigation("Discount");
                });

            modelBuilder.Entity("EfSample.Domain.Entities.Teacher", b =>
                {
                    b.Navigation("Account");
                });
#pragma warning restore 612, 618
        }
    }
}