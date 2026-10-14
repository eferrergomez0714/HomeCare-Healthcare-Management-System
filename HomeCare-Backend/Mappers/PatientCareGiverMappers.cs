using HomeCare.Dtos.CareGivers;
using HomeCare.Dtos.PatientCareGiver;
using System.Runtime.CompilerServices;
using HomeCare.Models;

namespace HomeCare.Mappers
{
    public static class PatientCareGiverMappers
    {
        public static PatientCareGiverDto ToPatientCareGiverDto(this PatientCareGiver model)
        {
            return new PatientCareGiverDto
            {
                PatientId = model.PatientId,
                PatientName = model.Patient.Name,

                CareGiverId = model.CareGiverId,
                CareGiverName = model.CareGiver.Name,

                DailyHours = model.DailyHours
            };
        }
    }
}
