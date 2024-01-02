using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Notice
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int SendFromUserID { get; set; }
        [Required]
        public int SendToUserID { get; set; }
        [Required]
        public string Status { get; set; }
        

    }
}
