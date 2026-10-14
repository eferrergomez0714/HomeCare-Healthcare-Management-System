using HomeCare.Dtos.CareGivers;
using HomeCare.Models;
using System.Runtime.CompilerServices;

namespace HomeCare.Mappers
{
    public static class CareGiversMappers
    {
        public static CareGiversDto ToCareGiversDto(this CareGivers careGiversModel)
        {
            return new CareGiversDto
            {
                Id = careGiversModel.Id,
                Name = careGiversModel.Name,
                Email = careGiversModel.Email,
                Rate = careGiversModel.Rate,
                City = careGiversModel.City,
            };
        }

        public static CareGivers ToCareGiversFromCreateDTO(this CreateCareGiversRequestDto careGiversDto) 
        {
            return new CareGivers
            {
                Name = careGiversDto.Name,
                Email = careGiversDto.Email,
                Rate = careGiversDto.Rate,
                City = careGiversDto.City,
            };
        }
    }
}
