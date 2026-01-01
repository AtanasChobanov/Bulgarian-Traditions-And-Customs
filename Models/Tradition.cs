using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace BulgarianTraditionsAndCustoms.Models
{
    public class Tradition
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [MaxLength(2000)]
        public string Description { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime CelebrationDate { get; set; }
        public string? ImagePath { get; set; }
        [Required]
        public int RegionId { get; set; }
        [Required]
        public int TraditionTypeId { get; set; }
        // Navigation Properties
        public Region? Region { get; set; }
        public TraditionType? TraditionType { get; set; }
        public ICollection<Holiday>? Holidays { get; set; }
        public ICollection<TraditionParticipant>? TraditionParticipants { get; set; }
    }
}
