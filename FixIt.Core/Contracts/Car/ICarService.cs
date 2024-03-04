using FixIt.Core.Models.Car;

namespace FixIt.Core.Contracts.Car
{
    public interface ICarService
    {
        Task<IEnumerable<CarViewModel>> GetAllAsync();
        string GetUserId();
        Task AddAsync(CarFormModel model);
        Task<CarDetailedViewModel> GetDetailsAsync(int id);
        Task UpdateAsync(CarFormModel model);
        Task<CarFormModel> GetFormByIdAsync(int id);
    }
}
