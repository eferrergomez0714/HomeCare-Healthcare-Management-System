using ClinicalHistory.Models;

namespace ClinicalHistory.Interfaces
{
    public interface IBlobStorageService
    {
        Task<List<MedicalRecord>> GetMedicalRecordsBySSNAsync(string ssn);
    }
}
