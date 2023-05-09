using AutoMapper;
using PostgreSQL.DataEntities.Models;
using PostgreSQL.DataEntities.ViewModels;
namespace PostgreSQL;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<Information, InformationViewModel>().ReverseMap();
    }
}
