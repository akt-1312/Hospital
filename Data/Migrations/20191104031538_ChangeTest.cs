using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalMS.Data.Migrations
{
    public partial class ChangeTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApprovedBy",
                table: "Tests");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Tests");

            migrationBuilder.DropColumn(
                name: "Department",
                table: "Tests");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Tests");

            migrationBuilder.DropColumn(
                name: "ExpectedReturnDate",
                table: "Tests");

            migrationBuilder.DropColumn(
                name: "From",
                table: "Tests");

            migrationBuilder.DropColumn(
                name: "HeadOfDepartment",
                table: "Tests");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Tests");

            migrationBuilder.DropColumn(
                name: "Reason",
                table: "Tests");

            migrationBuilder.DropColumn(
                name: "SerialNo",
                table: "Tests");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Tests",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Recipient",
                table: "Tests",
                newName: "Country");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Tests",
                newName: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Tests",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "Country",
                table: "Tests",
                newName: "Recipient");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "Tests",
                newName: "Id");

            migrationBuilder.AddColumn<string>(
                name: "ApprovedBy",
                table: "Tests",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Tests",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Department",
                table: "Tests",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Tests",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpectedReturnDate",
                table: "Tests",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "From",
                table: "Tests",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HeadOfDepartment",
                table: "Tests",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Tests",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Reason",
                table: "Tests",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SerialNo",
                table: "Tests",
                nullable: false,
                defaultValue: 0);
        }
    }
}
