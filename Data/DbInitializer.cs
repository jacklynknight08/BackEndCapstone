using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using BackEndCapstone.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace BackEndCapstone.Data
{
    public static class DbInitializer 
    {
        public static async void Initialize(IServiceProvider serviceProvider)
        {

            using (var context = new ApplicationDbContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                var roleStore = new RoleStore<IdentityRole>(context);
                var userStore = new UserStore<ApplicationUser>(context);

                if (!context.Roles.Any(r => r.Name == "Admin"))
                {
                    var role = new IdentityRole { Name = "Admin", NormalizedName = "Admin" };
                    await roleStore.CreateAsync(role);
                }

                if (!context.Roles.Any(r => r.Name == "Client"))
                {
                    var role = new IdentityRole { Name = "Client", NormalizedName = "Client" };
                    await roleStore.CreateAsync(role);
                }

                if (!context.ApplicationUser.Any(u => u.FirstName == "admin"))
                {
                    //  This method will be called after migrating to the latest version.
                    ApplicationUser user = new ApplicationUser {
                        FirstName = "admin",
                        LastName = "admin",
                        UserName = "admin@admin.com",
                        NormalizedUserName = "ADMIN@ADMIN.COM",
                        Email = "admin@admin.com",
                        NormalizedEmail = "ADMIN@ADMIN.COM",
                        EmailConfirmed = true,
                        LockoutEnabled = false,
                        SecurityStamp = Guid.NewGuid().ToString("D")
                    };
                    var passwordHash = new PasswordHasher<ApplicationUser>();
                    user.PasswordHash = passwordHash.HashPassword(user, "admin");
                    await userStore.CreateAsync(user);
                    await userStore.AddToRoleAsync(user, "Admin");
                    await context.SaveChangesAsync();
                }

                if (!context.ApplicationUser.Any(u => u.FirstName == "test"))
                {
                    //  This method will be called after migrating to the latest version.
                    ApplicationUser user = new ApplicationUser {
                        FirstName = "test",
                        LastName = "test",
                        UserName = "test@test.com",
                        NormalizedUserName = "TEST@TEST.COM",
                        Email = "test@test.com",
                        NormalizedEmail = "TEST@TEST.COM",
                        EmailConfirmed = true,
                        LockoutEnabled = false,
                        SecurityStamp = Guid.NewGuid().ToString("D")
                    };
                    var passwordHash = new PasswordHasher<ApplicationUser>();
                    user.PasswordHash = passwordHash.HashPassword(user, "test");
                    await userStore.CreateAsync(user);
                    await userStore.AddToRoleAsync(user, "Client");
                    await context.SaveChangesAsync();
                    }

                //Will Load Services to Seed Databse
                var services = new Service[]
                {
                    new Service { 
                        Name = "Men's Cut",
                        LengthOfService = 30
                    },
                    new Service { 
                        Name = "Women's Cut",
                        LengthOfService = 30
                    },
                    new Service { 
                        Name = "Brow Wax",
                        LengthOfService = 15
                    },
                    new Service { 
                        Name = "Bang Trim",
                        LengthOfService = 15
                    },
                    new Service { 
                        Name = "Beard Trim",
                        LengthOfService = 15
                    },
                    new Service { 
                        Name = "Shampoo",
                        LengthOfService = 15
                    },
                    new Service { 
                        Name = "BlowDry Style",
                        LengthOfService = 30
                    },
                    new Service { 
                        Name = "Shave",
                        LengthOfService = 45
                    },
                    new Service { 
                        Name = "Root Touchup",
                        LengthOfService = 60
                    },
                    new Service { 
                        Name = "Balayage",
                        LengthOfService = 120
                    },
                    new Service { 
                        Name = "Full Highlight",
                        LengthOfService = 120
                    },
                    new Service { 
                        Name = "Partial Highlight",
                        LengthOfService = 90
                    },
                    new Service { 
                        Name = "Full Color",
                        LengthOfService = 90
                    }
                };

                foreach (Service s in services)
                {
                    context.Service.Add(s);
                }
                context.SaveChanges();

                // Load stylists to seed database
                var stylists = new Stylist[]
                {
                    new Stylist { 
                        FirstName = "Jackie",
                        LastName = "Knight"
                    },
                    new Stylist { 
                        FirstName = "Tamela",
                        LastName = "Lerma"
                    },
                    new Stylist { 
                        FirstName = "Kathy",
                        LastName = "Weisensel"
                    },
                    new Stylist { 
                        FirstName = "Madeline",
                        LastName = "Power"
                    },
                    new Stylist { 
                        FirstName = "Eliza",
                        LastName = "Meeks"
                    }
                };
                
                foreach (Stylist t in stylists)
                {
                    context.Stylist.Add(t);
                }
                context.SaveChanges();
            }
        }
    }
}