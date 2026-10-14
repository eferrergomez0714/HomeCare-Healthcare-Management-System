namespace HomeCare.Models
{
    public class PatientCareGiver
    {
        public int PatientId {  get; set; }
        public int CareGiverId { get; set; }

        public int DailyHours { get; set; }

        public required CareGivers CareGiver { get; set; }
        public required Patients Patient { get; set; }
    }
}
