using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Shop_Framework.Domain
{
    public class EntityBase
    {
        public long Id { get; set; }
        public DateTime CreationDateTime { get; set; }

        public EntityBase()
        {
            CreationDateTime = DateTime.Now;
        }
    }
}
