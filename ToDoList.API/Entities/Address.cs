using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ToDoList.API.Entities
{
    [Table("address")]
    public class Address
    {
        [Key]
        public int AddressId { get; set; }
        public string AddressStreet { get; set; }
        public int AddressNumber { get; set; }
        public string AddressComplement { get; set; }
        public string AddressCity { get; set; }
        public string AddressState { get; set; }
        public string AddressPostalCode { get; set; }
        public int UserId { get; set; }

        public void Update(string addressStreet, int addressNumber, string addressComplement, string addressCity, string addressState, string postalCode)
        {
            AddressStreet = addressStreet;
            AddressNumber = addressNumber;
            AddressComplement = addressComplement;
            AddressCity = addressCity;
            AddressState = addressState;
            AddressPostalCode = postalCode;

        }
    }

    
}

