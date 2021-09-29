using Microsoft.EntityFrameworkCore;
using RestWithASPNETUdemy.Model.Base;
using RestWithASPNETUdemy.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNETUdemy.Repository.Generic
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        private SqlServerContext _context;

        private  DbSet<T> dataset;

        public GenericRepository(SqlServerContext context)
        {
            _context = context;
            dataset = _context.Set<T>();
        }

        public T Create(T item)
        {
            this.dataset.Add(item);
            this._context.SaveChanges();
            return item;
        }

        public void Delete(long id)
        {
            var dt = this.dataset.Where(o => o.Id == id).FirstOrDefault();
            this.dataset.Remove(dt);
            this._context.SaveChanges();
        }

        public List<T> FindAll()
        {
            return dataset.ToList();
        }

        public T FindByID(long id)
        {
            return dataset.Where(o => o.Id == id).FirstOrDefault();
        }

        public T Update(T item)
        {
            this.dataset.Update(item);
            this._context.SaveChanges();
            return item;
        }
    }
}
