using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManager.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "varchar(16)", unicode: false, maxLength: 16, nullable: false),
                    LastName = table.Column<string>(type: "varchar(16)", unicode: false, maxLength: 16, nullable: false),
                    PhoneNumber = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    Email = table.Column<string>(type: "varchar(64)", unicode: false, maxLength: 64, nullable: false),
                    Adult = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "RoomType",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "varchar(16)", unicode: false, maxLength: 16, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomType", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Password = table.Column<string>(type: "varchar(32)", unicode: false, maxLength: 32, nullable: false),
                    FirstName = table.Column<string>(type: "varchar(16)", unicode: false, maxLength: 16, nullable: false),
                    Surname = table.Column<string>(type: "varchar(16)", unicode: false, maxLength: 16, nullable: false),
                    LastName = table.Column<string>(type: "varchar(16)", unicode: false, maxLength: 16, nullable: false),
                    EGN = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    PhoneNumber = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    HireDate = table.Column<DateTime>(type: "date", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    LeftPosition = table.Column<DateTime>(type: "date", nullable: true),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false),
                    Username = table.Column<string>(type: "varchar(16)", unicode: false, maxLength: 16, nullable: true),
                    Email = table.Column<string>(type: "varchar(64)", unicode: false, maxLength: 64, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Occupied = table.Column<bool>(type: "bit", nullable: false),
                    PriceBedAdult = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    PriceBedChild = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    RoomNumber = table.Column<string>(type: "varchar(8)", unicode: false, maxLength: 8, nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.ID);
                    table.ForeignKey(
                        name: "FK__Rooms__Type__5CD6CB2B",
                        column: x => x.Type,
                        principalTable: "RoomType",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    Arrival = table.Column<DateTime>(type: "date", nullable: false),
                    Departure = table.Column<DateTime>(type: "date", nullable: false),
                    IncludedBreakfast = table.Column<bool>(type: "bit", nullable: false),
                    AllInclusive = table.Column<bool>(type: "bit", nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    RoomID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.ID);
                    table.ForeignKey(
                        name: "FK__Reservati__RoomN__14270015",
                        column: x => x.RoomID,
                        principalTable: "Rooms",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK__Reservati__UserC__6E01572D",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "ReservationsClients",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    ReservationID = table.Column<int>(type: "int", nullable: true),
                    ClientID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservationsClients", x => x.ID);
                    table.ForeignKey(
                        name: "FK__Reservati__Clien__03F0984C",
                        column: x => x.ClientID,
                        principalTable: "Clients",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK__Reservati__Reser__02FC7413",
                        column: x => x.ReservationID,
                        principalTable: "Reservations",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_RoomID",
                table: "Reservations",
                column: "RoomID");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_UserID",
                table: "Reservations",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_ReservationsClients_ClientID",
                table: "ReservationsClients",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_ReservationsClients_ReservationID",
                table: "ReservationsClients",
                column: "ReservationID");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_Type",
                table: "Rooms",
                column: "Type");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReservationsClients");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "RoomType");
        }
    }
}
