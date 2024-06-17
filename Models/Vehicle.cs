using System.ComponentModel.DataAnnotations;

namespace FireSafetyManager.Models
{
    public class Vehicle
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string CarModel { get; set; }
        public int IncidentsTotal { get; set; }
        public bool IsOnDuty { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<Incident> Incidents { get; set; }
    }
}
