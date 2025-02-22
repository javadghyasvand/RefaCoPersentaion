using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_ShopQuery.Contract.Video
{
    public interface IVideoQueryModel
    {
        List<IntroductionVideoQueryModel> GetIntroductionQuery();
        List<TutorialVideoQueryModel> GetTutorialQuery();
    }
}
