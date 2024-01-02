using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class AuthorizationRepo : Repo, IRepo<Authorization, int, Authorization>
    {

        public Authorization Create(Authorization obj)
        {
            db.Authorization.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(int id)
        {
            var ex = Read(id);
            db.Authorization.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<Authorization> Read()
        {
            return db.Authorization.ToList();
        }

        public Authorization Read(int id)
        {
            return db.Authorization.Find(id);
        }

        public Authorization Update(Authorization obj)
        {
            var ex = Read(obj.Id);
            db.Entry(ex).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }
    }
}
