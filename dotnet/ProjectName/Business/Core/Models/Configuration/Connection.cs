using ProjectName.Business.Core.Extensions;
using ProjectName.Business.Core.Interfaces.Data;
using System.Collections.Generic;
using System.Linq;

namespace ProjectName.Business.Core.Models.Configuration
{
    public class Connection : IConnection
    {
        #region Properties

        public string AdditionalParameters { get; set; }
        public string Database             { get; set; }
        public string Datasource           { get; set; }
        public string Password             { get; set; }
        public string UserId               { get; set; }

        #endregion Properties


        #region Public Methods

        public virtual string ToString(string delimiter = ";")
        {
            var results = new List<string>
            {
                Datasource,
                Database,
                Password,
                UserId,
                AdditionalParameters
            };

            return results.Where(ValidParameter).Join(delimiter);
        }

        #endregion Public Methods


        #region Protected Methods

        protected bool ValidParameter(string value)
        {
            return !string.IsNullOrEmpty(value);
        }

        #endregion Protected Methods
    }
}
