namespace My_ShopQuery.Contract.AboutUs
{
    public class AboutUsQueryModel
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public string History { get; set; }
        public string Poster { get; set; }
        public string Video { get; set; }
        public long LanguageId { get; set; }
    }
}