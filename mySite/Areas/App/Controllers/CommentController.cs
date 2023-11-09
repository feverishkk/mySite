using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using mySite.Data;
using mySite.Data.Models;
using mySite.Models.Post;
using mySite.Models.PostComment;
using mySite.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mySite.Areas.App.Controllers
{
    [Area("App")]
    public class CommentController : Controller
    {
        private readonly IPost _postService;
        private readonly IComments _commentService;
        private readonly IApplicationUser _userService;
        private readonly UserManager<IdentityUser> _userManager;

        public CommentController(IPost postService, IApplicationUser userService,
                                 UserManager<IdentityUser> userManager, IComments commentService)
        {
            _postService = postService;
            _userService = userService;
            _userManager = userManager;
            _commentService = commentService;
        }

        [ActionName("Create")]
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAsync(int commentId)
        {
            // View에 있는 Textarea에서 유저가 쓴 글을 가져온다.
            var getComment = Request.Form["commentCreate"];

            var userId = _userManager.GetUserId(User);
            var user = await _userManager.FindByIdAsync(userId);
            var post = _postService.GetById(commentId);

            if (commentId == 0 || userId == null)
            {
                TempData[SD.Failed] = "찾을 수 없습니다. 다시 확인해주세요.";
                return NotFound();
            }


            var comment = new PostComment
            {
                Content = getComment,
                Created = DateTime.Now,
                User = (ApplicationUser)user,
                Post = post,
            };


            await _commentService.AddComment(comment);
            TempData[SD.Success] = "댓글 등록 성공";

            return RedirectToAction(nameof(Index), nameof(Post), new { commentId = comment.Post.Id });
        }


        [HttpGet]
        public IActionResult Edit(int commentId)
        {
            if (!ModelState.IsValid && commentId == 0)
            {
                TempData[SD.Failed] = "실패하였습니다.";
                return NotFound();
            }
            var postComment = _commentService.GetById(commentId);

            var user = _userManager.GetUserAsync(User).Result;
            var userId = _userManager.GetUserIdAsync(user).Result.ToString();

            var userComment = postComment.User.Id;

            if (userId != userComment)
            {
                TempData[SD.Failed] = "찾을 수 없습니다. 다시 확인해주세요.";
                return BadRequest("잘못된 요청입니다.");
            }

            var model = new NewCommentModel
            {
                Content = postComment.Content,
                Id = postComment.Id,
                AuthorName = postComment.User.NickName,
            };

            
            return View(model);
        }

        [ActionName("Edit")]
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAsync(int commentId, NewCommentModel model)
        {
            var userId = _userManager.GetUserId(User);
            var user = await _userManager.FindByIdAsync(userId);

            if (commentId == 0 || user == null)
            {
                TempData[SD.Failed] = "찾을 수 없습니다. 다시 확인해주세요.";
                return NotFound();
            }

            _commentService.EditComment(commentId, model.Content).Wait();

            TempData[SD.Success] = "댓글 수정 성공";

            
            return RedirectToAction(nameof(Index), nameof(Post));
        }


        [HttpGet]
        public IActionResult Delete(int commentId)
        {
            var userId = _userManager.GetUserId(User);
            var user = _userManager.FindByIdAsync(userId).Result;

            var postComment = _commentService.GetById(commentId);

            if (commentId == 0 || user == null)
            {
                TempData[SD.Failed] = "댓글 삭제 실패";
                return NotFound();
            }

            var userComment = postComment.User.Id;

            if (userId != userComment)
            {
                TempData[SD.Failed] = "찾을 수 없습니다. 다시 확인해주세요.";
                return BadRequest("잘못된 요청입니다.");
            }

            var model = new DeleteCommentModel
            {
                Id = postComment.Id,
                AuthorName = postComment.User.NickName,
                Content = postComment.Content
            };

            return View(model);
        }


        [ActionName("Delete")]
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteAsync(int commentId, DeleteCommentModel model)
        {
            var userId = _userManager.GetUserId(User);
            var user = await _userManager.FindByIdAsync(userId);

            var postComment = _commentService.GetById(commentId);

            if (commentId == 0 || user == null)
            {
                TempData[SD.Failed] = "댓글 삭제 실패";
                return NotFound();
            }

            _commentService.DeleteComment(commentId).Wait();
            TempData[SD.Success] = "댓글 삭제 성공";

            return RedirectToAction(nameof(Index), nameof(Post), new { commentId = postComment.Post.Id });
        }



    }

}
