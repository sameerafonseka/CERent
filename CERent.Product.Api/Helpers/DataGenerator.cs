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
                          Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1",
                          TranslationKey = "Product.Caterpillar-bulldozer"

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
                         Description = "Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. ",
                         TranslationKey = "Product.KamAZ-truck"
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
                         Description = "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here'",
                         TranslationKey = "Product.Komatsu-crane"
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
                         Description = "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable.",
                         TranslationKey = "Product.Volvo-steamroller"
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
                         Description = "At vero eos et accusamus et iusto odio dignissimos ducimus qui blanditiis praesentium voluptatum deleniti atque corrupti quos dolores et quas molestias excepturi sint occaecati cupiditate non provident, similique sunt in culpa qui officia deserunt mollitia animi, id est laborum et dolorum fuga.",
                         TranslationKey = "Product.Bosch-jackhammer"
                     }
                  );
                }

                #endregion




                context.SaveChanges();
            }
        }
    }
}
