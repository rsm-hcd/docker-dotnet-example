using System;

namespace ProjectName.Business.Core.Interfaces.Entity
{
    public interface IUpdatable : ICreatable
    {
        long?           UpdatedById { get; set; }
        DateTimeOffset? UpdatedOn   { get; set; }
    }
}
