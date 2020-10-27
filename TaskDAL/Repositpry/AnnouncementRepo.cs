using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Models;

namespace TaskDAL.Repositpry
{
    public class AnnouncementRepo :BaseRepo<Announcement>, IRepository<Announcement>
    {
        public List<Announcement> GetNotAll(int id)
        {
            return (Context.Announcements.Where(c => c.Id == id).ToList());
        }
    }
    
}
