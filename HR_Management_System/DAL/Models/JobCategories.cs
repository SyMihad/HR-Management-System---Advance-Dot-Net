﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class JobCategories
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [ForeignKey("Organization")]
        public int OrganizationID { get; set; }

        public virtual Organization Organization { get; set; }
        public virtual ICollection<UserJobTable> UserJobTables { get; set; }
        public virtual ICollection<JobRequirments> JobRequirments { get; set; }

        public JobCategories()
        {
            UserJobTables = new List<UserJobTable>();
            JobRequirments = new List<JobRequirments>();
        }
    }
}
