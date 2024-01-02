using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class UserJobCategoryDTO : UserDTO
    {
        public JobCategoryDTO JobCategory { get; set; }
        public UserJobTableDTO UserJobTable { get; set; }

        public UserJobCategoryDTO()
        {
            JobCategory = new JobCategoryDTO();
            UserJobTable = new UserJobTableDTO();
        }
    }
}
