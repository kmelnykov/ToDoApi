using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ToDoItems",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    IsComplete = table.Column<bool>(type: "boolean", nullable: false),
                    DueDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Priority = table.Column<int>(type: "integer", nullable: false),
                    RecurrenceInterval = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToDoItems", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ToDoItems",
                columns: new[] { "Id", "DueDate", "IsComplete", "Name", "Priority", "RecurrenceInterval" },
                values: new object[,]
                {
                    { 1L, new DateTime(2024, 11, 4, 18, 48, 37, 823, DateTimeKind.Utc).AddTicks(1856), false, "Learn C#", 2, null },
                    { 2L, new DateTime(2024, 11, 7, 18, 48, 37, 823, DateTimeKind.Utc).AddTicks(1868), false, "Build a Web API", 1, null },
                    { 3L, new DateTime(2024, 11, 12, 18, 48, 37, 823, DateTimeKind.Utc).AddTicks(1870), false, "Test the API", 2, null },
                    { 4L, new DateTime(2024, 11, 17, 18, 48, 37, 823, DateTimeKind.Utc).AddTicks(1872), false, "Deploy to Production", 2, null },
                    { 5L, null, true, "Celebrate", 0, null },
                    { 6L, new DateTime(2024, 11, 2, 18, 48, 37, 823, DateTimeKind.Utc).AddTicks(1874), false, "Write Documentation", 1, null },
                    { 7L, null, true, "Update GitHub Repository", 1, null },
                    { 8L, new DateTime(2024, 10, 31, 18, 48, 37, 823, DateTimeKind.Utc).AddTicks(1877), false, "Research Unit Testing", 0, 1 },
                    { 9L, new DateTime(2024, 10, 30, 18, 48, 37, 823, DateTimeKind.Utc).AddTicks(1879), false, "Refactor Code", 1, null },
                    { 10L, null, false, "Optimize Performance", 2, 2 },
                    { 11L, null, true, "Add Logging", 0, null },
                    { 12L, null, true, "Set Up CI/CD Pipeline", 2, null },
                    { 13L, new DateTime(2024, 11, 9, 18, 48, 37, 823, DateTimeKind.Utc).AddTicks(1883), false, "Create Backup Strategy", 1, null },
                    { 14L, new DateTime(2024, 11, 5, 18, 48, 37, 823, DateTimeKind.Utc).AddTicks(1884), false, "Conduct Code Review", 2, null },
                    { 15L, null, true, "Plan Next Sprint", 1, null },
                    { 16L, new DateTime(2024, 10, 29, 18, 48, 37, 823, DateTimeKind.Utc).AddTicks(1887), false, "Fix Bugs", 2, null },
                    { 17L, new DateTime(2024, 11, 11, 18, 48, 37, 823, DateTimeKind.Utc).AddTicks(1888), false, "Prepare for Presentation", 1, null },
                    { 18L, null, true, "Clean Up Codebase", 0, null },
                    { 19L, null, true, "Archive Old Projects", 0, null },
                    { 20L, new DateTime(2024, 11, 3, 18, 48, 37, 823, DateTimeKind.Utc).AddTicks(1891), false, "Analyze User Feedback", 1, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ToDoItems");
        }
    }
}
