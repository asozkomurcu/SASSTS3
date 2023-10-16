using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SASSTS.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class FirstCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CATEGORIES",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CATEGORY_NAME = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    CREATE_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CREATED_BY = table.Column<string>(type: "nvarchar(500)", nullable: true),
                    MODIFIED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MODIFIED_BY = table.Column<string>(type: "nvarchar(500)", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "0")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CATEGORIES", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "WHOLESALER",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WHOLESALER_NAME = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    PHONE = table.Column<string>(type: "nvarchar(13)", nullable: false),
                    ADDRESS = table.Column<string>(type: "nvarchar(500)", nullable: false),
                    CREATE_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CREATED_BY = table.Column<string>(type: "nvarchar(500)", nullable: true),
                    MODIFIED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MODIFIED_BY = table.Column<string>(type: "nvarchar(500)", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "0")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WHOLESALER", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ACCOUNTS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CUSTOMER_ID = table.Column<int>(type: "int", nullable: false),
                    EMAIL = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    PASSWORD = table.Column<string>(type: "nvarchar(500)", nullable: false),
                    LAST_LOGIN_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LAST_LOGIN_IP = table.Column<string>(type: "nvarchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ACCOUNTS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BILLS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WHOLESALER_ID = table.Column<int>(type: "int", nullable: false),
                    PRODUCT_ID = table.Column<int>(type: "int", nullable: false),
                    BILL_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BILL_NUMBER = table.Column<string>(type: "nvarchar(16)", nullable: false),
                    BILL_TYPE = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    WHOLESALER_NAME = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    PRODUCT_NAME = table.Column<string>(type: "nvarchar(150)", nullable: false),
                    UNIT_PRICE = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    KDV = table.Column<int>(type: "int", nullable: false),
                    DISCOUNT = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    AMOUNT = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PRICE = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TOTAL_UNIT_PRICE = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TOTAL_DISCOUNT = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TOTAL_KDV = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TOTAL_PRICE = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CREATE_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CREATED_BY = table.Column<string>(type: "nvarchar(500)", nullable: true),
                    MODIFIED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MODIFIED_BY = table.Column<string>(type: "nvarchar(500)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BILLS", x => x.ID);
                    table.ForeignKey(
                        name: "BILL_WHOLESALER_WHOLESALER_ID",
                        column: x => x.WHOLESALER_ID,
                        principalTable: "WHOLESALER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "COMPANIES",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    COMPANY_MANAGER_ID = table.Column<int>(type: "int", nullable: true),
                    COMPANY_MANAGER_NAME = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    COMPANY_NAME = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    CREATE_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CREATED_BY = table.Column<string>(type: "nvarchar(500)", nullable: true),
                    MODIFIED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MODIFIED_BY = table.Column<string>(type: "nvarchar(500)", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "0")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COMPANIES", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CUSTOMERS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDENTITY_NUMBER = table.Column<string>(type: "nvarchar(11)", nullable: false),
                    NAME = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    SURNAME = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    EMAIL = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    PHONE = table.Column<string>(type: "nchar(11)", nullable: false),
                    GENDER = table.Column<int>(type: "int", nullable: false),
                    PASSWORD = table.Column<string>(type: "nvarchar(500)", nullable: false),
                    DEPARTMENT_ID = table.Column<int>(type: "int", nullable: false),
                    DEPARTMENT_NAME = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    ROLE = table.Column<int>(type: "int", nullable: false),
                    USER_AUTHORIZATION = table.Column<int>(type: "int", nullable: true),
                    CREATE_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CREATED_BY = table.Column<string>(type: "nvarchar(500)", nullable: true),
                    MODIFIED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MODIFIED_BY = table.Column<string>(type: "nvarchar(500)", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "0")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CUSTOMERS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DEPARTMENTS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DEPARTMENT_MANAGER_ID = table.Column<int>(type: "int", nullable: true),
                    COMPANY_ID = table.Column<int>(type: "int", nullable: false),
                    DEPARTMENT_MANAGER_NAME = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    DEPARTMENT_NAME = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    COMPANY_NAME = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    CREATE_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CREATED_BY = table.Column<string>(type: "nvarchar(500)", nullable: true),
                    MODIFIED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MODIFIED_BY = table.Column<string>(type: "nvarchar(500)", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "0")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DEPARTMENTS", x => x.ID);
                    table.ForeignKey(
                        name: "DEPARTMENT_COMPANY_COMPANY_ID",
                        column: x => x.COMPANY_ID,
                        principalTable: "COMPANIES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "DEPARTMENT_CUSTOMER_CUSTOMER_ID",
                        column: x => x.DEPARTMENT_MANAGER_ID,
                        principalTable: "CUSTOMERS",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "PRICE_OFFERS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PURCHASE_REQUEST_ID = table.Column<int>(type: "int", nullable: false),
                    CUSTOMER_ID = table.Column<int>(type: "int", nullable: false),
                    PRODUCT_ID = table.Column<int>(type: "int", nullable: false),
                    WHOLESALER_ID = table.Column<int>(type: "int", nullable: false),
                    CUSTOMER_NAME = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    PRODUCT_NAME = table.Column<string>(type: "nvarchar(150)", nullable: false),
                    WHOLESALER_NAME = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    AMOUNT = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UNIT_PRICE = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TOTAL_PRICE = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DELIVERY_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CREATE_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CREATED_BY = table.Column<string>(type: "nvarchar(500)", nullable: true),
                    MODIFIED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MODIFIED_BY = table.Column<string>(type: "nvarchar(500)", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "0")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRICE_OFFERS", x => x.ID);
                    table.ForeignKey(
                        name: "PRICE_OFFER_CUSTOMER_CUSTOMER_ID",
                        column: x => x.CUSTOMER_ID,
                        principalTable: "CUSTOMERS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "PRICE_OFFER_WHOLESALER_WHOLESALER_ID",
                        column: x => x.WHOLESALER_ID,
                        principalTable: "WHOLESALER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PRODUCTS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CATEGORY_ID = table.Column<int>(type: "int", nullable: false),
                    PRODUCT_NAME = table.Column<string>(type: "nvarchar(150)", nullable: false),
                    AMOUNT = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CATEGORY_NAME = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    UNIT_PRICE = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CREATE_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CREATED_BY = table.Column<string>(type: "nvarchar(500)", nullable: true),
                    MODIFIED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MODIFIED_BY = table.Column<string>(type: "nvarchar(500)", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "0"),
                    BillId = table.Column<int>(type: "int", nullable: true),
                    PriceOfferId = table.Column<int>(type: "int", nullable: true),
                    PurchaseRequestId = table.Column<int>(type: "int", nullable: true),
                    PurchasedProductId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUCTS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PRODUCTS_BILLS_BillId",
                        column: x => x.BillId,
                        principalTable: "BILLS",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_PRODUCTS_PRICE_OFFERS_PriceOfferId",
                        column: x => x.PriceOfferId,
                        principalTable: "PRICE_OFFERS",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "PRODUCT_CATEGORY_CATEGORY_ID",
                        column: x => x.CATEGORY_ID,
                        principalTable: "CATEGORIES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PURCHASE_REQUEST",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PRODUCT_ID = table.Column<int>(type: "int", nullable: false),
                    REQUEST_CUSTOMER_ID = table.Column<int>(type: "int", nullable: false),
                    OFFER_CUSTOMER_ID = table.Column<int>(type: "int", nullable: true),
                    APPROVING_CUSTOMER_ID = table.Column<int>(type: "int", nullable: true),
                    REQUEST_CUSTOMER_NAME = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    OFFER_CUSTOMER_NAME = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    APPROVING_CUSTOMER_NAME = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    PRODUCT_NAME = table.Column<string>(type: "nvarchar(150)", nullable: false),
                    PRODUCT_DESCRIPTION = table.Column<string>(type: "nvarchar(500)", nullable: false),
                    AMOUNT = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    STATUS = table.Column<int>(type: "int", nullable: false),
                    CREATE_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CREATED_BY = table.Column<string>(type: "nvarchar(500)", nullable: true),
                    MODIFIED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MODIFIED_BY = table.Column<string>(type: "nvarchar(500)", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "0")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PURCHASE_REQUEST", x => x.ID);
                    table.ForeignKey(
                        name: "PURCHASE_REQUEST_CUSTOMER_REQUEST_CUSTOMER_ID",
                        column: x => x.REQUEST_CUSTOMER_ID,
                        principalTable: "CUSTOMERS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "PURCHASE_REQUEST_PRODUCT_PRODUCT_ID",
                        column: x => x.PRODUCT_ID,
                        principalTable: "PRODUCTS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PURCHASED_PRODUCT",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PURCHASE_REQUEST_ID = table.Column<int>(type: "int", nullable: false),
                    PRICE_OFFER_ID = table.Column<int>(type: "int", nullable: false),
                    CUSTOMER_ID = table.Column<int>(type: "int", nullable: false),
                    PRODUCT_ID = table.Column<int>(type: "int", nullable: false),
                    WHOLESALER_ID = table.Column<int>(type: "int", nullable: false),
                    CUSTOMER_NAME = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    PRODUCT_NAME = table.Column<string>(type: "nvarchar(150)", nullable: false),
                    AMOUNT = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    WHOLESALER_NAME = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    UNIT_PRICE = table.Column<double>(type: "float", nullable: false),
                    TOTAL_PRICE = table.Column<double>(type: "float", nullable: false),
                    DELIVERY_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CREATE_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CREATED_BY = table.Column<string>(type: "nvarchar(500)", nullable: true),
                    MODIFIED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MODIFIED_BY = table.Column<string>(type: "nvarchar(500)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PURCHASED_PRODUCT", x => x.ID);
                    table.ForeignKey(
                        name: "PURCHASED_PRODUCT_CUSTOMER_CUSTOMER_ID",
                        column: x => x.CUSTOMER_ID,
                        principalTable: "CUSTOMERS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "PURCHASED_PRODUCT_PRICE_OFFER_PRICE_OFFER_ID",
                        column: x => x.PRICE_OFFER_ID,
                        principalTable: "PRICE_OFFERS",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "PURCHASED_PRODUCT_PRODUCT_PRODUCT_ID",
                        column: x => x.PRODUCT_ID,
                        principalTable: "PRODUCTS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "PURCHASED_PRODUCT_PURCHASE_REQUEST_PURCHASE_REQUEST_ID",
                        column: x => x.PURCHASE_REQUEST_ID,
                        principalTable: "PURCHASE_REQUEST",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "PURCHASED_PRODUCT_WHOLESALER_WHOLESALER_ID",
                        column: x => x.WHOLESALER_ID,
                        principalTable: "WHOLESALER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ACCOUNTS_CUSTOMER_ID",
                table: "ACCOUNTS",
                column: "CUSTOMER_ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BILLS_PRODUCT_ID",
                table: "BILLS",
                column: "PRODUCT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_BILLS_WHOLESALER_ID",
                table: "BILLS",
                column: "WHOLESALER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_COMPANIES_COMPANY_MANAGER_ID",
                table: "COMPANIES",
                column: "COMPANY_MANAGER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_CUSTOMERS_DEPARTMENT_ID",
                table: "CUSTOMERS",
                column: "DEPARTMENT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_DEPARTMENTS_COMPANY_ID",
                table: "DEPARTMENTS",
                column: "COMPANY_ID");

            migrationBuilder.CreateIndex(
                name: "IX_DEPARTMENTS_DEPARTMENT_MANAGER_ID",
                table: "DEPARTMENTS",
                column: "DEPARTMENT_MANAGER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PRICE_OFFERS_CUSTOMER_ID",
                table: "PRICE_OFFERS",
                column: "CUSTOMER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PRICE_OFFERS_PRODUCT_ID",
                table: "PRICE_OFFERS",
                column: "PRODUCT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PRICE_OFFERS_PURCHASE_REQUEST_ID",
                table: "PRICE_OFFERS",
                column: "PURCHASE_REQUEST_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PRICE_OFFERS_WHOLESALER_ID",
                table: "PRICE_OFFERS",
                column: "WHOLESALER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCTS_BillId",
                table: "PRODUCTS",
                column: "BillId");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCTS_CATEGORY_ID",
                table: "PRODUCTS",
                column: "CATEGORY_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCTS_PriceOfferId",
                table: "PRODUCTS",
                column: "PriceOfferId");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCTS_PurchasedProductId",
                table: "PRODUCTS",
                column: "PurchasedProductId");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCTS_PurchaseRequestId",
                table: "PRODUCTS",
                column: "PurchaseRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_PURCHASE_REQUEST_PRODUCT_ID",
                table: "PURCHASE_REQUEST",
                column: "PRODUCT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PURCHASE_REQUEST_REQUEST_CUSTOMER_ID",
                table: "PURCHASE_REQUEST",
                column: "REQUEST_CUSTOMER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PURCHASED_PRODUCT_CUSTOMER_ID",
                table: "PURCHASED_PRODUCT",
                column: "CUSTOMER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PURCHASED_PRODUCT_PRICE_OFFER_ID",
                table: "PURCHASED_PRODUCT",
                column: "PRICE_OFFER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PURCHASED_PRODUCT_PRODUCT_ID",
                table: "PURCHASED_PRODUCT",
                column: "PRODUCT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PURCHASED_PRODUCT_PURCHASE_REQUEST_ID",
                table: "PURCHASED_PRODUCT",
                column: "PURCHASE_REQUEST_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PURCHASED_PRODUCT_WHOLESALER_ID",
                table: "PURCHASED_PRODUCT",
                column: "WHOLESALER_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_ACCOUNTS_CUSTOMERS_CUSTOMER_ID",
                table: "ACCOUNTS",
                column: "CUSTOMER_ID",
                principalTable: "CUSTOMERS",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "BILL_PRODUCT_PRODUCT_ID",
                table: "BILLS",
                column: "PRODUCT_ID",
                principalTable: "PRODUCTS",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "COMPANY_CUSTOMER_CUSTOMER_ID",
                table: "COMPANIES",
                column: "COMPANY_MANAGER_ID",
                principalTable: "CUSTOMERS",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_CUSTOMERS_DEPARTMENTS_DEPARTMENT_ID",
                table: "CUSTOMERS",
                column: "DEPARTMENT_ID",
                principalTable: "DEPARTMENTS",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "PRICE_OFFER_PRODUCT_PRODUCT_ID",
                table: "PRICE_OFFERS",
                column: "PRODUCT_ID",
                principalTable: "PRODUCTS",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "PRICE_OFFER_PURCHASE_REQUEST_PURCHASE_REQUEST_ID",
                table: "PRICE_OFFERS",
                column: "PURCHASE_REQUEST_ID",
                principalTable: "PURCHASE_REQUEST",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_PRODUCTS_PURCHASED_PRODUCT_PurchasedProductId",
                table: "PRODUCTS",
                column: "PurchasedProductId",
                principalTable: "PURCHASED_PRODUCT",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_PRODUCTS_PURCHASE_REQUEST_PurchaseRequestId",
                table: "PRODUCTS",
                column: "PurchaseRequestId",
                principalTable: "PURCHASE_REQUEST",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "COMPANY_CUSTOMER_CUSTOMER_ID",
                table: "COMPANIES");

            migrationBuilder.DropForeignKey(
                name: "DEPARTMENT_CUSTOMER_CUSTOMER_ID",
                table: "DEPARTMENTS");

            migrationBuilder.DropForeignKey(
                name: "PRICE_OFFER_CUSTOMER_CUSTOMER_ID",
                table: "PRICE_OFFERS");

            migrationBuilder.DropForeignKey(
                name: "PURCHASE_REQUEST_CUSTOMER_REQUEST_CUSTOMER_ID",
                table: "PURCHASE_REQUEST");

            migrationBuilder.DropForeignKey(
                name: "PURCHASED_PRODUCT_CUSTOMER_CUSTOMER_ID",
                table: "PURCHASED_PRODUCT");

            migrationBuilder.DropForeignKey(
                name: "BILL_PRODUCT_PRODUCT_ID",
                table: "BILLS");

            migrationBuilder.DropForeignKey(
                name: "PRICE_OFFER_PRODUCT_PRODUCT_ID",
                table: "PRICE_OFFERS");

            migrationBuilder.DropForeignKey(
                name: "PURCHASE_REQUEST_PRODUCT_PRODUCT_ID",
                table: "PURCHASE_REQUEST");

            migrationBuilder.DropForeignKey(
                name: "PURCHASED_PRODUCT_PRODUCT_PRODUCT_ID",
                table: "PURCHASED_PRODUCT");

            migrationBuilder.DropTable(
                name: "ACCOUNTS");

            migrationBuilder.DropTable(
                name: "CUSTOMERS");

            migrationBuilder.DropTable(
                name: "DEPARTMENTS");

            migrationBuilder.DropTable(
                name: "COMPANIES");

            migrationBuilder.DropTable(
                name: "PRODUCTS");

            migrationBuilder.DropTable(
                name: "BILLS");

            migrationBuilder.DropTable(
                name: "PURCHASED_PRODUCT");

            migrationBuilder.DropTable(
                name: "CATEGORIES");

            migrationBuilder.DropTable(
                name: "PRICE_OFFERS");

            migrationBuilder.DropTable(
                name: "PURCHASE_REQUEST");

            migrationBuilder.DropTable(
                name: "WHOLESALER");
        }
    }
}
