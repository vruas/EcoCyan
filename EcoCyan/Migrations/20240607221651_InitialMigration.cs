using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcoCyan.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "usuarios",
                columns: table => new
                {
                    id_user = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    nm_user = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    email_user = table.Column<string>(type: "NVARCHAR2(150)", maxLength: 150, nullable: false),
                    senha_user = table.Column<string>(type: "NVARCHAR2(30)", maxLength: 30, nullable: false),
                    tipo_user = table.Column<string>(type: "NVARCHAR2(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarios", x => x.id_user);
                });

            migrationBuilder.CreateTable(
                name: "lixo_coletado",
                columns: table => new
                {
                    id_lixo_coletado = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    tp_lixo = table.Column<string>(type: "NVARCHAR2(15)", maxLength: 15, nullable: false),
                    quantidade_lixo = table.Column<string>(type: "NVARCHAR2(10)", maxLength: 10, nullable: false),
                    local_coleta = table.Column<string>(type: "NVARCHAR2(150)", maxLength: 150, nullable: false),
                    usuarios_id_user = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lixo_coletado", x => x.id_lixo_coletado);
                    table.ForeignKey(
                        name: "FK_lixo_coletado_usuarios_usuarios_id_user",
                        column: x => x.usuarios_id_user,
                        principalTable: "usuarios",
                        principalColumn: "id_user",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "reciclagem",
                columns: table => new
                {
                    id_reciclagem = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    dt_reciclagem = table.Column<string>(type: "NVARCHAR2(10)", maxLength: 10, nullable: false),
                    quantidade_reciclada = table.Column<string>(type: "NVARCHAR2(10)", maxLength: 10, nullable: false),
                    usuarios_id_user = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reciclagem", x => x.id_reciclagem);
                    table.ForeignKey(
                        name: "FK_reciclagem_usuarios_usuarios_id_user",
                        column: x => x.usuarios_id_user,
                        principalTable: "usuarios",
                        principalColumn: "id_user",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "entrega_lixo",
                columns: table => new
                {
                    id_entrega_lixo = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    dt_entrega = table.Column<string>(type: "NVARCHAR2(10)", maxLength: 10, nullable: false),
                    lixo_coletado_id_lixo_coletado = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    lixo_coletado_id_user = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_entrega_lixo", x => x.id_entrega_lixo);
                    table.ForeignKey(
                        name: "FK_entrega_lixo_lixo_coletado_lixo_coletado_id_lixo_coletado",
                        column: x => x.lixo_coletado_id_lixo_coletado,
                        principalTable: "lixo_coletado",
                        principalColumn: "id_lixo_coletado",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_entrega_lixo_usuarios_lixo_coletado_id_user",
                        column: x => x.lixo_coletado_id_user,
                        principalTable: "usuarios",
                        principalColumn: "id_user",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ponto_de_coleta",
                columns: table => new
                {
                    id_ponto_coleta = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    nm_ponto_coleta = table.Column<string>(type: "NVARCHAR2(30)", maxLength: 30, nullable: false),
                    endereco_ponto_coleta = table.Column<string>(type: "NVARCHAR2(150)", maxLength: 150, nullable: false),
                    contato_ponto_col = table.Column<string>(type: "NVARCHAR2(150)", maxLength: 150, nullable: false),
                    IdEntregaLixo = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    EntregaLixoIdEntregaLixo = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ponto_de_coleta", x => x.id_ponto_coleta);
                    table.ForeignKey(
                        name: "FK_ponto_de_coleta_entrega_lixo_EntregaLixoIdEntregaLixo",
                        column: x => x.EntregaLixoIdEntregaLixo,
                        principalTable: "entrega_lixo",
                        principalColumn: "id_entrega_lixo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_entrega_lixo_lixo_coletado_id_lixo_coletado",
                table: "entrega_lixo",
                column: "lixo_coletado_id_lixo_coletado");

            migrationBuilder.CreateIndex(
                name: "IX_entrega_lixo_lixo_coletado_id_user",
                table: "entrega_lixo",
                column: "lixo_coletado_id_user");

            migrationBuilder.CreateIndex(
                name: "IX_lixo_coletado_usuarios_id_user",
                table: "lixo_coletado",
                column: "usuarios_id_user");

            migrationBuilder.CreateIndex(
                name: "IX_ponto_de_coleta_EntregaLixoIdEntregaLixo",
                table: "ponto_de_coleta",
                column: "EntregaLixoIdEntregaLixo");

            migrationBuilder.CreateIndex(
                name: "IX_reciclagem_usuarios_id_user",
                table: "reciclagem",
                column: "usuarios_id_user");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ponto_de_coleta");

            migrationBuilder.DropTable(
                name: "reciclagem");

            migrationBuilder.DropTable(
                name: "entrega_lixo");

            migrationBuilder.DropTable(
                name: "lixo_coletado");

            migrationBuilder.DropTable(
                name: "usuarios");
        }
    }
}
