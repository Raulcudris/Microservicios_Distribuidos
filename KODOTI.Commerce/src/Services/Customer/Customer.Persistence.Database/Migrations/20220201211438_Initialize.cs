using Microsoft.EntityFrameworkCore.Migrations;

namespace Customer.Persistence.Database.Migrations
{
    public partial class Initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Customer");

            migrationBuilder.CreateTable(
                name: "Clients",
                schema: "Customer",
                columns: table => new
                {
                    ClientId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.ClientId);
                });

            migrationBuilder.InsertData(
                schema: "Customer",
                table: "Clients",
                columns: new[] { "ClientId", "Name" },
                values: new object[,]
                {
                    { 1, "Client1" },
                    { 73, "Client73" },
                    { 72, "Client72" },
                    { 71, "Client71" },
                    { 70, "Client70" },
                    { 69, "Client69" },
                    { 68, "Client68" },
                    { 67, "Client67" },
                    { 66, "Client66" },
                    { 65, "Client65" },
                    { 64, "Client64" },
                    { 63, "Client63" },
                    { 62, "Client62" },
                    { 61, "Client61" },
                    { 60, "Client60" },
                    { 59, "Client59" },
                    { 58, "Client58" },
                    { 57, "Client57" },
                    { 56, "Client56" },
                    { 55, "Client55" },
                    { 54, "Client54" },
                    { 53, "Client53" },
                    { 74, "Client74" },
                    { 52, "Client52" },
                    { 75, "Client75" },
                    { 77, "Client77" },
                    { 98, "Client98" },
                    { 97, "Client97" },
                    { 96, "Client96" },
                    { 95, "Client95" },
                    { 94, "Client94" },
                    { 93, "Client93" },
                    { 92, "Client92" },
                    { 91, "Client91" },
                    { 90, "Client90" },
                    { 89, "Client89" },
                    { 88, "Client88" },
                    { 87, "Client87" },
                    { 86, "Client86" },
                    { 85, "Client85" },
                    { 84, "Client84" },
                    { 83, "Client83" },
                    { 82, "Client82" },
                    { 81, "Client81" },
                    { 80, "Client80" },
                    { 79, "Client79" },
                    { 78, "Client78" },
                    { 76, "Client76" },
                    { 51, "Client51" },
                    { 50, "Client50" },
                    { 49, "Client49" },
                    { 22, "Client22" },
                    { 21, "Client21" },
                    { 20, "Client20" },
                    { 19, "Client19" },
                    { 18, "Client18" },
                    { 17, "Client17" },
                    { 16, "Client16" },
                    { 15, "Client15" },
                    { 14, "Client14" },
                    { 13, "Client13" },
                    { 12, "Client12" },
                    { 11, "Client11" },
                    { 10, "Client10" },
                    { 9, "Client9" },
                    { 8, "Client8" },
                    { 7, "Client7" },
                    { 6, "Client6" },
                    { 5, "Client5" },
                    { 4, "Client4" },
                    { 3, "Client3" },
                    { 2, "Client2" },
                    { 23, "Client23" },
                    { 24, "Client24" },
                    { 25, "Client25" },
                    { 26, "Client26" },
                    { 48, "Client48" },
                    { 47, "Client47" },
                    { 46, "Client46" },
                    { 45, "Client45" },
                    { 44, "Client44" },
                    { 43, "Client43" },
                    { 42, "Client42" },
                    { 41, "Client41" },
                    { 40, "Client40" },
                    { 39, "Client39" },
                    { 99, "Client99" },
                    { 38, "Client38" },
                    { 36, "Client36" },
                    { 35, "Client35" },
                    { 34, "Client34" },
                    { 33, "Client33" },
                    { 32, "Client32" },
                    { 31, "Client31" },
                    { 30, "Client30" },
                    { 29, "Client29" },
                    { 28, "Client28" },
                    { 27, "Client27" },
                    { 37, "Client37" },
                    { 100, "Client100" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clients",
                schema: "Customer");
        }
    }
}
