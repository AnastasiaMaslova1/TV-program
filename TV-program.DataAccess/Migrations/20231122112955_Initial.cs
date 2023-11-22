using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TV_program.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "actor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExternalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_actor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "admin",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Registration = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastEntry = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExternalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_admin", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "channel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExternalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_channel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "genre",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExternalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_genre", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Registration = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastEntry = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExternalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TV show",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Desctiption = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DurationInMinutes = table.Column<int>(type: "int", nullable: false),
                    BroadcastDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BroadcastTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    IdChannel = table.Column<int>(type: "int", nullable: false),
                    ExternalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TV show", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TV show_channel_IdChannel",
                        column: x => x.IdChannel,
                        principalTable: "channel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user-channel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUser = table.Column<int>(type: "int", nullable: false),
                    IdChannel = table.Column<int>(type: "int", nullable: false),
                    ExternalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user-channel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_user-channel_channel_IdChannel",
                        column: x => x.IdChannel,
                        principalTable: "channel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_user-channel_user_IdUser",
                        column: x => x.IdUser,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "show-actor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdShow = table.Column<int>(type: "int", nullable: false),
                    IdActor = table.Column<int>(type: "int", nullable: false),
                    ExternalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_show-actor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_show-actor_TV show_IdShow",
                        column: x => x.IdShow,
                        principalTable: "TV show",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_show-actor_actor_IdActor",
                        column: x => x.IdActor,
                        principalTable: "actor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "show-genre",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdShow = table.Column<int>(type: "int", nullable: false),
                    IdGenre = table.Column<int>(type: "int", nullable: false),
                    ExternalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_show-genre", x => x.Id);
                    table.ForeignKey(
                        name: "FK_show-genre_TV show_IdShow",
                        column: x => x.IdShow,
                        principalTable: "TV show",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_show-genre_genre_IdGenre",
                        column: x => x.IdGenre,
                        principalTable: "genre",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_actor_ExternalId",
                table: "actor",
                column: "ExternalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_admin_ExternalId",
                table: "admin",
                column: "ExternalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_channel_ExternalId",
                table: "channel",
                column: "ExternalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_genre_ExternalId",
                table: "genre",
                column: "ExternalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_show-actor_ExternalId",
                table: "show-actor",
                column: "ExternalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_show-actor_IdActor",
                table: "show-actor",
                column: "IdActor");

            migrationBuilder.CreateIndex(
                name: "IX_show-actor_IdShow",
                table: "show-actor",
                column: "IdShow");

            migrationBuilder.CreateIndex(
                name: "IX_show-genre_ExternalId",
                table: "show-genre",
                column: "ExternalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_show-genre_IdGenre",
                table: "show-genre",
                column: "IdGenre");

            migrationBuilder.CreateIndex(
                name: "IX_show-genre_IdShow",
                table: "show-genre",
                column: "IdShow");

            migrationBuilder.CreateIndex(
                name: "IX_TV show_ExternalId",
                table: "TV show",
                column: "ExternalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TV show_IdChannel",
                table: "TV show",
                column: "IdChannel");

            migrationBuilder.CreateIndex(
                name: "IX_user_ExternalId",
                table: "user",
                column: "ExternalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_user-channel_ExternalId",
                table: "user-channel",
                column: "ExternalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_user-channel_IdChannel",
                table: "user-channel",
                column: "IdChannel");

            migrationBuilder.CreateIndex(
                name: "IX_user-channel_IdUser",
                table: "user-channel",
                column: "IdUser");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "admin");

            migrationBuilder.DropTable(
                name: "show-actor");

            migrationBuilder.DropTable(
                name: "show-genre");

            migrationBuilder.DropTable(
                name: "user-channel");

            migrationBuilder.DropTable(
                name: "actor");

            migrationBuilder.DropTable(
                name: "TV show");

            migrationBuilder.DropTable(
                name: "genre");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "channel");
        }
    }
}
