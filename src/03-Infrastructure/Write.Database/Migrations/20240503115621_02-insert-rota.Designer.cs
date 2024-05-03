﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RotaDeViagem.DatabaseRepository.Context;

#nullable disable

namespace RotaDeViagem.Write.Database.Migrations
{
    [DbContext(typeof(RotaDeViagemContext))]
    [Migration("20240503115621_02-insert-rota")]
    partial class _02insertrota
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RotaDeViagem.Domain.Entities.Rota", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)");

                    b.Property<string>("Destino")
                        .IsRequired()
                        .HasColumnType("varchar(3)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)");

                    b.Property<string>("Origem")
                        .IsRequired()
                        .HasColumnType("varchar(3)");

                    b.Property<Guid>("UniqueId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(8,2)");

                    b.HasKey("Id");

                    b.ToTable("Rota", "dbo");

                    b.HasData(
                        new
                        {
                            Id = 6,
                            CreatedAt = new DateTime(2024, 5, 3, 8, 56, 21, 204, DateTimeKind.Local).AddTicks(8301),
                            CreatedBy = "1",
                            Destino = "BRC",
                            IsDeleted = false,
                            Origem = "GRU",
                            UniqueId = new Guid("7c7bb765-2e9c-437c-a784-2f9c99d151e0"),
                            Valor = 10m
                        },
                        new
                        {
                            Id = 7,
                            CreatedAt = new DateTime(2024, 5, 3, 8, 56, 21, 204, DateTimeKind.Local).AddTicks(8322),
                            CreatedBy = "1",
                            Destino = "SCL",
                            IsDeleted = false,
                            Origem = "BRC",
                            UniqueId = new Guid("2d490c3f-2e33-4514-926f-fdb6057a838b"),
                            Valor = 5m
                        },
                        new
                        {
                            Id = 8,
                            CreatedAt = new DateTime(2024, 5, 3, 8, 56, 21, 204, DateTimeKind.Local).AddTicks(8324),
                            CreatedBy = "1",
                            Destino = "CDG",
                            IsDeleted = false,
                            Origem = "GRU",
                            UniqueId = new Guid("871ad9ec-e8cf-4335-9847-091ffc3be2d2"),
                            Valor = 75m
                        },
                        new
                        {
                            Id = 9,
                            CreatedAt = new DateTime(2024, 5, 3, 8, 56, 21, 204, DateTimeKind.Local).AddTicks(8326),
                            CreatedBy = "1",
                            Destino = "SCL",
                            IsDeleted = false,
                            Origem = "GRU",
                            UniqueId = new Guid("de7411f4-e2a5-4832-886f-22866f4698a2"),
                            Valor = 20m
                        },
                        new
                        {
                            Id = 10,
                            CreatedAt = new DateTime(2024, 5, 3, 8, 56, 21, 204, DateTimeKind.Local).AddTicks(8328),
                            CreatedBy = "1",
                            Destino = "ORL",
                            IsDeleted = false,
                            Origem = "GRU",
                            UniqueId = new Guid("7abc463d-b4ff-4eb1-a077-bae6da7d461a"),
                            Valor = 56m
                        },
                        new
                        {
                            Id = 11,
                            CreatedAt = new DateTime(2024, 5, 3, 8, 56, 21, 204, DateTimeKind.Local).AddTicks(8329),
                            CreatedBy = "1",
                            Destino = "CDG",
                            IsDeleted = false,
                            Origem = "ORL",
                            UniqueId = new Guid("fefa25b3-8784-4d5e-92a6-35a0550ed428"),
                            Valor = 5m
                        },
                        new
                        {
                            Id = 12,
                            CreatedAt = new DateTime(2024, 5, 3, 8, 56, 21, 204, DateTimeKind.Local).AddTicks(8331),
                            CreatedBy = "1",
                            Destino = "ORL",
                            IsDeleted = false,
                            Origem = "SCL",
                            UniqueId = new Guid("77699955-4f0f-4d23-9f8b-248232b02a75"),
                            Valor = 20m
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
