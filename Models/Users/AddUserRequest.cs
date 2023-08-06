using TreainBookingApi.Entities;

namespace TreainBookingApi.Models.Users
{
    public class AddUserRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string CreditCard { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }
        public string Nic { get; set; }
        public string PhoneNo { get; set; }

        public Role? Role { get; set; }
    }
}