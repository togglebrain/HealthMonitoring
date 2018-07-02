namespace HealthMonitoring.Base.Models
{
    public class Dependency
    {
        /// <summary>
        /// Name of the dependency
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// ServiceCD (if any) of the dependency as per service map
        /// </summary>
        public string ServiceCD { get; set; }

        /// <summary>
        /// Status of the dependency - whether UP
        /// </summary>
        public Enums.DependencyStatus Status { get; set; }

        /// <summary>
        /// Type of application - whether dependency is an API/DB/Cache... etc.
        /// </summary>
        public Enums.ApplicationType Type { get; set; }
    }
}
