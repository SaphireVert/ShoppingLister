using Microsoft.EntityFrameworkCore.Migrations;

namespace angular.Migrations
{
    public partial class migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "T_Category",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    isDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Category", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "T_List",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    isDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_List", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "T_Product",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Brand = table.Column<string>(type: "TEXT", nullable: true),
                    isDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false),
                    fk_Categoryid = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Product", x => x.id);
                    table.ForeignKey(
                        name: "FK_T_Product_T_Category_fk_Categoryid",
                        column: x => x.fk_Categoryid,
                        principalTable: "T_Category",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "T_Item",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    ListId = table.Column<int>(type: "INTEGER", nullable: false),
                    fk_Listid = table.Column<int>(type: "INTEGER", nullable: true),
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false),
                    fk_Productid = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Item", x => x.id);
                    table.ForeignKey(
                        name: "FK_T_Item_T_List_fk_Listid",
                        column: x => x.fk_Listid,
                        principalTable: "T_List",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_T_Item_T_Product_fk_Productid",
                        column: x => x.fk_Productid,
                        principalTable: "T_Product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_T_Item_fk_Listid",
                table: "T_Item",
                column: "fk_Listid");

            migrationBuilder.CreateIndex(
                name: "IX_T_Item_fk_Productid",
                table: "T_Item",
                column: "fk_Productid");

            migrationBuilder.CreateIndex(
                name: "IX_T_Product_fk_Categoryid",
                table: "T_Product",
                column: "fk_Categoryid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_Item");

            migrationBuilder.DropTable(
                name: "T_List");

            migrationBuilder.DropTable(
                name: "T_Product");

            migrationBuilder.DropTable(
                name: "T_Category");
        }
    }
}
