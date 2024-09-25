using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DistributionCenter.Domain.Models
{
    public class Package
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime ArriveDate { get; set; }
        [ForeignKey("Employee")]
        public int? EmployeeId { get; set; }
        public Employee Employee { get; set; }
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
