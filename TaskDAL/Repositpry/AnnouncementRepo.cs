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
        public override List<Announcement> GetAll()
        {
            return Context.Announcements.OrderBy(x => x.Id).ToList();
        }
    }
    
}
