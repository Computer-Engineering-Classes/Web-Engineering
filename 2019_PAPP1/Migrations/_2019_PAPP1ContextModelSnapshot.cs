﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using _2019_PAPP1.Data;

namespace _2019_PAPP1.Migrations
{
    [DbContext(typeof(_2019_PAPP1Context))]
    partial class _2019_PAPP1ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("_2019_PAPP1.Models.Carro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Equipa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Carro");
                });

            modelBuilder.Entity("_2019_PAPP1.Models.Piloto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CarroId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Pontos")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CarroId");

                    b.ToTable("Piloto");
                });

            modelBuilder.Entity("_2019_PAPP1.Models.Piloto", b =>
                {
                    b.HasOne("_2019_PAPP1.Models.Carro", "Carro")
                        .WithMany()
                        .HasForeignKey("CarroId");

                    b.Navigation("Carro");
                });
#pragma warning restore 612, 618
        }
    }
}
