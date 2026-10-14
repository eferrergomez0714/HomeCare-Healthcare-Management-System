using System.ComponentModel.DataAnnotations;

namespace HomeCare.Dtos.CareGivers
{
    public class CreateCareGiversRequestDto
    {
        [Required]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 100 characters.")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        public string Email { get; set; } = string.Empty;

        [Required]
        [Range(0.01, 120, ErrorMessage = "Age must be between 18 and 120.")]
        public decimal Rate { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "City must be between 2 and 100 characters.")]
        public string City { get; set; } = string.Empty;
    }
}
