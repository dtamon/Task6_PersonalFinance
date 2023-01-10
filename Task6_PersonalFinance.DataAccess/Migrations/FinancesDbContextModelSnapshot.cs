﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Task6_PersonalFinance.DataAccess.Context;

#nullable disable

namespace Task6PersonalFinance.DataAccess.Migrations
{
    [DbContext(typeof(FinancesDbContext))]
    partial class FinancesDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Task6_PersonalFinance.DataAccess.Entities.Income", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IncomeCategoryId")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IncomeCategoryId");

                    b.HasIndex("UserId");

                    b.ToTable("Incomes", (string)null);
                });

            modelBuilder.Entity("Task6_PersonalFinance.DataAccess.Entities.IncomeCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("IncomeCategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("IncomeCategories", (string)null);
                });

            modelBuilder.Entity("Task6_PersonalFinance.DataAccess.Entities.Outcome", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OutcomeCategoryId")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OutcomeCategoryId");

                    b.HasIndex("UserId");

                    b.ToTable("Outcomes", (string)null);
                });

            modelBuilder.Entity("Task6_PersonalFinance.DataAccess.Entities.OutcomeCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("OutcomeCategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("OutcomeCategories", (string)null);
                });

            modelBuilder.Entity("Task6_PersonalFinance.DataAccess.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("Task6_PersonalFinance.DataAccess.Entities.Income", b =>
                {
                    b.HasOne("Task6_PersonalFinance.DataAccess.Entities.IncomeCategory", "IncomeCategory")
                        .WithMany()
                        .HasForeignKey("IncomeCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Task6_PersonalFinance.DataAccess.Entities.User", null)
                        .WithMany("Incomes")
                        .HasForeignKey("UserId");

                    b.Navigation("IncomeCategory");
                });

            modelBuilder.Entity("Task6_PersonalFinance.DataAccess.Entities.Outcome", b =>
                {
                    b.HasOne("Task6_PersonalFinance.DataAccess.Entities.OutcomeCategory", "OutcomeCategory")
                        .WithMany()
                        .HasForeignKey("OutcomeCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Task6_PersonalFinance.DataAccess.Entities.User", null)
                        .WithMany("Outcomes")
                        .HasForeignKey("UserId");

                    b.Navigation("OutcomeCategory");
                });

            modelBuilder.Entity("Task6_PersonalFinance.DataAccess.Entities.User", b =>
                {
                    b.Navigation("Incomes");

                    b.Navigation("Outcomes");
                });
#pragma warning restore 612, 618
        }
    }
}
