using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreAssignment.Migrations
{
    /// <inheritdoc />
    public partial class AddDatabaseTablestoDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    ContactId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Player = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BusinessPhone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    MobilePhone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.ContactId);
                });

            migrationBuilder.CreateTable(
                name: "EmailTemplates",
                columns: table => new
                {
                    EmailTemplateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmailTemplateName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EmailTemplateSubject = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    EmailTemplateBody = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailTemplates", x => x.EmailTemplateId);
                });

            migrationBuilder.CreateTable(
                name: "Monitorings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Alias = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Aggregate = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Node = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Player = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NodeType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TaskType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SLA = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Shifting = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ProcessDuration = table.Column<int>(type: "int", nullable: true),
                    Contact = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ContactCC = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastControlPosition = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NextReconciliationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Delay = table.Column<int>(type: "int", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Monitorings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Nodes",
                columns: table => new
                {
                    NodeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NodeName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Alias = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Aggregate = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Player = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NodeType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NodeSubType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LifeInsuranceClass = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NodeIdentifier = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PeriodicFormat = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PeriodicFormatStartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TransactionFormat = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TransactionFormatStartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaskType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EmailTemplateId = table.Column<int>(type: "int", nullable: true),
                    SlaId = table.Column<int>(type: "int", nullable: true),
                    Shifting = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ProcessDuration = table.Column<int>(type: "int", nullable: true),
                    ContactId = table.Column<int>(type: "int", nullable: true),
                    ContactCCId = table.Column<int>(type: "int", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nodes", x => x.NodeId);
                });

            migrationBuilder.CreateTable(
                name: "Slas",
                columns: table => new
                {
                    SlaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SlaName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SlaFrequencyTransaction = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SlaFrequencyPosition = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SlaAnniversary = table.Column<bool>(type: "bit", nullable: false),
                    SlaExcludeWeekends = table.Column<bool>(type: "bit", nullable: false),
                    SlaReminderDays = table.Column<int>(type: "int", nullable: true),
                    SlaEscalationDays = table.Column<int>(type: "int", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slas", x => x.SlaId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "EmailTemplates");

            migrationBuilder.DropTable(
                name: "Monitorings");

            migrationBuilder.DropTable(
                name: "Nodes");

            migrationBuilder.DropTable(
                name: "Slas");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
