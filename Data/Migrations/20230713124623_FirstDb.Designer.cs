﻿// <auto-generated />
using System;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Data.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20230713124623_FirstDb")]
    partial class FirstDb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Data.Entities.Concrete.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "6938ae18-bf53-43dc-bc7e-f6a8a6adb8ff",
                            CreatedDate = new DateTime(2023, 7, 13, 15, 46, 22, 682, DateTimeKind.Local).AddTicks(9808),
                            Email = "admin@toyssales.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedUserName = "ADMIN",
                            PasswordHash = "AQAAAAEAACcQAAAAEH8pOlXPFqF7Bi2PoW2b1o3r8eyE5Yzw2hYV7CG7OsdJTaF4GjZvkOIA84M2CRZs2w==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "9db94e77-fde6-4855-ba97-d23267c05bfd",
                            Status = 1,
                            TwoFactorEnabled = false,
                            UserName = "Admin"
                        });
                });

            modelBuilder.Entity("Data.Entities.Concrete.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2023, 7, 13, 15, 46, 22, 682, DateTimeKind.Local).AddTicks(9510),
                            Image = "Cars.jpg",
                            Name = "Cars",
                            Status = 1
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(2023, 7, 13, 15, 46, 22, 682, DateTimeKind.Local).AddTicks(9520),
                            Image = "Minecraft.jpg",
                            Name = "Minecraft",
                            Status = 1
                        },
                        new
                        {
                            Id = 3,
                            CreatedDate = new DateTime(2023, 7, 13, 15, 46, 22, 682, DateTimeKind.Local).AddTicks(9521),
                            Image = "StarWars.png",
                            Name = "Star Wars",
                            Status = 1
                        });
                });

            modelBuilder.Entity("Data.Entities.Concrete.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<decimal>("UnitPrice")
                        .HasPrecision(8, 2)
                        .HasColumnType("decimal(8,2)");

                    b.Property<int>("UnitStock")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            CreatedDate = new DateTime(2023, 7, 13, 15, 46, 22, 682, DateTimeKind.Local).AddTicks(9659),
                            Description = "Cars 3 filminin en sevdiğiniz karakterleri şimdi tekli paketlerde sizlerle!\r\n\r\n \r\n\r\n1:55 ölçeğindeki heyecan verici film detayları olan bu koleksiyona çocuklar bayılacak! Şimşek McQueen, Cruz Ramirez ve Jackson Storm ve daha birçok karakterin bulunduğu bu büyük koleksiyon ile çocuklar araba koleksiyonuna başlayabilir ya da araba koleksiyonunu genişletebilirler.\r\n\r\n \r\n\r\nKarakterlerin hepsini toplayın ve Cars koleksiyonunuzu tamamlayın!\r\n\r\n \r\n\r\nPaket içerisinde; 1 adet Cars araç yer almaktadır.\r\n\r\n \r\n\r\nPaket ölçüsü: 14 x 4,5 x 17 cm",
                            Image = "Arabalar3TekliKarakter.jpg",
                            Name = "Fabulous Lightning Mcqueen",
                            Status = 1,
                            UnitPrice = 179m,
                            UnitStock = 15
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 2,
                            CreatedDate = new DateTime(2023, 7, 13, 15, 46, 22, 682, DateTimeKind.Local).AddTicks(9662),
                            Description = "Minecraft oyuncuları için küçük bir sette büyük eğlence!\r\n\r\n \r\n\r\nBu kompakt, klasik Minecraft macerasında çocukları meşgul edecek çok şey var. Oyunun kahraman karakterlerinden biri olan Steve’e bir yavru domuz, bir civciv ve bir Patlayan Creeper katılıyor. Çocuklar önce çalışma masasında demir cevheriyle yaratıcılıklarını gösterir. Daha sonra hayvanlarla ilgilenir, ektikleri şeker kamışına bakar ve sahneyi gelinciklerle süslerler. Daha sonra korkunç Patlayan Creeper ile savaşmak için kılıcı kullanırlar. Çocukların özel patlayıcı bloğu itmesiyle savaş zirveye ulaşır ve Patlayıcı Creeper havaya uçar. O günün aksiyonu bittiğinde bu eğlenceli set, çocuk odasında sergilendiğinde harika görünür.",
                            Image = "MinecraftCreeperjpg.jpg",
                            Name = "LEGO Minecraft Creeper Pususu 21177",
                            Status = 1,
                            UnitPrice = 199m,
                            UnitStock = 32
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 3,
                            CreatedDate = new DateTime(2023, 7, 13, 15, 46, 22, 682, DateTimeKind.Local).AddTicks(9663),
                            Description = "Luke Skywalker’ın simgeleşmiş X-wing Fighter’ı ile heyecan verici bir hendek akınına hazırlan!\r\n\r\n \r\n\r\nSadık droid R2-D2’nin gemide olduğundan emin ol, sonra kokpite atla. Motorları çalıştır ve uzaya fırla. Kanatları saldırı moduna geçir ve yaylı atıcıları İmparatorluk starship'lerine ateşle! Savaşı kazandıktan sonra Asilerin üssüne dönerek kutlama yap!\r\n\r\n \r\n\r\nÇocuklar, klasik Star Wars üçlemesinden Luke Skywalker’ın X-wing Fighter'ının bu havalı LEGO versiyonuyla kendi epik hikayelerinin kahramanı olabilir. Arkasında R2-D2 için yeri olan açılan bir LEGO mini figür kokpiti, bir düğmeye basarak saldırı pozisyonuna geçen kanatlar, kapanan iniş takımı ve 2 yaylı atıcı gibi hayranlarının çok beğeneceği orijinal detaylarla doludur. Oynayın ve Sergileyin Çocuklara yönelik bu muhteşem yapım oyuncağında Luke Skywalker, Prenses Leia ve General Dodonna LEGO mini figürleri, Luke'un ışın kılıcı dahil silahlar, ayrıca bir R2-D2 LEGO droid figürü bulunur. Çocuklar için en iyi parçalı modeller LEGO Group, 1999'dan beri Star Wars evreninden simgeleşmiş starship'leri, araçları, yerleri ve karakterleri canlandırıyor. LEGO Star Wars, şu anda yaratıcı çocuklar ve yetişkinler için eğlenceli hediye fikirleriyle LEGO'nun en başarılı temasıdır.",
                            Image = "StarWarsSkywalkerin.jpg",
                            Name = "LEGO Star Wars Luke Skywalker'ın X-Wing Fighter'ı 75301",
                            Status = 1,
                            UnitPrice = 1199m,
                            UnitStock = 12
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "341743f0-asd2–42de-afbf-59kmkkmk72cf6",
                            ConcurrencyStamp = "341743f0-asd2–42de-afbf-59kmkkmk72cf6",
                            Name = "admin",
                            NormalizedName = "ADMIN"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                            RoleId = "341743f0-asd2–42de-afbf-59kmkkmk72cf6"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Data.Entities.Concrete.Product", b =>
                {
                    b.HasOne("Data.Entities.Concrete.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Data.Entities.Concrete.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Data.Entities.Concrete.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.Entities.Concrete.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Data.Entities.Concrete.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Data.Entities.Concrete.Category", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
