using System.Collections.Generic;
using AutoMapper;
using DarkKanban.Core.Contracts.Models;
using DarkKanban.Core.Contracts.Responses;

namespace DarkKanban.Core.Services.Board
{
    public class BoardMappingProfile : Profile
    {
        public BoardMappingProfile()
        {
            CreateMap<Contracts.Entities.Board, GetBoardResponse>()
                .ForMember(x => x.Columns, 
                    opt => opt.MapFrom(x => x.Columns))
                .ForMember(x=> x.Id,
                    opt => opt.MapFrom(x=>x.Id))
                .ForMember(x=>x.Name,
                    o => o.MapFrom(x=>x.Name))
                .ForMember(x=>x.Description, 
                    o => o.MapFrom(x=>x.Description))
                .ForMember(x=>x.Columns,
                    o => o.MapFrom(x=>x.Columns));

            CreateMap<Contracts.Entities.Board, EntityShortInfoModel>()
                .ForMember(x=>x.Id, 
                    o=>o.MapFrom(x=>x.Id))
                .ForMember(x=>x.Name, 
                    o => o.MapFrom(x=>x.Name));
        }
    }
}