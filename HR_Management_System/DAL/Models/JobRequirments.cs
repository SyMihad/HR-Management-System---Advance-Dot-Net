using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DAL.Models
{
    public class JobRequirments
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime SubmissionDate { get; set; }
        [Required]
        public DateTime CloseDate { get; set; }
        [Required]
        public string Status { get; set; }
        [ForeignKey("JobCategories")]
        public int JobCategoryId { get; set; }
        
        
        public int OrgID { get; set; }

        public virtual JobCategories JobCategories { get; set; }
       
    }
}
