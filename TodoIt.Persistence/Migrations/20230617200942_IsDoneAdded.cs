using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoIt.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class IsDoneAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDone",
                table: "Todos",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDone",
                table: "Todos");
        }
    }
}
