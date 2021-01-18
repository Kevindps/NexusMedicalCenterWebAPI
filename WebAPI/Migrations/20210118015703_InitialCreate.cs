using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    DoctorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorFullName = table.Column<string>(type: "ntext", nullable: false),
                    DoctorCredentialNumber = table.Column<string>(type: "varchar(32)", nullable: false),
                    DoctorSpecialty = table.Column<string>(type: "ntext", nullable: false),
                    DoctorHospital = table.Column<string>(type: "ntext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.DoctorId);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    PatientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientFullName = table.Column<string>(type: "ntext", nullable: false),
                    PatientPostalCode = table.Column<string>(type: "char(6)", nullable: false),
                    PatientSocialSecurityNumber = table.Column<string>(type: "varchar(32)", nullable: false),
                    PatientContactNumber = table.Column<string>(type: "varchar(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.PatientId);
                });

            migrationBuilder.CreateTable(
                name: "NexosMedicalCenterDoctorNexosMedicalCenterPatient",
                columns: table => new
                {
                    doctorPatientsPatientId = table.Column<int>(type: "int", nullable: false),
                    patientDoctorsDoctorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NexosMedicalCenterDoctorNexosMedicalCenterPatient", x => new { x.doctorPatientsPatientId, x.patientDoctorsDoctorId });
                    table.ForeignKey(
                        name: "FK_NexosMedicalCenterDoctorNexosMedicalCenterPatient_Doctors_patientDoctorsDoctorId",
                        column: x => x.patientDoctorsDoctorId,
                        principalTable: "Doctors",
                        principalColumn: "DoctorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NexosMedicalCenterDoctorNexosMedicalCenterPatient_Patients_doctorPatientsPatientId",
                        column: x => x.doctorPatientsPatientId,
                        principalTable: "Patients",
                        principalColumn: "PatientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_DoctorCredentialNumber",
                table: "Doctors",
                column: "DoctorCredentialNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NexosMedicalCenterDoctorNexosMedicalCenterPatient_patientDoctorsDoctorId",
                table: "NexosMedicalCenterDoctorNexosMedicalCenterPatient",
                column: "patientDoctorsDoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_PatientSocialSecurityNumber",
                table: "Patients",
                column: "PatientSocialSecurityNumber",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NexosMedicalCenterDoctorNexosMedicalCenterPatient");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "Patients");
        }
    }
}
