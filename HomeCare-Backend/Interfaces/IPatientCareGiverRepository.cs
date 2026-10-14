using HomeCare.Models;

namespace HomeCare.Interfaces
{
    public interface IPatientCareGiverRepository
    {
        Task<List<PatientCareGiver>> GetAllAsync();
    }
}
