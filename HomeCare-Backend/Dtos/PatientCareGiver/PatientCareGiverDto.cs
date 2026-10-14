using HomeCare.Models;
using HomeCare.Dtos.PatientCareGiver;

namespace HomeCare.Dtos.PatientCareGiver
{
    public class PatientCareGiverDto
    {
        public int PatientId { get; set; }
        public string? PatientName { get; set; }

        public int CareGiverId { get; set; }
        public string? CareGiverName { get; set; }

        public int DailyHours { get; set; }
    }
}
