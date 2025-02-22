using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_ShopQuery.Contract.Video
{
    public class IntroductionVideoQueryModel
    {
        public long LanguageId { get; set; }
        public long Id { get; set; }
        public string Poster { get; set; }
        public string Link { get; set; }
    }
}
