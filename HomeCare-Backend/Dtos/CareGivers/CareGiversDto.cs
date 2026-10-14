namespace HomeCare.Dtos.CareGivers
{
    public class CareGiversDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public decimal Rate { get; set; }
        public string City { get; set; } = string.Empty;
    }
}
