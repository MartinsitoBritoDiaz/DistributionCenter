using System.ComponentModel.DataAnnotations;

namespace DistributionCenter.Domain.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public virtual ICollection<Package> Packages { get; set; }
    }
}
