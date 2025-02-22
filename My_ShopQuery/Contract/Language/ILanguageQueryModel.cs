using System.Collections.Generic;

namespace My_ShopQuery.Contract.Language
{
    public interface ILanguageQueryModel
    {
        List<LanguageQueryModel> List();
        LanguageQueryModel GetBy(string id);
    }
}