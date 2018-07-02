using HealthMonitoring.Base.Models;

namespace HealthMonitoring.Base.Contracts
{
    /// <summary>
    /// Class encapsulating the logic for checking health of a given entity and settings related to the same
    /// </summary>
    public abstract class HealthCheck
    {
        protected Dependency attachedDependency;
        protected CacheSettings cache;
        private static readonly object lockObj = new object();
        private InMemoryCache cacheManager;


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="dep">Dependency represented by this instance</param>
        /// <param name="isCached">Cache settings for the dependency</param>
        public HealthCheck(Dependency dep)
        {
            attachedDependency = dep;
            //disable cache by default
            cache = new CacheSettings() { IsCached = false };
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="dep">Dependency represented by this instance</param>
        /// <param name="isCached">Cache settings for the dependency</param>
        public HealthCheck(Dependency dep, CacheSettings cacheSettings)
        {
            attachedDependency = dep;
            cache = cacheSettings;
            cacheSettings.Validate();
            cacheManager = InMemoryCache.GetInstance;
        }

        /// <summary>
        /// Get the status of the selected component
        /// </summary>
        /// <returns>Dependency object containing the status and other information</returns>
        public Dependency GetHealth()
        {
            //Prevent multiple parallel invocations
            lock (lockObj)
            {
                //Initially assume status is down
                attachedDependency.Status = Enums.DependencyStatus.DOWN;

                try
                {
                    if (cache.IsCached)
                    {
                        if (cacheManager.Contains(attachedDependency.Name))
                            return cacheManager.GetData<Dependency>(attachedDependency.Name);
                    }

                    SetHealthImplementation();

                    if (cache.IsCached)
                        //TODO: cache policy/expiry handling
                        cacheManager.Add<Dependency>(attachedDependency.Name, attachedDependency);
                }
                catch
                {
                    //TODO: Log?
                }
                return attachedDependency;
            }
        }

        /// <summary>
        /// PROTECTED METHOD - Child classes can only "inject" logic on how to set status as up or down
        /// caching, exception handling are handled by base class in GetHealth method above
        /// where this method is called
        /// </summary>
        protected abstract void SetHealthImplementation();
    }
}
