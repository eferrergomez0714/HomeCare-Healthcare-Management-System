using ClinicalHistory.Models;
using MedicalRecordsAPI.Services;
using ClinicalHistory.Interfaces;

namespace ClinicalHistory.Services
{
    public class PatientService : IPatientService
    {
        private readonly IBlobStorageService _blobStorageService;

        public PatientService(IBlobStorageService blobStorageService)
        {
            _blobStorageService = blobStorageService;
        }

        public async Task<Patient> GetPatientBySSNAsync(string ssn)
        {
            var medicalRecords =
                await _blobStorageService.GetMedicalRecordsBySSNAsync(ssn);

            return new Patient
            {
                SSN = ssn,
                MedicalRecords = medicalRecords
            };
        }
    }
}