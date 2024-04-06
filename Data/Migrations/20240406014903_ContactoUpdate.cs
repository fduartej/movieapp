﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace movieappauth.Data.Migrations
{
    /// <inheritdoc />
    public partial class ContactoUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "t_contacto",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "t_contacto");
        }
    }
}
