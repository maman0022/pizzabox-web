using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace PizzaBox.Storing.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Crusts",
                columns: table => new
                {
                    EntityId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Discriminator = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Price = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Crusts", x => x.EntityId);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    EntityId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.EntityId);
                });

            migrationBuilder.CreateTable(
                name: "PizzaTypes",
                columns: table => new
                {
                    EntityId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Discriminator = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PizzaTypes", x => x.EntityId);
                });

            migrationBuilder.CreateTable(
                name: "Sizes",
                columns: table => new
                {
                    EntityId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Discriminator = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Price = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sizes", x => x.EntityId);
                });

            migrationBuilder.CreateTable(
                name: "Stores",
                columns: table => new
                {
                    EntityId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Discriminator = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stores", x => x.EntityId);
                });

            migrationBuilder.CreateTable(
                name: "Toppings",
                columns: table => new
                {
                    EntityId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Discriminator = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Price = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Toppings", x => x.EntityId);
                });

            migrationBuilder.CreateTable(
                name: "Pizzas",
                columns: table => new
                {
                    EntityId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TypeEntityId = table.Column<long>(type: "bigint", nullable: true),
                    CrustEntityId = table.Column<long>(type: "bigint", nullable: true),
                    SizeEntityId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pizzas", x => x.EntityId);
                    table.ForeignKey(
                        name: "FK_Pizzas_Crusts_CrustEntityId",
                        column: x => x.CrustEntityId,
                        principalTable: "Crusts",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pizzas_PizzaTypes_TypeEntityId",
                        column: x => x.TypeEntityId,
                        principalTable: "PizzaTypes",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pizzas_Sizes_SizeEntityId",
                        column: x => x.SizeEntityId,
                        principalTable: "Sizes",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    EntityId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CustomerEntityId = table.Column<long>(type: "bigint", nullable: true),
                    StoreEntityId = table.Column<long>(type: "bigint", nullable: true),
                    orderTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.EntityId);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerEntityId",
                        column: x => x.CustomerEntityId,
                        principalTable: "Customers",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Stores_StoreEntityId",
                        column: x => x.StoreEntityId,
                        principalTable: "Stores",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AToppingPizza",
                columns: table => new
                {
                    PizzaEntityId = table.Column<long>(type: "bigint", nullable: false),
                    ToppingsEntityId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AToppingPizza", x => new { x.PizzaEntityId, x.ToppingsEntityId });
                    table.ForeignKey(
                        name: "FK_AToppingPizza_Pizzas_PizzaEntityId",
                        column: x => x.PizzaEntityId,
                        principalTable: "Pizzas",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AToppingPizza_Toppings_ToppingsEntityId",
                        column: x => x.ToppingsEntityId,
                        principalTable: "Toppings",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderPizza",
                columns: table => new
                {
                    OrderEntityId = table.Column<long>(type: "bigint", nullable: false),
                    PizzasEntityId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderPizza", x => new { x.OrderEntityId, x.PizzasEntityId });
                    table.ForeignKey(
                        name: "FK_OrderPizza_Orders_OrderEntityId",
                        column: x => x.OrderEntityId,
                        principalTable: "Orders",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderPizza_Pizzas_PizzasEntityId",
                        column: x => x.PizzasEntityId,
                        principalTable: "Pizzas",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Crusts",
                columns: new[] { "EntityId", "Discriminator", "Name", "Price" },
                values: new object[,]
                {
                    { 2L, "Pan", "Pan", 5.00m },
                    { 3L, "Stuffed", "Stuffed", 6.00m },
                    { 1L, "Thin", "Thin", 4.00m }
                });

            migrationBuilder.InsertData(
                table: "PizzaTypes",
                columns: new[] { "EntityId", "Discriminator", "Name" },
                values: new object[,]
                {
                    { 3L, "CustomPizza", "Custom Pizza" },
                    { 1L, "MeatPizza", "Meat Pizza" },
                    { 2L, "VeggiePizza", "Veggie Pizza" }
                });

            migrationBuilder.InsertData(
                table: "Sizes",
                columns: new[] { "EntityId", "Discriminator", "Name", "Price" },
                values: new object[,]
                {
                    { 3L, "Large", "Large", 7.00m },
                    { 2L, "Medium", "Medium", 6.00m },
                    { 1L, "Small", "Small", 5.00m }
                });

            migrationBuilder.InsertData(
                table: "Stores",
                columns: new[] { "EntityId", "Discriminator", "Name" },
                values: new object[,]
                {
                    { 1L, "ChicagoStore", "1234 Main Street, Chicago, IL" },
                    { 2L, "NewYorkStore", "801 128th Street, New York City, NY" }
                });

            migrationBuilder.InsertData(
                table: "Toppings",
                columns: new[] { "EntityId", "Discriminator", "Name", "Price" },
                values: new object[,]
                {
                    { 2L, "Mushrooms", "Mushrooms", 2.00m },
                    { 1L, "Onions", "Onions", 2.00m },
                    { 3L, "Pepperoni", "Pepperoni", 3.00m },
                    { 4L, "Sausage", "Sausage", 3.00m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AToppingPizza_ToppingsEntityId",
                table: "AToppingPizza",
                column: "ToppingsEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderPizza_PizzasEntityId",
                table: "OrderPizza",
                column: "PizzasEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerEntityId",
                table: "Orders",
                column: "CustomerEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_StoreEntityId",
                table: "Orders",
                column: "StoreEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Pizzas_CrustEntityId",
                table: "Pizzas",
                column: "CrustEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Pizzas_SizeEntityId",
                table: "Pizzas",
                column: "SizeEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Pizzas_TypeEntityId",
                table: "Pizzas",
                column: "TypeEntityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AToppingPizza");

            migrationBuilder.DropTable(
                name: "OrderPizza");

            migrationBuilder.DropTable(
                name: "Toppings");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Pizzas");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Stores");

            migrationBuilder.DropTable(
                name: "Crusts");

            migrationBuilder.DropTable(
                name: "PizzaTypes");

            migrationBuilder.DropTable(
                name: "Sizes");
        }
    }
}
