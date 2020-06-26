using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BizCover.Cars.Contract;
using BizCover.Cars.Data.Domain;

namespace BizCover.Cars.Service.MappingProfiles
{
    public class DomainToResponseProfile:Profile
    {
        public DomainToResponseProfile()
        {
            CreateMap<SelectCar, CarPurchaseResponse>()
             .ForMember(
                 dest => dest.LineDiscount,
                 opt => opt.MapFrom(src => 0)
             );
            CreateMap<IEnumerable<SelectCar>, CarsPurchaseResponse>()
            .ForMember(
               dest => dest.CarPurchaseCollection,
               opt => opt.MapFrom(src => src)
            ).ForMember(
               dest => dest.GrandTotal,
                opt => opt.MapFrom(src => src.Sum(e => e.Price))
            ).ForMember(
               dest => dest.TotalDiscount,
               opt => opt.MapFrom(src => 0)
            );
        }
    }
}
