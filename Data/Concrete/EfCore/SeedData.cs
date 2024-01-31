using BlogApp.Entity;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Data.Concrete.EfCore
{
    public static class SeedData
    {
        public static void TestDatalariDoldur(IApplicationBuilder app)
        {
            var context = app.ApplicationServices.CreateScope().ServiceProvider.GetService<BlogContext>();

            if(context != null)
            {
                if(context.Database.GetPendingMigrations().Any())
                {
                    context.Database.Migrate();
                }

                if(!context.Tags.Any())
                {
                    context.Tags.AddRange(
                        new Tag { Text = "Web Proqramlama", Url="web-programming", Color= TagColors.danger},
                        new Tag { Text = "Backend", Url="Backend", Color= TagColors.info},
                        new Tag { Text = "Frontend", Url="Frontend", Color= TagColors.secondary},
                        new Tag { Text = "Full Stack", Url="fullstack", Color= TagColors.warning},
                        new Tag { Text = "PHP", Url="php", Color= TagColors.primary}
                    );
                    context.SaveChanges();
                }

                if(!context.Users.Any())
                {
                    context.Users.AddRange(
                        new User {UserName = "Kenan Bayram", Image="p1.jpg"},
                        new User {UserName = "Kamal Allahverdizade", Image="p2.jpg"}
                    );
                    context.SaveChanges();
                }


                if(!context.Posts.Any())
                {
                    context.Posts.AddRange(
                        new Post {
                            Title = "Asp.net Core",
                            Content = "Asp.net core dersleri",
                            Url = "aspnet-core",
                            IsActive = true,
                            PublishedOn = DateTime.Now.AddDays(-10),
                            Tags = context.Tags.Take(3).ToList(),
                            Image = "1.jpg",
                            UserId = 1,
                            Comments = new List<Comment>{ 
                                new Comment {Text = "Cox gozel Resmdir", PublishedOn= new DateTime(), UserId = 1},
                                new Comment{ Text = "Mende bele cekirem!", PublishedOn=new DateTime(), UserId = 2}}
                        },
                        new Post {
                            Title = "PHP",
                            Content = "PHP dersleri",
                            Url = "php",
                            IsActive = true,
                            PublishedOn = DateTime.Now.AddDays(-5),
                            Tags = context.Tags.Take(5).ToList(),
                            Image = "2.jpg",
                            UserId = 2
                        },  
                        new Post {
                            Title = "Django/Python",
                            Content = "Django/python dersleri",
                            Url = "django",
                            IsActive = true,
                            PublishedOn = DateTime.Now.AddDays(-20),
                            Tags = context.Tags.Take(5).ToList(),
                            Image = "3.jpg",
                            UserId = 2
                        }
                    );
                }
                context.SaveChanges();
            }
        }
    }
}