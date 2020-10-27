using AutoLotDAL.Models.Base;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using Task.Models;
using TaskDAL.EF;

namespace TaskDAL.Repositpry
{
    public class BaseRepo<T> : IRepository<T> where T : EntityBase, new()
    {
        protected readonly DbSet<T> _table;
        private readonly TaskEntities _db;
        protected TaskEntities Context => _db;
        public BaseRepo()
        {
            _db = new TaskEntities();
            _table = _db.Set<T>();
        }
        public int Add(T entity)
        {
            _table.Add(entity);
            return SaveChanges();
        }

        public int Delete(int id)
        {
            Announcement ann = Context.Announcements.FirstOrDefault(row => row.Id == id);
            Context.Announcements.Remove(ann);
            return SaveChanges();
        }

        public void Dispose()
        {
            _db?.Dispose();
        }

        public virtual List<T> GetAll()
            => _table.ToList();
            
        

        public T GetOne(int? id)
            => _table.Find(id);

        public int Save(T entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
            return SaveChanges();
        }
        internal int SaveChanges()
        {
            try
            {
                return _db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw;
            }
            catch (DbUpdateException ex)
            {
                throw;
            }
            catch (CommitFailedException ex)
            {

                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
