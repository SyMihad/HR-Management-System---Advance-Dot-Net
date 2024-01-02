using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class OrganizationRepo : Repo, IRepo<Organization, int, Organization>
    {
        public Organization Create(Organization obj)
        {
            db.Organizations.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(int id)
        {
            var ex = Read(id);
            db.Organizations.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<Organization> Read()
        {
            return db.Organizations.ToList();
        }

        public Organization Read(int id)
        {
            return db.Organizations.Find(id);
        }

        public Organization Update(Organization obj)
        {
            var ex = Read(obj.Id);
            db.Entry(ex).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }
    }
}
