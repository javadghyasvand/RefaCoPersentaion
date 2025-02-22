using My_Shop_Framework.Domain;

namespace GeneralManagement.Domain.GeneralAgg
{
    public class GeneralSetting : EntityBase
    {
        public string SiteTitle { get; private set; }
        public string MetaDescription { get; private set; }
        public string MetaKeywords { get; private set; }
        public string AdminEmail { get; private set; }
        public string HostingSpace { get; private set; }
        public string Address { get; private set; }
        public string PostalCode { get; private set; }
        public string MapLink { get; private set; }
        public string WaysLink { get; private set; }
        public string BaladLink { get; private set; }
        public string GoogleLink { get; private set; }
        public string PhoneNumbers { get; private set; }
        public long LanguageId { get; private set; }


        public GeneralSetting(string siteTitle, string metaDescription,
            string metaKeywords, string adminEmail, string hostingSpace,
            string address, string postalCode, string mapLink, long languageId, 
            string phoneNumbers, string waysLink, string baladLink, string googleLink)
        {
            SiteTitle = siteTitle;
            MetaDescription = metaDescription;
            MetaKeywords = metaKeywords;
            AdminEmail = adminEmail;
            HostingSpace = hostingSpace;
            Address = address;
            PostalCode = postalCode;
            MapLink = mapLink;
            LanguageId = languageId;
            PhoneNumbers = phoneNumbers;
            WaysLink = waysLink;
            BaladLink = baladLink;
            GoogleLink = googleLink;
        }

        public void Edit(string siteTitle, string metaDescription,
            string metaKeywords, string adminEmail, string hostingSpace,
            string address, string postalCode, string mapLink, long languageId,
            string phoneNumbers, string waysLink, string baladLink, string googleLink)
        {
            SiteTitle = siteTitle;
            MetaDescription = metaDescription;
            MetaKeywords = metaKeywords;
            AdminEmail = adminEmail;
            HostingSpace = hostingSpace;
            Address = address;
            PostalCode = postalCode;
            MapLink = mapLink;
            LanguageId = languageId;
            PhoneNumbers = phoneNumbers;
            WaysLink = waysLink;
            BaladLink = baladLink;
            GoogleLink = googleLink;
        }
    }
}