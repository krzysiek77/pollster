using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace pollster.persistence.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    CreatedAt = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2018, 11, 16, 16, 38, 17, 569, DateTimeKind.Utc).AddTicks(4066)),
                    IsExisting = table.Column<bool>(nullable: false, defaultValue: true),
                    ClientId = table.Column<int>(maxLength: 6, nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClientName = table.Column<string>(maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.ClientId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    CreatedAt = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2018, 11, 16, 16, 38, 17, 596, DateTimeKind.Utc).AddTicks(4081)),
                    IsExisting = table.Column<bool>(nullable: false, defaultValue: true),
                    UserId = table.Column<int>(maxLength: 6, nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClientId = table.Column<int>(nullable: false),
                    UserEmail = table.Column<string>(maxLength: 100, nullable: false),
                    UserName = table.Column<string>(maxLength: 50, nullable: false),
                    UserType = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_Clients",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Surveys",
                columns: table => new
                {
                    CreatedAt = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2018, 11, 16, 16, 38, 17, 580, DateTimeKind.Utc).AddTicks(4072)),
                    IsExisting = table.Column<bool>(nullable: false, defaultValue: true),
                    SurveyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    SurveyName = table.Column<string>(maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Surveys", x => x.SurveyId);
                    table.ForeignKey(
                        name: "FK_Surveys_Users",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AnswerSets",
                columns: table => new
                {
                    CreatedAt = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2018, 11, 16, 16, 38, 17, 567, DateTimeKind.Utc).AddTicks(4064)),
                    IsExisting = table.Column<bool>(nullable: false, defaultValue: true),
                    AnswerSetId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SurveyId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    StartedAt = table.Column<DateTime>(nullable: false),
                    FinishedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnswerSets", x => x.AnswerSetId);
                    table.ForeignKey(
                        name: "FK_Answer_Sets_Surveys",
                        column: x => x.SurveyId,
                        principalTable: "Surveys",
                        principalColumn: "SurveyId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Answer_Sets_Users",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    CreatedAt = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2018, 11, 16, 16, 38, 17, 576, DateTimeKind.Utc).AddTicks(4070)),
                    IsExisting = table.Column<bool>(nullable: false, defaultValue: true),
                    QuestionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SurveyId = table.Column<int>(nullable: false),
                    QuestionText = table.Column<string>(maxLength: 1000, nullable: false),
                    IsRequired = table.Column<bool>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false, defaultValue: true),
                    SortOrder = table.Column<int>(nullable: false),
                    QuestionResponseType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.QuestionId);
                    table.ForeignKey(
                        name: "FK_Questions_Surveys",
                        column: x => x.SurveyId,
                        principalTable: "Surveys",
                        principalColumn: "SurveyId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PossibleAnswers",
                columns: table => new
                {
                    CreatedAt = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2018, 11, 16, 16, 38, 17, 572, DateTimeKind.Utc).AddTicks(4067)),
                    IsExisting = table.Column<bool>(nullable: false, defaultValue: true),
                    PossibleAnswerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PossibleAnswerText = table.Column<string>(maxLength: 100, nullable: false),
                    QuestionId = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false, defaultValue: true),
                    SortOrder = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PossibleAnswers", x => x.PossibleAnswerId);
                    table.ForeignKey(
                        name: "FK_Possible_Answers_Questions",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "QuestionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Answers",
                columns: table => new
                {
                    CreatedAt = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2018, 11, 16, 16, 38, 17, 562, DateTimeKind.Utc).AddTicks(4062)),
                    IsExisting = table.Column<bool>(nullable: false, defaultValue: true),
                    AnswerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AnswerSetId = table.Column<int>(nullable: false),
                    PossibleAnswerId = table.Column<int>(nullable: false),
                    AnswerText = table.Column<string>(maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answers", x => x.AnswerId);
                    table.ForeignKey(
                        name: "FK_Answers_Answer_Sets",
                        column: x => x.AnswerSetId,
                        principalTable: "AnswerSets",
                        principalColumn: "AnswerSetId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Answers_Possible_Answers",
                        column: x => x.PossibleAnswerId,
                        principalTable: "PossibleAnswers",
                        principalColumn: "PossibleAnswerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Answers_AnswerSetId",
                table: "Answers",
                column: "AnswerSetId");

            migrationBuilder.CreateIndex(
                name: "IX_Answers_PossibleAnswerId",
                table: "Answers",
                column: "PossibleAnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_AnswerSets_SurveyId",
                table: "AnswerSets",
                column: "SurveyId");

            migrationBuilder.CreateIndex(
                name: "IX_AnswerSets_UserId",
                table: "AnswerSets",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PossibleAnswers_QuestionId",
                table: "PossibleAnswers",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_SurveyId",
                table: "Questions",
                column: "SurveyId");

            migrationBuilder.CreateIndex(
                name: "IX_Surveys_UserId",
                table: "Surveys",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_ClientId",
                table: "Users",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserEmail",
                table: "Users",
                column: "UserEmail",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Answers");

            migrationBuilder.DropTable(
                name: "AnswerSets");

            migrationBuilder.DropTable(
                name: "PossibleAnswers");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Surveys");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Clients");
        }
    }
}
