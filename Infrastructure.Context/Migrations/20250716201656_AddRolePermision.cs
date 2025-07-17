using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Context.Migrations
{
    /// <inheritdoc />
    public partial class AddRolePermision : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence<int>(
                name: "Role_GKey");

            migrationBuilder.AlterColumn<long>(
                name: "GKey",
                table: "Role",
                type: "bigint",
                nullable: false,
                defaultValueSql: "NEXT VALUE FOR Role_GKey",
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.CreateTable(
                name: "ApiEndpointType",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GKey = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR ApiEndpointType_GKey"),
                    PublicId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateUserId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MetaData = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApiEndpointType", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApiEndpointType");

            migrationBuilder.DropSequence(
                name: "Role_GKey");

            migrationBuilder.AlterColumn<long>(
                name: "GKey",
                table: "Role",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldDefaultValueSql: "NEXT VALUE FOR Role_GKey");
        }
    }
}
