using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Shop_Framework.Infrastructure
{
    public interface IPermissionsExpose
    {
        Dictionary<string,List<PermissionsDto>> Expose();
    }
}
