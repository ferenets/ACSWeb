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
            migrationBuilder.CreateTable(
                name: "Pipeline",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pipeline", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SAKType",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    TypeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SAKType", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "UMG",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    City = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    ShortName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UMG", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SAK",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CommisioningDate = table.Column<DateTime>(nullable: false),
                    MTBase = table.Column<string>(nullable: true),
                    Manufacturer = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    SAKTypeID = table.Column<int>(nullable: true),
                    Seller = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SAK", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SAK_SAKType_SAKTypeID",
                        column: x => x.SAKTypeID,
                        principalTable: "SAKType",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LVU",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(nullable: true),
                    UMGID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LVU", x => x.ID);
                    table.ForeignKey(
                        name: "FK_LVU_UMG_UMGID",
                        column: x => x.UMGID,
                        principalTable: "UMG",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "KS",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    LVUID = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    PipelineID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_KS_LVU_LVUID",
                        column: x => x.LVUID,
                        principalTable: "LVU",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KS_Pipeline_PipelineID",
                        column: x => x.PipelineID,
                        principalTable: "Pipeline",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GPA",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    CompShopNumber = table.Column<string>(nullable: true),
                    GTDType = table.Column<string>(nullable: true),
                    KSID = table.Column<int>(nullable: true),
                    StationNumber = table.Column<int>(nullable: false),
                    Type = table.Column<string>(nullable: true),
                    VCNType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GPA", x => x.ID);
                    table.ForeignKey(
                        name: "FK_GPA_SAK_ID",
                        column: x => x.ID,
                        principalTable: "SAK",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GPA_KS_KSID",
                        column: x => x.KSID,
                        principalTable: "KS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
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
                name: "IX_SAK_SAKTypeID",
                table: "SAK",
                column: "SAKTypeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GPA");

            migrationBuilder.DropTable(
                name: "SAK");

            migrationBuilder.DropTable(
                name: "KS");

            migrationBuilder.DropTable(
                name: "SAKType");

            migrationBuilder.DropTable(
                name: "LVU");

            migrationBuilder.DropTable(
                name: "Pipeline");

            migrationBuilder.DropTable(
                name: "UMG");
        }
    }
}
