using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Organization
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string PhoneNumber { get; set;}
        [Required]
        public string Password { get; set; }

        public virtual ICollection<JobCategories> JobCategories { get; set; }
        public virtual ICollection<UserOrganizationTable> UserOrganizationTables { get; set; }

        public Organization()
        {
            JobCategories = new List<JobCategories>();
            UserOrganizationTables = new List<UserOrganizationTable>();
        }
    }
}
