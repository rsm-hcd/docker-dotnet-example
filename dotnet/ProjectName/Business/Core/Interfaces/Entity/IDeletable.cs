using System;

namespace ProjectName.Business.Core.Interfaces.Entity
{
    public interface IDeletable
    {
        long?           DeletedById { get; set; }
        DateTimeOffset? DeletedOn   { get; set; }
    }
}
