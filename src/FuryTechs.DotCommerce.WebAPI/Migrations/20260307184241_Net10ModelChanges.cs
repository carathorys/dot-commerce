using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FuryTechs.DotCommerce.WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class Net10ModelChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_channel_language_guid_default_language_id",
                table: "channel");

            migrationBuilder.DropForeignKey(
                name: "fk_channels_languages_language_guid_available_languages_id",
                table: "channels_languages");

            migrationBuilder.DropForeignKey(
                name: "fk_country_translation_language_guid_language_id",
                table: "country_translation");

            migrationBuilder.DropForeignKey(
                name: "fk_identity_role_claim_asp_net_roles_role_id",
                table: "identity_role_claim");

            migrationBuilder.DropForeignKey(
                name: "fk_identity_user_claim_asp_net_users_user_id",
                table: "identity_user_claim");

            migrationBuilder.DropForeignKey(
                name: "fk_identity_user_login_asp_net_users_user_id",
                table: "identity_user_login");

            migrationBuilder.DropForeignKey(
                name: "fk_identity_user_role_asp_net_users_user_id",
                table: "identity_user_role");

            migrationBuilder.DropForeignKey(
                name: "fk_identity_user_token_asp_net_users_user_id",
                table: "identity_user_token");

            migrationBuilder.RenameIndex(
                name: "UserNameIndex",
                table: "identity_user",
                newName: "user_name_index");

            migrationBuilder.RenameIndex(
                name: "EmailIndex",
                table: "identity_user",
                newName: "email_index");

            migrationBuilder.RenameIndex(
                name: "RoleNameIndex",
                table: "identity_role",
                newName: "role_name_index");

            migrationBuilder.AddForeignKey(
                name: "fk_channel_language_default_language_id",
                table: "channel",
                column: "default_language_id",
                principalTable: "language",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_channels_languages_language_available_languages_id",
                table: "channels_languages",
                column: "available_languages_id",
                principalTable: "language",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_country_translation_language_language_id",
                table: "country_translation",
                column: "language_id",
                principalTable: "language",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_identity_role_claim_identity_role_role_id",
                table: "identity_role_claim",
                column: "role_id",
                principalTable: "identity_role",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_identity_user_claim_identity_user_user_id",
                table: "identity_user_claim",
                column: "user_id",
                principalTable: "identity_user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_identity_user_login_identity_user_user_id",
                table: "identity_user_login",
                column: "user_id",
                principalTable: "identity_user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_identity_user_role_identity_user_user_id",
                table: "identity_user_role",
                column: "user_id",
                principalTable: "identity_user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_identity_user_token_identity_user_user_id",
                table: "identity_user_token",
                column: "user_id",
                principalTable: "identity_user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_channel_language_default_language_id",
                table: "channel");

            migrationBuilder.DropForeignKey(
                name: "fk_channels_languages_language_available_languages_id",
                table: "channels_languages");

            migrationBuilder.DropForeignKey(
                name: "fk_country_translation_language_language_id",
                table: "country_translation");

            migrationBuilder.DropForeignKey(
                name: "fk_identity_role_claim_identity_role_role_id",
                table: "identity_role_claim");

            migrationBuilder.DropForeignKey(
                name: "fk_identity_user_claim_identity_user_user_id",
                table: "identity_user_claim");

            migrationBuilder.DropForeignKey(
                name: "fk_identity_user_login_identity_user_user_id",
                table: "identity_user_login");

            migrationBuilder.DropForeignKey(
                name: "fk_identity_user_role_identity_user_user_id",
                table: "identity_user_role");

            migrationBuilder.DropForeignKey(
                name: "fk_identity_user_token_identity_user_user_id",
                table: "identity_user_token");

            migrationBuilder.RenameIndex(
                name: "user_name_index",
                table: "identity_user",
                newName: "UserNameIndex");

            migrationBuilder.RenameIndex(
                name: "email_index",
                table: "identity_user",
                newName: "EmailIndex");

            migrationBuilder.RenameIndex(
                name: "role_name_index",
                table: "identity_role",
                newName: "RoleNameIndex");

            migrationBuilder.AddForeignKey(
                name: "fk_channel_language_guid_default_language_id",
                table: "channel",
                column: "default_language_id",
                principalTable: "language",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_channels_languages_language_guid_available_languages_id",
                table: "channels_languages",
                column: "available_languages_id",
                principalTable: "language",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_country_translation_language_guid_language_id",
                table: "country_translation",
                column: "language_id",
                principalTable: "language",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_identity_role_claim_asp_net_roles_role_id",
                table: "identity_role_claim",
                column: "role_id",
                principalTable: "identity_role",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_identity_user_claim_asp_net_users_user_id",
                table: "identity_user_claim",
                column: "user_id",
                principalTable: "identity_user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_identity_user_login_asp_net_users_user_id",
                table: "identity_user_login",
                column: "user_id",
                principalTable: "identity_user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_identity_user_role_asp_net_users_user_id",
                table: "identity_user_role",
                column: "user_id",
                principalTable: "identity_user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_identity_user_token_asp_net_users_user_id",
                table: "identity_user_token",
                column: "user_id",
                principalTable: "identity_user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
