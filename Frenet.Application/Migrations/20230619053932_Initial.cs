using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Frenet.Application.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Quotes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SellerCEP = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Carrier = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    CarrierCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DeliveryTime = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ServiceCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ServiceDescription = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    ShippingPrice = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    OriginalDeliveryTime = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    OriginalShippingPrice = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quotes", x => x.Id);
                });

            migrationBuilder.Sql(@"
                CREATE PROCEDURE dbo.InsertQuoteHistory
                    @SellerCEP VARCHAR(MAX),
                    @Carrier VARCHAR(MAX),
                    @CarrierCode VARCHAR(MAX),
                    @DeliveryTime VARCHAR(MAX),
                    @ServiceCode VARCHAR(MAX),
                    @ServiceDescription VARCHAR(MAX),
                    @ShippingPrice VARCHAR(MAX),
                    @OriginalDeliveryTime VARCHAR(MAX),
                    @OriginalShippingPrice VARCHAR(MAX),
                    @CreationDate DATETIME
                AS
                BEGIN
                    INSERT INTO Quotes (SellerCEP, Carrier, CarrierCode, DeliveryTime, ServiceCode, ServiceDescription, ShippingPrice, OriginalDeliveryTime, OriginalShippingPrice, CreationDate)
                    VALUES (@SellerCEP, @Carrier, @CarrierCode, @DeliveryTime, @ServiceCode, @ServiceDescription, @ShippingPrice, @OriginalDeliveryTime, @OriginalShippingPrice, @CreationDate)
                END
            ");

            migrationBuilder.Sql(@"
                CREATE PROCEDURE dbo.GetLast10QuoteHistories
                    @SellerCEP VARCHAR(MAX)
                AS
                BEGIN
                    SELECT TOP 10 *
                    FROM Quotes
                    WHERE SellerCEP = @SellerCEP
                    ORDER BY CreationDate DESC
                END
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Quotes");

            migrationBuilder.Sql("DROP PROCEDURE IF EXISTS dbo.InsertQuoteHistory");
            migrationBuilder.Sql("DROP PROCEDURE IF EXISTS dbo.GetLast10QuoteHistories");
        }
    }
}
