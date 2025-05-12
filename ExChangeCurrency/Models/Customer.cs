
namespace CurrencyCource.Models
{
    public class Customer
    {
        public Guid Id { get; set; } = Guid.NewGuid(); // done
        public string FirstName { get; set; } // done
        public string LastName { get; set; } // done
        public int Age { get; set; } // done
        public DateTime DateOfBirth { get; set; } // done
        public string Email { get; set; } // done
        public string PhoneNumber { get; set; } // done 
        public string Password { get; set; } // done
        public decimal Balance { get; set; } // done
    }
}