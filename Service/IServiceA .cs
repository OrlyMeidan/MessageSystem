using Model;

namespace Service
{
    public interface IServiceA
    {
        public  Task<bool> AddMessage(string message);
    }
}
