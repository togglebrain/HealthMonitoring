using System.Collections.Generic;

namespace HealthMonitoring.Base.Models
{
    /// <summary>
    /// Health response of a given application
    /// </summary>
    public class HealthResponse
    {
        /// <summary>
        /// Name of the application for which health is being checked.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// ServiceCD - unique identifier of the application as per service map. 
        /// This is varchar(6)
        /// </summary>
        public string ServiceCD { get; set; }

        /// <summary>
        /// Application code of the application as per service map. This is varchar(16) and of the following format:
        /// USR_PRD_A_COR
        /// </summary>
        public string AppCD { get; set; }

        /// <summary>
        /// Overall status of the application
        /// </summary>
        public Enums.OverallStatus Status { get; internal set; }

        /// <summary>
        /// Type of application - API/Web
        /// </summary>
        public Enums.ApplicationType Type { get; set; }

        /// <summary>
        /// List of components on which the application depends.
        /// These can be other applications, DB, redis, table storage etc.
        /// </summary>
        public List<Dependency> Components { get; set; }

    }
}
