using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace book.dataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdateProductImagesUrl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImgUrl",
                value: "/Images/product/1101442f-3709-4795-b24b-20823feaa2b5.jpg");

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImgUrl",
                value: "/Images/product/2d43d0e3-3050-4f81-86c6-da72789d8325.jpg");

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImgUrl",
                value: "/Images/product/5db25f79-489d-418d-a05e-4516e28233d4.jpg");

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImgUrl",
                value: "/Images/product/90349c89-d598-4e6a-a2cc-5ad2e8bb5cf0.jpg");

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImgUrl",
                value: "/Images/product/94c0cad0-2a14-4cdb-8ca0-bd81c6782c00.jpg");

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "Id",
                keyValue: 6,
                column: "ImgUrl",
                value: "/Images/product/ab2bf287-b312-4b69-9837-771a9b44b07e.jpg");

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "Id",
                keyValue: 7,
                column: "ImgUrl",
                value: "/Images/product/c22de649-0034-4208-b43a-f29dc584cc90.jpg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImgUrl",
                value: "");

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImgUrl",
                value: "");

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImgUrl",
                value: "");

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImgUrl",
                value: "");

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImgUrl",
                value: "");

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "Id",
                keyValue: 6,
                column: "ImgUrl",
                value: "");

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "Id",
                keyValue: 7,
                column: "ImgUrl",
                value: "");
        }
    }
}
