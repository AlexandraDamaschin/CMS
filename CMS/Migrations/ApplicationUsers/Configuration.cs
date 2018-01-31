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
                Email = "super-admin@sallinet.ie",
                EmailConfirmed = true,
                UserName = "super-admin@sallinet.ie",
                PasswordHash = new PasswordHasher().HashPassword("LetMeIn"),
                SecurityStamp = Guid.NewGuid().ToString(),
            });
            context.SaveChanges();

            context.Users.AddOrUpdate(u => u.Email, new ApplicationUser
            {
                Email = "tourist-office@sligotourism.ie",
                EmailConfirmed = true,
                UserName = "tourist-office@sligotourism.ie",
                PasswordHash = new PasswordHasher().HashPassword("LetMeIn"),
                SecurityStamp = Guid.NewGuid().ToString(),
            });
            context.SaveChanges();

            context.Users.AddOrUpdate(u => u.Email, new ApplicationUser
            {
                Email = "coordinator@roscommon-taxidermists.ie",
                EmailConfirmed = true,
                UserName = "coordinator@roscommon-taxidermists.ie",
                PasswordHash = new PasswordHasher().HashPassword("LetMeIn"),
                SecurityStamp = Guid.NewGuid().ToString(),
            });
            context.SaveChanges();
            ApplicationUser SuperAdmin = manager.FindByEmail("super-admin@sallinet.ie");
            if (SuperAdmin != null)
            {
                manager.AddToRoles(SuperAdmin.Id, new string[] { "SuperAdmin" });
            }
            else
            {
                throw new Exception { Source = "Did not find user" };
            }

            ApplicationUser Administration = manager.FindByEmail("tourist-office@sligotourism.ie");
            if (manager.FindByEmail("tourist-office@sligotourism.ie") != null)
            {
                manager.AddToRoles(Administration.Id, new string[] { "Administration" });
            }

            ApplicationUser User = manager.FindByEmail("coordinator@roscommon-taxidermists.ie");
            if (manager.FindByEmail("coordinator@roscommon-taxidermists.ie") != null)
            {
                manager.AddToRoles(User.Id, new string[] { "User" });
            }
        }
    }
}