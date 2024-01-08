using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class EncryptionTableRepo : Repo, IRepo<EncryptionTable, int, EncryptionTable>
    {
        public EncryptionTable Create(EncryptionTable obj)
        {
            db.EncryptionTable.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(int id)
        {
            var ex = Read(id);
            db.EncryptionTable.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<EncryptionTable> Read()
        {
            return db.EncryptionTable.ToList();
        }

        public EncryptionTable Read(int id)
        {
            return db.EncryptionTable.Find(id);
        }

        public EncryptionTable Update(EncryptionTable obj)
        {
            var ex = Read(obj.Id);
            db.Entry(ex).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }
    }
}
