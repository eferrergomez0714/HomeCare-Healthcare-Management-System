namespace HomeCare.Dtos.Patients
{
    public class PatientMedicalRecordDto
    {
        public string SSN { get; set; } = string.Empty;

        public List<MedicalRecordDto> MedicalRecords { get; set; } = new();
    }
}
