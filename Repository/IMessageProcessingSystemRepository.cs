

using Model;

namespace Repository
{
    public interface IMessageProcessingSystemRepository
    {
        public Task<bool> AddMessage(MessageDTO messageDTO);
        public Task<int?> GetRandomValueByMessage(string message);
    }
}
