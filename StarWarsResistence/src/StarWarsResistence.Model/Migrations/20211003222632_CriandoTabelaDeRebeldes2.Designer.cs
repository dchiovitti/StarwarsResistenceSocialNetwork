﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StarWarsResistence.Model;

namespace StarWarsResistence.Model.Migrations
{
    [DbContext(typeof(ApiContext))]
    [Migration("20211003222632_CriandoTabelaDeRebeldes2")]
    partial class CriandoTabelaDeRebeldes2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("dbo")
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.4");

            modelBuilder.Entity("StarWarsResistence.Model.Entities.MyEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Col")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("MyEntity", "dbo");
                });

            modelBuilder.Entity("StarWarsResistence.Model.Entities.Rebelde", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("genero")
                        .HasColumnType("int");

                    b.Property<uint>("idade")
                        .HasColumnType("int unsigned");

                    b.Property<string>("nome")
                        .HasColumnType("text");

                    b.Property<int>("statusRebelde")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Rebeldes");
                });
#pragma warning restore 612, 618
        }
    }
}
