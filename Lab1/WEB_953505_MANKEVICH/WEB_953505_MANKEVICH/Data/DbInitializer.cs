using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using WEB_953505_MANKEVICH.Entities;

namespace WEB_953505_MANKEVICH.Data
{
    public class DbInitializer
    {
        public static async Task Seed(ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)

        {
            await context.Database.EnsureCreatedAsync();

            if (!context.Roles.Any())
            {
                var roleAdmin = new IdentityRole
                {
                    Name = "admin",
                    NormalizedName = "admin"
                };

                await roleManager.CreateAsync(roleAdmin);
            }

            if (!context.Users.Any())
            {
                var user = new ApplicationUser
                {
                    Email = "user@mail.ru",
                    UserName = "user@mail.ru"
                };
                await userManager.CreateAsync(user, "123456");

                var admin = new ApplicationUser
                {
                    Email = "admin@mail.ru",
                    UserName = "admin@mail.ru"
                };
                await userManager.CreateAsync(admin, "123456");

                admin = await userManager.FindByEmailAsync("admin@mail.ru");
                await userManager.AddToRoleAsync(admin, "admin");
            }

            if (!context.CarGroups.Any())
            {
                context.CarGroups.AddRange(
                    new List<CarGroup>
                    {
                        new CarGroup {GroupName = "Купе"},
                        new CarGroup {GroupName = "Седан"},
                        new CarGroup {GroupName = "Универсал"},
                        new CarGroup {GroupName = "Кабриолет"},
                        new CarGroup {GroupName = "Хэтчбек"}
                    });
                await context.SaveChangesAsync();
            }

            if (!context.Cars.Any())
            {
                context.Cars.AddRange(
                    new List<Car>
                    {
                        new()
                        {
                            ModelName = "4 series", ManufacturerName = "BMW",
                            CarGroupId = 1, Image = "BMW4.jpeg"
                        },
                        new()
                        {
                            ModelName = "A6", ManufacturerName = "Audi",
                            CarGroupId = 2, Image = "AudiA6.jpeg"
                        },
                        new()
                        {
                            ModelName = "Passat", ManufacturerName = "Volkswagen",
                            CarGroupId = 3, Image = "VWPassat.jpeg"
                        },
                        new()
                        {
                            ModelName = "SL", ManufacturerName = "Mercedes-Benz",
                            CarGroupId = 4, Image = "MBSL.jpeg"
                        },
                        new()
                        {
                            ModelName = "Civic", ManufacturerName = "Honda",
                            CarGroupId = 5, Image = "HondaCivic.jpeg"
                        }
                    });
                await context.SaveChangesAsync();
            }
        }
    }
}