using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Cwiczenia_11.Models
{
    public class SqlDbContext : DbContext
    {
        public DbSet<Doctor> Doctor { get; set; }
        public DbSet<Patient> Patient { get; set; }
        public DbSet<Medicament> Medicament { get; set; }
        public DbSet<Prescription> Prescription { get; set; }

        public DbSet<Prescription_Medicament> Prescription_Medicament { get; set; }

        public SqlDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            List<Doctor> doctors = new List<Doctor>();

            doctors.Add(new Doctor
                {IdDoctor = 1, FirstName = "Mateusz", LastName = "Lebski", Email = "mleb@gmail.com"});
            doctors.Add(new Doctor
                {IdDoctor = 2, FirstName = "Karolina", LastName = "Dobisz", Email = "karDob@gmail.com"});
            doctors.Add(new Doctor {IdDoctor = 3, FirstName = "Lilia", LastName = "Polec", Email = "Polec@gmail.com"});

            modelBuilder.Entity<Doctor>(e =>
            {
                e.HasKey(e => e.IdDoctor).HasName("Doctor_PrimaryKey");
                e.Property(e => e.FirstName).HasMaxLength(100).IsRequired();
                e.Property(e => e.LastName).HasMaxLength(100).IsRequired();
                e.Property(e => e.Email).HasMaxLength(100).IsRequired();
                e.HasData(doctors);
            });

            List<Patient> patients = new List<Patient>();
            patients.Add(new Patient
                {IdPatient = 1, FirstName = "Jakub", LastName = "Nowak", BirthDate = DateTime.Parse("20.01.1974")});
            patients.Add(new Patient
            {
                IdPatient = 2, FirstName = "Karolina", LastName = "Gruszka", BirthDate = DateTime.Parse("11.11.1991")
            });
            patients.Add(new Patient
                {IdPatient = 3, FirstName = "Pamela", LastName = "Naw", BirthDate = DateTime.Parse("13.05.1944")});
            patients.Add(new Patient
                {IdPatient = 4, FirstName = "Marek", LastName = "Dorsz", BirthDate = DateTime.Parse("24.08.1923")});

            modelBuilder.Entity<Patient>(e =>
            {
                //primary key
                e.HasKey(e => e.IdPatient).HasName("Patient_PrimaryKey");
                e.Property(e => e.FirstName).HasMaxLength(100).IsRequired();
                e.Property(e => e.LastName).HasMaxLength(100).IsRequired();
                e.Property(e => e.BirthDate).IsRequired();
                e.HasData(patients);
            });

            //uzupelnianko

            List<Medicament> medicament = new List<Medicament>();

            medicament.Add(new Medicament
                {IdMedicament = 1, Name = "Kram", Description = "na bol kolan", Type = "przeciw bolowy"});
            medicament.Add(new Medicament
                {IdMedicament = 2, Name = "Ramon", Description = "Na suche gardlo", Type = "tabletka musujaca"});
            medicament.Add(new Medicament
            {
                IdMedicament = 3, Name = "Ewanek", Description = "Na problemy ze snem",
                Type = "tabletki wspomagajace zasypianie"
            });


            modelBuilder.Entity<Medicament>(e =>
            {
                //primary key
                e.HasKey(e => e.IdMedicament).HasName("Medicament_PrimaryKey");
                e.Property(e => e.Name).HasMaxLength(100).IsRequired();
                e.Property(e => e.Description).HasMaxLength(100).IsRequired();
                e.Property(e => e.Type).HasMaxLength(100).IsRequired();
                e.HasData(medicament);
            });


            List<Prescription> prescriptions = new List<Prescription>();


            prescriptions.Add(new Prescription {IdPrescription = 1, Date = DateTime.Now, DueDate = DateTime.Now.AddDays(30), IdPatient = 1, IdDoctor = 1});
            prescriptions.Add(new Prescription {IdPrescription = 2, Date = DateTime.Now, DueDate = DateTime.Now.AddDays(30), IdPatient = 2, IdDoctor = 2});
            prescriptions.Add(new Prescription {IdPrescription = 3, Date = DateTime.Now, DueDate = DateTime.Now.AddDays(30), IdPatient = 3, IdDoctor = 3});
            prescriptions.Add(new Prescription {IdPrescription = 4, Date = DateTime.Now, DueDate = DateTime.Now.AddDays(30), IdPatient = 4, IdDoctor = 1});


            modelBuilder.Entity<Prescription>(e =>
            {
                //Primary key
                e.HasKey(e => e.IdPrescription).HasName("Prescription_PrimaryKey");
                e.Property(e => e.Date).IsRequired();
                e.Property(e => e.DueDate).IsRequired();


                //polaczenie Doctor - Prescription
                e.HasOne(e => e.Doctor)
                    .WithMany(e => e.Prescriptions)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasForeignKey(e => e.IdDoctor)
                    .HasConstraintName("Prescription-Doctor");

                //polaczenie Patient-Prescription
                e.HasOne(e => e.Patient)
                    .WithMany(e => e.Prescription)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasForeignKey(e => e.IdPatient)
                    .HasConstraintName("Prescription-Patient");

                e.HasData(prescriptions);
            });


            List<Prescription_Medicament> prescriptionMedicaments = new List<Prescription_Medicament>();

            prescriptionMedicaments.Add(new Prescription_Medicament
                {IdMedicament = 1, IdPrescription = 1, Dose = 3, Details = "smarowac do wchloniecia zelu"});
            prescriptionMedicaments.Add(new Prescription_Medicament
                {IdMedicament = 2, IdPrescription = 2, Dose = 1, Details = "plukac gardlo przez 30 min"});
            prescriptionMedicaments.Add(new Prescription_Medicament
                {IdMedicament = 3, IdPrescription = 3, Details = "zazyc godzine przed snem"});
            prescriptionMedicaments.Add(new Prescription_Medicament
                {IdMedicament = 1, IdPrescription = 4, Dose = 5, Details = "smarowac do wchloniecia zelu"});


            modelBuilder.Entity<Prescription_Medicament>(e =>
            {
                e.HasKey(e => new {e.IdMedicament, e.IdPrescription});
                e.Property(e => e.Details).HasMaxLength(100).IsRequired();


                // laczenie persription - perscription medicament
                e.HasOne(e => e.Prescription)
                    .WithMany(e => e.Prescription_Medicament)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasForeignKey(e => e.IdPrescription)
                    .HasConstraintName("Prescription_Prescription_Medicament");

                //laczenie medicament - perscription medicament
                e.HasOne(e => e.Medicament)
                    .WithMany(e => e.PrescriptionMedicament)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasForeignKey(e => e.IdMedicament)
                    .HasConstraintName("Medicament-Prescription_Medicament");
                e.HasData(prescriptionMedicaments);
            });
        }
    }
}