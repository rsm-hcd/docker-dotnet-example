using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.SqlServer.Maps
{
    public abstract class Map<TEntity> where TEntity : class
    {
        public abstract void Configure(EntityTypeBuilder<TEntity> entity);
    }
}
