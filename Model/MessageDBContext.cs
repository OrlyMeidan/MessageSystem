using Microsoft.EntityFrameworkCore;


namespace Model
{
    public class MessageDBContext : DbContext
    {
        public MessageDBContext(DbContextOptions<MessageDBContext> options) : base(options)
        { }
        public DbSet<Message> Messages{ get; set; }
       

    }
}
