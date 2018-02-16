using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ACSWeb.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(                  //Таблица Pipeline
                name: "Pipeline",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(nullable: false),
                    //ShortName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pipeline", x => x.ID);
                });

            migrationBuilder.CreateTable(                  //Таблица SAKType
                name: "SAKType",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    TypeName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SAKType", x => x.ID);
                });

            migrationBuilder.CreateTable(                  //Таблица UMG
                name: "UMG",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    City = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    ShortName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UMG", x => x.ID);
                });

            migrationBuilder.CreateTable(                  //Таблица LVU
                name: "LVU",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(nullable: false),
                    UMGID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LVU", x => x.ID);
                    table.ForeignKey(
                        name: "FK_LVU_UMG_UMGID",
                        column: x => x.UMGID,
                        principalTable: "UMG",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(                  //Таблица KS 
                name: "KS",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    LVUID = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    PipelineID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_KS_LVU_LVUID",
                        column: x => x.LVUID,
                        principalTable: "LVU",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KS_Pipeline_PipelineID",
                        column: x => x.PipelineID,
                        principalTable: "Pipeline",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(                  //Таблица GPA
                name: "GPA",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CompShopNumber = table.Column<string>(nullable: true),
                    GTDType = table.Column<string>(nullable: true),
                    KSID = table.Column<int>(nullable: false),
                    StationNumber = table.Column<int>(nullable: false),
                    Type = table.Column<string>(nullable: false),
                    VCNType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GPA", x => x.ID);
                    table.ForeignKey(
                        name: "FK_GPA_KS_KSID",
                        column: x => x.KSID,
                        principalTable: "KS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(                  //Таблица SAK
                name: "SAK",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CommisioningDate = table.Column<DateTime>(nullable: false),
                    GPAID = table.Column<int>(nullable: false),
                    MTBase = table.Column<string>(nullable: false),
                    Manufacturer = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    SAKTypeID = table.Column<int>(nullable: false),
                    Seller = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SAK", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SAK_GPA_GPAID",
                        column: x => x.GPAID,
                        principalTable: "GPA",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SAK_SAKType_SAKTypeID",
                        column: x => x.SAKTypeID,
                        principalTable: "SAKType",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GPA_KSID",
                table: "GPA",
                column: "KSID");

            migrationBuilder.CreateIndex(
                name: "IX_KS_LVUID",
                table: "KS",
                column: "LVUID");

            migrationBuilder.CreateIndex(
                name: "IX_KS_PipelineID",
                table: "KS",
                column: "PipelineID");

            migrationBuilder.CreateIndex(
                name: "IX_LVU_UMGID",
                table: "LVU",
                column: "UMGID");

            migrationBuilder.CreateIndex(
                name: "IX_SAK_GPAID",
                table: "SAK",
                column: "GPAID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SAK_SAKTypeID",
                table: "SAK",
                column: "SAKTypeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SAK");

            migrationBuilder.DropTable(
                name: "GPA");

            migrationBuilder.DropTable(
                name: "SAKType");

            migrationBuilder.DropTable(
                name: "KS");

            migrationBuilder.DropTable(
                name: "LVU");

            migrationBuilder.DropTable(
                name: "Pipeline");

            migrationBuilder.DropTable(
                name: "UMG");
        }
    }
}
