﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SystemProject.DataApp;

#nullable disable

namespace SystemProject.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("SystemProject.Models.Branch.Branch", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("text");

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<string>("ComID")
                        .HasColumnType("text");

                    b.Property<string>("Location")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("BRAN");
                });

            modelBuilder.Entity("SystemProject.Models.Branch.BranchInfo", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("text");

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<string>("BranID")
                        .HasColumnType("text");

                    b.Property<string>("Des1")
                        .HasColumnType("text");

                    b.Property<string>("Des2")
                        .HasColumnType("text");

                    b.Property<string>("Location")
                        .HasColumnType("text");

                    b.Property<string>("Logo")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Tel1")
                        .HasColumnType("text");

                    b.Property<string>("Tel2")
                        .HasColumnType("text");

                    b.Property<string>("Tel3")
                        .HasColumnType("text");

                    b.Property<string>("Tel4")
                        .HasColumnType("text");

                    b.Property<string>("Tel5")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("BRINFO");
                });

            modelBuilder.Entity("SystemProject.Models.BusinessPartner.Customer", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("text");

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<string>("Code")
                        .HasColumnType("text");

                    b.Property<string>("ComID")
                        .HasColumnType("text");

                    b.Property<string>("Location")
                        .HasColumnType("text");

                    b.Property<string>("Name1")
                        .HasColumnType("text");

                    b.Property<string>("Name2")
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("CUSMER");
                });

            modelBuilder.Entity("SystemProject.Models.BusinessPartner.Vendor", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("text");

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<string>("Code")
                        .HasColumnType("text");

                    b.Property<string>("ComID")
                        .HasColumnType("text");

                    b.Property<string>("Location")
                        .HasColumnType("text");

                    b.Property<string>("Name1")
                        .HasColumnType("text");

                    b.Property<string>("Name2")
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("VENDOR");
                });

            modelBuilder.Entity("SystemProject.Models.Company.Company", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("text");

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<string>("LC")
                        .HasColumnType("text");

                    b.Property<string>("Location")
                        .HasColumnType("text");

                    b.Property<string>("Logo")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("SC")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("COMP");
                });

            modelBuilder.Entity("SystemProject.Models.Company.Currency", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("text");

                    b.Property<string>("ComID")
                        .HasColumnType("text");

                    b.Property<string>("Des")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<string>("Symbol")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("OCURE");
                });

            modelBuilder.Entity("SystemProject.Models.Company.ExchangeRate", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("text");

                    b.Property<string>("CurrID")
                        .HasColumnType("text");

                    b.Property<decimal>("Rate1")
                        .HasColumnType("numeric(36,18)");

                    b.Property<decimal>("Rate2")
                        .HasColumnType("numeric(36,18)");

                    b.HasKey("ID");

                    b.ToTable("EXRATE");
                });

            modelBuilder.Entity("SystemProject.Models.Other.PrimaryKey", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<string>("KeyNumber")
                        .HasColumnType("text");

                    b.Property<int>("TableName")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.ToTable("PRIMARYKEYS");
                });

            modelBuilder.Entity("SystemProject.Models.UserAccount.UserAccount", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("text");

                    b.Property<string>("BranID")
                        .HasColumnType("text");

                    b.Property<string>("ComID")
                        .HasColumnType("text");

                    b.Property<int>("Gender")
                        .HasColumnType("integer");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("RoleID")
                        .HasColumnType("text");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<string>("Username")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("OUSR");
                });

            modelBuilder.Entity("SystemProject.Models.UsersPrivilege.Function", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("text");

                    b.Property<string>("Code")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("FUNCTI");
                });

            modelBuilder.Entity("SystemProject.Models.UsersPrivilege.Roles", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("text");

                    b.Property<string>("ComID")
                        .HasColumnType("text");

                    b.Property<bool>("Enable")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("ROLES");
                });

            modelBuilder.Entity("SystemProject.Models.UsersPrivilege.RolesPrivilege", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("text");

                    b.Property<bool>("Enable")
                        .HasColumnType("boolean");

                    b.Property<string>("FuncID")
                        .HasColumnType("text");

                    b.Property<string>("RoleID")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("ROLEPRIVI");
                });

            modelBuilder.Entity("SystemProject.Models.UsersPrivilege.UsersPrivilege", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("text");

                    b.Property<bool>("Enable")
                        .HasColumnType("boolean");

                    b.Property<string>("FuncID")
                        .HasColumnType("text");

                    b.Property<string>("RolePriviID")
                        .HasColumnType("text");

                    b.Property<string>("UserID")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("USERPRIVI");
                });
#pragma warning restore 612, 618
        }
    }
}
