using FuryTechs.DotCommerce.Core.Database.Entities.System;

namespace FuryTechs.DotCommerce.Core.Database.Entities.Base
{
    public abstract class EntityTranslation<TKey, TEntity>: DotCommerceEntity<TKey>
        where TKey : IEquatable<TKey>
        where TEntity : DotCommerceEntity<TKey>
    {
        public required TKey BaseId { get; set; }
        public required TEntity Base { get; set; }
        public virtual required Language<TKey> Language { get; set; }
    }
}
