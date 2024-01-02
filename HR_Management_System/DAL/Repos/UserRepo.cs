using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class UserRepo : Repo, IRepo<User, int, User>, IAuth<bool>, IFilter<User, String>, IUserOrganization<User, int>
    {
        public bool Authenticate(string email, string password)
        {
            var data = db.Users.FirstOrDefault(u => u.Email.Equals(email) &&
            u.Password.Equals(password));
            if (data != null) return true;
            return false;
        }

        public User Create(User obj)
        {
            db.Users.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(int id)
        {
            var ex = Read(id);
            db.Users.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<User> FilterWithType(string obj)
        {
            return db.Users
            .Where(u => u.Authorizations.Any(a => a.Role == obj))
            .ToList();
        }

        public User FilterWithTypeSingle(string obj)
        {
            throw new NotImplementedException();
        }

        public List<User> GetAllUserBasedOnOrganization(int obj)
        {

            return db.Users
            .Where(u => u.UserOrganizationTables.Any(a => a.OrganizationID == obj))
            .Include(u => u.UserJobTables.Select(ujt => ujt.JobCategories))
            .ToList();

        }

        public User GetUser(string email)
        {
            return db.Users.FirstOrDefault(t => t.Email.Equals(email));
        }

        public List<User> Read()
        {
            return db.Users.ToList();
        }

        public User Read(int id)
        {
            return db.Users.Find(id);
        }

        public User Update(User obj)
        {
            var ex = Read(obj.Id);
            db.Entry(ex).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }
    }
}
