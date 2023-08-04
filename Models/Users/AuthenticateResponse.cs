using TreainBookingApi.Entities;

namespace TreainBookingApi.Models.Users
{
    public class AuthenticateResponse
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public Role Role { get; set; }
        public string Token { get; set; }
        public string CreditCard { get; set; }
        public string Address { get; set; }

        public AuthenticateResponse(User user, string token)
        {
            Id = user.Id;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Username = user.Username;
            CreditCard = user.CreditCard;
            Address = user.Address;
            Role = user.Role ?? Role.User;
            Token = token;
        }
    }
}