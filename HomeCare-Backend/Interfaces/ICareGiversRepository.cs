using HomeCare.Dtos.CareGivers;
using HomeCare.Models;

namespace HomeCare.Interfaces
{
    public interface ICareGiversRepository
    {
        Task<List<CareGivers>> GetAllAsync();
        Task<CareGivers?> GetByIdAsync(int id);
        Task<CareGivers> CreateAsync(CareGivers careGiversModel);
        Task<CareGivers?> UpdateAsync(int id, UpdateCareGiversDto careGiversDto);
        Task<CareGivers?> DeleteAsync(int id);
    }
}
