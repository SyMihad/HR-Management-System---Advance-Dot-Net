using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class JobRequirmentsRepo : Repo, IRepo<JobRequirments, int, JobRequirments>, IFilter<JobRequirments, int>
    {
        public JobRequirments Create(JobRequirments obj)
        {
            db.JobRequirments.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(int id)
        {
            var ex = Read(id);
            db.JobRequirments.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<JobRequirments> FilterWithType(int obj)
        {
            return db.JobRequirments
            .Where(j => j.OrgID == obj)
            .ToList();
        }

        public JobRequirments FilterWithTypeSingle(int obj)
        {
            throw new NotImplementedException();
        }

        public List<JobRequirments> Read()
        {
            return db.JobRequirments.ToList();
        }

        public JobRequirments Read(int id)
        {
            return db.JobRequirments.Find(id);
        }

        public JobRequirments Update(JobRequirments obj)
        {
            var ex = Read(obj.Id);
            db.Entry(ex).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }
    }
}
