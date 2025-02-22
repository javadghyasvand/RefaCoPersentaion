using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Shop_Framework.Application.SMS
{
    public interface ISmsService
    {
        void Send(string number, string message);
    }
}
