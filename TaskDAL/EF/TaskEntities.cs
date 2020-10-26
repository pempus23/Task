using Task.Models;
using System.Data.Entity;

namespace TaskDAL.EF
{
    public class TaskEntities : DbContext
    {
        public TaskEntities()
           : base("AutoConnection")
        {
           
        }

        public virtual DbSet<Announcement> Announcements { get; set; }

    }
}
