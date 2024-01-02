using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class UserJobTableRepo : Repo, IRepo<UserJobTable, int, UserJobTable>
    {
        public UserJobTable Create(UserJobTable obj)
        {
            db.UserJobTable.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(int id)
        {
            var ex = Read(id);
            db.UserJobTable.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<UserJobTable> Read()
        {
            return db.UserJobTable.ToList();
        }

        public UserJobTable Read(int id)
        {
            return db.UserJobTable.Find(id);
        }

        public UserJobTable Update(UserJobTable obj)
        {
            var ex = Read(obj.Id);
            db.Entry(ex).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }
    }
}
