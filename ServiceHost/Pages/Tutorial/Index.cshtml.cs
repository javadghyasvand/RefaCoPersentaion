using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using My_ShopQuery.Contract.Video;
using System.Threading.Tasks;
using System;
using TutorialManagement.Domain.TutorialVideo.Agg;
using TutorialManagement.Infrastructure.EfCore;
using AccountManagement.Domain.Account.Agg;
using Microsoft.EntityFrameworkCore;

namespace ServiceHost.Pages.Tutorial
{
    public class IndexModel : PageModel
    {
        private readonly IVideoQueryModel _videoQueryModel;
        public TutorialModel TutorialModel =new();
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly TutorialContext _generalContext;
        public IndexModel(IVideoQueryModel videoQueryModel, UserManager<ApplicationUser> userManager, TutorialContext generalContext)
        {
            _videoQueryModel = videoQueryModel;
            _userManager = userManager;
            _generalContext = generalContext;
        }

        public void OnGet()
        {
            TutorialModel.TutorialVideoQueryModels = _videoQueryModel.GetTutorialQuery();
            TutorialModel.IntroductionVideoQueryModels = _videoQueryModel.GetIntroductionQuery();
        }
        public async Task<IActionResult> OnPostLogVideoView(int videoId)
        {
            var userId = _userManager.GetUserId(User);
            if (string.IsNullOrEmpty(userId))
            {
                return new JsonResult(new { success = false, message = "Unauthorized" }) { StatusCode = 401 };
            }

            var videoExists = await _generalContext.TutorialVideos.AnyAsync(v => v.Id == videoId);
            if (!videoExists)
            {
                return new JsonResult(new { success = false, message = "Video not found" }) { StatusCode = 404 };
            }

            var alreadyLogged = await _generalContext.VideoViews.AnyAsync(v => v.UserId == userId && v.VideoId == videoId);
            if (alreadyLogged)
            {
                return new JsonResult(new { success = false, message = "Video view already logged." });
            }

            var videoView = new VideoView
            {
                UserId = userId,
                VideoId = videoId,
                ViewTimestamp = DateTime.UtcNow
            };

            try
            {
                _generalContext.VideoViews.Add(videoView);
                await _generalContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return new JsonResult(new { success = false, message = "An error occurred while logging the video view." })
                {
                    StatusCode = 500
                };
            }

            return new JsonResult(new { success = true, message = "Video view logged successfully" });
        }

        // public async Task<IActionResult> OnPostLogVideoView([FromBody] string videoId)
        // {
        //     var userId = _userManager.GetUserId(User);
        //     if (string.IsNullOrEmpty(userId))
        //     {
        //         return new JsonResult(new { success = false, message = "Unauthorized" }) { StatusCode = 401 };
        //     }
        //
        //     if (!int.TryParse(videoId, out int parsedVideoId))
        //     {
        //         return new JsonResult(new { success = false, message = "Invalid video ID" }) { StatusCode = 400 };
        //     }
        //
        //     var videoExists = await _generalContext.VideoViews.AnyAsync(v => v.Id == parsedVideoId);
        //     if (!videoExists)
        //     {
        //         return new JsonResult(new { success = false, message = "Video not found" }) { StatusCode = 404 };
        //     }
        //
        //     var alreadyLogged = await _generalContext.VideoViews.AnyAsync(v => v.UserId == userId && v.VideoId == parsedVideoId);
        //     if (alreadyLogged)
        //     {
        //         return new JsonResult(new { success = false, message = "Video view already logged." });
        //     }
        //
        //     var videoView = new VideoView
        //     {
        //         UserId = userId,
        //         VideoId = parsedVideoId,
        //         ViewTimestamp = DateTime.UtcNow
        //     };
        //
        //     try
        //     {
        //         _generalContext.VideoViews.Add(videoView);
        //         await _generalContext.SaveChangesAsync();
        //     }
        //     catch (Exception ex)
        //     {
        //         return new JsonResult(new { success = false, message = "An error occurred while logging the video view." })
        //         {
        //             StatusCode = 500
        //         };
        //     }
        //
        //     return new JsonResult(new { success = true, message = "Video view logged successfully" });
        // }

    }
}
