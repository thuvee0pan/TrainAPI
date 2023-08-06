﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using TreainBookingApi.Authorization;
using TreainBookingApi.Entities;
using TreainBookingApi.Helpers;
using TreainBookingApi.Models.Users;
using BCryptNet = BCrypt.Net.BCrypt;

namespace TreainBookingApi.Services
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);

        Task<AuthenticateResponse> CreateNormalUser(AddUserRequest user);

        IEnumerable<User> GetAll();

        Task<User> GetById(int id);
    }

    public class UserService : IUserService
    {
        private DataContext _context;
        private IJwtUtils _jwtUtils;
        private readonly AppSettings _appSettings;

        public UserService(
            DataContext context,
            IJwtUtils jwtUtils,
            IOptions<AppSettings> appSettings)
        {
            _context = context;
            _jwtUtils = jwtUtils;
            _appSettings = appSettings.Value;
        }

        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            var user = _context.Users.SingleOrDefault(x => x.Username == model.Username);

            // validate
            if (user == null || !BCryptNet.Verify(model.Password, user.PasswordHash))
                throw new AppException("Username or password is incorrect");

            // authentication successful so generate jwt token
            var jwtToken = _jwtUtils.GenerateJwtToken(user);

            return new AuthenticateResponse(user, jwtToken);
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users;
        }

        public async Task<User> GetById(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) throw new KeyNotFoundException("User not found");
            return user;
        }

        public async Task<AuthenticateResponse> CreateNormalUser(AddUserRequest user)
        {
            var Exsisting = await _context.Users.FirstOrDefaultAsync(x => x.Username == user.Username);
            if (Exsisting != null)
            {
                throw new AppException("User already Exsist");
            }

            var newUser = new User
            {
                FirstName = user.FirstName,
                LastName = user?.LastName,
                Username = user.Username.ToLower(),
                Role = user.Role,
                CreditCard = user.CreditCard,
                Address = user.Address,
                PasswordHash = BCryptNet.HashPassword(user.Password),
                Nic = user.Nic,
                PhoneNo = user.PhoneNo,
                CreatedBy = "aDMIN",
                UpdatedBy = "aDMIN",
                CreatedDate = DateTime.UtcNow
            };
            try
            {
                await _context.Users.AddAsync(newUser);
                await _context.SaveChangesAsync();
                return this.Authenticate(new AuthenticateRequest { Username = user.Username, Password = user.Password });
            }
            catch (Exception ex)
            {
                throw new AppException(ex.Message);
            }
        }
    }
}