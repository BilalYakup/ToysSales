using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(8,2)", precision: 8, scale: 2, nullable: false),
                    UnitStock = table.Column<int>(type: "int", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Image", "ModifiedDate", "Name", "Status" },
                values: new object[] { 1, new DateTime(2023, 7, 13, 15, 41, 53, 260, DateTimeKind.Local).AddTicks(7532), null, "Cars.jpg", null, "Cars", 1 });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Image", "ModifiedDate", "Name", "Status" },
                values: new object[] { 2, new DateTime(2023, 7, 13, 15, 41, 53, 260, DateTimeKind.Local).AddTicks(7542), null, "Minecraft.jpg", null, "Minecraft", 1 });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Image", "ModifiedDate", "Name", "Status" },
                values: new object[] { 3, new DateTime(2023, 7, 13, 15, 41, 53, 260, DateTimeKind.Local).AddTicks(7543), null, "StarWars.png", null, "Star Wars", 1 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedDate", "DeletedDate", "Description", "Image", "ModifiedDate", "Name", "Status", "UnitPrice", "UnitStock" },
                values: new object[] { 1, 1, new DateTime(2023, 7, 13, 15, 41, 53, 260, DateTimeKind.Local).AddTicks(7695), null, "Cars 3 filminin en sevdiğiniz karakterleri şimdi tekli paketlerde sizlerle!\r\n\r\n \r\n\r\n1:55 ölçeğindeki heyecan verici film detayları olan bu koleksiyona çocuklar bayılacak! Şimşek McQueen, Cruz Ramirez ve Jackson Storm ve daha birçok karakterin bulunduğu bu büyük koleksiyon ile çocuklar araba koleksiyonuna başlayabilir ya da araba koleksiyonunu genişletebilirler.\r\n\r\n \r\n\r\nKarakterlerin hepsini toplayın ve Cars koleksiyonunuzu tamamlayın!\r\n\r\n \r\n\r\nPaket içerisinde; 1 adet Cars araç yer almaktadır.\r\n\r\n \r\n\r\nPaket ölçüsü: 14 x 4,5 x 17 cm", "Arabalar3TekliKarakter.jpg", null, "Fabulous Lightning Mcqueen", 1, 179m, 15 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedDate", "DeletedDate", "Description", "Image", "ModifiedDate", "Name", "Status", "UnitPrice", "UnitStock" },
                values: new object[] { 2, 2, new DateTime(2023, 7, 13, 15, 41, 53, 260, DateTimeKind.Local).AddTicks(7699), null, "Minecraft oyuncuları için küçük bir sette büyük eğlence!\r\n\r\n \r\n\r\nBu kompakt, klasik Minecraft macerasında çocukları meşgul edecek çok şey var. Oyunun kahraman karakterlerinden biri olan Steve’e bir yavru domuz, bir civciv ve bir Patlayan Creeper katılıyor. Çocuklar önce çalışma masasında demir cevheriyle yaratıcılıklarını gösterir. Daha sonra hayvanlarla ilgilenir, ektikleri şeker kamışına bakar ve sahneyi gelinciklerle süslerler. Daha sonra korkunç Patlayan Creeper ile savaşmak için kılıcı kullanırlar. Çocukların özel patlayıcı bloğu itmesiyle savaş zirveye ulaşır ve Patlayıcı Creeper havaya uçar. O günün aksiyonu bittiğinde bu eğlenceli set, çocuk odasında sergilendiğinde harika görünür.", "MinecraftCreeperjpg.jpg", null, "LEGO Minecraft Creeper Pususu 21177", 1, 199m, 32 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedDate", "DeletedDate", "Description", "Image", "ModifiedDate", "Name", "Status", "UnitPrice", "UnitStock" },
                values: new object[] { 3, 3, new DateTime(2023, 7, 13, 15, 41, 53, 260, DateTimeKind.Local).AddTicks(7700), null, "Luke Skywalker’ın simgeleşmiş X-wing Fighter’ı ile heyecan verici bir hendek akınına hazırlan!\r\n\r\n \r\n\r\nSadık droid R2-D2’nin gemide olduğundan emin ol, sonra kokpite atla. Motorları çalıştır ve uzaya fırla. Kanatları saldırı moduna geçir ve yaylı atıcıları İmparatorluk starship'lerine ateşle! Savaşı kazandıktan sonra Asilerin üssüne dönerek kutlama yap!\r\n\r\n \r\n\r\nÇocuklar, klasik Star Wars üçlemesinden Luke Skywalker’ın X-wing Fighter'ının bu havalı LEGO versiyonuyla kendi epik hikayelerinin kahramanı olabilir. Arkasında R2-D2 için yeri olan açılan bir LEGO mini figür kokpiti, bir düğmeye basarak saldırı pozisyonuna geçen kanatlar, kapanan iniş takımı ve 2 yaylı atıcı gibi hayranlarının çok beğeneceği orijinal detaylarla doludur. Oynayın ve Sergileyin Çocuklara yönelik bu muhteşem yapım oyuncağında Luke Skywalker, Prenses Leia ve General Dodonna LEGO mini figürleri, Luke'un ışın kılıcı dahil silahlar, ayrıca bir R2-D2 LEGO droid figürü bulunur. Çocuklar için en iyi parçalı modeller LEGO Group, 1999'dan beri Star Wars evreninden simgeleşmiş starship'leri, araçları, yerleri ve karakterleri canlandırıyor. LEGO Star Wars, şu anda yaratıcı çocuklar ve yetişkinler için eğlenceli hediye fikirleriyle LEGO'nun en başarılı temasıdır.", "StarWarsSkywalkerin.jpg", null, "LEGO Star Wars Luke Skywalker'ın X-Wing Fighter'ı 75301", 1, 1199m, 12 });

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
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
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
                name: "Products");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
