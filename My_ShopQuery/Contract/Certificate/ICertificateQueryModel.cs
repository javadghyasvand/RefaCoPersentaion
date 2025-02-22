using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using My_ShopQuery.Contract.ArticleCategory;

namespace My_ShopQuery.Contract.Certificate
{
    public interface ICertificateQueryModel
    {
        CertificateQueryModel GetCertificate(long id);
        List<CertificateQueryModel> GetCertificateList();
        List<CertificateQueryModel> TakeCertificate();
    }
}