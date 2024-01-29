using AutoMapper;
using Model;

namespace Mapper
{
    public class MapperConfig
    {
        public class MappingProfile : Profile
        {
            public MappingProfile()
            {
                // Add as many of these lines as you need to map your objects

                CreateMap<Message, MessageDTO>();
                CreateMap<MessageDTO, Message>();

            }

        }
    }
}
