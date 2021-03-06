﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebAPI.Models;

namespace WebAPI.Migrations
{
    [DbContext(typeof(NexosMedicalCenterContext))]
    [Migration("20210118015703_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("NexosMedicalCenterDoctorNexosMedicalCenterPatient", b =>
                {
                    b.Property<int>("doctorPatientsPatientId")
                        .HasColumnType("int");

                    b.Property<int>("patientDoctorsDoctorId")
                        .HasColumnType("int");

                    b.HasKey("doctorPatientsPatientId", "patientDoctorsDoctorId");

                    b.HasIndex("patientDoctorsDoctorId");

                    b.ToTable("NexosMedicalCenterDoctorNexosMedicalCenterPatient");
                });

            modelBuilder.Entity("WebAPI.Models.NexosMedicalCenterDoctor", b =>
                {
                    b.Property<int>("DoctorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("DoctorCredentialNumber")
                        .IsRequired()
                        .HasColumnType("varchar(32)");

                    b.Property<string>("DoctorFullName")
                        .IsRequired()
                        .HasColumnType("ntext");

                    b.Property<string>("DoctorHospital")
                        .IsRequired()
                        .HasColumnType("ntext");

                    b.Property<string>("DoctorSpecialty")
                        .IsRequired()
                        .HasColumnType("ntext");

                    b.HasKey("DoctorId");

                    b.HasIndex("DoctorCredentialNumber")
                        .IsUnique();

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("WebAPI.Models.NexosMedicalCenterPatient", b =>
                {
                    b.Property<int>("PatientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("PatientContactNumber")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.Property<string>("PatientFullName")
                        .IsRequired()
                        .HasColumnType("ntext");

                    b.Property<string>("PatientPostalCode")
                        .IsRequired()
                        .HasColumnType("char(6)");

                    b.Property<string>("PatientSocialSecurityNumber")
                        .IsRequired()
                        .HasColumnType("varchar(32)");

                    b.HasKey("PatientId");

                    b.HasIndex("PatientSocialSecurityNumber")
                        .IsUnique();

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("NexosMedicalCenterDoctorNexosMedicalCenterPatient", b =>
                {
                    b.HasOne("WebAPI.Models.NexosMedicalCenterPatient", null)
                        .WithMany()
                        .HasForeignKey("doctorPatientsPatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebAPI.Models.NexosMedicalCenterDoctor", null)
                        .WithMany()
                        .HasForeignKey("patientDoctorsDoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
