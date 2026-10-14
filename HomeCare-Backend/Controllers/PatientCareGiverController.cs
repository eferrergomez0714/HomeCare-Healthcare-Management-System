using HomeCare.Interfaces;
using Microsoft.AspNetCore.Mvc;
using HomeCare.Mappers;
using Microsoft.EntityFrameworkCore;
using HomeCare.Dtos.PatientCareGiver;
using HomeCare.Data;

namespace HomeCare.Controllers
{
        [Route("homecare/patientcaregivers")]
        [ApiController]
        public class PatientCareGiverController : ControllerBase
        {
            private readonly IPatientCareGiverRepository _patientCareGiverRepo;
            public PatientCareGiverController(IPatientCareGiverRepository patientCareGiverRepo)
            {
                _patientCareGiverRepo = patientCareGiverRepo;
            }

            [HttpGet]
            public async Task<IActionResult> GetAll()
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var patientCareGiver = await _patientCareGiverRepo.GetAllAsync();
                var patientCareGiverDto = patientCareGiver.Select(s => s.ToPatientCareGiverDto());

                return Ok(patientCareGiver);
            }
        }
}
