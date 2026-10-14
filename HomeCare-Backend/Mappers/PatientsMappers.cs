using HomeCare.Dtos.Patients;
using HomeCare.Models;

namespace HomeCare.Mappers
{
    public static class PatientsMappers
    {
        public static PatientsDto ToPatientsDto(this Patients patientsModel)
        {
            return new PatientsDto
            {
                Id= patientsModel.Id,
                Name= patientsModel.Name,
                Email= patientsModel.Email,
                Age= patientsModel.Age,
                City= patientsModel.City,
            };
        }

        public static Patients ToPatientsFromCreateDTO(this CreatePatientsRequestDto patientsDto)
        {
            return new Patients
            {
                Name = patientsDto.Name,
                Email = patientsDto.Email,
                Age = patientsDto.Age,
                City = patientsDto.City,
            };
        }
    }
}
