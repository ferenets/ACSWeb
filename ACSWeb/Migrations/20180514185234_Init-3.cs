using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ACSWeb.Migrations
{
    public partial class Init3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SAK_AOType_AOTypeID",
                table: "SAK");

            migrationBuilder.DropIndex(
                name: "IX_SAK_AOTypeID",
                table: "SAK");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_SAK_AOTypeID",
                table: "SAK",
                column: "AOTypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_SAK_AOType_AOTypeID",
                table: "SAK",
                column: "AOTypeID",
                principalTable: "AOType",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
