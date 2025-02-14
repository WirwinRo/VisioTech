using AutoMapper;
using visiotech.api.Dtos;
using visiotech.domain.Entities;

namespace visiotech.api.Extensions
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Grape, GrapeDto>().ReverseMap();
            CreateMap<Manager, ManagerDto>().ReverseMap();
            CreateMap<Parcel, ParcelDto>().ReverseMap();
            CreateMap<Vineyard, VineyardDto>().ReverseMap();
        }
    }
}
