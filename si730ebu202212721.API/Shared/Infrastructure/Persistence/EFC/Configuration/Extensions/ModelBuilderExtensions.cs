using Microsoft.EntityFrameworkCore;

namespace si730ebu202212721.API.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;

/**
 *  ModelBuilderExtensions
 * <summary>
 *    - This class contains the extension methods for the ModelBuilder class.
 *    - The extension methods are used to configure the naming conventions for the database tables, columns, keys, foreign keys, and indexes.
 * </summary>
 * <remarks>
 *    - Author: U202212721 Mathias Jave Diaz
 *    - Version: 1.0.0
 * </remarks>
 */
public static class ModelBuilderExtensions
{
    public static void UseSnakeCaseWithPluralizedTableNamingConvention(this ModelBuilder builder)
    {
        foreach (var entity in builder.Model.GetEntityTypes())
        {
            var tableName = entity.GetTableName();
            if (!string.IsNullOrEmpty(tableName)) entity.SetTableName(tableName.ToPlural().ToSnakeCase());

            foreach (var property in entity.GetProperties())
                property.SetColumnName(property.GetColumnName().ToSnakeCase());

            foreach (var key in entity.GetKeys())
            {
                var keyName = key.GetName();
                if (!string.IsNullOrEmpty(keyName)) key.SetName(keyName.ToSnakeCase());
            }

            foreach (var foreignKey in entity.GetForeignKeys())
            {
                var foreignKeyConstraintName = foreignKey.GetConstraintName();
                if (!string.IsNullOrEmpty(foreignKeyConstraintName))
                    foreignKey.SetConstraintName(foreignKeyConstraintName.ToSnakeCase());
            }

            foreach (var index in entity.GetIndexes())
            {
                var indexDatabaseName = index.GetDatabaseName();
                if (!string.IsNullOrEmpty(indexDatabaseName)) index.SetDatabaseName(indexDatabaseName.ToSnakeCase());
            }
        }
    } 
}