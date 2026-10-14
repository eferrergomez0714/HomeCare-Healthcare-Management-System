using HomeCare.Dtos.Patients;
using System.Net.Http.Json;

namespace HomeCare.Services
{
    public class MedicalRecordsService
    {
        private readonly HttpClient _httpClient;

        public MedicalRecordsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<PatientMedicalRecordDto?> GetMedicalRecordsAsync(
            string ssn)
        {
            return await _httpClient.GetFromJsonAsync<PatientMedicalRecordDto>(
                $"api/patients/{ssn}/medical-records");
        }
    }
}