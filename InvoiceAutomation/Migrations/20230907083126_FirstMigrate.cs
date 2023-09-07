using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InvoiceAutomation.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigrate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Invoice",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Invoice_Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Document_Number = table.Column<int>(type: "int", nullable: false),
                    Data_Of_Creation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Sender_Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Recipient_Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Serial_Number = table.Column<int>(type: "int", nullable: false),
                    Cost_Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Item_Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    Sum = table.Column<float>(type: "real", nullable: false),
                    Allowed = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Controller = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Passed = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Accepted = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoice", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Invoice");
        }
    }
}
