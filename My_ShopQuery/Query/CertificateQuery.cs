using System.Collections.Generic;
using BlogManagement.Infrastructure.EFCore;
using System.Globalization;
using System.Linq;
using CommentManagement.Infrastructure.EFCore;
using GeneralManagement.Infrastructure.EFCore;
using LanguageManagement.Infrastructure.EFCore;
using My_ShopQuery.Contract.Article;
using My_ShopQuery.Contract.Certificate;

namespace My_ShopQuery.Query
{
    public class CertificateQuery : ICertificateQueryModel
    {
        private readonly GeneralContext _generalContext;
        private readonly LanguageContext _languageContext;

        public CertificateQuery(GeneralContext generalContext, LanguageContext languageContext)
        {
            _generalContext = generalContext;
            _languageContext = languageContext;
        }

        public CertificateQueryModel GetCertificate(long id)
        {
            var currentLanguage = CultureInfo.CurrentCulture.ToString();
            var language = _languageContext.Languages.FirstOrDefault(x => x.LanguageTitle == currentLanguage).Id;
            return _generalContext.Certificates.Select(X => new CertificateQueryModel()
            {
                Title = X.Title,
                Description = X.Description,
                ImageString = X.Image,
                IconString = X.Logo,
                Id = X.Id,
                Pdf = X.PdfFile
            }).SingleOrDefault(x => x.Id == id);

        }

        public List<CertificateQueryModel> GetCertificateList()
        {
            var currentLanguage = CultureInfo.CurrentCulture.ToString();
            var language = _languageContext.Languages.FirstOrDefault(x => x.LanguageTitle == currentLanguage).Id;
            return _generalContext.Certificates.Select(X => new CertificateQueryModel()
            {
                Title = X.Title,
                Description = X.Description,
                ImageString = X.Image,
                IconString = X.Logo,
                Id = X.Id,
                LanguageId = X.LanguageId
            }).Where(x=>x.LanguageId==language).ToList();
        }

        public List<CertificateQueryModel> TakeCertificate()
        {
            var currentLanguage = CultureInfo.CurrentCulture.ToString();
            var language = _languageContext.Languages.FirstOrDefault(x => x.LanguageTitle == currentLanguage).Id;
            return _generalContext.Certificates.Select(X => new CertificateQueryModel()
            {
                Title = X.Title,
                Description = X.Description,
                ImageString = X.Image,
                IconString = X.Logo,
                Id = X.Id,
                LanguageId = X.LanguageId
            }).Where(x => x.LanguageId == language).Take(3).ToList();
        }
    }
}