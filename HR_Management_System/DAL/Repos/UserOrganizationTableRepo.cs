using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class UserOrganizationTableRepo : Repo, IRepo<UserOrganizationTable, int, UserOrganizationTable>
    {
        public UserOrganizationTable Create(UserOrganizationTable obj)
        {
            db.UserOrganizationTable.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(int id)
        {
            var ex = Read(id);
            db.UserOrganizationTable.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<UserOrganizationTable> Read()
        {
            return db.UserOrganizationTable.ToList();
        }

        public UserOrganizationTable Read(int id)
        {
            return db.UserOrganizationTable.Find(id);
        }

        public UserOrganizationTable Update(UserOrganizationTable obj)
        {
            var ex = Read(obj.Id);
            db.Entry(ex).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }
    }
}
