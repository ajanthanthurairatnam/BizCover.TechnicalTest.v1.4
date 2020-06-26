using System.Collections.Generic;
using System.Threading.Tasks;
using BizCover.Cars.Contract;
using BizCover.Cars.Data.Domain;

namespace BizCover.Cars.Service
{
    public interface ICarsService
    {
        Task<IEnumerable<SelectCar>> GetCars(List<int> Ids);
        Task<SelectCar> PostCar(CarPostRequest carPostRequest);
    }
}
