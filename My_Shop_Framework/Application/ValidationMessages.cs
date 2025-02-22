using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Shop_Framework.Application
{
    public  class ValidationMessages
    {
        public const string IsRequired = "مقدار این فیلد نمی تواند خالی باشد.";
        public const string MaxFileSize = "حجم فایل مجاز 1mb  می باشد.";
        public const string InvalidFileFormatImage = "فرمت فایل مجاز نیست (jpeg,png,webp,jpg)";
        public const string PhoneNumber = "شماره تلفن را به درستی وارد کنید وارد کنید";
        public const string Email = "ایمیل را به درستی وارد کنید وارد کنید";
        public const string Link = "لینک را به درستی وارد کنید وارد کنید";
        public const string ReturnPageFail = "لطفا اطلاعات وارد شده را بررسی نمایید";
    }
}
