using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class NoticeRepo : Repo, IRepo<Notice, int, Notice>, INoticeFilter<Notice, int>
    {
        public Notice Create(Notice obj)
        {
            db.Notice.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(int id)
        {
            var ex = Read(id);
            db.Notice.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<Notice> Read()
        {
            return db.Notice.ToList();
        }

        public Notice Read(int id)
        {
            return db.Notice.Find(id);
        }

        public List<Notice> TrackAll(int obj)
        {
            return db.Notice
            .Where(j => j.SendFromUserID == obj)
            .ToList();
        }

        public Notice Update(Notice obj)
        {
            var ex = Read(obj.Id);
            db.Entry(ex).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public List<Notice> ViewAll(int obj)
        {
            return db.Notice
            .Where(j => j.SendToUserID == obj)
            .ToList();
        }
    }
}
