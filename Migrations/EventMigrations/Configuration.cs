namespace ZenithWebSite.Migrations.EventMigrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using Models.Entity;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ZenithWebSite.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\EventMigrations";
            
        }

        //protected override void Seed(ZenithWebSite.Models.ApplicationDbContext context)
        //{
        //    context.Activity.AddOrUpdate(a => a.activityId, getActivities());
        //    context.SaveChanges();

        //    context.Event.AddOrUpdate(e => e.eventId, getEvents());
        //    context.SaveChanges();
        //}

        //private Event[] getEvents()
        //{
        //    var events = new List<Event>
        //    {
        //       new Event() { eventFrom=new DateTime(2017,2,1,15,30,00), eventTo=new DateTime(2017,2,1,16,30,00), createEvent=new DateTime(2017,1,18), isActive=true, activityId=1  },
        //       new Event() { eventFrom=new DateTime(2017,2,4,12,30,00), eventTo=new DateTime(2017,2,4,13,30,00), createEvent=new DateTime(2017,1,12), isActive=true, activityId=2 },
        //       new Event() { eventFrom=new DateTime(2017,2,5,11,30,00), eventTo=new DateTime(2017,2,5,14,30,00),  createEvent=new DateTime(2017,1,30), isActive=false, activityId=3  },
        //       new Event() { eventFrom=new DateTime(2017,2,5,18,30,00), eventTo=new DateTime(2017,2,5,20,30,00), createEvent=new DateTime(2017,1,14), isActive=false, activityId=4  },
        //       new Event() { eventFrom=new DateTime(2017,2,6,15,30,00), eventTo=new DateTime(2017,2,6,16,30,00), createEvent=new DateTime(2017,1,18), isActive=true, activityId=5  },
        //       new Event() { eventFrom=new DateTime(2017,2,7,15,30,00), eventTo=new DateTime(2017,2,7,16,30,00), createEvent=new DateTime(2016,12,17), isActive=false, activityId=6 },
        //       new Event() { eventFrom=new DateTime(2017,2,8,15,30,00), eventTo=new DateTime(2017,2,8,16,30,00), createEvent=new DateTime(2017,1,10), isActive=true, activityId=4  },
        //       new Event() { eventFrom=new DateTime(2017,2,10,10,30,00), eventTo=new DateTime(2017,2,10,14,30,00), createEvent=new DateTime(2017,1,6), isActive=false, activityId=5  },
        //       new Event() { eventFrom=new DateTime(2017,2,12,10,30,00), eventTo=new DateTime(2017,2,12,14,30,00), createEvent=new DateTime(2017,1,6), isActive=false, activityId=6  },
        //       new Event() { eventFrom=new DateTime(2017,2,14,10,30,00), eventTo=new DateTime(2017,2,14,14,30,00), createEvent=new DateTime(2017,1,6), isActive=false, activityId=2  },


        //    };
        //    return events.ToArray();
        //}

        //private Activity[] getActivities()
        //{
        //    var activities = new List<Activity>
        //    {
        //       new Activity() { description="Seniors  Golf Tournament", createActivity=new DateTime(2016,12,6) },
        //       new Activity() { description="Leadership General Assembly Meeting", createActivity=new DateTime(2016,12,3) },
        //       new Activity() { description="Youth Bowling Tournament", createActivity=new DateTime(2016,11,20) },
        //       new Activity() { description="Young ladies cooking lessons", createActivity=new DateTime(2016,10,4) },
        //       new Activity() { description="Pancake Breakfast", createActivity=new DateTime(2016,10,17) },
        //       new Activity() { description="Swimming Exercise for parents", createActivity=new DateTime(2016,11,25) },
        //    };
        //    return activities.ToArray();
        //}



         protected override void Seed(ZenithWebSite.Models.ApplicationDbContext context)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            if (!roleManager.RoleExists("Admin"))
                roleManager.Create(new IdentityRole("Admin"));

            if (!roleManager.RoleExists("Member"))
                roleManager.Create(new IdentityRole("Member"));

            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            // Add a user with email & uid of a@a.a then add to admin role
            if (userManager.FindByName("a") == null)
            {
                var user = new ApplicationUser
                {
                    Email = "a@a.a",
                    UserName = "a",
                };
                var result = userManager.Create(user, "P@$$w0rd");
                if (result.Succeeded)
                    userManager.AddToRole(userManager.FindByName(user.UserName).Id, "Admin");
            }

            // Add a user with email & uid of m@m.m then add to member role
            if (userManager.FindByName("m@m.m") == null)
            {
                var user = new ApplicationUser
                {
                    Email = "m@m.m",
                    UserName = "m",
                };
                var result = userManager.Create(user, "P@$$w0rd");
                if (result.Succeeded)
                    userManager.AddToRole(userManager.FindByName(user.UserName).Id, "Member");
            }
        }



    }
}
