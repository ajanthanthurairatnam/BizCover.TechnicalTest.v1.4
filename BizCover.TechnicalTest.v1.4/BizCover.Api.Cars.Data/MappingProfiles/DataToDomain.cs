using AutoMapper;
using BizCover.Cars.Data.Domain;
using BizCover.Repository.Cars;

namespace BizCover.Cars.Service.MappingProfiles
{
    public class DataToDomain : Profile
    {
        public DataToDomain()
        {
            CreateMap<Car, SelectCar>();
        }
    }

    public class DomainToData : Profile
    {
        public DomainToData()
        {
            CreateMap<PostCar, Car>();
        }
    }
}
