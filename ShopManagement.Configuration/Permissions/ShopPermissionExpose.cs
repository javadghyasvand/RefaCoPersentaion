using System.Collections.Generic;
using My_Shop_Framework.Infrastructure;

namespace ShopManagement.Configuration.Permissions
{
    public class ShopPermissionExpose:IPermissionsExpose
    {
        public Dictionary<string, List<PermissionsDto>> Expose()
        {
            return new Dictionary<string, List<PermissionsDto>>
            {
                {
                    "Product",new List<PermissionsDto>
                    {
                        new PermissionsDto(ShopPermission.ProductCreateCode,ShopPermission.ProductCreateName),
                        new PermissionsDto(ShopPermission.ProductEditCode,ShopPermission.ProductEditName),
                    }
                },
                {
                    "ProductCategory",new List<PermissionsDto>
                    {
                        new PermissionsDto(ShopPermission.ProductCategoryCreateCode,ShopPermission.ProductCategoryCreateName),
                        new PermissionsDto(ShopPermission.ProductCategoryEditCode,ShopPermission.ProductCategoryEditName),
                    }
                }

                
            };
        }
    }
}