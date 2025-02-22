using My_Shop_Framework.Application;
using System.ComponentModel.DataAnnotations;

namespace LanguageManagement.Application.Contracts.Language
{
    public class LanguageViewModel
    {
        public long Id { get; set; }
        public string LanguageTitle { get; set; }
        public string LanguageNameFa { get; set; }
        public string LanguageNameEn { get; set; }
        public string LanguageNameRu { get; set; }
        public string LanguageNameAr { get; set; }
    }
}