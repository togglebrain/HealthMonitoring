using System;

namespace HealthMonitoring.Base.CustomExceptions
{
    [Serializable]
    public class CacheSettingsException : Exception
    {
        public CacheSettingsException()
        {
        }

        public CacheSettingsException(string message)
        : base(message)
        {
        }

        public CacheSettingsException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}