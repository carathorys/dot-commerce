using FuryTechs.DotCommerce.Core.Database.Entities.System;

namespace FuryTechs.DotCommerce.Core.Database.Entities.Base
{
    public abstract class EntityTranslation<TKey, TEntity>: DotCommerceEntity<TKey>
        where TKey : IEquatable<TKey>
        where TEntity : DotCommerceEntity<TKey>
    {
        public TKey BaseId { get; set; }
        public  TEntity Base { get; set; }
        public Language<TKey> Language { get; set; }
    }
}
