using Data.SqlServer.Extensions;
using ProjectName.Business.Core.Interfaces.Data;
using ProjectName.Business.Core.Utilities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Data.SqlServer
{
    public class ProjectNameContext : DataContext, IProjectNameContext
    {
        #region Properties

        //public DbSet<MyModel> MyModels { get; set; }


        #endregion

        #region Constructor

        public ProjectNameContext()
            : base(Configuration.GetConnectionString())
        {
            Console.WriteLine($"ProjectNameContext () => {Configuration.GetConnectionString()}");
        }

        /// <summary>
        ///
        /// </summary>
        public ProjectNameContext(string connectionString)
            : base(connectionString)
        {
            Console.WriteLine($"ProjectNameContext (string connectionString) => {connectionString}");
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="connection"></param>
        public ProjectNameContext(IConnection connection)
            : base(connection)
        {
            Console.WriteLine($"ProjectNameContext (IConnection connection) => {connection.ToString()}");
        }

        #endregion

        #region IProjectNameContext Implementation

        //IQueryable<MyModel> IProjectNameContext.MyModels => MyModels;

        #endregion

        #region Configure Mappings

        public override void ConfigureMappings(ModelBuilder modelBuilder)
        {
            // base.ConfigureMappings(modelBuilder);
        }

        #endregion
    }
}
