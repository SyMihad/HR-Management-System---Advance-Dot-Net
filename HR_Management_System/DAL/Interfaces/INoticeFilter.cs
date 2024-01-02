using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface INoticeFilter<TYPE, PARAM>
    {
        List<TYPE> ViewAll(PARAM obj);
        List<TYPE> TrackAll(PARAM obj);
    }
}
