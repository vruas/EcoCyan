using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcoCyan.Migrations
{
    /// <inheritdoc />
    public partial class EcoCyanMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_entrega_lixo_lixo_coletado_lixo_coletado_id_lixo_coletado",
                table: "entrega_lixo");

            migrationBuilder.DropForeignKey(
                name: "FK_entrega_lixo_usuarios_lixo_coletado_id_user",
                table: "entrega_lixo");

            migrationBuilder.DropForeignKey(
                name: "FK_lixo_coletado_usuarios_usuarios_id_user",
                table: "lixo_coletado");

            migrationBuilder.DropForeignKey(
                name: "FK_ponto_de_coleta_entrega_lixo_EntregaLixoIdEntregaLixo",
                table: "ponto_de_coleta");

            migrationBuilder.DropForeignKey(
                name: "FK_reciclagem_usuarios_usuarios_id_user",
                table: "reciclagem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_usuarios",
                table: "usuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_reciclagem",
                table: "reciclagem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ponto_de_coleta",
                table: "ponto_de_coleta");

            migrationBuilder.DropPrimaryKey(
                name: "PK_lixo_coletado",
                table: "lixo_coletado");

            migrationBuilder.DropPrimaryKey(
                name: "PK_entrega_lixo",
                table: "entrega_lixo");

            migrationBuilder.RenameTable(
                name: "usuarios",
                newName: "USUARIOS");

            migrationBuilder.RenameTable(
                name: "reciclagem",
                newName: "RECICLAGEM");

            migrationBuilder.RenameTable(
                name: "ponto_de_coleta",
                newName: "PONTO_DE_COLETA");

            migrationBuilder.RenameTable(
                name: "lixo_coletado",
                newName: "LIXO_COLETADO");

            migrationBuilder.RenameTable(
                name: "entrega_lixo",
                newName: "ENTREGA_LIXO");

            migrationBuilder.RenameIndex(
                name: "IX_reciclagem_usuarios_id_user",
                table: "RECICLAGEM",
                newName: "IX_RECICLAGEM_usuarios_id_user");

            migrationBuilder.RenameIndex(
                name: "IX_ponto_de_coleta_EntregaLixoIdEntregaLixo",
                table: "PONTO_DE_COLETA",
                newName: "IX_PONTO_DE_COLETA_EntregaLixoIdEntregaLixo");

            migrationBuilder.RenameIndex(
                name: "IX_lixo_coletado_usuarios_id_user",
                table: "LIXO_COLETADO",
                newName: "IX_LIXO_COLETADO_usuarios_id_user");

            migrationBuilder.RenameIndex(
                name: "IX_entrega_lixo_lixo_coletado_id_user",
                table: "ENTREGA_LIXO",
                newName: "IX_ENTREGA_LIXO_lixo_coletado_id_user");

            migrationBuilder.RenameIndex(
                name: "IX_entrega_lixo_lixo_coletado_id_lixo_coletado",
                table: "ENTREGA_LIXO",
                newName: "IX_ENTREGA_LIXO_lixo_coletado_id_lixo_coletado");

            migrationBuilder.AddPrimaryKey(
                name: "PK_USUARIOS",
                table: "USUARIOS",
                column: "id_user");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RECICLAGEM",
                table: "RECICLAGEM",
                column: "id_reciclagem");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PONTO_DE_COLETA",
                table: "PONTO_DE_COLETA",
                column: "id_ponto_coleta");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LIXO_COLETADO",
                table: "LIXO_COLETADO",
                column: "id_lixo_coletado");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ENTREGA_LIXO",
                table: "ENTREGA_LIXO",
                column: "id_entrega_lixo");

            migrationBuilder.AddForeignKey(
                name: "FK_ENTREGA_LIXO_LIXO_COLETADO_lixo_coletado_id_lixo_coletado",
                table: "ENTREGA_LIXO",
                column: "lixo_coletado_id_lixo_coletado",
                principalTable: "LIXO_COLETADO",
                principalColumn: "id_lixo_coletado",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ENTREGA_LIXO_USUARIOS_lixo_coletado_id_user",
                table: "ENTREGA_LIXO",
                column: "lixo_coletado_id_user",
                principalTable: "USUARIOS",
                principalColumn: "id_user",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LIXO_COLETADO_USUARIOS_usuarios_id_user",
                table: "LIXO_COLETADO",
                column: "usuarios_id_user",
                principalTable: "USUARIOS",
                principalColumn: "id_user",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PONTO_DE_COLETA_ENTREGA_LIXO_EntregaLixoIdEntregaLixo",
                table: "PONTO_DE_COLETA",
                column: "EntregaLixoIdEntregaLixo",
                principalTable: "ENTREGA_LIXO",
                principalColumn: "id_entrega_lixo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RECICLAGEM_USUARIOS_usuarios_id_user",
                table: "RECICLAGEM",
                column: "usuarios_id_user",
                principalTable: "USUARIOS",
                principalColumn: "id_user",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ENTREGA_LIXO_LIXO_COLETADO_lixo_coletado_id_lixo_coletado",
                table: "ENTREGA_LIXO");

            migrationBuilder.DropForeignKey(
                name: "FK_ENTREGA_LIXO_USUARIOS_lixo_coletado_id_user",
                table: "ENTREGA_LIXO");

            migrationBuilder.DropForeignKey(
                name: "FK_LIXO_COLETADO_USUARIOS_usuarios_id_user",
                table: "LIXO_COLETADO");

            migrationBuilder.DropForeignKey(
                name: "FK_PONTO_DE_COLETA_ENTREGA_LIXO_EntregaLixoIdEntregaLixo",
                table: "PONTO_DE_COLETA");

            migrationBuilder.DropForeignKey(
                name: "FK_RECICLAGEM_USUARIOS_usuarios_id_user",
                table: "RECICLAGEM");

            migrationBuilder.DropPrimaryKey(
                name: "PK_USUARIOS",
                table: "USUARIOS");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RECICLAGEM",
                table: "RECICLAGEM");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PONTO_DE_COLETA",
                table: "PONTO_DE_COLETA");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LIXO_COLETADO",
                table: "LIXO_COLETADO");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ENTREGA_LIXO",
                table: "ENTREGA_LIXO");

            migrationBuilder.RenameTable(
                name: "USUARIOS",
                newName: "usuarios");

            migrationBuilder.RenameTable(
                name: "RECICLAGEM",
                newName: "reciclagem");

            migrationBuilder.RenameTable(
                name: "PONTO_DE_COLETA",
                newName: "ponto_de_coleta");

            migrationBuilder.RenameTable(
                name: "LIXO_COLETADO",
                newName: "lixo_coletado");

            migrationBuilder.RenameTable(
                name: "ENTREGA_LIXO",
                newName: "entrega_lixo");

            migrationBuilder.RenameIndex(
                name: "IX_RECICLAGEM_usuarios_id_user",
                table: "reciclagem",
                newName: "IX_reciclagem_usuarios_id_user");

            migrationBuilder.RenameIndex(
                name: "IX_PONTO_DE_COLETA_EntregaLixoIdEntregaLixo",
                table: "ponto_de_coleta",
                newName: "IX_ponto_de_coleta_EntregaLixoIdEntregaLixo");

            migrationBuilder.RenameIndex(
                name: "IX_LIXO_COLETADO_usuarios_id_user",
                table: "lixo_coletado",
                newName: "IX_lixo_coletado_usuarios_id_user");

            migrationBuilder.RenameIndex(
                name: "IX_ENTREGA_LIXO_lixo_coletado_id_user",
                table: "entrega_lixo",
                newName: "IX_entrega_lixo_lixo_coletado_id_user");

            migrationBuilder.RenameIndex(
                name: "IX_ENTREGA_LIXO_lixo_coletado_id_lixo_coletado",
                table: "entrega_lixo",
                newName: "IX_entrega_lixo_lixo_coletado_id_lixo_coletado");

            migrationBuilder.AddPrimaryKey(
                name: "PK_usuarios",
                table: "usuarios",
                column: "id_user");

            migrationBuilder.AddPrimaryKey(
                name: "PK_reciclagem",
                table: "reciclagem",
                column: "id_reciclagem");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ponto_de_coleta",
                table: "ponto_de_coleta",
                column: "id_ponto_coleta");

            migrationBuilder.AddPrimaryKey(
                name: "PK_lixo_coletado",
                table: "lixo_coletado",
                column: "id_lixo_coletado");

            migrationBuilder.AddPrimaryKey(
                name: "PK_entrega_lixo",
                table: "entrega_lixo",
                column: "id_entrega_lixo");

            migrationBuilder.AddForeignKey(
                name: "FK_entrega_lixo_lixo_coletado_lixo_coletado_id_lixo_coletado",
                table: "entrega_lixo",
                column: "lixo_coletado_id_lixo_coletado",
                principalTable: "lixo_coletado",
                principalColumn: "id_lixo_coletado",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_entrega_lixo_usuarios_lixo_coletado_id_user",
                table: "entrega_lixo",
                column: "lixo_coletado_id_user",
                principalTable: "usuarios",
                principalColumn: "id_user",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_lixo_coletado_usuarios_usuarios_id_user",
                table: "lixo_coletado",
                column: "usuarios_id_user",
                principalTable: "usuarios",
                principalColumn: "id_user",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ponto_de_coleta_entrega_lixo_EntregaLixoIdEntregaLixo",
                table: "ponto_de_coleta",
                column: "EntregaLixoIdEntregaLixo",
                principalTable: "entrega_lixo",
                principalColumn: "id_entrega_lixo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_reciclagem_usuarios_usuarios_id_user",
                table: "reciclagem",
                column: "usuarios_id_user",
                principalTable: "usuarios",
                principalColumn: "id_user",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
