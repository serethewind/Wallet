using System.ComponentModel.DataAnnotations;
using WalletApi.Models.Domains;

namespace WalletApi.Models.DTO
{
    public class WalkRequestDto
    {
        [Required]
        public string Name { get; set; }
        [Required(ErrorMessage = "")]
        public string Description { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Value must be between 0 and max int value")]
        public double LengthInKm { get; set; }
        public string? WalkImageUrl { get; set; }
        [Required]
        public Guid RegionId { get; set; }
        [Required]
        public Guid DifficultyId { get; set; }

    }
}
