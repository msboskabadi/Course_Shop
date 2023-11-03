﻿// <auto-generated />
using System;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccessLayer.Migrations
{
    [DbContext(typeof(CourseStoredDbContext))]
    [Migration("20231103164154_init01")]
    partial class init01
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CourseShop.Comment", b =>
                {
                    b.Property<int>("CommentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CommentId"));

                    b.Property<string>("CommentBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CommentText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<bool>("IsApprove")
                        .HasColumnType("bit");

                    b.Property<int>("StartCount")
                        .HasColumnType("int");

                    b.HasKey("CommentId");

                    b.HasIndex("CourseId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("CourseShop.Course", b =>
                {
                    b.Property<int>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CourseId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("CourseId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("CourseShop.CourseTeachers", b =>
                {
                    b.Property<int>("CourseTeachersId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CourseTeachersId"));

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<int>("CourseTeacherId")
                        .HasColumnType("int");

                    b.Property<int>("TeacherId")
                        .HasColumnType("int");

                    b.HasKey("CourseTeachersId");

                    b.HasIndex("CourseId");

                    b.HasIndex("TeacherId");

                    b.ToTable("CourseTeachers");
                });

            modelBuilder.Entity("CourseShop.Dicount", b =>
                {
                    b.Property<int>("DicountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DicountId"));

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NewPrice")
                        .HasColumnType("int");

                    b.HasKey("DicountId");

                    b.HasIndex("CourseId")
                        .IsUnique();

                    b.ToTable("Dicount");
                });

            modelBuilder.Entity("CourseShop.Tag", b =>
                {
                    b.Property<int>("TagId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TagId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TagId");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("CourseShop.Teacher", b =>
                {
                    b.Property<int>("TeacherId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TeacherId"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TeacherId");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("CourseTag", b =>
                {
                    b.Property<int>("TagsTagId")
                        .HasColumnType("int");

                    b.Property<int>("coursesCourseId")
                        .HasColumnType("int");

                    b.HasKey("TagsTagId", "coursesCourseId");

                    b.HasIndex("coursesCourseId");

                    b.ToTable("CourseTag");
                });

            modelBuilder.Entity("CourseShop.Comment", b =>
                {
                    b.HasOne("CourseShop.Course", "Course")
                        .WithMany("Comments")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("CourseShop.CourseTeachers", b =>
                {
                    b.HasOne("CourseShop.Course", "Course")
                        .WithMany("CourseTeachers")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CourseShop.Teacher", "Teacher")
                        .WithMany("CourseTeachers")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("CourseShop.Dicount", b =>
                {
                    b.HasOne("CourseShop.Course", "Course")
                        .WithOne("Dicounts")
                        .HasForeignKey("CourseShop.Dicount", "CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("CourseTag", b =>
                {
                    b.HasOne("CourseShop.Tag", null)
                        .WithMany()
                        .HasForeignKey("TagsTagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CourseShop.Course", null)
                        .WithMany()
                        .HasForeignKey("coursesCourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CourseShop.Course", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("CourseTeachers");

                    b.Navigation("Dicounts")
                        .IsRequired();
                });

            modelBuilder.Entity("CourseShop.Teacher", b =>
                {
                    b.Navigation("CourseTeachers");
                });
#pragma warning restore 612, 618
        }
    }
}
