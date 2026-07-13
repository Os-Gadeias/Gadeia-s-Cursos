using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EscolaDeCursos.Infra.Compartilhado.Orm.Migrations
{
    /// <inheritdoc />
    public partial class ConfigExemplo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBCategoria",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Cor = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBCategoria", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TBTutor",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Cpf = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBTutor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TBCurso",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CargaHoraria = table.Column<int>(type: "int", nullable: false),
                    Dificuldade = table.Column<int>(type: "int", nullable: false),
                    CategoriaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBCurso", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBCurso_TBCategoria",
                        column: x => x.CategoriaId,
                        principalTable: "TBCategoria",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TB_Aula",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Duracao = table.Column<int>(type: "int", nullable: false),
                    CursoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBAula", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBAula_TBCurso",
                        column: x => x.CursoId,
                        principalTable: "TBCurso",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TBTurma",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CapacidadeMaxima = table.Column<int>(type: "int", nullable: false),
                    DataInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataTermino = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TutorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CursoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBTurma", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBCurso_TBTurma",
                        column: x => x.CursoId,
                        principalTable: "TBCurso",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TBTutor_TBTurma",
                        column: x => x.TutorId,
                        principalTable: "TBTutor",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TBAluno",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Cpf = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    AlunoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBAluno", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBAluno_TBTurma",
                        column: x => x.AlunoId,
                        principalTable: "TBTurma",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_Aula_CursoId",
                table: "TB_Aula",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_TBAluno_AlunoId",
                table: "TBAluno",
                column: "AlunoId");

            migrationBuilder.CreateIndex(
                name: "UQ_TBAluno_Cpf",
                table: "TBAluno",
                column: "Cpf",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ_TBAluno_Telefone",
                table: "TBAluno",
                column: "Telefone",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ_TBCategoria_Titulo",
                table: "TBCategoria",
                column: "Titulo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TBCurso_CategoriaId",
                table: "TBCurso",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_TBTurma_CursoId",
                table: "TBTurma",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_TBTurma_TutorId",
                table: "TBTurma",
                column: "TutorId");

            migrationBuilder.CreateIndex(
                name: "UQ_TBTutor_Cpf",
                table: "TBTutor",
                column: "Cpf",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ_TBTutor_Telefone",
                table: "TBTutor",
                column: "Telefone",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_Aula");

            migrationBuilder.DropTable(
                name: "TBAluno");

            migrationBuilder.DropTable(
                name: "TBTurma");

            migrationBuilder.DropTable(
                name: "TBCurso");

            migrationBuilder.DropTable(
                name: "TBTutor");

            migrationBuilder.DropTable(
                name: "TBCategoria");
        }
    }
}
