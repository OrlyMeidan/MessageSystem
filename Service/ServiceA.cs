
using Model;
using Repository;

namespace Service
{
    public class ServiceA: IServiceA
    {
        private readonly IMessageProcessingSystemRepository _messageProcessingSystemRepository;
        Random rnd = new Random();
        public ServiceA(IMessageProcessingSystemRepository messageProcessingSystemRepository ) 
        {
            _messageProcessingSystemRepository = messageProcessingSystemRepository;
          
        }

        public async Task<bool> AddMessage(string message)
        {
            try
            {
                MessageDTO messageDTO = new MessageDTO {
                    MessageData = message,
                    RandomNumber = rnd.Next(0, int.MaxValue)
                };   
                return await _messageProcessingSystemRepository.AddMessage(messageDTO).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                //TODO add Logget
                // _logger.($ ex , "");
                throw;
            }

        }
    }
}
