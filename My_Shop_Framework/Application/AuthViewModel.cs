using System.Collections.Generic;

namespace My_Shop_Framework.Application
{
    public class AuthViewModel
    {
        public  long  Id { get; set; }
        public long RoleId { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Mobile { get; set; }
        public string Role { get; set; }
        public string ProfilePicture { get; set; }
        public List<long> Permissions { get; set; }

    }
}