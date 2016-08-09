namespace Talker.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Talker.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;


    internal sealed class Configuration : DbMigrationsConfiguration<Talker.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Talker.Models.ApplicationDbContext";
        }

        bool AddUserAndRole(Talker.Models.ApplicationDbContext context)
        {
            IdentityResult ir;
            var rm = new RoleManager<IdentityRole>
                (new RoleStore<IdentityRole>(context));
            ir = rm.Create(new IdentityRole("canEdit"));
            var um = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(context));
            var user = new ApplicationUser()
            {
                UserName = "user1@talker.com",
            };
            ir = um.Create(user, "P_assw0rd1");
            if (ir.Succeeded == false)
                return ir.Succeeded;
            ir = um.AddToRole(user.Id, "canEdit");
            return ir.Succeeded;
        }

        protected override void Seed(Talker.Models.ApplicationDbContext context)
        {
            AddUserAndRole(context);
            context.Talks.AddOrUpdate(p => p.TalkContent,
                new Talk
                {
                    TalkContent = "My first talk post",
                    timestamp = DateTime.Now.ToString(),
                    //User = context.Users.Single(u => u.UserName == "user1@talker.com"),
                }


                );
        
           
        }
    }
}
