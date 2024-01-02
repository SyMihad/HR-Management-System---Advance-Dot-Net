using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class JobCategoryRepo : Repo, IRepo<JobCategories, int, JobCategories>, IFilter<JobCategories, string>
    {

        public JobCategories Create(JobCategories obj)
        {
            db.JobCategories.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(int id)
        {
            var ex = Read(id);
            db.JobCategories.Remove(ex);
            return db.SaveChanges() > 0;
        }
        

        public List<JobCategories> Read()
        {
            return db.JobCategories.ToList();
        }

        public JobCategories Read(int id)
        {
            return db.JobCategories.Find(id);
        }

        public JobCategories Update(JobCategories obj)
        {
            var ex = Read(obj.Id);
            db.Entry(ex).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public List<JobCategories> FilterWithType(string obj)
        {
            throw new NotImplementedException();
        }

        public JobCategories FilterWithTypeSingle(string obj)
        {
            var jobCat = db.JobCategories
            .SingleOrDefault(jc => jc.Name == obj);
            return jobCat;
        }
    }
}
