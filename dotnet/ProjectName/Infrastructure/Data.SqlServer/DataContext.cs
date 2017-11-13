using Data.SqlServer.Extensions;
using ProjectName.Business.Core.Interfaces.Data;
using ProjectName.Business.Core.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace Data.SqlServer
{
    public class DataContext : Context, IDataContext
    {
        #region Properties



        #endregion Properties


        #region IDataContext Implementation

        #endregion IDataContext Implementation


        #region Constructor

        /// <summary>
        /// 
        /// </summary>
        public DataContext()
            : base(Configuration.GetConnectionString())
        {
        }

        public DataContext(string connectionString)
            : base(connectionString)
        {
        }

        /// <summary>
        /// </summary>
        /// <param name="connection">Connection that should be used for the data context</param>
        public DataContext(IConnection connection)
            : base(connection.ToString())
        {
        }

        #endregion Constructor


        #region Overrides of DataContext

        /// <summary>
        /// Configure the database mappings
        /// </summary>
        /// <param name="modelBuilder"></param>
        public override void ConfigureMappings(ModelBuilder modelBuilder)
        {
            base.ConfigureMappings(modelBuilder);

            //modelBuilder.AddMapping(new MyModelMap());
        }

        /// <summary>
        /// Generate the database structure by running the code-first migrations
        /// </summary>
        public override void CreateStructure()
        {
            Database.Migrate();
        }

        /// <summary>
        /// 
        /// </summary>
        public override void DeleteDatabase()
        {
            Database.EnsureDeleted();
        }

        /// <summary>
        /// Drop the database structure by reverting the code-first migrations
        /// </summary>
        public override void DropStructure()
        {
            var migrator = this.GetInfrastructure().GetRequiredService<IMigrator>();
            migrator.Migrate("0");
        }

        #endregion Overrides of DataContext
    }
}
