using AutoMapper;
using DarkKanban.Core.Contracts.Models;

namespace DarkKanban.Core.Services.Record
{
    public class RecordMappingProfile : Profile
    {
        public RecordMappingProfile()
        {
            CreateMap<Contracts.Entities.Record, EntityShortInfoModel>()
                .ForMember(x=>x.Id, 
                    o=>o.MapFrom(x=>x.Id))
                .ForMember(x=>x.Name, 
                    o => o.MapFrom(x=>x.Name));
        }
    }
}