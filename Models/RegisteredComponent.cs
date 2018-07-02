using System;

namespace HealthMonitoring.Base.Models
{
    public class RegisteredComponent
    {
        /// <summary>
        /// Name of the component being registered
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// ServiceCD, if any of the component
        /// </summary>
        public string ServiceCD { get; set; }

        /// <summary>
        /// Application type of the component
        /// </summary>
        public Enums.ApplicationType ComponentType { get; set; }

        /// <summary>
        /// Whether caching of health check status is required 
        /// </summary>
        public bool EnableResultCaching { get; set; }

        /// <summary>
        /// Time period for which health check results should be cached
        /// </summary>
        public TimeSpan CacheDuration { get; set; }
    }
}
