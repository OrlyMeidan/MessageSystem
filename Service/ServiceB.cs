using Microsoft.Extensions.Caching.Distributed;
using Repository;

namespace Service
{
    public class ServiceB : IServiceB
    {
        private readonly IMessageProcessingSystemRepository _messageProcessingSystemRepository;
        private readonly IDistributedCache _distributedCache;

        public ServiceB(IMessageProcessingSystemRepository messageProcessingSystemRepository, IDistributedCache distributedCache) //, ILogger<PollAndTriviaService> logger)
        {
            _messageProcessingSystemRepository = messageProcessingSystemRepository;
            _distributedCache = distributedCache;
            //  _logger = logger;
        }

        public async Task<bool> GetMessageAndSaveInRedis(string message)
        {
            try
            {
                var key = $"message-{message}";
                var randomValue = await _messageProcessingSystemRepository.GetRandomValueByMessage(message);
                if (randomValue == null )
                {
                    return false;
                }
                await _distributedCache.SetStringAsync(key, randomValue.ToString(), default);

                return true;
            }
            catch (Exception ex)
            {
                //TODO add Logger
                throw;
            }

        }
    }
}
