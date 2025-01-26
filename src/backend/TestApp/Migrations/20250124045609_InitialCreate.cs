using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestApp.Migrations
{
	/// <inheritdoc />
	public partial class InitialCreate : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
				name: "InsuranceMembers",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
					LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
					Address1 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
					Address2 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
					City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
					State = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
					Zip = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
					PhoneNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
					Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
					MemberPlan = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
					DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
					PolicyStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
					PolicyEndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_InsuranceMembers", x => x.Id);
				});
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "InsuranceMembers");
		}
	}
}