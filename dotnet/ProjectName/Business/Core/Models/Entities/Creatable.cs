using ProjectName.Business.Core.Interfaces.Entity;
using System;

namespace ProjectName.Business.Core.Models.Entities
{
    public class Creatable : Entity, ICreatable
    {
        #region ICreatable Implementation

        public long?           CreatedById { get; set; }
        public DateTimeOffset? CreatedOn   { get; set; }

        #endregion
    }
}
