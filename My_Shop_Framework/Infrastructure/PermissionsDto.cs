namespace My_Shop_Framework.Infrastructure
{
    public  class PermissionsDto
    {
        public long Code { get; set; }
        public string Name { get; set; }

        public PermissionsDto(long code, string name)
        {
            Code = code;
            Name = name;
        }
    }
}