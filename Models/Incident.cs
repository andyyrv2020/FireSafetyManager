using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FireSafetyManager.Models
{
    public class Incident
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Address { get; set; }
        [Required]
        public string Type { get; set; }
        public int WaterUsed { get; set; }
        [Required]
        public TimeOnly IncidentStart { get; set; }
        public TimeOnly IncidentEnd { get; set; }

        public int? VehicleId { get; set; }
        [ForeignKey("VehicleId")]
        public virtual Vehicle? Vehicle { get; set; }
    }
}
