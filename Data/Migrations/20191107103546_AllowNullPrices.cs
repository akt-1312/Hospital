using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalMS.Data.Migrations
{
    public partial class AllowNullPrices : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "LocalPrice",
                table: "ServicePrices",
                nullable: true,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<double>(
                name: "ForeignerFormulaPrice",
                table: "ServicePrices",
                nullable: true,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<double>(
                name: "ForeignerFixedPrice",
                table: "ServicePrices",
                nullable: true,
                oldClrType: typeof(double));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "LocalPrice",
                table: "ServicePrices",
                nullable: false,
                oldClrType: typeof(double),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "ForeignerFormulaPrice",
                table: "ServicePrices",
                nullable: false,
                oldClrType: typeof(double),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "ForeignerFixedPrice",
                table: "ServicePrices",
                nullable: false,
                oldClrType: typeof(double),
                oldNullable: true);
        }
    }
}
