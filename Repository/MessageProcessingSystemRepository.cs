

using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Model;

namespace Repository
{
    public class MessageProcessingSystemRepository: IMessageProcessingSystemRepository
    {
        private readonly MessageDBContext _context;
        private readonly IMapper _mapper;

        public MessageProcessingSystemRepository(MessageDBContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<bool> AddMessage(MessageDTO messageDTO)
        {
            try
            {
                var remssaseToSave = _mapper.Map<Message>(messageDTO);
                await _context.Messages.AddAsync(remssaseToSave);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<int?> GetRandomValueByMessage(string message)
        {
            try
            {
               var resprson = await _context.Messages.AsQueryable().Where(x => x.MessageData == message).ToListAsync();
               var res = _mapper.Map<MessageDTO>(resprson[0]);
                return res.RandomNumber;
 
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        
    }
}
