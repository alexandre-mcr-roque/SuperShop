using Microsoft.AspNetCore.Identity;
using SuperShop.Data.Entities;
using SuperShop.Helpers;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SuperShop.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;
        private Random _random;

        public SeedDb(DataContext context, IUserHelper userHelper)
        {
            _context = context;
            _userHelper = userHelper;
            _random = new Random();
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();

            var user = await _userHelper.GetUserByEmailAsync("alexandre.mcr.roque@gmail.com");
            if (user == null)
            {
                user = new User
                {
                    FirstName = "Alexandre",
                    LastName = "Roque",
                    Email = "alexandre.mcr.roque@gmail.com",
                    UserName = "alexandre.mcr.roque@gmail.com",
                    PhoneNumber = "987564231"
                };

                var result = await _userHelper.AddUserAsync(user, "123456");
                if (!result.Succeeded)
                {
                    throw new InvalidOperationException("Could not create the user in seeder");
                }
            }

            if (!_context.Products.Any())
            {
                AddProduct("iPhone X", user);
                AddProduct("Magic Mouse", user);
                AddProduct("iWatch Series 4", user);
                AddProduct("iPad Mini", user);

                await _context.SaveChangesAsync();
            }
        }

        private void AddProduct(string name, User user)
        {
            _context.Products.Add(new Product
            {
                Name = name,
                Price = _random.Next(1000),
                IsAvailable = true,
                Stock = _random.Next(100),
                User = user
            });
        }
    }
}
