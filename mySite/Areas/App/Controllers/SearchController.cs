using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using mySite.Data;
using mySite.Models.Post;
using mySite.Models.Search;
using System.Linq;

namespace mySite.Areas.App.Controllers
{
    [Area("App")]
    public class SearchController : Controller
    {
        private readonly IPost _postService;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IApplicationUser _userService;
        
        public SearchController(IPost postService, UserManager<IdentityUser> userManager,
                                IApplicationUser userService)
        {
            _postService = postService;
            _userManager = userManager;
            _userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Search(string searchQuery)
        {
            return RedirectToAction("Results", new { searchQuery});
        }


        public IActionResult Results(string searchQuery)
        {
            var user = _userManager.GetUserAsync(User).Result;

            var posts = _postService.SearchingInPosts(searchQuery);
                        
            var noResults = (!string.IsNullOrEmpty(searchQuery) && !posts.Any());

            var resultListings = posts.Select(post => new PostListingModel
            {
                Id = post.Id,
                AuthorId = post.User.Id,
                AuthorName = post.User.UserName,
                Title = post.Title,
                CommentCount = post.Comments?.Count() ?? 0,
                DatePosted = post.Created.ToString(),
            });

            var model = new SearchResultModel
            {
                Posts = resultListings,
                EmptySearchResults = noResults,
                SearchQuery = searchQuery,
            };

            return View(model);

        }

    }
}
