using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StrateInfo.Infrastructure.Migrations
{
	/// <inheritdoc />
	public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "state_organizations");

            migrationBuilder.CreateTable(
                name: "address",
                schema: "state_organizations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Street = table.Column<string>(type: "text", nullable: true),
                    City = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_address", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "organization",
                schema: "state_organizations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    AddressId = table.Column<Guid>(type: "uuid", nullable: false),
                    TelephoneNumber = table.Column<string>(type: "text", nullable: false),
                    PhotoUrl = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_organization", x => x.Id);
                    table.ForeignKey(
                        name: "FK_organization_address_AddressId",
                        column: x => x.AddressId,
                        principalSchema: "state_organizations",
                        principalTable: "address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_organization_AddressId",
                schema: "state_organizations",
                table: "organization",
                column: "AddressId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "organization",
                schema: "state_organizations");

            migrationBuilder.DropTable(
                name: "address",
                schema: "state_organizations");
        }
    }
}
