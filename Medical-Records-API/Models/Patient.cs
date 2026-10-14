namespace ClinicalHistory.Models
{
    public class Patient
    {
        public string SSN { get; set; } = string.Empty;

        public List<MedicalRecord> MedicalRecords { get; set; } = new();
    }
}
