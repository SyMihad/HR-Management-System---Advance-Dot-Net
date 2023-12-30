using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class UserOrganizationTable
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("User")]
        public int UserID { get; set; }
        [ForeignKey("Organization")]
        public int OrganizationID { get; set; }

        public virtual User User { get; set; }
        public virtual Organization Organization { get; set; }
    }
}
