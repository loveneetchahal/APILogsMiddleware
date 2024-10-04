using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APILogs.Migrations
{
    /// <inheritdoc />
    public partial class ApiLogs_Migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RequestLogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LogId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Node = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClientIp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TraceId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequestDateTimeUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RequestDateTimeUtcActionLevel = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RequestPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequestQuery = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequestQueries = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequestMethod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequestScheme = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequestHost = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequestHeaders = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequestBody = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequestContentType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResponseDateTimeUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ResponseDateTimeUtcActionLevel = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ResponseStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResponseHeaders = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResponseBody = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResponseContentType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsExceptionActionLevel = table.Column<bool>(type: "bit", nullable: true),
                    ExceptionMessage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExceptionStackTrace = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestLogs", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RequestLogs");
        }
    }
}
