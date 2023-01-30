using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Everyday.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class DatabaseCreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "dictionarycategories",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    description = table.Column<string>(type: "character varying(254)", maxLength: 254, nullable: true),
                    createdat = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dictionarycategories", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "itemdefinitions",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    dimensionsmeasureunitid = table.Column<int>(type: "integer", nullable: false),
                    weightmeasureunitid = table.Column<int>(type: "integer", nullable: false),
                    itemcategorytypeid = table.Column<int>(type: "integer", nullable: false),
                    containerid = table.Column<int>(type: "integer", nullable: true),
                    createdat = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_itemdefinitions", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "manufacturers",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    name = table.Column<string>(type: "character varying(254)", maxLength: 254, nullable: false),
                    description = table.Column<string>(type: "character varying(254)", maxLength: 254, nullable: true),
                    createdat = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_manufacturers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "measureunits",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    signature = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: false),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    createdat = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_measureunits", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    description = table.Column<string>(type: "character varying(254)", maxLength: 254, nullable: true),
                    createdat = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "userroles",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    userid = table.Column<int>(type: "integer", nullable: false),
                    roleid = table.Column<int>(type: "integer", nullable: false),
                    createdat = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userroles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    login = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    password = table.Column<string>(type: "character varying(254)", maxLength: 254, nullable: false),
                    createdat = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "dictionaries",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    categoryid = table.Column<int>(type: "integer", nullable: false),
                    description = table.Column<string>(type: "character varying(254)", maxLength: 254, nullable: true),
                    value = table.Column<int>(type: "integer", nullable: false),
                    createdat = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dictionaries", x => x.id);
                    table.ForeignKey(
                        name: "dict_dictcat_fk_categoryid",
                        column: x => x.categoryid,
                        principalTable: "dictionarycategories",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "items",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    code = table.Column<string>(type: "character varying(254)", maxLength: 254, nullable: true),
                    name = table.Column<string>(type: "character varying(254)", maxLength: 254, nullable: false),
                    description = table.Column<string>(type: "character varying(254)", maxLength: 254, nullable: true),
                    width = table.Column<double>(type: "double precision", nullable: true),
                    height = table.Column<double>(type: "double precision", nullable: true),
                    depth = table.Column<double>(type: "double precision", nullable: true),
                    weight = table.Column<double>(type: "double precision", nullable: true),
                    price = table.Column<double>(type: "double precision", nullable: true),
                    itemdefinitionid = table.Column<int>(type: "integer", nullable: false),
                    manufacturerid = table.Column<int>(type: "integer", nullable: true),
                    createdat = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_items", x => x.id);
                    table.ForeignKey(
                        name: "items_itemdefinitionid_fkey",
                        column: x => x.itemdefinitionid,
                        principalTable: "itemdefinitions",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "items_manufacturerid_fkey",
                        column: x => x.manufacturerid,
                        principalTable: "manufacturers",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "consumables",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    protein = table.Column<double>(type: "double precision", nullable: true),
                    carbohydrates = table.Column<double>(type: "double precision", nullable: true),
                    sugars = table.Column<double>(type: "double precision", nullable: true),
                    fat = table.Column<double>(type: "double precision", nullable: true),
                    saturatedfat = table.Column<double>(type: "double precision", nullable: true),
                    fiber = table.Column<double>(type: "double precision", nullable: true),
                    salt = table.Column<double>(type: "double precision", nullable: true),
                    energy = table.Column<double>(type: "double precision", nullable: true),
                    itemid = table.Column<int>(type: "integer", nullable: false),
                    createdat = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_consumables", x => x.id);
                    table.ForeignKey(
                        name: "consumables_itemid_fkey",
                        column: x => x.itemid,
                        principalTable: "items",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "containers",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    trashtypeid = table.Column<int>(type: "integer", nullable: false),
                    isreusable = table.Column<bool>(type: "boolean", nullable: false),
                    itemid = table.Column<int>(type: "integer", nullable: false),
                    createdat = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_containers", x => x.id);
                    table.ForeignKey(
                        name: "containers_itemid_fkey",
                        column: x => x.itemid,
                        principalTable: "items",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "existingitems",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    itemid = table.Column<int>(type: "integer", nullable: false),
                    qty = table.Column<double>(type: "double precision", nullable: false),
                    createdat = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_existingitems", x => x.id);
                    table.ForeignKey(
                        name: "existingitems_itemid_fkey",
                        column: x => x.itemid,
                        principalTable: "items",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_consumables_itemid",
                table: "consumables",
                column: "itemid");

            migrationBuilder.CreateIndex(
                name: "IX_containers_itemid",
                table: "containers",
                column: "itemid");

            migrationBuilder.CreateIndex(
                name: "IX_dictionaries_categoryid",
                table: "dictionaries",
                column: "categoryid");

            migrationBuilder.CreateIndex(
                name: "dictionarycategories_name_key",
                table: "dictionarycategories",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_existingitems_itemid",
                table: "existingitems",
                column: "itemid");

            migrationBuilder.CreateIndex(
                name: "IX_items_itemdefinitionid",
                table: "items",
                column: "itemdefinitionid");

            migrationBuilder.CreateIndex(
                name: "IX_items_manufacturerid",
                table: "items",
                column: "manufacturerid");

            migrationBuilder.CreateIndex(
                name: "uq_items_code",
                table: "items",
                column: "code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "manufacturers_name_key",
                table: "manufacturers",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "roles_name_key",
                table: "roles",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "users_login_key",
                table: "users",
                column: "login",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "consumables");

            migrationBuilder.DropTable(
                name: "containers");

            migrationBuilder.DropTable(
                name: "dictionaries");

            migrationBuilder.DropTable(
                name: "existingitems");

            migrationBuilder.DropTable(
                name: "measureunits");

            migrationBuilder.DropTable(
                name: "roles");

            migrationBuilder.DropTable(
                name: "userroles");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "dictionarycategories");

            migrationBuilder.DropTable(
                name: "items");

            migrationBuilder.DropTable(
                name: "itemdefinitions");

            migrationBuilder.DropTable(
                name: "manufacturers");
        }
    }
}
