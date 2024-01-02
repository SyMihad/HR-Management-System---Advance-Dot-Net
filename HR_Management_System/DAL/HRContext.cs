using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    internal class HRContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Authorization> Authorization { get; set; }
        public DbSet<JobCategories> JobCategories { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<UserJobTable> UserJobTable { get; set; }
        public DbSet<UserOrganizationTable> UserOrganizationTable { get; set; }
        public DbSet<JobRequirments> JobRequirments { get; set;}
        public DbSet<JobApplications> JobApplications { get; set; }
        public DbSet<Notice> Notice { get; set; }
        public DbSet<Token> Tokens { get; set; }
    }
}
