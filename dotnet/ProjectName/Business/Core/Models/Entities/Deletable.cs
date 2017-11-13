using ProjectName.Business.Core.Interfaces.Entity;
using System;

namespace ProjectName.Business.Core.Models.Entities
{
    public class Deletable : Entity, IDeletable
    {
        #region IDeletable Implementation

        public long?           DeletedById { get; set; }
        public DateTimeOffset? DeletedOn   { get; set; }

        #endregion
    }
}
