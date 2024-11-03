using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace DistributionCenter.Domain.Models
{
    public class Package
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        [JsonProperty(PropertyName = "type")] 
        public string Type { get; set; } = string.Empty;
        public DateTime ArriveDate { get; set; }
    }
}
 