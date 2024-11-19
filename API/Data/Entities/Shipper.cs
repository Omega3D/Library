using System.ComponentModel.DataAnnotations;

namespace API.Data.Entities
{
    public class Shipper
    {
        [Key]
        public int ShipperId { get; set; }
        public string ShipperName { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email {  get; set; } = string.Empty;

        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
