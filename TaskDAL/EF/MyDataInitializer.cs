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
                new Announcement {Title = "Dave", Description = "BrenneBrenner Brenne BrenneBrenner BrenneBrenneBrenner Brenne BrenneBrenner BrenneBrenneBrenner Brenne BrenneBrenner Brenne",DateAdded = new DateTime(2015, 7, 20, 12, 35, 22) },
                new Announcement {Title = "Matt", Description = "Walton",DateAdded = new DateTime(2011, 3, 2, 18, 30, 25)},
                new Announcement {Title = "Steve", Description = "Hagen",DateAdded = new DateTime(2008, 5, 10, 18, 30, 25)},
                new Announcement {Title = "Pat", Description = "Walton",DateAdded = new DateTime(2018, 7, 11, 18, 30, 25)},
                new Announcement {Title = "asdasd Pat", Description = "",DateAdded = new DateTime(2018, 7, 11, 18, 30, 25)},
                new Announcement {Title = "Pat Pat", Description = "",DateAdded = new DateTime(2018, 7, 11, 18, 30, 25)},
                new Announcement {Title = "Bad", Description = "Customer",DateAdded = new DateTime(2025, 7, 7, 18, 30, 25)},
            };
            announ.ForEach(x => context.Announcements.AddOrUpdate(
                c => new { c.Title, c.Description }, x));
        }
    }
}
