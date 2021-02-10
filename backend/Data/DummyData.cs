using System.Collections.Generic;
using System.Linq;
using backend.Data;
using backend.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace backend.Data
{
    public class DummyData
    {
        public static void Initialize(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<SocialNetworkContext>();
                context.Database.EnsureCreated();
                //context.Database.Migrate();

                // Look for any ailments
                if (context.People != null && context.People.Any())
                    return;   // DB has already been seeded

                var people = DummyData.GetPeople().ToArray();
                context.People.AddRange(people);
                context.SaveChanges();
            }
        }

        public static List<Person> GetPeople()
        {
            List<Person> people = new List<Person>() {
            new Person {Name="Pedro"},
            new Person {Name="Viviane"},
            };
            return people;
        }
    }

}