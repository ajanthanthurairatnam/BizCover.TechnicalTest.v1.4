using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BizCover.Cars.Data.Domain;
using BizCover.Cars.Data;
using BizCover.Cars.Contract;
using AutoMapper;

namespace BizCover.Cars.Service
{
    public class CarsService : ICarsService
    {
        private readonly IData _data;
        private readonly IMapper _mapper;
        public CarsService(IData data, IMapper mapper)
        {
            _data = data;
            _mapper = mapper;
        }
        public async Task<IEnumerable<SelectCar>> GetCars(List<int> Ids)
        {
            var selectedCarList = await _data.GetAllCars();
            var selectedCars = Ids != null ? selectedCarList.Where(e => Ids.Contains(e.Id)).AsEnumerable() : selectedCarList.AsEnumerable();
            return selectedCars;
        }
        public async Task<SelectCar> PostCar(CarPostRequest carPostRequest)
        {
            var postCar=_mapper.Map<PostCar>(carPostRequest);
            var selectCar = await _data.Save(postCar);
            return selectCar;
        }
    }
}
