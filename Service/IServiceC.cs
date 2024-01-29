namespace Service
{
    public interface IServiceC
    {
        public Task<int?> GetRandomFromRedis(string message);
    }
}
