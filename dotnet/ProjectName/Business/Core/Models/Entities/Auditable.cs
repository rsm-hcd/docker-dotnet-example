using ProjectName.Business.Core.Interfaces.Entity;
using System;

namespace ProjectName.Business.Core.Models.Entities
{
    public abstract class Auditable : Entity, IAuditable
    {
        #region IAuditable Implementation

        public long?           DeletedById { get; set; }
        public DateTimeOffset? DeletedOn   { get; set; }
        public long?           UpdatedById { get; set; }
        public DateTimeOffset? UpdatedOn   { get; set; }
        public long?           CreatedById { get; set; }
        public DateTimeOffset? CreatedOn   { get; set; }

        #endregion
    }
}
