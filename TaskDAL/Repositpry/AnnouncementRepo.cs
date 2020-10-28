using System;
using System.Collections.Generic;
using System.Data.Entity;
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
        public override int Add(Announcement entity)
        {
            entity.DateAdded = DateTime.Now;
            Context.Entry(entity).State = EntityState.Added;
            return SaveChanges();
        }
        public override int Save(Announcement entity)
        {
            entity.DateAdded = DateTime.Now;
            Context.Entry(entity).State = EntityState.Modified;
            return SaveChanges();
        }
    }
    
}
