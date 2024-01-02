using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class JobRequirmentsDTO
    {
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
        public int JobCategoryId { get; set; }
        public int OrgID { get; set; }
    }
}
