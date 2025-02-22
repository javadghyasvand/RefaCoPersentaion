#nullable enable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_ShopQuery.Contract.Video
{
    public class TutorialVideoQueryModel
    {
        public long Id { get; set; }
        public string TitleFa { get; set; }
        public string TitleEn { get; set; }
        public string TitleAr { get; set; }
        public string TitleRu { get; set; }
        public string Title { get; set; }
        public string LinkFa { get; set; }
        public string? LinkEn { get; set; }
        public string? LinkAr { get; set; }
        public string? LinkRu { get; set; }
        public string PosterStr { get; set; }
    }
}
