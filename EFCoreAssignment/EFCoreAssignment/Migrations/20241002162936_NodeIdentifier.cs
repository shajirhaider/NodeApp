using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreAssignment.Migrations
{
    /// <inheritdoc />
    public partial class NodeIdentifier : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NodeIdentifier",
                table: "Nodes",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NodeIdentifier",
                table: "Nodes");
        }
    }
}
