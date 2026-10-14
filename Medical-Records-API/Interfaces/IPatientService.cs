using ClinicalHistory.Models;

namespace ClinicalHistory.Interfaces
{
    public interface IPatientService
    {
        Task<Patient> GetPatientBySSNAsync(string ssn);
    }
}
