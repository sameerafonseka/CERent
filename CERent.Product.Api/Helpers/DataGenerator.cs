using CERent.Product.Lib.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CERent.Product.Api.Helpers
{
    public static class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ProductDbContext(serviceProvider.GetRequiredService<DbContextOptions<ProductDbContext>>()))
            {
                #region Equipments

                if (!context.Equipments.Any())
                {
                    context.Equipments.AddRange(
                      new Lib.Domain.Entities.Equipment
                      {
                          Id = 1,
                          Name = "Caterpillar bulldozer",
                          Type = EquipmentType.Heavy,
                          CreatedBy = "Admin",
                          CreatedDate = DateTimeOffset.Now,
                          ModifiedBy = "Admin",
                          ModifiedDate = DateTimeOffset.Now,
                      },
                     new Lib.Domain.Entities.Equipment
                     {
                         Id = 2,
                         Name = "KamAZ truck",
                         Type = EquipmentType.Heavy,
                         CreatedBy = "Admin",
                         CreatedDate = DateTimeOffset.Now,
                         ModifiedBy = "Admin",
                         ModifiedDate = DateTimeOffset.Now,
                     },
                     new Lib.Domain.Entities.Equipment
                     {
                         Id = 3,
                         Name = "Komatsu crane",
                         Type = EquipmentType.Heavy,
                         CreatedBy = "Admin",
                         CreatedDate = DateTimeOffset.Now,
                         ModifiedBy = "Admin",
                         ModifiedDate = DateTimeOffset.Now,
                     },
                     new Lib.Domain.Entities.Equipment
                     {
                         Id = 4,
                         Name = "Volvo steamroller",
                         Type = EquipmentType.Heavy,
                         CreatedBy = "Admin",
                         CreatedDate = DateTimeOffset.Now,
                         ModifiedBy = "Admin",
                         ModifiedDate = DateTimeOffset.Now,
                     },
                     new Lib.Domain.Entities.Equipment
                     {
                         Id = 5,
                         Name = "Bosch jackhammer",
                         Type = EquipmentType.Heavy,
                         CreatedBy = "Admin",
                         CreatedDate = DateTimeOffset.Now,
                         ModifiedBy = "Admin",
                         ModifiedDate = DateTimeOffset.Now,
                     }
                  );
                }

                #endregion




                context.SaveChanges();
            }
        }
    }
}
