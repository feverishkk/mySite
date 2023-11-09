using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using mySite.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Primitives;
using System.Net.Http.Headers;
using mySite.Models.ApplicationUser;
using mySite.Utility;
using mySite.Models.Post;
using mySite.Models.PostComment;

namespace mySite.Areas.App.Controllers
{
    [Area("App")]
    public class ProfileController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;

        private readonly IApplicationUser _userService;
        private readonly IPost _postService;
        private readonly IComments _commentService;
        private readonly IUpload _uploadService;

        private readonly IConfiguration _configuration;

        public ProfileController(UserManager<IdentityUser> userManager, IApplicationUser userService,
                                 IConfiguration configuration, IUpload uploadService, IPost postService,
                                 IComments commentService)
        {
            _userManager = userManager;
            _userService = userService;
            _configuration = configuration;
            _uploadService = uploadService;
            _postService = postService;
            _commentService = commentService;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Detail(string profileId)
        {
            var user = _userService.GetById(profileId);
            var userRoles = _userManager.GetRolesAsync(user).Result;

            var profiles = new ProfileModel
            {
                UserId = user.Id,
                UserName = user.UserName,
                UserPoints = user.Points.ToString(),
                IsAdmin = userRoles.Contains("Admin"),
                Email = user.Email,
                ProfileImageUrl = user.ProfileImageUrl,
                RegisteredDate = user.RegisteredDate,
            };

            var model = new ProfileListModel
            {
                Profiles = profiles,
            };

            return View(model);
        }

        public IActionResult UserPostsAndComments(string profileId)
        {
            var user = _userService.GetById(profileId);
            var userRoles = _userManager.GetRolesAsync(user).Result;

            if(user == null || !ModelState.IsValid)
            {
                TempData[SD.Failed] = "잘 못된 요청입니다. 다시 시도해주세요.";
                return RedirectToAction(actionName: "Index", controllerName: "Home");
            }

            var posts = _postService.GetUserPosts(user.Id)
                        .Select(post => new PostListingModel
                        {
                            Id = post.Id,
                            AuthorId = user.Id,
                            AuthorName = user.NickName,
                            DatePosted = post.Created.ToString(),
                            IsAuthorAdmin = userRoles.Contains(SD.Admin),
                            postType = (PostListingModel.PostType)post.postType,
                            Title = post.Title,
                            CommentCount = post.Comments?.Count() ?? 0,
                        })
                        .OrderByDescending(posts=>posts.DatePosted);

            var comments = _commentService.GetUserComments(user.Id)
                           .Select(comment => new PostCommentModel
                           {
                               Id = comment.Id,
                               AuthorId = user.Id,
                               AuthorName = user.NickName,
                               Created = comment.Created,
                               CommentContent = comment.Content,
                           });

            var model = new ProfileListModel
            {
                PostListings = posts,
                Comments = comments,
            };

            return View(model);
        }

        

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UploadProfileImage(IFormFile file)
        {
            var userId = _userManager.GetUserId(User);

            // 이미지가 없다면..
            if (file == null)
            {
                TempData[SD.Failed] = "새 사진을 업로드해주세요.";
                return RedirectToAction(nameof(Detail), new { profileId = userId });
            }

            // 업로드할 이미지가 있다면..
            else
            {
                // Connect to an Azure Storage Account Container
                // Azure 스토리지 계정 컨테이너에 연결
                var connectionString = _configuration.GetConnectionString("AzureStorageAccount");

                // Get Blob Container
                // Blob컨테이너를 가져온다.
                var container = _uploadService.GetBlobContainer(connectionString, "profile-images");

                // Parse the Content Disposition response header
                // 
                var contentDisposition = ContentDispositionHeaderValue.Parse(file.ContentDisposition);

                // Grab the filename
                var filename = contentDisposition.FileName.Trim('"');

                // Get a reference to a Block Blob
                var blockBlob = container.GetBlockBlobReference(filename);

                // On that block blob, Upload our file <-- file uploaded to the cloud
                await blockBlob.UploadFromStreamAsync(file.OpenReadStream());

                // Set the User's proifle image to the URI
                await _userService.SetProfileImage(userId, blockBlob.Uri);

                TempData[SD.Success] = "업로드에 성공하였습니다.";
                // Redirect to the user's profile page
                return RedirectToAction(nameof(Detail), new { profileId = userId });
            }

        }

    }
}
