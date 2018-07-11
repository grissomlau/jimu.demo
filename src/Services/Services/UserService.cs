using System;
using IServices;
using IServices.Models;

namespace Services
{
    public class UserService : IUserService
    {
        public User GetById(int userId)
        {
            return new User()
            {
                Id = userId,
                Name = "jimu user"

            };
        }

        public int Add(User user)
        {
            Console.WriteLine($"added User name is : {user.Name}");
            user.Id = 1;
            return user.Id;
        }
    }
}
