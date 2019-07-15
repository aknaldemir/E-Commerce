using App.MvcWebUI.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace App.MvcWebUI.Identity
{
    public class IdentityInitializer : DropCreateDatabaseIfModelChanges<IdentityDataContext>
    {
        protected override void Seed(IdentityDataContext context)
        {
            //roller
            if (!context.Roles.Any(i=>i.Name=="admin"))//admin adında rol yok ise
            {
                var store = new RoleStore<ApplicationRole>(context);
                var manager =new RoleManager<ApplicationRole>(store);

                var role = new ApplicationRole() { Name="admin",Description="Admin rolü"};
                manager.Create(role);
            }

            if (!context.Roles.Any(i=>i.Name=="user"))//admin adında rol yok ise
            {
                var store = new RoleStore<ApplicationRole>(context);
                var manager =new RoleManager<ApplicationRole>(store);

                var role = new ApplicationRole() { Name = "user", Description = "user rolü" };
                manager.Create(role);
            }

            if (!context.Roles.Any(i => i.Name == "akinaldemir"))//admin adında rol yok ise
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);

                var user = new ApplicationUser() {
                    Name="Akın",
                    Surname="Aldemir",
                    Email="aknaldemir@gmail.com",
                    UserName="akinaldemir"

                };
                manager.Create(user,"1234567");
                manager.AddToRole(user.Id, "admin");
                manager.AddToRole(user.Id, "user");

            }

            if (!context.Roles.Any(i => i.Name == "tolgaaldemir"))//admin adında rol yok ise
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);

                var user = new ApplicationUser()
                {
                    Name = "Tolga",
                    Surname = "Aldemir",
                    Email = "tolgaaldemir@gmail.com",
                    UserName="tolgaaldemir"

                };
                manager.Create(user, "1234567");               
                manager.AddToRole(user.Id, "user");

            }






            //user
            base.Seed(context);
        }
    }
}