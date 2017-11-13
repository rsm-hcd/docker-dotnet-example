using System;

namespace ProjectName.Business.Core.Interfaces.Entity
{
    public interface ICreatable
    {
        long?           CreatedById { get; set; }
        DateTimeOffset? CreatedOn   { get; set; }
    }
}
