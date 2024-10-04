using APILogs.Dtos;
using APILogs.Models;
using AutoMapper;

namespace APILogs.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Create your mappings here
            CreateMap<RequestResponseLogModel, RequestLogs>();
            // Add other mappings as needed
        }
    }
}
