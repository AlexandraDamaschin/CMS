namespace CMS.Migrations.ApplicationUsers
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CMS.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\ApplicationUsers";
        }

        protected override void Seed(CMS.Models.ApplicationDbContext context)
        {
            var manager =
          new UserManager<ApplicationUser>(
              new UserStore<ApplicationUser>(context));

            var roleManager =
                new RoleManager<IdentityRole>(
                    new RoleStore<IdentityRole>(context));

            roleManager.Create(new IdentityRole { Name = "SuperAdmin" });
            roleManager.Create(new IdentityRole { Name = "Administration" });
            roleManager.Create(new IdentityRole { Name = "User" });


            context.Users.AddOrUpdate(u => u.Email, new ApplicationUser
            {
                Email = "S12345678@mail.itsligo.ie",
                EmailConfirmed = true,
                UserName = "S12345678@mail.itsligo.ie",
                PasswordHash = new PasswordHasher().HashPassword("Ss1234567$1"),
                SecurityStamp = Guid.NewGuid().ToString(),
            });
            context.SaveChanges();

            context.Users.AddOrUpdate(u => u.Email, new ApplicationUser
            {
                Email = "S00000001@mail.itsligo.ie",
                EmailConfirmed = true,
                UserName = "S00000001@mail.itsligo.ie",
                PasswordHash = new PasswordHasher().HashPassword("SS00000001$1"),
                SecurityStamp = Guid.NewGuid().ToString(),
            });
            context.SaveChanges();

            context.Users.AddOrUpdate(u => u.Email, new ApplicationUser
            {
                Email = "S00001111@mail.itsligo.ie",
                EmailConfirmed = true,
                UserName = "S00001111@mail.itsligo.ie",
                PasswordHash = new PasswordHasher().HashPassword("SS00001111$1"),
                SecurityStamp = Guid.NewGuid().ToString(),
            });
            context.SaveChanges();
            ApplicationUser SuperAdmin = manager.FindByEmail("S12345678@mail.itsligo.ie");
            if (SuperAdmin != null)
            {
                manager.AddToRoles(SuperAdmin.Id, new string[] { "SuperAdmin" });
            }
            else
            {
                throw new Exception { Source = "Did not find user" };
            }

            ApplicationUser Administration = manager.FindByEmail("S00000001@mail.itsligo.ie");
            if (manager.FindByEmail("S00000001@mail.itsligo.ie") != null)
            {
                manager.AddToRoles(Administration.Id, new string[] { "Administration" });
            }

            ApplicationUser User = manager.FindByEmail("S00001111@mail.itsligo.ie");
            if (manager.FindByEmail("S00001111@mail.itsligo.ie") != null)
            {
                manager.AddToRoles(User.Id, new string[] { "User" });
            }
        }
    }
}
