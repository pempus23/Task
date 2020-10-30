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

        public override List<Announcement> Similar(int? id)
        {
            List<Announcement> list = new List<Announcement>();
            List<Announcement> similar = new List<Announcement>();

            Announcement str = new Announcement();
            str = Context.Announcements.Find(id);
            string[] words = str.Title.Split(new char[] {' '});

            list.AddRange(GetAll());

            foreach (var item in list)
            {
                foreach (var i in words) 
                {
                    if (item.Title.Contains(i))
                    {
                        if (!similar.Any(x => x.Id == item.Id))
                        {          
                            similar.Add(item);
                        }
                    }
                }
            }
            similar.Remove(str);

            return (similar);
        }
    }
    
}
