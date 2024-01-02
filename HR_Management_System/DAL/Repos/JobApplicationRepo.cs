using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class JobApplicationRepo : Repo, IRepo<JobApplications, int, JobApplications>, IFilter<JobApplications, string>
    {
        public JobApplications Create(JobApplications obj)
        {
            db.JobApplications.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(int id)
        {
            var ex = Read(id);
            db.JobApplications.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<JobApplications> FilterWithType(string obj)
        {
            return db.JobApplications
            .Where(j => j.Status == obj)
            .ToList();
        }

        public JobApplications FilterWithTypeSingle(string obj)
        {
            throw new NotImplementedException();
        }

        public List<JobApplications> Read()
        {
            return db.JobApplications.ToList();
        }

        public JobApplications Read(int id)
        {
            return db.JobApplications.Find(id);
        }

        public JobApplications Update(JobApplications obj)
        {
            var ex = Read(obj.Id);
            db.Entry(ex).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }
    }
}
