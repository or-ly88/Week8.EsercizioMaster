﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Week8.RepositoryEntityFramework;

#nullable disable

namespace Week8.RepositoryEntityFramework.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Week8.Core.Models.Corso", b =>
                {
                    b.Property<string>("CodiceCorso")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Descrizione")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CodiceCorso");

                    b.ToTable("Corso", (string)null);
                });

            modelBuilder.Entity("Week8.Core.Models.Docente", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("CodiceCorso")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cognome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CorsoCodiceCorso")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumeroDiTelefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("CorsoCodiceCorso");

                    b.ToTable("Docente", (string)null);
                });

            modelBuilder.Entity("Week8.Core.Models.Lezione", b =>
                {
                    b.Property<int>("LezioneID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LezioneID"), 1L, 1);

                    b.Property<string>("Aula")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CodiceCorso")
                        .HasColumnType("int");

                    b.Property<string>("CorsoCodiceCorso")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("DataOraInizio")
                        .HasColumnType("datetime2");

                    b.Property<int>("DocenteId")
                        .HasColumnType("int");

                    b.Property<int>("Durata")
                        .HasColumnType("int");

                    b.HasKey("LezioneID");

                    b.HasIndex("CorsoCodiceCorso");

                    b.HasIndex("DocenteId");

                    b.ToTable("Lezione", (string)null);
                });

            modelBuilder.Entity("Week8.Core.Models.Studente", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("CodiceCorso")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Cognome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataDiNascita")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TitoloDiStudio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("CodiceCorso");

                    b.ToTable("Studente", (string)null);
                });

            modelBuilder.Entity("Week8.Core.Models.Docente", b =>
                {
                    b.HasOne("Week8.Core.Models.Corso", "Corso")
                        .WithMany()
                        .HasForeignKey("CorsoCodiceCorso")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Corso");
                });

            modelBuilder.Entity("Week8.Core.Models.Lezione", b =>
                {
                    b.HasOne("Week8.Core.Models.Corso", "Corso")
                        .WithMany("Lezioni")
                        .HasForeignKey("CorsoCodiceCorso")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Week8.Core.Models.Docente", "Docente")
                        .WithMany("Lezioni")
                        .HasForeignKey("DocenteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Docente ID");

                    b.Navigation("Corso");

                    b.Navigation("Docente");
                });

            modelBuilder.Entity("Week8.Core.Models.Studente", b =>
                {
                    b.HasOne("Week8.Core.Models.Corso", "Corso")
                        .WithMany("Studenti")
                        .HasForeignKey("CodiceCorso")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Codice Corso");

                    b.Navigation("Corso");
                });

            modelBuilder.Entity("Week8.Core.Models.Corso", b =>
                {
                    b.Navigation("Lezioni");

                    b.Navigation("Studenti");
                });

            modelBuilder.Entity("Week8.Core.Models.Docente", b =>
                {
                    b.Navigation("Lezioni");
                });
#pragma warning restore 612, 618
        }
    }
}
