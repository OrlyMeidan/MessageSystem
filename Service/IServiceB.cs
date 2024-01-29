namespace Service
{
    public interface IServiceB
    {
        public Task<bool> GetMessageAndSaveInRedis(string message);
    }
}
