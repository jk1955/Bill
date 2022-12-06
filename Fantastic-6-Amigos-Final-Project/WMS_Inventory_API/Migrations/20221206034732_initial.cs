using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WMS_Inventory_API.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZipCode = table.Column<int>(type: "int", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StorageLocation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocationName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZipCode = table.Column<int>(type: "int", nullable: true),
                    Longitude = table.Column<double>(type: "float", nullable: true),
                    Latitude = table.Column<double>(type: "float", nullable: true),
                    AccountId = table.Column<int>(type: "int", nullable: true),
                    AccountId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StorageLocation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StorageLocation_Account_AccountId1",
                        column: x => x.AccountId1,
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);

                });

            migrationBuilder.CreateTable(
                name: "Container",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StorageLocationId = table.Column<int>(type: "int", nullable: true),
                    StorageLocationId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Container", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Container_Container_StorageLocationId",
                        column: x => x.StorageLocationId,
                        principalTable: "Container",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Container_StorageLocation_StorageLocationId1",
                        column: x => x.StorageLocationId1,
                        principalTable: "StorageLocation",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Content",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContainerId = table.Column<int>(type: "int", nullable: true),
                    ContainerId1 = table.Column<int>(type: "int", nullable: true),
                    StorageLocationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Content", x => x.Id);
                    table.ForeignKey(
                    name: "FK_Content_Container_ContainerId1",
                    column: x => x.ContainerId1,
                    principalTable: "Container",
                    principalColumn: "Id");

                    table.ForeignKey(
                        name: "FK_Content_Content_ContainerId",
                        column: x => x.ContainerId,
                        principalTable: "Content",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Content_StorageLocation_StorageLocationId",
                        column: x => x.StorageLocationId,
                        principalTable: "StorageLocation",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Account",
                columns: new[] { "Id", "Address1", "Address2", "City", "Email", "Name", "Password", "State", "ZipCode" },
                values: new object[] { 1, "5814 N 17th St", "", "Tampa", "charles.baker@gmail.com", "Charles Baker", "password", "FL", 33610 });

            migrationBuilder.InsertData(
                table: "Container",
                columns: new[] { "Id", "Description", "StorageLocationId", "StorageLocationId1", "Type" },
                values: new object[] { 2, "Clear plastic w/ blue lid - clothes", 2, null, "Tote" });

            migrationBuilder.InsertData(
                table: "Content",
                columns: new[] { "Id", "ContainerId", "ContainerId1", "Description", "Quantity", "StorageLocationId" },
                values: new object[] { 1, 1, null, "5 lbs box 2 inch cut nails", 1, null });

            migrationBuilder.InsertData(
                table: "StorageLocation",
                columns: new[] { "Id", "AccountId", "AccountId1", "Address1", "Address2", "City", "Latitude", "LocationName", "Longitude", "State", "ZipCode" },
                values: new object[] { 1, 1, null, "5814 N 17th St", "", "Tampa", -82.440321999999995, "Home Shop", 27.995778000000001, "FL", 33610 });

            migrationBuilder.InsertData(
                table: "Container",
                columns: new[] { "Id", "Description", "StorageLocationId", "StorageLocationId1", "Type" },
                values: new object[] { 1, "Brown corrugated box containing metal fasteners", 2, null, "Box" });

            migrationBuilder.InsertData(
                table: "Content",
                columns: new[] { "Id", "ContainerId", "ContainerId1", "Description", "Quantity", "StorageLocationId" },
                values: new object[,]
                {
                    { 2, 1, null, "1 lbs box 2 1/2 in cut nails", 3, null },
                    { 3, 1, null, "Misc boxes of cut nails - finish, box, brad", 6, null },
                    { 4, 1, null, "Misc boxes wood screws, brass/bronze, #8/9, 3/4 in - 1 1/2 in", 4, null }
                });

            migrationBuilder.InsertData(
                table: "StorageLocation",
                columns: new[] { "Id", "AccountId", "AccountId1", "Address1", "Address2", "City", "Latitude", "LocationName", "Longitude", "State", "ZipCode" },
                values: new object[] { 2, 1, null, "1711 E Hillsborough Ave", "", "Tampa", -82.441528000000005, "Extra Space Storage", 28.000686999999999, "FL", 33610 });

            migrationBuilder.InsertData(
                table: "Container",
                columns: new[] { "Id", "Description", "StorageLocationId", "StorageLocationId1", "Type" },
                values: new object[,]
                {
                    { 3, "Blue painted wooden chest - fishing tackle", 1, null, "Chest" },
                    { 4, "Far left cabinet under built in work bench", 1, null, "Cabinet" }
                });

            migrationBuilder.InsertData(
                table: "Content",
                columns: new[] { "Id", "ContainerId", "ContainerId1", "Description", "Quantity", "StorageLocationId" },
                values: new object[,]
                {
                    { 5, 2, null, "Mom's winter clothes - slacks, tops, sweaters", 25, null },
                    { 6, 3, null, "Box of fly reels - Berkley, Ross, Pflueger", 1, null },
                    { 7, 3, null, "Leonard 37H flyrod", 1, null },
                    { 8, 3, null, "Orvis Fullflex fly/spin rod", 1, null },
                    { 9, 3, null, "Box of spinning reels - Shakespeare, Micron, Mitchell", 1, null },
                    { 10, 4, null, "Makita 7 1/4 in track saw", 1, null },
                    { 11, 4, null, "Parallel guides for Makita track", 1, null },
                    { 12, 4, null, "Makita 10 in circular saw", 1, null },
                    { 13, 4, null, "Skilsaw 5 1/2 in circular saw", 1, null },
                    { 14, 4, null, "Ryobi One+ tools - 1/2 in drill, finish sander, brad nailer", 3, null },
                    { 15, 4, null, "Milwaukee 7 1/4 in circular saw", 1, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Container_StorageLocationId",
                table: "Container",
                column: "StorageLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Container_StorageLocationId1",
                table: "Container",
                column: "StorageLocationId1");

            migrationBuilder.CreateIndex(
                name: "IX_Content_ContainerId",
                table: "Content",
                column: "ContainerId");

            migrationBuilder.CreateIndex(
                name: "IX_Content_ContainerId1",
                table: "Content",
                column: "ContainerId1");

            migrationBuilder.CreateIndex(
                name: "IX_Content_StorageLocationId",
                table: "Content",
                column: "StorageLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_StorageLocation_AccountId",
                table: "StorageLocation",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_StorageLocation_AccountId1",
                table: "StorageLocation",
                column: "AccountId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Content");

            migrationBuilder.DropTable(
                name: "Container");

            migrationBuilder.DropTable(
                name: "StorageLocation");

            migrationBuilder.DropTable(
                name: "Account");
        }
    }
}
