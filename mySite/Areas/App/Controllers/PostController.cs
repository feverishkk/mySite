using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using mySite.Data;
using mySite.Data.Models;
using mySite.Models.Post;
using mySite.Models.PostComment;
using mySite.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static mySite.Data.Models.Post;

namespace mySite.Areas.App.Controllers
{
    [Area("App")]
    [Authorize]
    public class PostController : Controller
    {
        private readonly IPost _postService;
        private readonly IApplicationUser _userService;
        private readonly IUpload _uploadService;
        private readonly IComments _commentService;

        private readonly UserManager<IdentityUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _hostEnvironment;

        public PostController(IPost postService, UserManager<IdentityUser> userManager,
                              IApplicationUser userService, IConfiguration configuration,
                              IUpload uploadService, IWebHostEnvironment hostEnvironment,
                              IComments commentService)
        {
            _postService = postService;
            _userManager = userManager;
            _userService = userService;
            _configuration = configuration;
            _uploadService = uploadService;
            _hostEnvironment = hostEnvironment;
            _commentService = commentService;
        }


        public IActionResult Index()
        {
            var model = BuildPostIndexModel();
            return View(model);
        }

        private PostMainPageModel BuildPostIndexModel()
        {
            var latestPosts = _postService.GetLatestPosts(3);

            var getLatestPosts = latestPosts.Select(post => new PostIndexModel
            {
                Id = post.Id,

                AuthorId = post.User.Id,
                AuthorName = post.User.NickName,
                IsAuthorAdmin = IsAuthorAdmin(post.User),

                Title = post.Title,
                CommentCount = post.Comments?.Count() ?? 0,
                PostContent = post.Content,
                Created = post.Created,
                viewCount = post.ViewCount,
            });

            var postListings = _postService.GetAll()
                              .Select(post => new PostListingModel
                              {
                                  Id = post.Id,
                                  AuthorId = post.User.Id,
                                  AuthorName = post.User.NickName,
                                  IsAuthorAdmin = IsAuthorAdmin(post.User),

                                  Title = post.Title,
                                  CommentCount = post.Comments?.Count() ?? 0,
                                  PostContent = post.Content,
                                  DatePosted = post.Created.ToString(),
                                  viewCount = post.ViewCount,

                                  postType = (PostListingModel.PostType)post.postType,
                                  
                              })
                              .OrderByDescending(post => post.DatePosted);

            return new PostMainPageModel
            {
                PostIndexModels = getLatestPosts,
                PostListingModels = postListings,
            };
        }


        //[Authorize]
        [HttpGet]
        public IActionResult Create()
        {
            var userId = _userManager.GetUserId(User);
            var user = _userService.GetById(userId);

            if (user == null)
            {
                TempData[SD.Failed] = "찾을 수 없습니다. 다시 확인해주세요.";
                return NotFound();
            }

            var model = new NewPostModel
            {
                AuthorName = user.NickName,
            };

            return View(model);
        }

        //[Authorize]
        [ActionName("Create")]
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAsync(NewPostModel model)
        {
            var userId = _userManager.GetUserId(User);
            var user = _userManager.FindByIdAsync(userId).Result;

            if (userId == null)
            {
                TempData[SD.Failed] = "생성에 실패하였습니다.";
                return NotFound();
            }

            var post = BuildPost(model, user);

            await _postService.Add(post);

            TempData[SD.Success] = "생성 성공";
            return RedirectToAction(nameof(Index), nameof(Post), new { id = post.Id });

        }


        private Post BuildPost(NewPostModel model, IdentityUser user)
        {
            return new Post
            {
                Title = model.Title,
                Content = model.Content,
                Created = DateTime.Now,
                User = (ApplicationUser)user,
                postType = (Post.PostType)model.postType,
            };
        }


