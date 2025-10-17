using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlackBird.TicketManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial_Migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GeneralTypeGroups",
                columns: table => new
                {
                    GeneralTypeGroupId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneralTypes", x => x.GeneralTypeGroupId);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserRoleId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.UserRoleId);
                });

            migrationBuilder.CreateTable(
                name: "GeneralTypeItems",
                columns: table => new
                {
                    GeneralTypeItemId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GeneralTypeGroupFk = table.Column<long>(type: "bigint", nullable: false),
                    ItemName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneralTypeItems", x => x.GeneralTypeItemId);
                    table.ForeignKey(
                        name: "FK_GeneralTypeItems_GeneralTypeGroups",
                        column: x => x.GeneralTypeGroupFk,
                        principalTable: "GeneralTypeGroups",
                        principalColumn: "GeneralTypeGroupId");
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    UserSecret = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Phone = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    IsLocked = table.Column<bool>(type: "bit", nullable: false),
                    LastAccess = table.Column<DateTime>(type: "datetime", nullable: true),
                    RoleFk = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_UserRoles",
                        column: x => x.RoleFk,
                        principalTable: "UserRoles",
                        principalColumn: "UserRoleId");
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    TicketId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TicketTypeFk = table.Column<long>(type: "bigint", nullable: false),
                    TicketStateFk = table.Column<long>(type: "bigint", nullable: false),
                    CreatedByUserFk = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Details = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Audience = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Localization = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    EventDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedByUserFk = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    AsignedToUserFk = table.Column<long>(type: "bigint", nullable: true),
                    ValidFrom = table.Column<DateTime>(type: "datetime2", nullable: false)
                        .Annotation("SqlServer:TemporalIsPeriodStartColumn", true),
                    ValidTo = table.Column<DateTime>(type: "datetime2", nullable: false)
                        .Annotation("SqlServer:TemporalIsPeriodEndColumn", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Tickets__712CC607530232FC", x => x.TicketId);
                    table.ForeignKey(
                        name: "FK_Tickets_GeneralTypeItems",
                        column: x => x.TicketTypeFk,
                        principalTable: "GeneralTypeItems",
                        principalColumn: "GeneralTypeItemId");
                    table.ForeignKey(
                        name: "FK_Tickets_GeneralTypeItems1",
                        column: x => x.TicketStateFk,
                        principalTable: "GeneralTypeItems",
                        principalColumn: "GeneralTypeItemId");
                    table.ForeignKey(
                        name: "FK_Tickets_Users",
                        column: x => x.CreatedByUserFk,
                        principalTable: "Users",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_Tickets_Users1",
                        column: x => x.AsignedToUserFk,
                        principalTable: "Users",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_Tickets_Users2",
                        column: x => x.UpdatedByUserFk,
                        principalTable: "Users",
                        principalColumn: "UserId");
                })
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "TicketsHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "dbo")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "ValidTo")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "ValidFrom");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralTypeItems_GeneralTypeGroupFk",
                table: "GeneralTypeItems",
                column: "GeneralTypeGroupFk");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_AsignedToUserFk",
                table: "Tickets",
                column: "AsignedToUserFk");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_CreatedByUserFk",
                table: "Tickets",
                column: "CreatedByUserFk");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_TicketStateFk",
                table: "Tickets",
                column: "TicketStateFk");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_TicketTypeFk",
                table: "Tickets",
                column: "TicketTypeFk");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_UpdatedByUserFk",
                table: "Tickets",
                column: "UpdatedByUserFk");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleFk",
                table: "Users",
                column: "RoleFk");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tickets")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "TicketsHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "dbo")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "ValidTo")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "ValidFrom");

            migrationBuilder.DropTable(
                name: "GeneralTypeItems");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "GeneralTypeGroups");

            migrationBuilder.DropTable(
                name: "UserRoles");
        }
    }
}
