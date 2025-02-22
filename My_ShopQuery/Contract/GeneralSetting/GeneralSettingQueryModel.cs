namespace My_ShopQuery.Contract.GeneralSetting
{
    public class GeneralSettingQueryModel
    {
        public long Id { get; set; }
        public string SiteTitle { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public string PhoneNumbers { get; set; }
        public long LanguageId { get; set; }
        public string MetaDescription { get; set; }
        public string MetaKeywords { get; set; }
        public string Email { get; set; }
        public string MapLink { get; set; }
        public string WaysLink { get;  set; }
        public string BaladLink { get;  set; }
        public string GoogleLink { get;  set; }
    }
}