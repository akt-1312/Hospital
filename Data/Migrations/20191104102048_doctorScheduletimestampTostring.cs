using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalMS.Data.Migrations
{
    public partial class doctorScheduletimestampTostring : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "StartTime",
                table: "DoctorSchedules",
                nullable: true,
                oldClrType: typeof(TimeSpan));

            migrationBuilder.AlterColumn<string>(
                name: "EndTime",
                table: "DoctorSchedules",
                nullable: true,
                oldClrType: typeof(TimeSpan));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<TimeSpan>(
                name: "StartTime",
                table: "DoctorSchedules",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "EndTime",
                table: "DoctorSchedules",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
