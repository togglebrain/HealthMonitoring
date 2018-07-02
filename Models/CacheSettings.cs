using HealthMonitoring.Base.CustomExceptions;
using System;

namespace HealthMonitoring.Base.Models
{
    public class CacheSettings
    {
        public bool IsCached { get; set; }
        public TimeSpan CacheInterval { get; set; }
        public DateTime ExpiresAt { get; set; }

        public override string ToString()
        {
            return $"IsCached: {IsCached}, CacheInterval: {CacheInterval}, ExpiresAt: {ExpiresAt}";
        }

        internal void Validate()
        {
            if (CacheInterval != null && ExpiresAt != null)
            {
                throw new CacheSettingsException("CacheInterval and ExpiresAt cannot both be set. Please specify only one.");
            }
        }
    }
}
