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
                name: "TB_Aluno",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Cpf = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBAluno", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_Categoria",
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
                name: "TB_Tutor",
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
                name: "TB_Curso",
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
                        principalTable: "TB_Categoria",
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
                        principalTable: "TB_Curso",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TB_Turma",
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
                        principalTable: "TB_Curso",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TBTutor_TBTurma",
                        column: x => x.TutorId,
                        principalTable: "TB_Tutor",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TB_Matricula",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AlunoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TurmaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataMatricula = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matricula", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBAluno_TBMatricula",
                        column: x => x.AlunoId,
                        principalTable: "TB_Aluno",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TBMatricula_TBTurma",
                        column: x => x.TurmaId,
                        principalTable: "TB_Turma",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "UQ_TBAluno_Cpf",
                table: "TB_Aluno",
                column: "Cpf",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ_TBAluno_Telefone",
                table: "TB_Aluno",
                column: "Telefone",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_Aula_CursoId",
                table: "TB_Aula",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "UQ_TBCategoria_Titulo",
                table: "TB_Categoria",
                column: "Titulo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_Curso_CategoriaId",
                table: "TB_Curso",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_Matricula_AlunoId",
                table: "TB_Matricula",
                column: "AlunoId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_Matricula_TurmaId",
                table: "TB_Matricula",
                column: "TurmaId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_Turma_CursoId",
                table: "TB_Turma",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_Turma_TutorId",
                table: "TB_Turma",
                column: "TutorId");

            migrationBuilder.CreateIndex(
                name: "UQ_TBTutor_Cpf",
                table: "TB_Tutor",
                column: "Cpf",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ_TBTutor_Telefone",
                table: "TB_Tutor",
                column: "Telefone",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_Aula");

            migrationBuilder.DropTable(
                name: "TB_Matricula");

            migrationBuilder.DropTable(
                name: "TB_Aluno");

            migrationBuilder.DropTable(
                name: "TB_Turma");

            migrationBuilder.DropTable(
                name: "TB_Curso");

            migrationBuilder.DropTable(
                name: "TB_Tutor");

            migrationBuilder.DropTable(
                name: "TB_Categoria");
        }
    }
}
