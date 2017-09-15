using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using BackEndCapstone.Models;
using System.Threading.Tasks;

namespace BackEndCapstone.Data
{
    public static class DbInitializer 
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {

            using (var context = new ApplicationDbContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                // Look for any services.
                if (context.AppointmentService.Any())
                {
                    return;   // DB has been seeded
                }

                if (context.Appointment.Any())
                {
                    return;   // DB has been seeded
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