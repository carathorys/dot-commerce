﻿// <auto-generated />
using System;
using FuryTechs.DotCommerce.WebAPI;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FuryTechs.DotCommerce.WebAPI.Migrations
{
    [DbContext(typeof(WebDbContext))]
    partial class WebDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("FuryTechs.DotCommerce.Core.Database.Entities.Customer.Country<System.Guid>", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("CountryCode")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("country_code");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at")
                        .HasDefaultValueSql("NOW()");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at")
                        .HasDefaultValueSql("NOW()");

                    b.HasKey("Id")
                        .HasName("pk_country");

                    b.HasIndex("CountryCode")
                        .IsUnique()
                        .HasDatabaseName("ix_country_country_code");

                    b.HasIndex("CreatedAt")
                        .HasDatabaseName("ix_country_created_at");

                    b.HasIndex("UpdatedAt")
                        .HasDatabaseName("ix_country_updated_at");

                    b.ToTable("country", (string)null);
                });

            modelBuilder.Entity("FuryTechs.DotCommerce.Core.Database.Entities.Customer.CountryTranslation<System.Guid>", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid>("BaseId")
                        .HasColumnType("uuid")
                        .HasColumnName("base_id");

                    b.Property<string>("CountryName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("country_name");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<Guid>("LanguageId")
                        .HasColumnType("uuid")
                        .HasColumnName("language_id");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.HasKey("Id")
                        .HasName("pk_country_translation");

                    b.HasIndex("BaseId")
                        .HasDatabaseName("ix_country_translation_base_id");

                    b.HasIndex("LanguageId")
                        .HasDatabaseName("ix_country_translation_language_id");

                    b.ToTable("country_translation", (string)null);
                });

            modelBuilder.Entity("FuryTechs.DotCommerce.Core.Database.Entities.Identity.Role<System.Guid>", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text")
                        .HasColumnName("concurrency_stamp");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at")
                        .HasDefaultValueSql("NOW()");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("name");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("normalized_name");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at")
                        .HasDefaultValueSql("NOW()");

                    b.HasKey("Id")
                        .HasName("pk_identity_role");

                    b.HasIndex("CreatedAt")
                        .HasDatabaseName("ix_identity_role_created_at");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.HasIndex("UpdatedAt")
                        .HasDatabaseName("ix_identity_role_updated_at");

                    b.ToTable("identity_role", (string)null);
                });

            modelBuilder.Entity("FuryTechs.DotCommerce.Core.Database.Entities.Identity.RoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text")
                        .HasColumnName("claim_type");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text")
                        .HasColumnName("claim_value");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at")
                        .HasDefaultValueSql("NOW()");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uuid")
                        .HasColumnName("role_id");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at")
                        .HasDefaultValueSql("NOW()");

                    b.HasKey("Id")
                        .HasName("pk_identity_role_claim");

                    b.HasIndex("CreatedAt")
                        .HasDatabaseName("ix_identity_role_claim_created_at");

                    b.HasIndex("RoleId")
                        .HasDatabaseName("ix_identity_role_claim_role_id");

                    b.HasIndex("UpdatedAt")
                        .HasDatabaseName("ix_identity_role_claim_updated_at");

                    b.ToTable("identity_role_claim", (string)null);
                });

            modelBuilder.Entity("FuryTechs.DotCommerce.Core.Database.Entities.Identity.User<System.Guid>", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer")
                        .HasColumnName("access_failed_count");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text")
                        .HasColumnName("concurrency_stamp");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at")
                        .HasDefaultValueSql("NOW()");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("email");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean")
                        .HasColumnName("email_confirmed");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean")
                        .HasColumnName("lockout_enabled");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("lockout_end");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("normalized_email");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("normalized_user_name");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text")
                        .HasColumnName("password_hash");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text")
                        .HasColumnName("phone_number");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean")
                        .HasColumnName("phone_number_confirmed");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text")
                        .HasColumnName("security_stamp");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean")
                        .HasColumnName("two_factor_enabled");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at")
                        .HasDefaultValueSql("NOW()");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("user_name");

                    b.HasKey("Id")
                        .HasName("pk_identity_user");

                    b.HasIndex("CreatedAt")
                        .HasDatabaseName("ix_identity_user_created_at");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.HasIndex("UpdatedAt")
                        .HasDatabaseName("ix_identity_user_updated_at");

                    b.ToTable("identity_user", (string)null);
                });

            modelBuilder.Entity("FuryTechs.DotCommerce.Core.Database.Entities.Identity.UserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text")
                        .HasColumnName("claim_type");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text")
                        .HasColumnName("claim_value");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at")
                        .HasDefaultValueSql("NOW()");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at")
                        .HasDefaultValueSql("NOW()");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_identity_user_claim");

                    b.HasIndex("CreatedAt")
                        .HasDatabaseName("ix_identity_user_claim_created_at");

                    b.HasIndex("UpdatedAt")
                        .HasDatabaseName("ix_identity_user_claim_updated_at");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_identity_user_claim_user_id");

                    b.ToTable("identity_user_claim", (string)null);
                });

            modelBuilder.Entity("FuryTechs.DotCommerce.Core.Database.Entities.Identity.UserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text")
                        .HasColumnName("login_provider");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text")
                        .HasColumnName("provider_key");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at")
                        .HasDefaultValueSql("NOW()");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text")
                        .HasColumnName("provider_display_name");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at")
                        .HasDefaultValueSql("NOW()");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.HasKey("LoginProvider", "ProviderKey")
                        .HasName("pk_identity_user_login");

                    b.HasIndex("CreatedAt")
                        .HasDatabaseName("ix_identity_user_login_created_at");

                    b.HasIndex("UpdatedAt")
                        .HasDatabaseName("ix_identity_user_login_updated_at");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_identity_user_login_user_id");

                    b.ToTable("identity_user_login", (string)null);
                });

            modelBuilder.Entity("FuryTechs.DotCommerce.Core.Database.Entities.Identity.UserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uuid")
                        .HasColumnName("role_id");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at")
                        .HasDefaultValueSql("NOW()");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at")
                        .HasDefaultValueSql("NOW()");

                    b.HasKey("UserId", "RoleId")
                        .HasName("pk_identity_user_role");

                    b.HasIndex("CreatedAt")
                        .HasDatabaseName("ix_identity_user_role_created_at");

                    b.HasIndex("RoleId")
                        .HasDatabaseName("ix_identity_user_role_role_id");

                    b.HasIndex("UpdatedAt")
                        .HasDatabaseName("ix_identity_user_role_updated_at");

                    b.ToTable("identity_user_role", (string)null);
                });

            modelBuilder.Entity("FuryTechs.DotCommerce.Core.Database.Entities.Identity.UserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text")
                        .HasColumnName("login_provider");

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at")
                        .HasDefaultValueSql("NOW()");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at")
                        .HasDefaultValueSql("NOW()");

                    b.Property<string>("Value")
                        .HasColumnType("text")
                        .HasColumnName("value");

                    b.HasKey("UserId", "LoginProvider", "Name")
                        .HasName("pk_identity_user_token");

                    b.HasIndex("CreatedAt")
                        .HasDatabaseName("ix_identity_user_token_created_at");

                    b.HasIndex("UpdatedAt")
                        .HasDatabaseName("ix_identity_user_token_updated_at");

                    b.ToTable("identity_user_token", (string)null);
                });

            modelBuilder.Entity("FuryTechs.DotCommerce.Core.Database.Entities.System.Channel<System.Guid>", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at")
                        .HasDefaultValueSql("NOW()");

                    b.Property<Guid>("DefaultLanguageId")
                        .HasColumnType("uuid")
                        .HasColumnName("default_language_id");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("character varying(512)")
                        .HasColumnName("description");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)")
                        .HasColumnName("token");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at")
                        .HasDefaultValueSql("NOW()");

                    b.HasKey("Id")
                        .HasName("pk_channel");

                    b.HasIndex("CreatedAt")
                        .HasDatabaseName("ix_channel_created_at");

                    b.HasIndex("DefaultLanguageId")
                        .HasDatabaseName("ix_channel_default_language_id");

                    b.HasIndex("Token")
                        .IsUnique()
                        .HasDatabaseName("ix_channel_token");

                    b.HasIndex("UpdatedAt")
                        .HasDatabaseName("ix_channel_updated_at");

                    b.ToTable("channel", (string)null);
                });

            modelBuilder.Entity("FuryTechs.DotCommerce.Core.Database.Entities.System.Language<System.Guid>", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(6)
                        .HasColumnType("character varying(6)")
                        .HasColumnName("code");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at")
                        .HasDefaultValueSql("NOW()");

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("display_name");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at")
                        .HasDefaultValueSql("NOW()");

                    b.HasKey("Id")
                        .HasName("pk_language");

                    b.HasIndex("Code")
                        .IsUnique()
                        .HasDatabaseName("ix_language_code");

                    b.HasIndex("CreatedAt")
                        .HasDatabaseName("ix_language_created_at");

                    b.HasIndex("UpdatedAt")
                        .HasDatabaseName("ix_language_updated_at");

                    b.ToTable("language", (string)null);
                });

            modelBuilder.Entity("channels_languages", b =>
                {
                    b.Property<Guid>("AvailableLanguagesId")
                        .HasColumnType("uuid")
                        .HasColumnName("available_languages_id");

                    b.Property<Guid>("ChannelId")
                        .HasColumnType("uuid")
                        .HasColumnName("channel_id");

                    b.HasKey("AvailableLanguagesId", "ChannelId")
                        .HasName("pk_channels_languages");

                    b.HasIndex("ChannelId")
                        .HasDatabaseName("ix_channels_languages_channel_id");

                    b.ToTable("channels_languages", (string)null);
                });

            modelBuilder.Entity("FuryTechs.DotCommerce.Core.Database.Entities.Customer.CountryTranslation<System.Guid>", b =>
                {
                    b.HasOne("FuryTechs.DotCommerce.Core.Database.Entities.Customer.Country<System.Guid>", "Base")
                        .WithMany("Translations")
                        .HasForeignKey("BaseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_country_translation_country_base_id");

                    b.HasOne("FuryTechs.DotCommerce.Core.Database.Entities.System.Language<System.Guid>", "Language")
                        .WithMany()
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_country_translation_language_guid_language_id");

                    b.Navigation("Base");

                    b.Navigation("Language");
                });

            modelBuilder.Entity("FuryTechs.DotCommerce.Core.Database.Entities.Identity.RoleClaim<System.Guid>", b =>
                {
                    b.HasOne("FuryTechs.DotCommerce.Core.Database.Entities.Identity.Role<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_identity_role_claim_asp_net_roles_role_id");
                });

            modelBuilder.Entity("FuryTechs.DotCommerce.Core.Database.Entities.Identity.UserClaim<System.Guid>", b =>
                {
                    b.HasOne("FuryTechs.DotCommerce.Core.Database.Entities.Identity.User<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_identity_user_claim_asp_net_users_user_id");
                });

            modelBuilder.Entity("FuryTechs.DotCommerce.Core.Database.Entities.Identity.UserLogin<System.Guid>", b =>
                {
                    b.HasOne("FuryTechs.DotCommerce.Core.Database.Entities.Identity.User<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_identity_user_login_asp_net_users_user_id");
                });

            modelBuilder.Entity("FuryTechs.DotCommerce.Core.Database.Entities.Identity.UserRole<System.Guid>", b =>
                {
                    b.HasOne("FuryTechs.DotCommerce.Core.Database.Entities.Identity.Role<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_identity_user_role_identity_role_role_id");

                    b.HasOne("FuryTechs.DotCommerce.Core.Database.Entities.Identity.User<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_identity_user_role_asp_net_users_user_id");
                });

            modelBuilder.Entity("FuryTechs.DotCommerce.Core.Database.Entities.Identity.UserToken<System.Guid>", b =>
                {
                    b.HasOne("FuryTechs.DotCommerce.Core.Database.Entities.Identity.User<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_identity_user_token_asp_net_users_user_id");
                });

            modelBuilder.Entity("FuryTechs.DotCommerce.Core.Database.Entities.System.Channel<System.Guid>", b =>
                {
                    b.HasOne("FuryTechs.DotCommerce.Core.Database.Entities.System.Language<System.Guid>", "DefaultLanguage")
                        .WithMany()
                        .HasForeignKey("DefaultLanguageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_channel_language_guid_default_language_id");

                    b.Navigation("DefaultLanguage");
                });

            modelBuilder.Entity("channels_languages", b =>
                {
                    b.HasOne("FuryTechs.DotCommerce.Core.Database.Entities.System.Language<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("AvailableLanguagesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_channels_languages_language_guid_available_languages_id");

                    b.HasOne("FuryTechs.DotCommerce.Core.Database.Entities.System.Channel<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("ChannelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_channels_languages_channel_channel_id");
                });

            modelBuilder.Entity("FuryTechs.DotCommerce.Core.Database.Entities.Customer.Country<System.Guid>", b =>
                {
                    b.Navigation("Translations");
                });
#pragma warning restore 612, 618
        }
    }
}
