using Aula4.Models;
using System.Linq;

namespace Aula4.Data
{
    public class DbInitializer
    {
        public static void Initialize(Aula4Context context)
        {
            context.Database.EnsureCreated();

            // Look for any categories
            if (context.Category.Any())
            {
                return; // DB has been seeded
            }

            var categories = new Category[]
            {
                new Category {Name="Programming", Description="Algorithms and programming area courses", Date=new(2022, 4, 1, 10, 0, 0), State=true},
                new Category {Name="Administration", Description="Public administration and business management courses", Date=new(2022, 1, 1, 9, 30, 0), State=true},
                new Category {Name="Communication", Description="Business and institutional communication courses", State=true}
            };
            foreach (var category in categories)
            {
                context.Category.Add(category);
            }
            context.SaveChanges();

            var courses = new Course[]
            {
                new Course
                {
                    Name = "Web Engineering",
                    Description = "Creating new sites using ASP.NET.",
                    Cost = 50,
                    Credits = 6,
                    CategoryId = categories.Single(categories => categories.Name == "Programming").Id
                },
                new Course
                {
                    Name = "Strategic Leadership and Management",
                    Description = "Leadership and Business Skill for Immediate Impact.",
                    Cost = 100,
                    Credits = 6,
                    CategoryId = categories.Single(categories => categories.Name == "Administration").Id
                },
                new Course
                {
                    Name = "Master in Corporate Communication",
                    Description = "This Master in Corporate Communication will provide the required skills to organize a Communication Department.",
                    Cost = 80,
                    Credits = 10,
                    CategoryId = categories.Single(categories => categories.Name == "Communication").Id
                }
            };

            context.Course.AddRange(courses);
            context.SaveChanges();
        }
    }
}
