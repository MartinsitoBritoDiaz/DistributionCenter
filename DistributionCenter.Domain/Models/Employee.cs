using System.ComponentModel.DataAnnotations;

namespace DistributionCenter.Domain.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public virtual ICollection<Package> Packages { get; set; }
    }
}
