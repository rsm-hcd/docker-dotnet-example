namespace ProjectName.Business.Core.Interfaces.Data
{
    public interface IConnection
    {
        #region Properties

        /// <summary>
        /// Additional custom configuration parameters
        /// </summary>
        string AdditionalParameters { get; }

        /// <summary>
        /// Name of database
        /// </summary>
        string Database { get; }

        /// <summary>
        /// Url/Name for server 
        /// </summary>
        string Datasource { get; }

        /// <summary>
        /// Hopefully a secure password 
        /// </summary>
        string Password { get; }

        /// <summary>
        /// User identifier
        /// </summary>
        string UserId { get; }

        #endregion Properties


        #region Methods

        /// <summary>
        /// Single flattened string representation for the connection
        /// </summary>
        /// <returns></returns>
        string ToString(string delimiter = ";");

        #endregion
    }
}
