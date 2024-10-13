using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DistributionCenter.Domain.Models
{
    public class Package
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime ArriveDate { get; set; }
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        [JsonIgnore]
        public Customer? Customer { get; set; }
    }
}
