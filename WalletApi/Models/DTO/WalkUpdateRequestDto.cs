using System.ComponentModel.DataAnnotations;
using WalletApi.Models.Domains;

namespace WalletApi.Models.DTO
{
    public class WalkUpdateRequestDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public double LengthInKm { get; set; }
        public string? WalkImageUrl { get; set; }
        public Guid RegionId { get; set; }

        public Guid DifficultyId { get; set; }
    }
}
