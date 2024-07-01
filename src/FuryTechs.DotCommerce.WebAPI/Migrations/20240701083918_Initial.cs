using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FuryTechs.DotCommerce.WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "country",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    country_code = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_country", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "identity_role",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    normalized_name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    concurrency_stamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_identity_role", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "identity_user",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    user_name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    normalized_user_name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    normalized_email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    email_confirmed = table.Column<bool>(type: "boolean", nullable: false),
                    password_hash = table.Column<string>(type: "text", nullable: true),
                    security_stamp = table.Column<string>(type: "text", nullable: true),
                    concurrency_stamp = table.Column<string>(type: "text", nullable: true),
                    phone_number = table.Column<string>(type: "text", nullable: true),
                    phone_number_confirmed = table.Column<bool>(type: "boolean", nullable: false),
                    two_factor_enabled = table.Column<bool>(type: "boolean", nullable: false),
                    lockout_end = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    lockout_enabled = table.Column<bool>(type: "boolean", nullable: false),
                    access_failed_count = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_identity_user", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "language",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    display_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    code = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_language", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "identity_role_claim",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    role_id = table.Column<int>(type: "integer", nullable: false),
                    claim_type = table.Column<string>(type: "text", nullable: true),
                    claim_value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_identity_role_claim", x => x.id);
                    table.ForeignKey(
                        name: "fk_identity_role_claim_asp_net_roles_role_id",
                        column: x => x.role_id,
                        principalTable: "identity_role",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "identity_user_claim",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    claim_type = table.Column<string>(type: "text", nullable: true),
                    claim_value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_identity_user_claim", x => x.id);
                    table.ForeignKey(
                        name: "fk_identity_user_claim_asp_net_users_user_id",
                        column: x => x.user_id,
                        principalTable: "identity_user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "identity_user_login",
                columns: table => new
                {
                    login_provider = table.Column<string>(type: "text", nullable: false),
                    provider_key = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    provider_display_name = table.Column<string>(type: "text", nullable: true),
                    user_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_identity_user_login", x => new { x.login_provider, x.provider_key });
                    table.ForeignKey(
                        name: "fk_identity_user_login_asp_net_users_user_id",
                        column: x => x.user_id,
                        principalTable: "identity_user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "identity_user_role",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    role_id = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_identity_user_role", x => new { x.user_id, x.role_id });
                    table.ForeignKey(
                        name: "fk_identity_user_role_asp_net_users_user_id",
                        column: x => x.user_id,
                        principalTable: "identity_user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_identity_user_role_identity_role_role_id",
                        column: x => x.role_id,
                        principalTable: "identity_role",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "identity_user_token",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    login_provider = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_identity_user_token", x => new { x.user_id, x.login_provider, x.name });
                    table.ForeignKey(
                        name: "fk_identity_user_token_asp_net_users_user_id",
                        column: x => x.user_id,
                        principalTable: "identity_user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "channel",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    token = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    description = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: false),
                    default_language_id = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_channel", x => x.id);
                    table.ForeignKey(
                        name: "fk_channel_language_int_default_language_id",
                        column: x => x.default_language_id,
                        principalTable: "language",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "country_translation",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    language_id = table.Column<int>(type: "integer", nullable: false),
                    country_name = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    base_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_country_translation", x => x.id);
                    table.ForeignKey(
                        name: "fk_country_translation_country_base_id",
                        column: x => x.base_id,
                        principalTable: "country",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_country_translation_language_int_language_id",
                        column: x => x.language_id,
                        principalTable: "language",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "channels_languages",
                columns: table => new
                {
                    available_languages_id = table.Column<int>(type: "integer", nullable: false),
                    channel_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_channels_languages", x => new { x.available_languages_id, x.channel_id });
                    table.ForeignKey(
                        name: "fk_channels_languages_channel_channel_id",
                        column: x => x.channel_id,
                        principalTable: "channel",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_channels_languages_language_int_available_languages_id",
                        column: x => x.available_languages_id,
                        principalTable: "language",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_channel_created_at",
                table: "channel",
                column: "created_at");

            migrationBuilder.CreateIndex(
                name: "ix_channel_default_language_id",
                table: "channel",
                column: "default_language_id");

            migrationBuilder.CreateIndex(
                name: "ix_channel_token",
                table: "channel",
                column: "token",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_channel_updated_at",
                table: "channel",
                column: "updated_at");

            migrationBuilder.CreateIndex(
                name: "ix_channels_languages_channel_id",
                table: "channels_languages",
                column: "channel_id");

            migrationBuilder.CreateIndex(
                name: "ix_country_country_code",
                table: "country",
                column: "country_code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_country_created_at",
                table: "country",
                column: "created_at");

            migrationBuilder.CreateIndex(
                name: "ix_country_updated_at",
                table: "country",
                column: "updated_at");

            migrationBuilder.CreateIndex(
                name: "ix_country_translation_base_id",
                table: "country_translation",
                column: "base_id");

            migrationBuilder.CreateIndex(
                name: "ix_country_translation_language_id",
                table: "country_translation",
                column: "language_id");

            migrationBuilder.CreateIndex(
                name: "ix_identity_role_created_at",
                table: "identity_role",
                column: "created_at");

            migrationBuilder.CreateIndex(
                name: "ix_identity_role_updated_at",
                table: "identity_role",
                column: "updated_at");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "identity_role",
                column: "normalized_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_identity_role_claim_created_at",
                table: "identity_role_claim",
                column: "created_at");

            migrationBuilder.CreateIndex(
                name: "ix_identity_role_claim_role_id",
                table: "identity_role_claim",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "ix_identity_role_claim_updated_at",
                table: "identity_role_claim",
                column: "updated_at");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "identity_user",
                column: "normalized_email");

            migrationBuilder.CreateIndex(
                name: "ix_identity_user_created_at",
                table: "identity_user",
                column: "created_at");

            migrationBuilder.CreateIndex(
                name: "ix_identity_user_updated_at",
                table: "identity_user",
                column: "updated_at");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "identity_user",
                column: "normalized_user_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_identity_user_claim_created_at",
                table: "identity_user_claim",
                column: "created_at");

            migrationBuilder.CreateIndex(
                name: "ix_identity_user_claim_updated_at",
                table: "identity_user_claim",
                column: "updated_at");

            migrationBuilder.CreateIndex(
                name: "ix_identity_user_claim_user_id",
                table: "identity_user_claim",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_identity_user_login_created_at",
                table: "identity_user_login",
                column: "created_at");

            migrationBuilder.CreateIndex(
                name: "ix_identity_user_login_updated_at",
                table: "identity_user_login",
                column: "updated_at");

            migrationBuilder.CreateIndex(
                name: "ix_identity_user_login_user_id",
                table: "identity_user_login",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_identity_user_role_created_at",
                table: "identity_user_role",
                column: "created_at");

            migrationBuilder.CreateIndex(
                name: "ix_identity_user_role_role_id",
                table: "identity_user_role",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "ix_identity_user_role_updated_at",
                table: "identity_user_role",
                column: "updated_at");

            migrationBuilder.CreateIndex(
                name: "ix_identity_user_token_created_at",
                table: "identity_user_token",
                column: "created_at");

            migrationBuilder.CreateIndex(
                name: "ix_identity_user_token_updated_at",
                table: "identity_user_token",
                column: "updated_at");

            migrationBuilder.CreateIndex(
                name: "ix_language_code",
                table: "language",
                column: "code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_language_created_at",
                table: "language",
                column: "created_at");

            migrationBuilder.CreateIndex(
                name: "ix_language_updated_at",
                table: "language",
                column: "updated_at");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "channels_languages");

            migrationBuilder.DropTable(
                name: "country_translation");

            migrationBuilder.DropTable(
                name: "identity_role_claim");

            migrationBuilder.DropTable(
                name: "identity_user_claim");

            migrationBuilder.DropTable(
                name: "identity_user_login");

            migrationBuilder.DropTable(
                name: "identity_user_role");

            migrationBuilder.DropTable(
                name: "identity_user_token");

            migrationBuilder.DropTable(
                name: "channel");

            migrationBuilder.DropTable(
                name: "country");

            migrationBuilder.DropTable(
                name: "identity_role");

            migrationBuilder.DropTable(
                name: "identity_user");

            migrationBuilder.DropTable(
                name: "language");
        }
    }
}
