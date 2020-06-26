using AutoMapper;
using BizCover.Cars.Data.Domain;

namespace BizCover.Cars.Contract.MappingProfiles
{
    public class RequestToDomain : Profile
    {
        public RequestToDomain()
        {
            CreateMap<CarPostRequest, PostCar>();
        }
    }
}
