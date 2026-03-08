using System.Text;
using System.Text.RegularExpressions;

using Microsoft.EntityFrameworkCore;

namespace FuryTechs.DotCommerce.Core.Database;

/// <summary>
/// Applies snake_case naming convention to all database objects.
/// Replaces the EFCore.NamingConventions package which does not support .NET 10.
/// </summary>
public static partial class SnakeCaseNamingConvention
{
    /// <summary>
    /// Applies snake_case naming to all tables, columns, keys, indexes, and foreign keys
    /// in the model, matching the behavior of UseSnakeCaseNamingConvention().
    /// </summary>
    /// <param name="modelBuilder">The model builder to apply conventions to.</param>
    public static void ApplySnakeCaseNamingConvention(this ModelBuilder modelBuilder)
    {
        foreach (var entity in modelBuilder.Model.GetEntityTypes())
        {
            // Table name
            var tableName = entity.GetTableName();
            if (tableName != null)
            {
                entity.SetTableName(ToSnakeCase(tableName));
            }

            // Column names
            foreach (var property in entity.GetProperties())
            {
                var storeObjectId = Microsoft.EntityFrameworkCore.Metadata.StoreObjectIdentifier.Table(
                    entity.GetTableName()!, entity.GetSchema());
                var columnName = property.GetColumnName(storeObjectId);
                if (columnName != null)
                {
                    property.SetColumnName(ToSnakeCase(columnName));
                }
            }

            // Primary and alternate keys
            foreach (var key in entity.GetKeys())
            {
                var keyName = key.GetName();
                if (keyName != null)
                {
                    key.SetName(ToSnakeCase(keyName));
                }
            }

            // Foreign keys
            foreach (var foreignKey in entity.GetForeignKeys())
            {
                var constraintName = foreignKey.GetConstraintName();
                if (constraintName != null)
                {
                    foreignKey.SetConstraintName(ToSnakeCase(constraintName));
                }
            }

            // Indexes
            foreach (var index in entity.GetIndexes())
            {
                var indexName = index.GetDatabaseName();
                if (indexName != null)
                {
                    index.SetDatabaseName(ToSnakeCase(indexName));
                }
            }
        }
    }

    private static string ToSnakeCase(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            return name;
        }

        return SnakeCaseRegex().Replace(name, "$1_$2").ToLowerInvariant();
    }

    [GeneratedRegex("([a-z0-9])([A-Z])")]
    private static partial Regex SnakeCaseRegex();
}
