using My_Shop_Framework.Domain;

namespace LanguageManagement.Domain.Language.Agg
{
    public class Language: EntityBase
    {
       
        public string LanguageTitle { get; private set; }
        public string LanguageNameFa { get; private set; }
        public string LanguageNameEn { get; private set; }
        public string LanguageNameRu { get; private set; }
        public string LanguageNameAr { get; private set; }
        public Language(string languageTitle, string languageNameEn, string languageNameFa, string languageNameRu, string languageNameAr)
        {
            LanguageTitle = languageTitle;
            LanguageNameEn = languageNameEn;
            LanguageNameFa = languageNameFa;
            LanguageNameRu = languageNameRu;
            LanguageNameAr = languageNameAr;
        }

        public void  Edit(string languageTitle, string languageNameEn, string languageNameFa, string languageNameRu, string languageNameAr)
        {
            LanguageTitle = languageTitle;
            LanguageNameEn = languageNameEn;
            LanguageNameFa = languageNameFa;
            LanguageNameRu = languageNameRu;
            LanguageNameAr = languageNameAr;
        }
    }
}