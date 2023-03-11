﻿// <auto-generated />
using System;
using Lucrare_licenta.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Lucrare_licenta.Migrations
{
    [DbContext(typeof(Lucrare_licentaContext))]
    [Migration("20230311200255_vehiculeNOU")]
    partial class vehiculeNOU
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Lucrare_licenta.Models.CategorieVehicul", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("CategoriaVehicul")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("CategorieVehicul");
                });

            modelBuilder.Entity("Lucrare_licenta.Models.Client", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("ActivitateSocietate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CNP")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CUI")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CodPostal")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Judet")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Localitate")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Numar")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumarCI")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumeFirma")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("NumeProprietar")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("NumeReprezentantFirma")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("PrenumeProprietar")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("PrenumeReprezentantFirma")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("SerieCI")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Strada")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Telefon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TipSocietateID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("TipSocietateID");

                    b.ToTable("Client");
                });

            modelBuilder.Entity("Lucrare_licenta.Models.Oferta", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("AnFabricatie")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CapacitateCilindrica")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CategorieVehiculID")
                        .HasColumnType("int");

                    b.Property<int?>("ClientID")
                        .HasColumnType("int");

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MasaMaxima")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NrInmatriculare")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NrLocuri")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumarIdentificare")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Putere")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SerieCIV")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TipCombustibilID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CategorieVehiculID");

                    b.HasIndex("ClientID");

                    b.HasIndex("TipCombustibilID");

                    b.ToTable("Oferta");
                });

            modelBuilder.Entity("Lucrare_licenta.Models.PersoanaFizica", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int?>("ClientID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ClientID");

                    b.ToTable("PersoanaFizica");
                });

            modelBuilder.Entity("Lucrare_licenta.Models.PersoanaJuridica", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int?>("ClientID")
                        .HasColumnType("int");

                    b.Property<int?>("TipSocietateID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ClientID");

                    b.HasIndex("TipSocietateID");

                    b.ToTable("PersoanaJuridica");
                });

            modelBuilder.Entity("Lucrare_licenta.Models.TipCombustibil", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("TipulCombustibil")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("TipCombustibil");
                });

            modelBuilder.Entity("Lucrare_licenta.Models.TipSocietate", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("TipulSocietate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("TipSocietate");
                });

            modelBuilder.Entity("Lucrare_licenta.Models.Vehicul", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int?>("CategorieVehiculID")
                        .HasColumnType("int");

                    b.Property<int?>("OfertaID")
                        .HasColumnType("int");

                    b.Property<int?>("TipCombustibilID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CategorieVehiculID");

                    b.HasIndex("OfertaID");

                    b.HasIndex("TipCombustibilID");

                    b.ToTable("Vehicul");
                });

            modelBuilder.Entity("Lucrare_licenta.Models.Client", b =>
                {
                    b.HasOne("Lucrare_licenta.Models.TipSocietate", "TipSocietate")
                        .WithMany("Client")
                        .HasForeignKey("TipSocietateID");

                    b.Navigation("TipSocietate");
                });

            modelBuilder.Entity("Lucrare_licenta.Models.Oferta", b =>
                {
                    b.HasOne("Lucrare_licenta.Models.CategorieVehicul", "CategorieVehicul")
                        .WithMany("Oferte")
                        .HasForeignKey("CategorieVehiculID");

                    b.HasOne("Lucrare_licenta.Models.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientID");

                    b.HasOne("Lucrare_licenta.Models.TipCombustibil", "TipCombustibil")
                        .WithMany("Oferte")
                        .HasForeignKey("TipCombustibilID");

                    b.Navigation("CategorieVehicul");

                    b.Navigation("Client");

                    b.Navigation("TipCombustibil");
                });

            modelBuilder.Entity("Lucrare_licenta.Models.PersoanaFizica", b =>
                {
                    b.HasOne("Lucrare_licenta.Models.Client", "Client")
                        .WithMany("PersoaneFizice")
                        .HasForeignKey("ClientID");

                    b.Navigation("Client");
                });

            modelBuilder.Entity("Lucrare_licenta.Models.PersoanaJuridica", b =>
                {
                    b.HasOne("Lucrare_licenta.Models.Client", "Client")
                        .WithMany("PersoaneJuridice")
                        .HasForeignKey("ClientID");

                    b.HasOne("Lucrare_licenta.Models.TipSocietate", "TipSocietate")
                        .WithMany("PersoaneJuridice")
                        .HasForeignKey("TipSocietateID");

                    b.Navigation("Client");

                    b.Navigation("TipSocietate");
                });

            modelBuilder.Entity("Lucrare_licenta.Models.Vehicul", b =>
                {
                    b.HasOne("Lucrare_licenta.Models.CategorieVehicul", null)
                        .WithMany("Vehicule")
                        .HasForeignKey("CategorieVehiculID");

                    b.HasOne("Lucrare_licenta.Models.Oferta", "Oferte")
                        .WithMany()
                        .HasForeignKey("OfertaID");

                    b.HasOne("Lucrare_licenta.Models.TipCombustibil", null)
                        .WithMany("Vehicule")
                        .HasForeignKey("TipCombustibilID");

                    b.Navigation("Oferte");
                });

            modelBuilder.Entity("Lucrare_licenta.Models.CategorieVehicul", b =>
                {
                    b.Navigation("Oferte");

                    b.Navigation("Vehicule");
                });

            modelBuilder.Entity("Lucrare_licenta.Models.Client", b =>
                {
                    b.Navigation("PersoaneFizice");

                    b.Navigation("PersoaneJuridice");
                });

            modelBuilder.Entity("Lucrare_licenta.Models.TipCombustibil", b =>
                {
                    b.Navigation("Oferte");

                    b.Navigation("Vehicule");
                });

            modelBuilder.Entity("Lucrare_licenta.Models.TipSocietate", b =>
                {
                    b.Navigation("Client");

                    b.Navigation("PersoaneJuridice");
                });
#pragma warning restore 612, 618
        }
    }
}
