using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VehicleParkingAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddTableSlotAreaAndBkkongSlot : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    VehicleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleCategoryID = table.Column<int>(type: "int", nullable: false),
                    VehicleCompany = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Photo = table.Column<string>(type: "nvarchar(500)", nullable: true),
                    VehicleModel = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    VehicleNumber = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    OwnerName = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    OwnerMobileNo = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.VehicleID);
                    table.ForeignKey(
                        name: "FK_Vehicles_VehicleCategorys_VehicleCategoryID",
                        column: x => x.VehicleCategoryID,
                        principalTable: "VehicleCategorys",
                        principalColumn: "VehicleCategoryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_VehicleCategoryID",
                table: "Vehicles",
                column: "VehicleCategoryID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vehicles");
        }
    }
}
