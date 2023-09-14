using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InvoiceAutomation.Migrations
{
    /// <inheritdoc />
    public partial class pupa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Data_Of_Creation",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "Document_Number",
                table: "Invoice");

            migrationBuilder.RenameColumn(
                name: "Sender_Code",
                table: "Invoice",
                newName: "SenderCode");

            migrationBuilder.RenameColumn(
                name: "Recipient_Code",
                table: "Invoice",
                newName: "RecipientCode");

            migrationBuilder.RenameColumn(
                name: "Item_Number",
                table: "Invoice",
                newName: "ItemNumber");

            migrationBuilder.RenameColumn(
                name: "Invoice_Number",
                table: "Invoice",
                newName: "InvoiceNumber");

            migrationBuilder.RenameColumn(
                name: "Cost_Code",
                table: "Invoice",
                newName: "DocumentNumber");

            migrationBuilder.AlterColumn<string>(
                name: "Quantity",
                table: "Invoice",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Price",
                table: "Invoice",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<int>(
                name: "Accepted",
                table: "Invoice",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "CostCode",
                table: "Invoice",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DataOfCreation",
                table: "Invoice",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CostCode",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "DataOfCreation",
                table: "Invoice");

            migrationBuilder.RenameColumn(
                name: "SenderCode",
                table: "Invoice",
                newName: "Sender_Code");

            migrationBuilder.RenameColumn(
                name: "RecipientCode",
                table: "Invoice",
                newName: "Recipient_Code");

            migrationBuilder.RenameColumn(
                name: "ItemNumber",
                table: "Invoice",
                newName: "Item_Number");

            migrationBuilder.RenameColumn(
                name: "InvoiceNumber",
                table: "Invoice",
                newName: "Invoice_Number");

            migrationBuilder.RenameColumn(
                name: "DocumentNumber",
                table: "Invoice",
                newName: "Cost_Code");

            migrationBuilder.AlterColumn<int>(
                name: "Quantity",
                table: "Invoice",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<float>(
                name: "Price",
                table: "Invoice",
                type: "real",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Accepted",
                table: "Invoice",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<DateTime>(
                name: "Data_Of_Creation",
                table: "Invoice",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Document_Number",
                table: "Invoice",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
