// <auto-generated />
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

            modelBuilder.Entity("Task6_PersonalFinance.DataAccess.Entities.Expense", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Expenses", (string)null);
                });

            modelBuilder.Entity("Task6_PersonalFinance.DataAccess.Entities.Income", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Incomes", (string)null);
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

            modelBuilder.Entity("Task6_PersonalFinance.DataAccess.Entities.UserExpenseCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserExpenseCategories", (string)null);
                });

            modelBuilder.Entity("Task6_PersonalFinance.DataAccess.Entities.UserIncomeCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserIncomeCategories", (string)null);
                });

            modelBuilder.Entity("Task6_PersonalFinance.DataAccess.Entities.Expense", b =>
                {
                    b.HasOne("Task6_PersonalFinance.DataAccess.Entities.UserExpenseCategory", "Category")
                        .WithMany("Expenses")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Task6_PersonalFinance.DataAccess.Entities.Income", b =>
                {
                    b.HasOne("Task6_PersonalFinance.DataAccess.Entities.UserIncomeCategory", "Category")
                        .WithMany("Incomes")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Task6_PersonalFinance.DataAccess.Entities.UserExpenseCategory", b =>
                {
                    b.HasOne("Task6_PersonalFinance.DataAccess.Entities.User", "User")
                        .WithMany("ExpenseCategories")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Task6_PersonalFinance.DataAccess.Entities.UserIncomeCategory", b =>
                {
                    b.HasOne("Task6_PersonalFinance.DataAccess.Entities.User", "User")
                        .WithMany("IncomeCategories")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Task6_PersonalFinance.DataAccess.Entities.User", b =>
                {
                    b.Navigation("ExpenseCategories");

                    b.Navigation("IncomeCategories");
                });

            modelBuilder.Entity("Task6_PersonalFinance.DataAccess.Entities.UserExpenseCategory", b =>
                {
                    b.Navigation("Expenses");
                });

            modelBuilder.Entity("Task6_PersonalFinance.DataAccess.Entities.UserIncomeCategory", b =>
                {
                    b.Navigation("Incomes");
                });
#pragma warning restore 612, 618
        }
    }
}
