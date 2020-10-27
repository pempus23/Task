using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Models;

namespace TaskDAL.EF
{
    public class MyDataInitializer : DropCreateDatabaseAlways<TaskEntities>
    {
        protected override void Seed(TaskEntities context)
        {
            var announ = new List<Announcement>
            {
                new Announcement {Title = "Dave", Description = "Brenner"},
                new Announcement {Title = "Matt", Description = "Walton"},
                new Announcement {Title = "Steve", Description = "Hagen"},
                new Announcement {Title = "Pat", Description = "Walton"},
                new Announcement {Title = "Bad", Description = "Customer"},
            };
            announ.ForEach(x => context.Announcements.AddOrUpdate(
                c => new { c.Title, c.Description }, x));
        }
    }
}
