using AutoMapper;
using DarkKanban.Core.Contracts.Models;
using DarkKanban.Core.Contracts.Responses;

namespace DarkKanban.Core.Services.Column
{
    public class ColumnMappingProfile : Profile
    {
        public ColumnMappingProfile()
        {
            CreateMap<Contracts.Entities.Column, ColumnModel>()
                .ForMember(x=> x.Id,
                    opt => opt.MapFrom(x=>x.Id))
                .ForMember(x=>x.Name,
                    o => o.MapFrom(x=>x.Name))
                .ForMember(x=>x.Description, 
                    o => o.MapFrom(x=>x.Description))
                .ForMember(x=>x.Type, o => o.MapFrom(x=>x.Type));
            
            CreateMap<Contracts.Entities.Column, EntityShortInfoModel>()
                .ForMember(x=>x.Id, 
                    o => o.MapFrom(x=>x.Id))
                .ForMember(x=>x.Name,
                    o => o.MapFrom(x=>x.Name));
            
            CreateMap<Contracts.Entities.Column, ColumnShortInfo>()
                .ForMember(x=>x.Id, 
                    o => o.MapFrom(x=>x.Id))
                .ForMember(x=>x.Name,
                    o => o.MapFrom(x=>x.Name))
                .ForMember(x=>x.Type,
                    o => o.MapFrom(x=>x.Type));
        }
    }
}