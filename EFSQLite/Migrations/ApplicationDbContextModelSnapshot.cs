﻿// <auto-generated />
using System;
using EFSQLite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EFSQLite.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024");

            modelBuilder.Entity("EFSQLite.Direcciones", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Calle");

                    b.Property<string>("Ciudad");

                    b.Property<int>("PersonaId");

                    b.HasKey("Id");

                    b.HasIndex("PersonaId");

                    b.ToTable("Direcciones");
                });

            modelBuilder.Entity("EFSQLite.Persona", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Edad");

                    b.Property<DateTime>("FechaDeNacimiento");

                    b.Property<string>("Nombre");

                    b.HasKey("Id");

                    b.ToTable("Personas");
                });

            modelBuilder.Entity("EFSQLite.Direcciones", b =>
                {
                    b.HasOne("EFSQLite.Persona", "Persona")
                        .WithMany("Direcciones")
                        .HasForeignKey("PersonaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}