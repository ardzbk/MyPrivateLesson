using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OzelDers.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialdDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Branches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BranchName = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Url = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsApproved = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branches", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Url = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsApproved = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
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
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: true),
                    LastName = table.Column<string>(type: "TEXT", nullable: true),
                    Gender = table.Column<string>(type: "TEXT", nullable: true),
                    City = table.Column<string>(type: "TEXT", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Phone = table.Column<string>(type: "TEXT", nullable: true),
                    ImageId = table.Column<int>(type: "INTEGER", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Images_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
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
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
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
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false)
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
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
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
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OrderDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", nullable: true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: true),
                    LastName = table.Column<string>(type: "TEXT", nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", nullable: true),
                    Address = table.Column<string>(type: "TEXT", nullable: true),
                    City = table.Column<string>(type: "TEXT", nullable: true),
                    Phone = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    OrderState = table.Column<int>(type: "INTEGER", nullable: false),
                    OrderType = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Url = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsApproved = table.Column<bool>(type: "INTEGER", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Graduation = table.Column<string>(type: "TEXT", nullable: false),
                    Url = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsApproved = table.Column<bool>(type: "INTEGER", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teachers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Adverts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TeacherId = table.Column<int>(type: "INTEGER", nullable: false),
                    BranchId = table.Column<int>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Price = table.Column<decimal>(type: "TEXT", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsApproved = table.Column<bool>(type: "INTEGER", nullable: false),
                    Url = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adverts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Adverts_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Adverts_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeacherBranches",
                columns: table => new
                {
                    TeacherId = table.Column<int>(type: "INTEGER", nullable: false),
                    BranchId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherBranches", x => new { x.BranchId, x.TeacherId });
                    table.ForeignKey(
                        name: "FK_TeacherBranches_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeacherBranches_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeacherStudents",
                columns: table => new
                {
                    TeacherId = table.Column<int>(type: "INTEGER", nullable: false),
                    StudentId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherStudents", x => new { x.TeacherId, x.StudentId });
                    table.ForeignKey(
                        name: "FK_TeacherStudents_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeacherStudents_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AdvertId = table.Column<int>(type: "INTEGER", nullable: false),
                    CartId = table.Column<int>(type: "INTEGER", nullable: false),
                    Amount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartItems_Adverts_AdvertId",
                        column: x => x.AdvertId,
                        principalTable: "Adverts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartItems_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OrderId = table.Column<int>(type: "INTEGER", nullable: false),
                    AdvertId = table.Column<int>(type: "INTEGER", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: true),
                    Amount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Adverts_AdvertId",
                        column: x => x.AdvertId,
                        principalTable: "Adverts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "30ff35dd-3866-45c9-879f-b1a6ebe1dfd3", null, "Yöneticiler", "Admin", "ADMIN" },
                    { "559b7044-6d24-4174-ba8a-399cb74029d2", null, "Öğretmenler", "Ogretmen", "OGRETMEN" },
                    { "8d1c8104-67cd-42f3-b185-a8de18e4b6bf", null, "Öğrenciler", "Ogrenci", "OGRENCI" }
                });

            migrationBuilder.InsertData(
                table: "Branches",
                columns: new[] { "Id", "BranchName", "CreatedDate", "Description", "IsApproved", "UpdatedDate", "Url" },
                values: new object[,]
                {
                    { 1, "Matematik", new DateTime(2023, 5, 15, 17, 49, 34, 120, DateTimeKind.Local).AddTicks(1430), "Matematik Dersleri", true, new DateTime(2023, 5, 15, 17, 49, 34, 120, DateTimeKind.Local).AddTicks(1430), "matematik" },
                    { 2, "Fizik", new DateTime(2023, 5, 15, 17, 49, 34, 120, DateTimeKind.Local).AddTicks(1430), "Fizik Dersleri", true, new DateTime(2023, 5, 15, 17, 49, 34, 120, DateTimeKind.Local).AddTicks(1440), "fizik" },
                    { 3, "Kimya", new DateTime(2023, 5, 15, 17, 49, 34, 120, DateTimeKind.Local).AddTicks(1440), "Kimya Dersleri", true, new DateTime(2023, 5, 15, 17, 49, 34, 120, DateTimeKind.Local).AddTicks(1440), "kimya" },
                    { 4, "Biyoloji", new DateTime(2023, 5, 15, 17, 49, 34, 120, DateTimeKind.Local).AddTicks(1440), "Biyoloji Dersleri", true, new DateTime(2023, 5, 15, 17, 49, 34, 120, DateTimeKind.Local).AddTicks(1440), "biyoloji" },
                    { 5, "Tarih", new DateTime(2023, 5, 15, 17, 49, 34, 120, DateTimeKind.Local).AddTicks(1440), "Tarih Dersleri", true, new DateTime(2023, 5, 15, 17, 49, 34, 120, DateTimeKind.Local).AddTicks(1440), "tarih" },
                    { 6, "Coğrafya", new DateTime(2023, 5, 15, 17, 49, 34, 120, DateTimeKind.Local).AddTicks(1440), "Coğrafya Dersleri", true, new DateTime(2023, 5, 15, 17, 49, 34, 120, DateTimeKind.Local).AddTicks(1440), "cografya" },
                    { 7, "İngilizce", new DateTime(2023, 5, 15, 17, 49, 34, 120, DateTimeKind.Local).AddTicks(1450), "İngilizce Dersleri", true, new DateTime(2023, 5, 15, 17, 49, 34, 120, DateTimeKind.Local).AddTicks(1450), "ingilizce" },
                    { 8, "Almanca", new DateTime(2023, 5, 15, 17, 49, 34, 120, DateTimeKind.Local).AddTicks(1450), "Almanca Dersleri", true, new DateTime(2023, 5, 15, 17, 49, 34, 120, DateTimeKind.Local).AddTicks(1450), "almanca" },
                    { 9, "Fransızca", new DateTime(2023, 5, 15, 17, 49, 34, 120, DateTimeKind.Local).AddTicks(1450), "Fransızca Dersleri", true, new DateTime(2023, 5, 15, 17, 49, 34, 120, DateTimeKind.Local).AddTicks(1450), "fransizca" },
                    { 10, "Felsefe", new DateTime(2023, 5, 15, 17, 49, 34, 120, DateTimeKind.Local).AddTicks(1450), "Felsefe Dersleri", true, new DateTime(2023, 5, 15, 17, 49, 34, 120, DateTimeKind.Local).AddTicks(1450), "felsefe" },
                    { 11, "Müzik", new DateTime(2023, 5, 15, 17, 49, 34, 120, DateTimeKind.Local).AddTicks(1450), "Müzik Dersleri", true, new DateTime(2023, 5, 15, 17, 49, 34, 120, DateTimeKind.Local).AddTicks(1460), "muzik" },
                    { 12, "Resim", new DateTime(2023, 5, 15, 17, 49, 34, 120, DateTimeKind.Local).AddTicks(1460), "Resim Dersleri", true, new DateTime(2023, 5, 15, 17, 49, 34, 120, DateTimeKind.Local).AddTicks(1460), "resim" }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "CreatedDate", "IsApproved", "UpdatedDate", "Url" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 5, 15, 17, 49, 34, 120, DateTimeKind.Local).AddTicks(2910), true, new DateTime(2023, 5, 15, 17, 49, 34, 120, DateTimeKind.Local).AddTicks(2920), "teacher-1.jpg" },
                    { 2, new DateTime(2023, 5, 15, 17, 49, 34, 120, DateTimeKind.Local).AddTicks(2920), true, new DateTime(2023, 5, 15, 17, 49, 34, 120, DateTimeKind.Local).AddTicks(2920), "teacher-2.jpg" },
                    { 3, new DateTime(2023, 5, 15, 17, 49, 34, 120, DateTimeKind.Local).AddTicks(2920), true, new DateTime(2023, 5, 15, 17, 49, 34, 120, DateTimeKind.Local).AddTicks(2920), "teacher-3.jpg" },
                    { 4, new DateTime(2023, 5, 15, 17, 49, 34, 120, DateTimeKind.Local).AddTicks(2920), true, new DateTime(2023, 5, 15, 17, 49, 34, 120, DateTimeKind.Local).AddTicks(2920), "teacher-4.jpg" },
                    { 5, new DateTime(2023, 5, 15, 17, 49, 34, 120, DateTimeKind.Local).AddTicks(2920), true, new DateTime(2023, 5, 15, 17, 49, 34, 120, DateTimeKind.Local).AddTicks(2920), "teacher-5.jpg" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "City", "ConcurrencyStamp", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "Gender", "ImageId", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "Phone", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "017e48f4-28d6-40e6-b3b5-740178fe348d", 0, "Kocaeli", "4fdad626-3148-4b4b-9f1e-b45828b32ac1", new DateTime(2000, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "ardaozbek@hotmail.com", true, "Arda", "Erkek", 5, "Ozbek", false, null, "ARDAOZBEK@HOTMAIL.COM", "ARDAOZBEK", "AQAAAAIAAYagAAAAEAKy3Tm7WSbshPnJbtghWwx9X7jOHr7zh4fEDfJ0PM0xRN+2ZtNM0sj9BY64pVU8lw==", "5555555555", null, false, "83a8b19f-f9ad-44d4-a40e-5e4831030954", false, "ardaozbek" },
                    { "09875cf2-8743-4485-9ec7-e53fba9e8561", 0, "Ankara", "63ced254-61c4-4629-af16-827ac51a994c", new DateTime(2005, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "zeynepturk@gmail.com", true, "Zeynep", "Kadın", 5, "Türk", false, null, "ZEYNEPTURK@GMAIL.COM", "ZEYNEPTURK", "AQAAAAIAAYagAAAAEKTQ8r0vyWHhEUup1qE2gGRWoIvDw/KgE93aVGyDK9O72n97jhzeMYSEWj8FJv4kdw==", "5336549872", null, false, "414d52b3-1972-4ad3-a25d-596e4a160a4f", false, "zeynepturk" },
                    { "27f671d7-f91d-4f04-b3a5-49c0c8269e6f", 0, "Bursa", "7fa1ae41-cadc-4416-aa7b-664660005eb4", new DateTime(2009, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "mehmetkaya@hotmail.com", true, "Mehmet", "Erkek", 5, "Kaya", false, null, "MEHMETKAYA@HOTMAIL.COM", "MEHMETKAYA", "AQAAAAIAAYagAAAAEGBtWWB6GOPHuOVsDhNA4LF5D9wIpG+W+c9yrQ57d4C0PJSMAztZXYmgQo6d0prk5g==", "5396542513", null, false, "fea1cdc5-8d4b-4a0e-b1a0-10eaf440491a", false, "mehmetkaya" },
                    { "3048b95c-ee31-46b8-b8a0-cd37b8d21ba8", 0, "İstanbul", "0029197d-6232-4d75-806b-b5b01938526c", new DateTime(1992, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "esraaydin@hotmail.com", true, "Şevval", "Kadın", 1, "Demir", false, null, "sevval.demir@hotmail.com", "SEVVALDEMIR", "AQAAAAIAAYagAAAAEK+gSq/N420oUQdLlJldSd9KXW0M1OoZ4TOh+4YLvvfENk/iXc2z4I1OeoGQ3yuTGg==", "5387891234", null, false, "4a5ab433-b385-4d50-9031-b6fc94b25c14", false, "sevvaldemir" },
                    { "37bf95fd-a365-4112-97d5-35830bad6d28", 0, "Bursa", "44df29d2-6ad2-4708-a1ce-5eae56b02d22", new DateTime(1992, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "seyma.yilmaz@hotmail.com", true, "Şeyma", "Kadın", 1, "Yılmaz", false, null, "SEYMA.YILMAZ@HOTMAIL.COM", "SEYMAYILMAZ", "AQAAAAIAAYagAAAAECKWFgrH0M6E01jHk2S+jV2HLE2mGqgyFvYZwqWcc4xv1tXm04nsnTxg2upUXtsNQg==", "5399876543", null, false, "9c7f82cf-f9a0-4e03-8802-cd5f50ebd593", false, "seymayilmaz" },
                    { "5d2e0e62-8893-462d-902e-91edbcdc62f3", 0, "Adana", "a52fe9c4-3bd6-4b19-afca-ce3aeffcf197", new DateTime(2003, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "fatmasahin@gmail.com", true, "Fatma", "Kadın", 5, "Şahin", false, null, "FATMASAHIN@GMAIL.COM", "FATMASAHIN", "AQAAAAIAAYagAAAAEAQvsiQMY5aT34elgXZuw0Qk/Z0kTUfYRIKmU5SoSZevbCRo9Zqt8Ph779qJ7oxqqQ==", "5334567890", null, false, "13305226-1a4f-4f5d-a820-a737b122f55a", false, "fatmasahin" },
                    { "6dc72582-a387-4986-a3e6-8579780056e0", 0, "Ankara", "e98e5b2d-677c-4308-8f68-a3bea65e6368", new DateTime(2002, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "erdiutku@gmail.com", true, "Erdi", "Erkek", 5, "Utku", false, null, "ERDIUTKU@GMAİL.COM", "ERDIUTKU", "AQAAAAIAAYagAAAAEO3maalEbtwIUWf1niI2JtJYKzT7An7Hazkk7w8L3PQpWX9KK+dgjDRgxRSXZCAtHA==", "5551234567", null, false, "d81fc7e0-9c59-41fc-950e-a17d1ad7501b", false, "erdiutku" },
                    { "7d15f7ab-59b0-4fdc-af5f-b3a6679e476a", 0, "İzmir", "e142d017-2ac7-4318-96dd-54b684e892d4", new DateTime(2001, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "ayse.demir@yahoo.com", true, "Ayşe", "Kadın", 5, "Demir", false, null, "AYSE.DEMIR@YAHOO.COM", "AYSEDEMIR", "AQAAAAIAAYagAAAAEJEPi2wZ/5fAYVPJG6z8c4lU7wQLJ6YGWz2T9wd0PATfrLxM78G5UoEo3ZxhZQToAg==", "5329876543", null, false, "77b17e5d-ae1d-4209-80e4-61ac3a8dd491", false, "aysedemir" },
                    { "92c8f829-e555-4cb4-8b63-1fb21b1c178b", 0, "İzmir", "68d5778d-a66c-4b64-bd58-e59954197664", new DateTime(1994, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "mehmet.yildiz@gmail.com", true, "Mehmet", "Erkek", 1, "Yıldız", false, null, "MEHMET.YILDIZ@GMAIL.COM", "MEHMETYILDIZ", "AQAAAAIAAYagAAAAEKLNQJIw8GN/FZmsIHzOCKog45aYfw92IJiNVVsb17WfuQHgBnt0UwXgHPR94bIl/Q==", "5336549876", null, false, "d21a14ee-8a6b-4080-8dc7-33582d19d812", false, "mehmetyildiz" },
                    { "94b29472-e77f-4dd5-a535-bd6ef0aa31b3", 0, "Kayseri", "d1bbf96f-46ff-4496-9a88-2f609c9fe701", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "kemal.kaya@gmail.com", true, "Kemal", "Erkek", 1, "Kaya", false, null, "KEMAL.KAYA@GMAIL.COM", "KEMALKAYA", "AQAAAAIAAYagAAAAEBM79IkKBupsu866EMDH/xuBG6IbDQXVz12ENZmzN23HWM1sBwiiprPwB/ZLO6GHrA==", "5359876543", null, false, "8c5823e8-d373-444e-8b72-19ef371b5c90", false, "kemalkaya" },
                    { "9725ae03-6471-4dbf-982e-8dabfcc5d73d", 0, "İstanbul", "93e7d53e-4e29-4421-9184-2bf720eeb7e9", new DateTime(2007, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "cananumac@hotmail.com", true, "Canan", "Kadın", 5, "Umac", false, null, "CANANUMAC@HOTMAIL.COM", "CANANUMAC", "AQAAAAIAAYagAAAAED7j3x1v5UCYAnpo3eEomgIiiFAXEoWzdwe3HL2dvvllxsp1J0udTTZtb2NzxEY4qg==", "5396542513", null, false, "cd923cb5-023a-41df-92fa-93f0eaf71a8a", false, "cananumac" },
                    { "aaa79067-b136-4088-b15e-875859ce6e11", 0, "Bursa", "976efe73-3f36-4fad-97c5-ce7f1ba77b05", new DateTime(1980, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "selinkar@hotmail.com", true, "Selin", "Kadın", 1, "Kar", false, null, "SELINKAR@HOTMAIL.COM", "SELINKAR", "AQAAAAIAAYagAAAAEC/zxdFYYQwp8wms7RJ7EP0p9VqdzrSaNx9nDccN/I2BpwO6soKV4dB5/4/B5FmYXw==", "5399782513", null, false, "615e169c-649b-4b1e-9b3e-68a2580dc522", false, "selinkar" },
                    { "b5d7b86b-3034-4280-a19b-f172bdb64a00", 0, "Antalya", "5733e1f0-4924-4b02-9c19-3140379f7674", new DateTime(2009, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "mustafaozkan@gmail.com", true, "Mustafa", "Erkek", 5, "Özkan", false, null, "MUSTAFAOZKAN@GMAIL.COM", "MUSTAFAOZKAN", "AQAAAAIAAYagAAAAEPN+DUXt+XNvX+XfLGBnAcR+ze3oi2WmbnixsQC1aD9UKEP9kV6llANegBifFHpVDQ==", "5423456789", null, false, "0cd85894-5e05-45f1-9a26-68fb0edaf024", false, "mustafaozkan" },
                    { "d5815fd3-b3ac-4b8e-808a-7458f76a45d4", 0, "İstanbul", "7e33881f-45ec-488b-b864-bc0045e38ff2", new DateTime(2008, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "esraaydin@hotmail.com", true, "Esra", "Kadın", 5, "Aydın", false, null, "ESRAAYDIN@HOTMAIL.COM", "ESRAAYDIN", "AQAAAAIAAYagAAAAEOuMOFRIBcMWC1cgESOLYgLDvsXLTzgEy96btBVMM8tGtqvdTA8o9mCznozuUcw6KA==", "5397891234", null, false, "7e5671c9-26d6-409d-b71d-d09b17599797", false, "esraaydin" },
                    { "e1d3b45a-32fb-4ca4-ae5e-9be1e0f10390", 0, "Adana", "bff00c9b-713c-4923-b223-7a685f452274", new DateTime(1990, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "gokhan.aydin@gmail.com", true, "Gökhan", "Erkek", 1, "Aydın", false, null, "GOKHAN.AYDIN@GMAIL.COM", "GOKHANAYDIN", "AQAAAAIAAYagAAAAEOy78GJoNtzRuPERX587Xo5EpmY/s+RKki78Cbf5N7mzAr58DuL+/w/6GDiE+kcUbQ==", "5321234567", null, false, "f6300690-7b79-4bcc-846f-94bf92569571", false, "gokhanaydin" },
                    { "eb7696e4-0884-4d14-b323-b1f741c83824", 0, "Ankara", "5aea8ab1-ef83-4096-a787-171dc34c1e3e", new DateTime(1990, 2, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "cem.yilmaz@gmail.com", true, "Cem", "Erkek", 1, "Yılmaz", false, null, "CEM.YILMAZ@GMAIL.COM", "CEMYILMAZ", "AQAAAAIAAYagAAAAEK3cARcNT+K7CqHU/R+xZDe8XCnePLctzWAzByOr/iS2XSZUEzYxccftov9GpLknSQ==", "5323456789", null, false, "3db0d348-dc89-419c-ac05-f6a1d71e4044", false, "cemyilmaz" },
                    { "f7672743-d404-489d-a94e-b38567524321", 0, "İstanbul", "f70c7821-9f3d-4e60-8be0-cd7d95e31181", new DateTime(2008, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "emreakin@hotmail.com", true, "Emre", "Erkek", 5, "Akın", false, null, "EMREAKIN@HOTMAIL.COM", "EMREAKIN", "AQAAAAIAAYagAAAAEDK/3UnJHm2BCWgHnfQ70GIN5MwyJ96I/MOgQV8t48q1qDl1Tv50FFs38G3JZtDK1Q==", "5379876543", null, false, "ef07d8a5-131f-4305-9076-3d4854ce46f2", false, "emreakin" },
                    { "f8d91c58-9339-4efb-a435-3803676bf0c4", 0, "Antalya", "02d9b1c6-3697-4fc9-8a4f-9685157af194", new DateTime(1980, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "gul.sahin@hotmail.com", true, "Gül", "Kadın", 1, "Şahin", false, null, "GUL.SAHIN@HOTMAIL.COM", "GULSAHIN", "AQAAAAIAAYagAAAAEIGMpU1xYYwHU+L1cxSLDAOAaXdkaWDXWdFjuG+zNGRaLRCRHYiX2/JG+xB4QfFwiw==", "5361234567", null, false, "5f3f813e-45ba-4bf9-9087-f0af4c1f3ec9", false, "gulsahin" },
                    { "fc151106-cb36-483f-887a-be75dd330661", 0, "İzmir", "40fa3a66-202f-481b-bfd4-b1e19211c5c0", new DateTime(2007, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ali.yildiz@gmail.com", true, "Ali", "Erkek", 5, "Yıldız", false, null, "ALI.YILDIZ@GMAIL.COM", "ALIYILDIZ", "AQAAAAIAAYagAAAAEH511yFLVbyc5uE4dTMc66IDTOUUcdDQJUcBfRSjC3pknu1RrOS75j+U/w7nParV2A==", "5559876543", null, false, "b7a81098-ccbc-4caa-b202-4d8fd5bc5b40", false, "aliyildiz" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "30ff35dd-3866-45c9-879f-b1a6ebe1dfd3", "017e48f4-28d6-40e6-b3b5-740178fe348d" },
                    { "8d1c8104-67cd-42f3-b185-a8de18e4b6bf", "09875cf2-8743-4485-9ec7-e53fba9e8561" },
                    { "8d1c8104-67cd-42f3-b185-a8de18e4b6bf", "27f671d7-f91d-4f04-b3a5-49c0c8269e6f" },
                    { "559b7044-6d24-4174-ba8a-399cb74029d2", "3048b95c-ee31-46b8-b8a0-cd37b8d21ba8" },
                    { "559b7044-6d24-4174-ba8a-399cb74029d2", "37bf95fd-a365-4112-97d5-35830bad6d28" },
                    { "8d1c8104-67cd-42f3-b185-a8de18e4b6bf", "5d2e0e62-8893-462d-902e-91edbcdc62f3" },
                    { "8d1c8104-67cd-42f3-b185-a8de18e4b6bf", "6dc72582-a387-4986-a3e6-8579780056e0" },
                    { "8d1c8104-67cd-42f3-b185-a8de18e4b6bf", "7d15f7ab-59b0-4fdc-af5f-b3a6679e476a" },
                    { "559b7044-6d24-4174-ba8a-399cb74029d2", "92c8f829-e555-4cb4-8b63-1fb21b1c178b" },
                    { "559b7044-6d24-4174-ba8a-399cb74029d2", "94b29472-e77f-4dd5-a535-bd6ef0aa31b3" },
                    { "8d1c8104-67cd-42f3-b185-a8de18e4b6bf", "9725ae03-6471-4dbf-982e-8dabfcc5d73d" },
                    { "559b7044-6d24-4174-ba8a-399cb74029d2", "aaa79067-b136-4088-b15e-875859ce6e11" },
                    { "8d1c8104-67cd-42f3-b185-a8de18e4b6bf", "b5d7b86b-3034-4280-a19b-f172bdb64a00" },
                    { "8d1c8104-67cd-42f3-b185-a8de18e4b6bf", "d5815fd3-b3ac-4b8e-808a-7458f76a45d4" },
                    { "559b7044-6d24-4174-ba8a-399cb74029d2", "e1d3b45a-32fb-4ca4-ae5e-9be1e0f10390" },
                    { "559b7044-6d24-4174-ba8a-399cb74029d2", "eb7696e4-0884-4d14-b323-b1f741c83824" },
                    { "8d1c8104-67cd-42f3-b185-a8de18e4b6bf", "f7672743-d404-489d-a94e-b38567524321" },
                    { "559b7044-6d24-4174-ba8a-399cb74029d2", "f8d91c58-9339-4efb-a435-3803676bf0c4" },
                    { "8d1c8104-67cd-42f3-b185-a8de18e4b6bf", "fc151106-cb36-483f-887a-be75dd330661" }
                });

            migrationBuilder.InsertData(
                table: "Carts",
                columns: new[] { "Id", "UserId" },
                values: new object[,]
                {
                    { 1, "017e48f4-28d6-40e6-b3b5-740178fe348d" },
                    { 2, "9725ae03-6471-4dbf-982e-8dabfcc5d73d" },
                    { 3, "6dc72582-a387-4986-a3e6-8579780056e0" },
                    { 4, "7d15f7ab-59b0-4fdc-af5f-b3a6679e476a" },
                    { 5, "27f671d7-f91d-4f04-b3a5-49c0c8269e6f" },
                    { 6, "5d2e0e62-8893-462d-902e-91edbcdc62f3" },
                    { 7, "f7672743-d404-489d-a94e-b38567524321" },
                    { 8, "09875cf2-8743-4485-9ec7-e53fba9e8561" },
                    { 9, "fc151106-cb36-483f-887a-be75dd330661" },
                    { 10, "b5d7b86b-3034-4280-a19b-f172bdb64a00" },
                    { 11, "d5815fd3-b3ac-4b8e-808a-7458f76a45d4" },
                    { 12, "aaa79067-b136-4088-b15e-875859ce6e11" },
                    { 13, "eb7696e4-0884-4d14-b323-b1f741c83824" },
                    { 14, "3048b95c-ee31-46b8-b8a0-cd37b8d21ba8" },
                    { 15, "92c8f829-e555-4cb4-8b63-1fb21b1c178b" },
                    { 16, "f8d91c58-9339-4efb-a435-3803676bf0c4" },
                    { 17, "94b29472-e77f-4dd5-a535-bd6ef0aa31b3" },
                    { 18, "e1d3b45a-32fb-4ca4-ae5e-9be1e0f10390" },
                    { 19, "37bf95fd-a365-4112-97d5-35830bad6d28" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "CreatedDate", "IsApproved", "UpdatedDate", "Url", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 5, 15, 17, 49, 33, 399, DateTimeKind.Local).AddTicks(3140), true, new DateTime(2023, 5, 15, 17, 49, 33, 399, DateTimeKind.Local).AddTicks(3190), null, "9725ae03-6471-4dbf-982e-8dabfcc5d73d" },
                    { 2, new DateTime(2023, 5, 15, 17, 49, 33, 399, DateTimeKind.Local).AddTicks(3200), true, new DateTime(2023, 5, 15, 17, 49, 33, 399, DateTimeKind.Local).AddTicks(3200), null, "6dc72582-a387-4986-a3e6-8579780056e0" },
                    { 3, new DateTime(2023, 5, 15, 17, 49, 33, 399, DateTimeKind.Local).AddTicks(3200), true, new DateTime(2023, 5, 15, 17, 49, 33, 399, DateTimeKind.Local).AddTicks(3200), null, "7d15f7ab-59b0-4fdc-af5f-b3a6679e476a" },
                    { 4, new DateTime(2023, 5, 15, 17, 49, 33, 399, DateTimeKind.Local).AddTicks(3200), true, new DateTime(2023, 5, 15, 17, 49, 33, 399, DateTimeKind.Local).AddTicks(3200), null, "27f671d7-f91d-4f04-b3a5-49c0c8269e6f" },
                    { 5, new DateTime(2023, 5, 15, 17, 49, 33, 399, DateTimeKind.Local).AddTicks(3200), true, new DateTime(2023, 5, 15, 17, 49, 33, 399, DateTimeKind.Local).AddTicks(3210), null, "5d2e0e62-8893-462d-902e-91edbcdc62f3" },
                    { 6, new DateTime(2023, 5, 15, 17, 49, 33, 399, DateTimeKind.Local).AddTicks(3210), true, new DateTime(2023, 5, 15, 17, 49, 33, 399, DateTimeKind.Local).AddTicks(3210), null, "f7672743-d404-489d-a94e-b38567524321" },
                    { 7, new DateTime(2023, 5, 15, 17, 49, 33, 399, DateTimeKind.Local).AddTicks(3210), true, new DateTime(2023, 5, 15, 17, 49, 33, 399, DateTimeKind.Local).AddTicks(3210), null, "09875cf2-8743-4485-9ec7-e53fba9e8561" },
                    { 8, new DateTime(2023, 5, 15, 17, 49, 33, 399, DateTimeKind.Local).AddTicks(3210), true, new DateTime(2023, 5, 15, 17, 49, 33, 399, DateTimeKind.Local).AddTicks(3210), null, "fc151106-cb36-483f-887a-be75dd330661" },
                    { 9, new DateTime(2023, 5, 15, 17, 49, 33, 399, DateTimeKind.Local).AddTicks(3220), true, new DateTime(2023, 5, 15, 17, 49, 33, 399, DateTimeKind.Local).AddTicks(3220), null, "b5d7b86b-3034-4280-a19b-f172bdb64a00" },
                    { 10, new DateTime(2023, 5, 15, 17, 49, 33, 399, DateTimeKind.Local).AddTicks(3220), true, new DateTime(2023, 5, 15, 17, 49, 33, 399, DateTimeKind.Local).AddTicks(3220), null, "d5815fd3-b3ac-4b8e-808a-7458f76a45d4" }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "CreatedDate", "Graduation", "IsApproved", "UpdatedDate", "Url", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 5, 15, 17, 49, 33, 399, DateTimeKind.Local).AddTicks(3270), "Çanakkale Onsekiz Mart Üniversitesi", true, new DateTime(2023, 5, 15, 17, 49, 33, 399, DateTimeKind.Local).AddTicks(3270), null, "aaa79067-b136-4088-b15e-875859ce6e11" },
                    { 2, new DateTime(2023, 5, 15, 17, 49, 33, 399, DateTimeKind.Local).AddTicks(3280), "Orta Doğu Teknik Üniversitesi", true, new DateTime(2023, 5, 15, 17, 49, 33, 399, DateTimeKind.Local).AddTicks(3290), null, "eb7696e4-0884-4d14-b323-b1f741c83824" },
                    { 3, new DateTime(2023, 5, 15, 17, 49, 33, 399, DateTimeKind.Local).AddTicks(3290), "İstanbul Teknik Üniversitesi", true, new DateTime(2023, 5, 15, 17, 49, 33, 399, DateTimeKind.Local).AddTicks(3290), null, "3048b95c-ee31-46b8-b8a0-cd37b8d21ba8" },
                    { 4, new DateTime(2023, 5, 15, 17, 49, 33, 399, DateTimeKind.Local).AddTicks(3290), "Ege Üniversitesi", true, new DateTime(2023, 5, 15, 17, 49, 33, 399, DateTimeKind.Local).AddTicks(3290), null, "92c8f829-e555-4cb4-8b63-1fb21b1c178b" },
                    { 5, new DateTime(2023, 5, 15, 17, 49, 33, 399, DateTimeKind.Local).AddTicks(3300), "Akdeniz Üniversitesi", true, new DateTime(2023, 5, 15, 17, 49, 33, 399, DateTimeKind.Local).AddTicks(3300), null, "f8d91c58-9339-4efb-a435-3803676bf0c4" },
                    { 6, new DateTime(2023, 5, 15, 17, 49, 33, 399, DateTimeKind.Local).AddTicks(3300), "Erciyes Üniversitesi", true, new DateTime(2023, 5, 15, 17, 49, 33, 399, DateTimeKind.Local).AddTicks(3300), null, "94b29472-e77f-4dd5-a535-bd6ef0aa31b3" },
                    { 7, new DateTime(2023, 5, 15, 17, 49, 33, 399, DateTimeKind.Local).AddTicks(3300), "Çukurova Üniversitesi", true, new DateTime(2023, 5, 15, 17, 49, 33, 399, DateTimeKind.Local).AddTicks(3300), null, "e1d3b45a-32fb-4ca4-ae5e-9be1e0f10390" },
                    { 8, new DateTime(2023, 5, 15, 17, 49, 33, 399, DateTimeKind.Local).AddTicks(3300), "Uludağ Üniversitesi", true, new DateTime(2023, 5, 15, 17, 49, 33, 399, DateTimeKind.Local).AddTicks(3310), null, "37bf95fd-a365-4112-97d5-35830bad6d28" }
                });

            migrationBuilder.InsertData(
                table: "Adverts",
                columns: new[] { "Id", "BranchId", "CreatedDate", "Description", "IsApproved", "Price", "TeacherId", "UpdatedDate", "Url" },
                values: new object[] { 1, 4, new DateTime(2023, 5, 15, 17, 49, 34, 119, DateTimeKind.Local).AddTicks(6090), "dsdasd", true, 45m, 4, new DateTime(2023, 5, 15, 17, 49, 34, 119, DateTimeKind.Local).AddTicks(6110), "dsdds" });

            migrationBuilder.InsertData(
                table: "TeacherBranches",
                columns: new[] { "BranchId", "TeacherId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 },
                    { 4, 4 },
                    { 5, 5 },
                    { 6, 6 },
                    { 7, 7 },
                    { 7, 8 }
                });

            migrationBuilder.InsertData(
                table: "TeacherStudents",
                columns: new[] { "StudentId", "TeacherId" },
                values: new object[,]
                {
                    { 2, 1 },
                    { 4, 2 },
                    { 6, 3 },
                    { 5, 6 },
                    { 1, 7 },
                    { 2, 7 },
                    { 3, 7 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Adverts_BranchId",
                table: "Adverts",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Adverts_TeacherId",
                table: "Adverts",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

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
                name: "IX_AspNetUsers_ImageId",
                table: "AspNetUsers",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_AdvertId",
                table: "CartItems",
                column: "AdvertId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_CartId",
                table: "CartItems",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_UserId",
                table: "Carts",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_AdvertId",
                table: "OrderItems",
                column: "AdvertId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_UserId",
                table: "Students",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TeacherBranches_TeacherId",
                table: "TeacherBranches",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_UserId",
                table: "Teachers",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TeacherStudents_StudentId",
                table: "TeacherStudents",
                column: "StudentId");
        }

        /// <inheritdoc />
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
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "TeacherBranches");

            migrationBuilder.DropTable(
                name: "TeacherStudents");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Adverts");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Branches");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Images");
        }
    }
}
