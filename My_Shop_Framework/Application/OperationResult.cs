using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Shop_Framework.Application
{
    public class OperationResult
    {
        public bool IsSuccess { get; set; }
        public string Massage { get; set; }

        public OperationResult()
        {
            IsSuccess = false;
        }
        public OperationResult Success(string message = "عملیات با موفقیت انجام شد.")
        {
            IsSuccess = true;
            Massage = message;
            return this;
        }

        public OperationResult Failed(string message= "عملیات با  نا موفقیت.")
        {
            IsSuccess = false;
            Massage = message;
            return this;
        }
        public OperationResult NotValid(string message = "اطلاعات به درستی وارد نشد مجددا تلاش نمایید.")
        {
            IsSuccess = false;
            Massage = message;
            return this;
        }
    }
}
