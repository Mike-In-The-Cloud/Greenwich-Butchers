using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GreButchersEFCore_V2.Migrations
{
    public partial class BulkOrderRemoveComplete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    DOB = table.Column<DateTime>(nullable: true),
                    BuildingName = table.Column<string>(nullable: true),
                    StreetAddress1 = table.Column<string>(nullable: true),
                    StreetAddress2 = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    PostCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Category_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Category_Name = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Category_Id);
                });

            migrationBuilder.CreateTable(
                name: "Supplier",
                columns: table => new
                {
                    Supplier_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Supplier_Name = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Supplier_ContactNumber = table.Column<string>(maxLength: 20, nullable: true),
                    Supplier_Email = table.Column<string>(maxLength: 100, nullable: true),
                    Supplier_Company = table.Column<string>(maxLength: 40, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplier", x => x.Supplier_Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Customer_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Customer_CompanyName = table.Column<string>(unicode: false, maxLength: 30, nullable: true),
                    ApplicationUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Customer_Id);
                    table.ForeignKey(
                        name: "FK_Customer_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Employee_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Employee_StartDate = table.Column<DateTime>(unicode: false, maxLength: 50, nullable: false),
                    Employee_EndDate = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Employee_Type = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    ApplicationUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Employee_Id);
                    table.ForeignKey(
                        name: "FK_Employee_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Product_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Product_Name = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Product_Price = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Product_Description = table.Column<string>(unicode: false, maxLength: 150, nullable: true),
                    Product_Weight = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Product_Image = table.Column<string>(nullable: true),
                    FK_Category_Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Product_Id);
                    table.ForeignKey(
                        name: "FK_Product_Category",
                        column: x => x.FK_Category_Id,
                        principalTable: "Category",
                        principalColumn: "Category_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BulkOrder",
                columns: table => new
                {
                    BulkOrder_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BulkOrder_Status = table.Column<int>(nullable: false),
                    BulkOrder_CreationDate = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    BulkOrder_CompletionDate = table.Column<string>(maxLength: 50, nullable: true),
                    BulkOrder_Margin = table.Column<double>(unicode: false, nullable: false),
                    FK_Customer_Id = table.Column<int>(nullable: true),
                    BulkOrder_Profit = table.Column<decimal>(type: "decimal(18, 2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BulkOrder", x => x.BulkOrder_Id);
                    table.ForeignKey(
                        name: "FK_BulkOrder_Customer",
                        column: x => x.FK_Customer_Id,
                        principalTable: "Customer",
                        principalColumn: "Customer_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InShopSales",
                columns: table => new
                {
                    InShopSales_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    InShopSales_Date = table.Column<string>(unicode: false, maxLength: 20, nullable: false),
                    InShopSales_Total = table.Column<decimal>(type: "decimal(18, 2)", nullable: true),
                    FK_Product_Id = table.Column<int>(nullable: true),
                    FK_Employee_Id = table.Column<int>(nullable: true),
                    InShopSales_Quantity = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InShopSales", x => x.InShopSales_Id);
                    table.ForeignKey(
                        name: "FK_InShopSales_Employee",
                        column: x => x.FK_Employee_Id,
                        principalTable: "Employee",
                        principalColumn: "Employee_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InShopSales_Product",
                        column: x => x.FK_Product_Id,
                        principalTable: "Product",
                        principalColumn: "Product_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Stock",
                columns: table => new
                {
                    Stock_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Stock_Shop = table.Column<int>(nullable: true),
                    Stock_Warehouse = table.Column<int>(nullable: true),
                    FK_Product_Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stock", x => x.Stock_Id);
                    table.ForeignKey(
                        name: "FK_Stock_Product",
                        column: x => x.FK_Product_Id,
                        principalTable: "Product",
                        principalColumn: "Product_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BulkOrderItem",
                columns: table => new
                {
                    BulkOrderItem_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FK_Product_Id = table.Column<int>(nullable: false),
                    BulkOrderItem_Quantity = table.Column<int>(nullable: true),
                    FK_BulkOrder_Id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BulkOrderItem", x => x.BulkOrderItem_Id);
                    table.ForeignKey(
                        name: "FK_BulkOrderItem_BulkOrder",
                        column: x => x.FK_BulkOrder_Id,
                        principalTable: "BulkOrder",
                        principalColumn: "BulkOrder_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BulkOrderItem_Product",
                        column: x => x.FK_Product_Id,
                        principalTable: "Product",
                        principalColumn: "Product_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ModifiedBy",
                columns: table => new
                {
                    ModifiedBy_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ModifiedBy_Date = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    FK_Employee_Id = table.Column<int>(nullable: true),
                    FK_BulkOrder_Id = table.Column<int>(nullable: true),
                    ModifiedBy_First = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModifiedBy", x => x.ModifiedBy_Id);
                    table.ForeignKey(
                        name: "FK_ModifiedBy_BulkOrder",
                        column: x => x.FK_BulkOrder_Id,
                        principalTable: "BulkOrder",
                        principalColumn: "BulkOrder_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ModifiedBy_Employee",
                        column: x => x.FK_Employee_Id,
                        principalTable: "Employee",
                        principalColumn: "Employee_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SupplierContacted",
                columns: table => new
                {
                    SupplierContacted_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SupplierContacted_Date = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    SupplierContacted_Reply = table.Column<bool>(nullable: false),
                    SupplerContacted_ReplyDate = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    SupplierContacted_Quote = table.Column<decimal>(type: "decimal(18, 2)", unicode: false, nullable: true),
                    SupplierContacted_DisplayToUser = table.Column<bool>(nullable: false),
                    SupplierContacted_UserSelected = table.Column<bool>(nullable: false),
                    FK_BulkOrder_Id = table.Column<int>(nullable: true),
                    FK_Suppler_Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplierContacted", x => x.SupplierContacted_Id);
                    table.ForeignKey(
                        name: "FK_SupplierContacted_BulkOrder",
                        column: x => x.FK_BulkOrder_Id,
                        principalTable: "BulkOrder",
                        principalColumn: "BulkOrder_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SupplierContacted_Supplier",
                        column: x => x.FK_Suppler_Id,
                        principalTable: "Supplier",
                        principalColumn: "Supplier_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BulkOrder_FK_Customer_Id",
                table: "BulkOrder",
                column: "FK_Customer_Id");

            migrationBuilder.CreateIndex(
                name: "IX_BulkOrderItem_FK_BulkOrder_Id",
                table: "BulkOrderItem",
                column: "FK_BulkOrder_Id");

            migrationBuilder.CreateIndex(
                name: "IX_BulkOrderItem_FK_Product_Id",
                table: "BulkOrderItem",
                column: "FK_Product_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_ApplicationUserId",
                table: "Customer",
                column: "ApplicationUserId",
                unique: true,
                filter: "[ApplicationUserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_ApplicationUserId",
                table: "Employee",
                column: "ApplicationUserId",
                unique: true,
                filter: "[ApplicationUserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_InShopSales_FK_Employee_Id",
                table: "InShopSales",
                column: "FK_Employee_Id");

            migrationBuilder.CreateIndex(
                name: "IX_InShopSales_FK_Product_Id",
                table: "InShopSales",
                column: "FK_Product_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ModifiedBy_FK_BulkOrder_Id",
                table: "ModifiedBy",
                column: "FK_BulkOrder_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ModifiedBy_FK_Employee_Id",
                table: "ModifiedBy",
                column: "FK_Employee_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Product_FK_Category_Id",
                table: "Product",
                column: "FK_Category_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Stock_FK_Product_Id",
                table: "Stock",
                column: "FK_Product_Id");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierContacted_FK_BulkOrder_Id",
                table: "SupplierContacted",
                column: "FK_BulkOrder_Id");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierContacted_FK_Suppler_Id",
                table: "SupplierContacted",
                column: "FK_Suppler_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "BulkOrderItem");

            migrationBuilder.DropTable(
                name: "InShopSales");

            migrationBuilder.DropTable(
                name: "ModifiedBy");

            migrationBuilder.DropTable(
                name: "Stock");

            migrationBuilder.DropTable(
                name: "SupplierContacted");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "BulkOrder");

            migrationBuilder.DropTable(
                name: "Supplier");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
