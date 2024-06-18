using System.ComponentModel.DataAnnotations;

namespace FireSafetyManager.Models
{
    public class Vehicle
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Vehicle")]
        public string? CarModel { get; set; }

        [Display(Name = "Total Incidents")]
        public int IncidentsTotal { get; set; }

        [Display(Name = "Available?")]
        public bool IsOnDuty { get; set; }



        public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
        public virtual ICollection<Incident> Incidents { get; set; } = new List<Incident>();
    }
}
