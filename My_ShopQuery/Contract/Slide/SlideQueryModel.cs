namespace My_ShopQuery.Contract.Slide
{
    public class SlideQueryModel
    {
        public string Heading { get; set; }
        public string Text { get; set; }
        public string BtnText { get; set; }
        public bool IsRemoved { get; set; }
        public string Link { get; set; }
        public string CreationDate { get; set; }
        public long  LanguageId { get; set; }
    }
}