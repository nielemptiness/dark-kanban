using AutoMapper;
using DarkKanban.Core.Contracts.Models;

namespace DarkKanban.Core.Services.BoardView
{
    public class BoarViewMappingProfile : Profile
    {
        public BoarViewMappingProfile()
        {
            CreateMap<Contracts.Entities.Board, BoardModel>()
                .ForMember(x => x.Columns, 
                        opt => opt.MapFrom(x => x.Columns))
                    .ForMember(x=> x.Id,
                        opt => opt.MapFrom(x=> x.Id))
                    .ForMember(x=>x.Name,
                        o => o.MapFrom(x=> x.Name))
                    .ForMember(x=>x.Description, 
                        o => o.MapFrom(x=> x.Description))
                    .ForMember(x=>x.Columns,
                    o => o.MapFrom(x=> x.Columns));
        }
    }
}