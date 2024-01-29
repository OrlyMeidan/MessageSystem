using Microsoft.Extensions.Caching.Distributed;
using Repository;

namespace Service
{
    public class ServiceC: IServiceC
    {
        private readonly IDistributedCache _distributedCache;

        public ServiceC(IDistributedCache distributedCache) //, ILogger<PollAndTriviaService> logger)
        {
          
            _distributedCache = distributedCache;
            //  _logger = logger;
        }

        public async Task<int?> GetRandomFromRedis(string message)
        {
            try
            {
                var key = $"message-{message}";

                string? number = await _distributedCache.GetStringAsync(key, default);
                if (string.IsNullOrEmpty(number))
                {
                    return null;
                }
                return Convert.ToInt32(number);
            }
            catch (Exception ex)
            {
                //TODO add Logger
                throw;
            }

        }
    }
}
