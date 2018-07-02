namespace HealthMonitoring.Base.Models
{
    public class Enums
    {
        /// <summary>
        /// UP - Application is up and running fine
        /// DOWN - Application has critical error
        /// WARN - Application is running but with non-blocking errors
        /// </summary>
        public enum OverallStatus { UP, DOWN, WARN }

        /// <summary>
        /// API: A
        /// Web: W
        /// Database: DB
        /// Table Storage: TS
        /// Blob Storage: BS
        /// Queue Storage: QS
        /// Service Bus: SB
        /// Solr: SLR
        /// Event hub: HB
        /// RCH: Redis Cache
        /// MCH: Memcache
        /// </summary>
        public enum ApplicationType { A, W, DB, TS, BS, QS, SB, SLR, HB, RCH, MCH }

        /// <summary>
        /// UP - Dependency is up and running fine
        /// DOWN - Dependency not working
        /// </summary>
        public enum DependencyStatus { UP, DOWN }
    }
}
