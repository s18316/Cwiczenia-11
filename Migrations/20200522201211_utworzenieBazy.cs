using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cwiczenia_11.Migrations
{
    public partial class utworzenieBazy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Doctor",
                columns: table => new
                {
                    IdDoctor = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 100, nullable: false),
                    LastName = table.Column<string>(maxLength: 100, nullable: false),
                    Email = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Doctor_PrimaryKey", x => x.IdDoctor);
                });

            migrationBuilder.CreateTable(
                name: "Medicament",
                columns: table => new
                {
                    IdMedicament = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(maxLength: 100, nullable: false),
                    Type = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Medicament_PrimaryKey", x => x.IdMedicament);
                });

            migrationBuilder.CreateTable(
                name: "Patient",
                columns: table => new
                {
                    IdPatient = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 100, nullable: false),
                    LastName = table.Column<string>(maxLength: 100, nullable: false),
                    BirthDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Patient_PrimaryKey", x => x.IdPatient);
                });

            migrationBuilder.CreateTable(
                name: "Prescription",
                columns: table => new
                {
                    IdPrescription = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(nullable: false),
                    DueDate = table.Column<DateTime>(nullable: false),
                    IdDoctor = table.Column<int>(nullable: false),
                    IdPatient = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Prescription_PrimaryKey", x => x.IdPrescription);
                    table.ForeignKey(
                        name: "Prescription-Doctor",
                        column: x => x.IdDoctor,
                        principalTable: "Doctor",
                        principalColumn: "IdDoctor",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Prescription-Patient",
                        column: x => x.IdPatient,
                        principalTable: "Patient",
                        principalColumn: "IdPatient",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Prescription_Medicament",
                columns: table => new
                {
                    IdMedicament = table.Column<int>(nullable: false),
                    IdPrescription = table.Column<int>(nullable: false),
                    Dose = table.Column<int>(nullable: true),
                    Details = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prescription_Medicament", x => new { x.IdMedicament, x.IdPrescription });
                    table.ForeignKey(
                        name: "Medicament-Prescription_Medicament",
                        column: x => x.IdMedicament,
                        principalTable: "Medicament",
                        principalColumn: "IdMedicament",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Prescription_Prescription_Medicament",
                        column: x => x.IdPrescription,
                        principalTable: "Prescription",
                        principalColumn: "IdPrescription",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Doctor",
                columns: new[] { "IdDoctor", "Email", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "mleb@gmail.com", "Mateusz", "Lebski" },
                    { 2, "karDob@gmail.com", "Karolina", "Dobisz" },
                    { 3, "Polec@gmail.com", "Lilia", "Polec" }
                });

            migrationBuilder.InsertData(
                table: "Medicament",
                columns: new[] { "IdMedicament", "Description", "Name", "Type" },
                values: new object[,]
                {
                    { 1, "na bol kolan", "Kram", "przeciw bolowy" },
                    { 2, "Na suche gardlo", "Ramon", "tabletka musujaca" },
                    { 3, "Na problemy ze snem", "Ewanek", "tabletki wspomagajace zasypianie" }
                });

            migrationBuilder.InsertData(
                table: "Patient",
                columns: new[] { "IdPatient", "BirthDate", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, new DateTime(1974, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jakub", "Nowak" },
                    { 2, new DateTime(1991, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Karolina", "Gruszka" },
                    { 3, new DateTime(1944, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pamela", "Naw" },
                    { 4, new DateTime(1923, 8, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Marek", "Dorsz" }
                });

            migrationBuilder.InsertData(
                table: "Prescription",
                columns: new[] { "IdPrescription", "Date", "DueDate", "IdDoctor", "IdPatient" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 5, 22, 22, 12, 10, 826, DateTimeKind.Local).AddTicks(1511), new DateTime(2020, 6, 21, 22, 12, 10, 833, DateTimeKind.Local).AddTicks(4887), 1, 1 },
                    { 2, new DateTime(2020, 5, 22, 22, 12, 10, 833, DateTimeKind.Local).AddTicks(7597), new DateTime(2020, 6, 21, 22, 12, 10, 833, DateTimeKind.Local).AddTicks(7635), 2, 2 },
                    { 3, new DateTime(2020, 5, 22, 22, 12, 10, 833, DateTimeKind.Local).AddTicks(7675), new DateTime(2020, 6, 21, 22, 12, 10, 833, DateTimeKind.Local).AddTicks(7682), 3, 3 },
                    { 4, new DateTime(2020, 5, 22, 22, 12, 10, 833, DateTimeKind.Local).AddTicks(7688), new DateTime(2020, 6, 21, 22, 12, 10, 833, DateTimeKind.Local).AddTicks(7693), 1, 4 }
                });

            migrationBuilder.InsertData(
                table: "Prescription_Medicament",
                columns: new[] { "IdMedicament", "IdPrescription", "Details", "Dose" },
                values: new object[,]
                {
                    { 1, 1, "smarowac do wchloniecia zelu", 3 },
                    { 2, 2, "plukac gardlo przez 30 min", 1 },
                    { 3, 3, "zazyc godzine przed snem", null },
                    { 1, 4, "smarowac do wchloniecia zelu", 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_IdDoctor",
                table: "Prescription",
                column: "IdDoctor");

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_IdPatient",
                table: "Prescription",
                column: "IdPatient");

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_Medicament_IdPrescription",
                table: "Prescription_Medicament",
                column: "IdPrescription");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prescription_Medicament");

            migrationBuilder.DropTable(
                name: "Medicament");

            migrationBuilder.DropTable(
                name: "Prescription");

            migrationBuilder.DropTable(
                name: "Doctor");

            migrationBuilder.DropTable(
                name: "Patient");
        }
    }
}
