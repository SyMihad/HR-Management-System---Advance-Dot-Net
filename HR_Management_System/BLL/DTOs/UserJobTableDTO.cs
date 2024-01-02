using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class UserJobTableDTO
    {
        public int Id { get; set; }
        public int UserID { get; set; }
        public int JobCategoryID { get; set; }
    }
}
