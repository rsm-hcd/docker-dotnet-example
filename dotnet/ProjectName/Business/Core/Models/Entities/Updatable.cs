using ProjectName.Business.Core.Interfaces.Entity;
using System;

namespace ProjectName.Business.Core.Models.Entities
{
    public class Updatable : Creatable, IUpdatable
    {
        #region IUpdatable Implementation

        public long?           UpdatedById { get; set; }
        public DateTimeOffset? UpdatedOn   { get; set; }

        #endregion
    }
}
