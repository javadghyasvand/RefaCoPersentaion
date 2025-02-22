namespace ShopManagement.Configuration.Permissions
{
    public static class ShopPermission
    {
        //Product
        public const long ProductCreateCode = 10;
        public const string ProductCreateName = "ایجاد محصول";

        public const long ProductEditCode = 11;
        public const string ProductEditName = "ویرایش محصول";

        //ProductCategory
        public const long ProductCategoryCreateCode = 20;
        public const string ProductCategoryCreateName = "ایجاد گروه محصول";

        public const long ProductCategoryEditCode = 21;
        public const string ProductCategoryEditName = "ویرایش گروه محصول";

    }
}