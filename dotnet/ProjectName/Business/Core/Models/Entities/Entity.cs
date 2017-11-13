using ProjectName.Business.Core.Interfaces.Entity;

namespace ProjectName.Business.Core.Models.Entities
{
    public abstract class Entity : IEntity
    {
        public long Id { get; set; }
    }
}
