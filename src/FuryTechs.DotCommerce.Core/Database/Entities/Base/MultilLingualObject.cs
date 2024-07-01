namespace FuryTechs.DotCommerce.Core.Database.Entities.Base
{
    public abstract class MultilLingualObject<TKey, TTranslation, TEntity> : DotCommerceEntity<TKey>
        where TKey : IEquatable<TKey>
        where TEntity : DotCommerceEntity<TKey>
        where TTranslation: EntityTranslation<TKey, TEntity>
    {
        public required ICollection<TTranslation> Translations { get; set; }
    }
}
