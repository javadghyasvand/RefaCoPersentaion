using System;

namespace My_Shop_Framework.Infrastructure
{
    public class NeedPermissionAttribute:Attribute
    {
        public long Permission { get; set; }

        public NeedPermissionAttribute(long permission)
        {
            Permission = permission;
        }
    }
}