        public IActionResult Detail(int postId)
        {
            var post = _postService.GetById(postId);

            // var getPostComment = _commentService.GetById(postId);

            if (post == null)
            {
                TempData[SD.Failed] = "찾을 수 없습니다. 다시 확인해주세요.";
                return NotFound();
            }

            // 조회수 증가 기능
            // await _postService.ViewCount(postId);

            // 글에 달려 있는 댓글들을 불러온다.
            var comments = BuildPostComments(post);

            var model = new PostIndexModel
            {
                Id = post.Id,
                Title = post.Title,
                AuthorId = post.User.Id,
                AuthorName = post.User.NickName,
                AuthorImageUrl = post.User.ProfileImageUrl,
                PostContent = post.Content,
                Comments = comments,
                CommentCount = post.Comments.Count(),
                Created = post.Created,
                IsAuthorAdmin = IsAuthorAdmin(post.User),
            };

            return View(model);
        }

        private bool IsAuthorAdmin(ApplicationUser user)
        {
            return _userManager.GetRolesAsync(user).Result.Contains("Admin");
        }

        private IEnumerable<PostCommentModel> BuildPostComments(Post post)
        {
            return post.Comments.Select(comment => new PostCommentModel
            {
                Id = comment.Id,
                AuthorId = comment.User.Id,
                AuthorImageUrl = comment.User.ProfileImageUrl,
                AuthorName = comment.User.NickName,
                AuthorPoints = comment.User.Points,
                CommentContent = comment.Content,
                Created = comment.Created,
                IsAuthorAdmin = IsAuthorAdmin(comment.User),
            });
        }

        [HttpGet]
        public IActionResult Edit(int postId)
        {
            var post = _postService.GetById(postId);

            var user = _userManager.GetUserAsync(User).Result;
            var userId = _userManager.GetUserIdAsync(user).Result.ToString();

            var userPost = post.User.Id.ToString();

            if((!ModelState.IsValid || postId == 0))
            {
                TempData[SD.Failed] = "찾을 수 없습니다. 다시 확인해주세요.";
                return BadRequest("잘못된 요청입니다.");
            }

            if (User.IsInRole("Admin"))
            {
                var modelForAdmin = new NewPostModel
                {
                    Content = post.Content,
                    Title = post.Title,
                    Id = post.Id,
                    AuthorName = post.User.NickName,

                };

                return View(modelForAdmin);
            }

            if (userId != userPost)
            {
                TempData[SD.Failed] = "찾을 수 없습니다. 다시 확인해주세요.";
                return BadRequest("잘못된 요청입니다.");
            }

            var model = new NewPostModel
            {
                Content = post.Content,
                Title = post.Title,
                Id = post.Id,
                AuthorName = post.User.NickName,

            };


            return View(model);
        }

        [ActionName("Edit")]
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Edit(int postId, NewPostModel model)
        {
            if (postId == 0)
            {
                return NotFound();
            }


            _postService.EditPostTitle(postId, model.Title).Wait();
            _postService.EditPostContent(postId, model.Content).Wait();

            TempData[SD.Success] = "수정 성공";
            return RedirectToAction(nameof(Index), nameof(Post));
        }


        [HttpGet]
        public IActionResult Delete(int postId)
        {
            var post = _postService.GetById(postId);

            var user = _userManager.GetUserAsync(User).Result;
            var userId = _userManager.GetUserIdAsync(user).Result.ToString();

            var userPost = post.User.Id.ToString();

            if (User.IsInRole(SD.Admin))
            {
                var modelForAdmin = new DeletePostModel
                {
                    PostId = post.Id,
                    PostAuthor = post.User.NickName,
                    PostTitle = post.Title,
                };

                return View(modelForAdmin);
            }

            if ((userId != userPost) || (post == null))
            {
                TempData[SD.Failed] = "찾을 수 없습니다. 다시 확인해주세요.";
                return BadRequest("잘못된 요청입니다.");
            }

            var model = new DeletePostModel
            {
                PostId = post.Id,
                PostAuthor = post.User.NickName,
                PostTitle = post.Title,
            };


            return View(model);
        }

        [ActionName("Delete")]
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult ConfirmDelete(int postId)
        {
            if (postId == 0)
            {
                return NotFound();
            }

            var post = _postService.GetById(postId);
            _postService.Delete(postId).Wait();

            TempData[SD.Success] = "삭제 성공";
            return RedirectToAction(nameof(Index), nameof(Post), new { id = post.Id });
        }

    }
}

