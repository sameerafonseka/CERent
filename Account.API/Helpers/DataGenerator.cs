using CERent.Account.Lib.Domain;
using CERent.Core.Lib.Model;
using CERent.Core.Lib.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CERent.Account.API.Helpers
{
    public static class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new AccountDbContext(serviceProvider.GetRequiredService<DbContextOptions<AccountDbContext>>()))
            {
                // Look for any board games already in database.
                if (context.Users.Any())
                {
                    return;   // Database has been seeded
                }

                var encryptionUtil = serviceProvider.GetService<IEncryptionUtil>();

                context.Users.AddRange(
                    new Lib.Domain.Models.User
                    {
                        Id = 1,
                        CreatedBy = "Admin",
                        CreatedDate = DateTimeOffset.Now,
                        Email = "sfonseka@gmail.com",
                        FirstName = "Sameera",
                        LastName = "Fonseka",
                        ModifiedBy = "Admin",
                        ModifiedDate = DateTimeOffset.Now,
                        Password = encryptionUtil.Encrypt("xxx"),
                        UserType = UserType.Buyer
                    });

                context.SaveChanges();
            }
        }
    }
}
