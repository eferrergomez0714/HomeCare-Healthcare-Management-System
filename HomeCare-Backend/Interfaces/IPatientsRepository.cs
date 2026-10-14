using HomeCare.Dtos.Patients;
using HomeCare.Models;

namespace HomeCare.Interfaces
{
    public interface IPatientsRepository
    {
        Task<List<Patients>> GetAllAsync();
        Task<List<Patients>> SearchByNameAsync(string name);
        Task<List<Patients>> SearchByAgeAsync(int age);
        Task<Patients?> GetByIdAsync(int id);  
        Task<Patients> CreateAsync(Patients patientModel); 
        Task<Patients?> UpdateAsync(int id, UpdatePatientsDto patientsDto);
        Task<Patients?> DeleteAsync(int id);
    }
}
