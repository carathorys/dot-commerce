using Microsoft.EntityFrameworkCore;

namespace FuryTechs.DotCommerce.Core.Database.TypeConfigurations.Base;

public interface IDotCommerceEntityTypeConfig<TEntity> : IEntityTypeConfiguration<TEntity>
  where TEntity : class
{
}