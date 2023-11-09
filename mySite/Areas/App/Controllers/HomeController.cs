using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using mySite.Data;
using mySite.Data.Models;
using mySite.Models.ApplicationUser;
using mySite.Models.Home;
using mySite.Models.Post;
using mySite.Models.PostComment;
using System.Collections.Generic;
using System.Linq;

namespace mySite.Areas.App.Controllers
{
    [Area("App")]
    public class HomeController : Controller
    {
        private readonly IPost _postService;
        private readonly IApplicationUser _userService;
        private readonly IComments _commentService;

        private readonly UserManager<IdentityUser> _userManager;

        public HomeController(IPost postService, IApplicationUser userService,
                              UserManager<IdentityUser> userManager, IComments commentsService)
        {
            _postService = postService;
            _userManager = userManager;
            _userService = userService;
            _commentService = commentsService;
        }

        public IActionResult Index()
        {
            var model = BuildHomeIndexModel();

            return View(model);
        }

        private HomeIndexModel BuildHomeIndexModel()
        {
            var userId = _userManager.GetUserId(User);
            var user = _userService.GetById(userId);

            var latestPosts = _postService.GetLatestPosts(1);
            var latestComments = _commentService.GetLatestComments(1);

            var posts = latestPosts.Select(post => new PostListingModel
            {
                Id = post.Id,
                Title = post.Title,
                AuthorId = post.User.Id,
                AuthorName = post.User.NickName,
                CommentCount = post.Comments?.Count() ?? 0,
                DatePosted = post.Created.ToString(),
                PostContent = post.Content,
            });

            var comments = latestComments.Select(comment => new PostCommentModel
            {
                Id = comment.Id,

                AuthorId = comment.User.Id,
                AuthorName = comment.User.NickName,
                CommentContent = comment.Content,

                Created = comment.Created,
            });

            return new HomeIndexModel
            {
                LatestPosts = posts,
                SearchQuery = "",
                LatestComments = comments,
                Users = BuildHomeIndexProfileModel(user),
            };
        }

        private IEnumerable<ProfileModel> BuildHomeIndexProfileModel(ApplicationUser user)
        {
            yield return new ProfileModel
            {
                UserId = user.Id,
                UserPoints = user.Points.ToString(),
                RegisteredDate = user.RegisteredDate,
                UserName = user.NickName,
                LastLoginDate = user.LatestLoginDate,
            };
        }


    }
}
