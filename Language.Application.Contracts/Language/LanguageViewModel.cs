using My_Shop_Framework.Application;
using System.ComponentModel.DataAnnotations;

namespace LanguageManagement.Application.Contracts.Language
{
    public class LanguageViewModel
    {
        public long Id { get; set; }

        public string LanguageTitle { get; set; }
    }
}