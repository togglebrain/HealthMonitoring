using HealthMonitoring.Base.Contracts;
using HealthMonitoring.Base.Models;
using System.Data.SqlClient;

namespace HealthMonitoring.Base.Workers
{
    public class SQLHealthChecker : HealthCheck
    {
        private string sqlConnectionString;

        public SQLHealthChecker(Dependency dep, string connectionString) : base(dep)
        {
            sqlConnectionString = connectionString;
        }

        protected override void SetHealthImplementation()
        {
            using (SqlConnection connection = new SqlConnection(sqlConnectionString))
            {
                connection.Open();
                if (connection.State != System.Data.ConnectionState.Open)
                {
                    attachedDependency.Status = Enums.DependencyStatus.DOWN;
                }
                else
                {
                    attachedDependency.Status = Enums.DependencyStatus.UP;

                }
            }
        }
    }
}
