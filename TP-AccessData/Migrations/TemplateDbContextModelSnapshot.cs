﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TP_AccessData;

namespace TP_AccessData.Migrations
{
    [DbContext(typeof(TemplateDbContext))]
    partial class TemplateDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TP_Domain.Entities.CalendarioTurnos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("DiaId")
                        .HasColumnType("int");

                    b.Property<DateTime>("HoraFin")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("HoraInicio")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdEspecialista")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DiaId");

                    b.ToTable("CalendarioTurnos");
                });

            modelBuilder.Entity("TP_Domain.Entities.Dia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Dias");
                });

            modelBuilder.Entity("TP_Domain.Entities.Turno", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("HoraFin")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("HoraInicio")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdConsultorio")
                        .HasColumnType("int");

                    b.Property<int>("IdEspecialista")
                        .HasColumnType("int");

                    b.Property<int>("IdPaciente")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Turnos");
                });

            modelBuilder.Entity("TP_Domain.Entities.CalendarioTurnos", b =>
                {
                    b.HasOne("TP_Domain.Entities.Dia", "Dia")
                        .WithMany()
                        .HasForeignKey("DiaId");
                });
#pragma warning restore 612, 618
        }
    }
}