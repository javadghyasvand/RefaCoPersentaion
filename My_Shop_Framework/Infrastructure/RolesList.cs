using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Shop_Framework.Infrastructure
{
    public static class RolesList
    {
        public const string Owner = "1";
        //public const string Admin = "4";
        public const string User = "2";
        //public const string ContentUploader = "";
        //public const string WarehouseManager = "6";
        //public const string ColleagueUser = "7";

        public static string GetRoleBy(long id)
        {
            switch (id)
            {
                case 1:
                    return "مدیر سیستم";
                case 3:
                    return "محتوا";
                case 4:
                    return "ادمین";
                case 6:
                    return "مدیر انبار";
                case 8:
                    return "کاربر همکار";
                default:
                    return "کاربر سیستم";
            }
        }
    }
}