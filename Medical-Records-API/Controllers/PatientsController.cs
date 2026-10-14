using ClinicalHistory.Models;
using ClinicalHistory.Services;
using Microsoft.AspNetCore.Mvc;
using ClinicalHistory.Interfaces;

namespace MedicalRecordsAPI.Controllers
{
    [ApiController]
    [Route("api/patients")]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientService _patientService;

        public PatientsController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpGet("{ssn}/medical-records")]
        public async Task<ActionResult<Patient>> GetMedicalRecords(
            string ssn)
        {
            var patient =
                await _patientService.GetPatientBySSNAsync(ssn);

            if (patient.MedicalRecords.Count == 0)
            {
                return NotFound();
            }

            return Ok(patient);
        }
    }
}