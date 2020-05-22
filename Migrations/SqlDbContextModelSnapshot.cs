﻿// <auto-generated />
using System;
using Cwiczenia_11.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Cwiczenia_11.Migrations
{
    [DbContext(typeof(SqlDbContext))]
    partial class SqlDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Cwiczenia_11.Models.Doctor", b =>
                {
                    b.Property<int>("IdDoctor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("IdDoctor")
                        .HasName("Doctor_PrimaryKey");

                    b.ToTable("Doctor");

                    b.HasData(
                        new
                        {
                            IdDoctor = 1,
                            Email = "mleb@gmail.com",
                            FirstName = "Mateusz",
                            LastName = "Lebski"
                        },
                        new
                        {
                            IdDoctor = 2,
                            Email = "karDob@gmail.com",
                            FirstName = "Karolina",
                            LastName = "Dobisz"
                        },
                        new
                        {
                            IdDoctor = 3,
                            Email = "Polec@gmail.com",
                            FirstName = "Lilia",
                            LastName = "Polec"
                        });
                });

            modelBuilder.Entity("Cwiczenia_11.Models.Medicament", b =>
                {
                    b.Property<int>("IdMedicament")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("IdMedicament")
                        .HasName("Medicament_PrimaryKey");

                    b.ToTable("Medicament");

                    b.HasData(
                        new
                        {
                            IdMedicament = 1,
                            Description = "na bol kolan",
                            Name = "Kram",
                            Type = "przeciw bolowy"
                        },
                        new
                        {
                            IdMedicament = 2,
                            Description = "Na suche gardlo",
                            Name = "Ramon",
                            Type = "tabletka musujaca"
                        },
                        new
                        {
                            IdMedicament = 3,
                            Description = "Na problemy ze snem",
                            Name = "Ewanek",
                            Type = "tabletki wspomagajace zasypianie"
                        });
                });

            modelBuilder.Entity("Cwiczenia_11.Models.Patient", b =>
                {
                    b.Property<int>("IdPatient")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("IdPatient")
                        .HasName("Patient_PrimaryKey");

                    b.ToTable("Patient");

                    b.HasData(
                        new
                        {
                            IdPatient = 1,
                            BirthDate = new DateTime(1974, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Jakub",
                            LastName = "Nowak"
                        },
                        new
                        {
                            IdPatient = 2,
                            BirthDate = new DateTime(1991, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Karolina",
                            LastName = "Gruszka"
                        },
                        new
                        {
                            IdPatient = 3,
                            BirthDate = new DateTime(1944, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Pamela",
                            LastName = "Naw"
                        },
                        new
                        {
                            IdPatient = 4,
                            BirthDate = new DateTime(1923, 8, 24, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Marek",
                            LastName = "Dorsz"
                        });
                });

            modelBuilder.Entity("Cwiczenia_11.Models.Prescription", b =>
                {
                    b.Property<int>("IdPrescription")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdDoctor")
                        .HasColumnType("int");

                    b.Property<int>("IdPatient")
                        .HasColumnType("int");

                    b.HasKey("IdPrescription")
                        .HasName("Prescription_PrimaryKey");

                    b.HasIndex("IdDoctor");

                    b.HasIndex("IdPatient");

                    b.ToTable("Prescription");

                    b.HasData(
                        new
                        {
                            IdPrescription = 1,
                            Date = new DateTime(2020, 5, 22, 22, 12, 10, 826, DateTimeKind.Local).AddTicks(1511),
                            DueDate = new DateTime(2020, 6, 21, 22, 12, 10, 833, DateTimeKind.Local).AddTicks(4887),
                            IdDoctor = 1,
                            IdPatient = 1
                        },
                        new
                        {
                            IdPrescription = 2,
                            Date = new DateTime(2020, 5, 22, 22, 12, 10, 833, DateTimeKind.Local).AddTicks(7597),
                            DueDate = new DateTime(2020, 6, 21, 22, 12, 10, 833, DateTimeKind.Local).AddTicks(7635),
                            IdDoctor = 2,
                            IdPatient = 2
                        },
                        new
                        {
                            IdPrescription = 3,
                            Date = new DateTime(2020, 5, 22, 22, 12, 10, 833, DateTimeKind.Local).AddTicks(7675),
                            DueDate = new DateTime(2020, 6, 21, 22, 12, 10, 833, DateTimeKind.Local).AddTicks(7682),
                            IdDoctor = 3,
                            IdPatient = 3
                        },
                        new
                        {
                            IdPrescription = 4,
                            Date = new DateTime(2020, 5, 22, 22, 12, 10, 833, DateTimeKind.Local).AddTicks(7688),
                            DueDate = new DateTime(2020, 6, 21, 22, 12, 10, 833, DateTimeKind.Local).AddTicks(7693),
                            IdDoctor = 1,
                            IdPatient = 4
                        });
                });

            modelBuilder.Entity("Cwiczenia_11.Models.Prescription_Medicament", b =>
                {
                    b.Property<int>("IdMedicament")
                        .HasColumnType("int");

                    b.Property<int>("IdPrescription")
                        .HasColumnType("int");

                    b.Property<string>("Details")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<int?>("Dose")
                        .HasColumnType("int");

                    b.HasKey("IdMedicament", "IdPrescription");

                    b.HasIndex("IdPrescription");

                    b.ToTable("Prescription_Medicament");

                    b.HasData(
                        new
                        {
                            IdMedicament = 1,
                            IdPrescription = 1,
                            Details = "smarowac do wchloniecia zelu",
                            Dose = 3
                        },
                        new
                        {
                            IdMedicament = 2,
                            IdPrescription = 2,
                            Details = "plukac gardlo przez 30 min",
                            Dose = 1
                        },
                        new
                        {
                            IdMedicament = 3,
                            IdPrescription = 3,
                            Details = "zazyc godzine przed snem"
                        },
                        new
                        {
                            IdMedicament = 1,
                            IdPrescription = 4,
                            Details = "smarowac do wchloniecia zelu",
                            Dose = 5
                        });
                });

            modelBuilder.Entity("Cwiczenia_11.Models.Prescription", b =>
                {
                    b.HasOne("Cwiczenia_11.Models.Doctor", "Doctor")
                        .WithMany("Prescriptions")
                        .HasForeignKey("IdDoctor")
                        .HasConstraintName("Prescription-Doctor")
                        .IsRequired();

                    b.HasOne("Cwiczenia_11.Models.Patient", "Patient")
                        .WithMany("Prescription")
                        .HasForeignKey("IdPatient")
                        .HasConstraintName("Prescription-Patient")
                        .IsRequired();
                });

            modelBuilder.Entity("Cwiczenia_11.Models.Prescription_Medicament", b =>
                {
                    b.HasOne("Cwiczenia_11.Models.Medicament", "Medicament")
                        .WithMany("PrescriptionMedicament")
                        .HasForeignKey("IdMedicament")
                        .HasConstraintName("Medicament-Prescription_Medicament")
                        .IsRequired();

                    b.HasOne("Cwiczenia_11.Models.Prescription", "Prescription")
                        .WithMany("Prescription_Medicament")
                        .HasForeignKey("IdPrescription")
                        .HasConstraintName("Prescription_Prescription_Medicament")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}