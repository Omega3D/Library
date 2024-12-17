using API.Data.Migrations;

namespace API.Dto
{
    public class CustomerDto
    {
        public int CustomerId {  get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public int Phone { get; set; }
        public string City {  get; set; } = string.Empty;
        public string PostalCode { get; set; } = string.Empty;
        public int UserId { get; set; }
    }
}
