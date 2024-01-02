using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public DateTime DOB { get; set; }
        [Required]
        public string PhoneNum { get; set; }

        public virtual ICollection<Authorization> Authorizations { get; set; }
        public virtual ICollection<UserOrganizationTable> UserOrganizationTables { get; set; }
        public virtual ICollection<UserJobTable> UserJobTables { get; set; }

        public User()
        {
            Authorizations = new List<Authorization>();
            UserOrganizationTables = new List<UserOrganizationTable>();
            UserJobTables = new List<UserJobTable>();
        }

    }
}
