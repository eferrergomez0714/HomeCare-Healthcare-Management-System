using HomeCare.Dtos.CareGivers;
using HomeCare.Dtos.Patients;
using HomeCare.Interfaces;
using HomeCare.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace HomeCare.Controllers
{
    [Route("homecare/caregivers")]
    [ApiController]
    public class CareGiversController : ControllerBase
    {
        private readonly ICareGiversRepository _careGiversRepo;
        public CareGiversController(ICareGiversRepository careGiversRepo)
        {
            _careGiversRepo = careGiversRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var careGivers = await _careGiversRepo.GetAllAsync();
            var CareGiversDto = careGivers.Select(s => s.ToCareGiversDto());

            return Ok(careGivers);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var careGiver = await _careGiversRepo.GetByIdAsync(id);

            if (careGiver == null)
            {
                return NotFound();
            }
            return Ok(careGiver.ToCareGiversDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCareGiversRequestDto careGiversDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var careGiversModel = careGiversDto.ToCareGiversFromCreateDTO();
            await _careGiversRepo.CreateAsync(careGiversModel);
            return CreatedAtAction(nameof(GetById), new { id = careGiversModel.Id }, careGiversModel.ToCareGiversDto());
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateCareGiversDto updateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var careGiversModel = await _careGiversRepo.UpdateAsync(id, updateDto);

            if (careGiversModel == null)
            {
                return NotFound();
            }

            return Ok(careGiversModel.ToCareGiversDto());
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var careGiversModel = await _careGiversRepo.DeleteAsync(id);

            if (careGiversModel == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
