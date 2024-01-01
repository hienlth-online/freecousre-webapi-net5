﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyWebApiApp.Data;

namespace MyWebApiApp.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20240101181933_Transaction")]
    partial class Transaction
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MyWebApiApp.Data.Category", b =>
                {
                    b.Property<int>("category_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("category_name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("category_id");

                    b.ToTable("category");
                });

            modelBuilder.Entity("MyWebApiApp.Data.Transaction", b =>
                {
                    b.Property<Guid>("transaction_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("amount")
                        .HasColumnType("float");

                    b.Property<int>("category_id")
                        .HasColumnType("int");

                    b.Property<DateTime>("created_at")
                        .HasColumnType("datetime2");

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("type_id")
                        .HasColumnType("int");

                    b.Property<Guid>("user_id")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("transaction_id");

                    b.HasIndex("category_id");

                    b.HasIndex("type_id");

                    b.HasIndex("user_id");

                    b.ToTable("transaction");
                });

            modelBuilder.Entity("MyWebApiApp.Data.Type", b =>
                {
                    b.Property<int>("type_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("type_name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("type_id");

                    b.ToTable("type");
                });

            modelBuilder.Entity("MyWebApiApp.Data.User", b =>
                {
                    b.Property<Guid>("user_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("user_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("user_id");

                    b.ToTable("user");
                });

            modelBuilder.Entity("MyWebApiApp.Data.Transaction", b =>
                {
                    b.HasOne("MyWebApiApp.Data.Category", "category")
                        .WithMany("transactions")
                        .HasForeignKey("category_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyWebApiApp.Data.Type", "type")
                        .WithMany("transactions")
                        .HasForeignKey("type_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyWebApiApp.Data.User", "user")
                        .WithMany("transactions")
                        .HasForeignKey("user_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("category");

                    b.Navigation("type");

                    b.Navigation("user");
                });

            modelBuilder.Entity("MyWebApiApp.Data.Category", b =>
                {
                    b.Navigation("transactions");
                });

            modelBuilder.Entity("MyWebApiApp.Data.Type", b =>
                {
                    b.Navigation("transactions");
                });

            modelBuilder.Entity("MyWebApiApp.Data.User", b =>
                {
                    b.Navigation("transactions");
                });
#pragma warning restore 612, 618
        }
    }
}
