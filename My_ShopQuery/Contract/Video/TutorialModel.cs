using My_ShopQuery.Contract.Language;
using My_ShopQuery.Contract.SocialMedia;
using System.Collections.Generic;

namespace My_ShopQuery.Contract.Video
{
    public class TutorialModel
    {
        public List<IntroductionVideoQueryModel> IntroductionVideoQueryModels { get; set; }
        public List<TutorialVideoQueryModel> TutorialVideoQueryModels { get; set; }
    }
}