using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BizCover.Cars.Data.Domain;
using BizCover.Repository.Cars;

namespace BizCover.Cars.Data
{
    public interface IData
    {
        Task<IEnumerable<SelectCar>> GetAllCars();
        Task<SelectCar> Save(PostCar postCar);
    }

    public class CarData: IData
    {
        private readonly ICarRepository _carRepository;
        private readonly IMapper _mapper;

        public CarData(ICarRepository carRepository, IMapper mapper)
        {
            _carRepository = carRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SelectCar>> GetAllCars()
        {
            var carList = await _carRepository.GetAllCars();
            var cars = carList.AsEnumerable();
            return _mapper.Map<IEnumerable<SelectCar>>(cars);
        }

        /// <summary>
        /// Lock mechanism to handle single thread execution is
        /// not handled, hense Lock is applied in CarRepository
        /// 
        /// </summary>
        /// <param name="postCar"></param>
        /// <returns></returns>
        public async Task<SelectCar> Save(PostCar postCar)
        {
            var car = _mapper.Map<Car>(postCar);
            if (car.Id <= 0)
            {
                car.Id = await _carRepository.Add(car);
            }
            else
            {
                await _carRepository.Update(car);
            }
            return _mapper.Map<SelectCar>(car);
        }
    }

}
