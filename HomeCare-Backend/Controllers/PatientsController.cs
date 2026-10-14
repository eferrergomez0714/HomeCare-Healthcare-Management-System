using HomeCare.Data;
using HomeCare.Dtos.Patients;
using HomeCare.Interfaces;
using HomeCare.Mappers;
using HomeCare.Repository;
using HomeCare.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HomeCare.Controllers
{
    [Route("homecare/patients")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientsRepository _patientsRepo;
        private readonly MedicalRecordsService _medicalRecordsService;
        public PatientsController(IPatientsRepository patientsRepo, MedicalRecordsService medicalRecordsService)
        {
            _patientsRepo = patientsRepo;
            _medicalRecordsService = medicalRecordsService;
        }

        [HttpGet("{id}/medical-records")]
        public async Task<IActionResult> GetMedicalRecords(int id)
        {
            var patient = await _patientsRepo.GetByIdAsync(id);

            if (patient == null)
            {
                return NotFound("Patient not found.");
            }

            if (string.IsNullOrEmpty(patient.SSN))
            {
                return NotFound("Patient does not have an SSN.");
            }

            var medicalRecords =
                await _medicalRecordsService.GetMedicalRecordsAsync(patient.SSN);

            if (medicalRecords == null)
            {
                return NotFound("Medical records not found.");
            }

            return Ok(medicalRecords);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var patients = await _patientsRepo.GetAllAsync();
            var patientsDto = patients.Select(s => s.ToPatientsDto());

            return Ok(patients);
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchByName([FromQuery] string name)
        {
            var patients = await _patientsRepo.SearchByNameAsync(name);

            return Ok(patients);
        }

        [HttpGet("search/age")]
        public async Task<IActionResult> SearchByAge([FromQuery] int age)
        {
            var patients = await _patientsRepo.SearchByAgeAsync(age);

            return Ok(patients);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var patient = await _patientsRepo.GetByIdAsync(id);

            if (patient == null)
            {
                return NotFound();
            }
            return Ok(patient.ToPatientsDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePatientsRequestDto patientDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var patientsModel = patientDto.ToPatientsFromCreateDTO();
            await _patientsRepo.CreateAsync(patientsModel);
            return CreatedAtAction(nameof(GetById), new { id = patientsModel.Id }, patientsModel.ToPatientsDto());
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdatePatientsDto updateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var patientModel = await _patientsRepo.UpdateAsync(id, updateDto);

            if (patientModel == null)
            {
                return NotFound();
            }

            return Ok(patientModel.ToPatientsDto());
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute]int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var patientsModel = await _patientsRepo.DeleteAsync(id);

            if (patientsModel == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
