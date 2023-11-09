using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using mySite.Data;
using mySite.Data.Models;
using mySite.Models.UserClaims;
using mySite.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using static mySite.Models.UserClaims.UserClaimsIndexModel;

namespace mySite.Areas.App.Controllers
{
    [Area("App")]
    
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<IdentityUser> _userMananger;

        public UserController(ApplicationDbContext db, UserManager<IdentityUser> userMananger)
        {
            _db = db;
            _userMananger = userMananger;
        }
        
        public IActionResult Index()
        {
            var userRoleList = _db.ApplicationUsers.ToList();
            var userRole = _db.UserRoles.ToList();
            var roles = _db.Roles.ToList();

            foreach (var user in userRoleList)
            {
                var role = userRole.FirstOrDefault(obj => obj.UserId == user.Id);

                if (role == null)
                {
                    user.Role = "None";
                }

                else
                {
                    user.Role = roles.FirstOrDefault(user => user.Id == role.RoleId).Name;
                }
            }

            return View(userRoleList);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult banShortTime(string userId, int time = 30)
        {
            var currentUser = _db.ApplicationUsers.FirstOrDefault(User => User.Id == userId);

            if(currentUser.LockoutEnd != null && currentUser.LockoutEnd > DateTime.Now)
            {
                currentUser.LockoutEnd = DateTime.Now.AddMinutes(time);
                TempData[SD.Success] = "30분금지에 성공했습니다.";
            }

            _db.SaveChanges();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult LockUnlock(string userId)
        {

            var users = _db.ApplicationUsers.FirstOrDefault(user => user.Id == userId);

            // 해당하는 유저가 없다면...
            if (users == null)
            {
                return NotFound();
            }


            if (users.LockoutEnd != null && users.LockoutEnd > DateTime.Now)
            {
                users.LockoutEnd = DateTime.Now;
                TempData[SD.Success] = "유저 잠금풀기에 성공하였습니다.";
            }

            else
            {
                users.LockoutEnd = DateTime.Now.AddYears(1000);
                TempData[SD.Success] = "유저 잠금에 성공하였습니다.";
            }

            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(string userId)
        {
            var users = _db.ApplicationUsers.FirstOrDefault(user => user.Id == userId);

            if (users == null)
            {
                return NotFound();
            }

            var userRole = _db.UserRoles.ToList();
            var roles = _db.Roles.ToList();
            var role = userRole.FirstOrDefault(user => user.UserId == users.Id);

            if (role != null)
            {
                users.RoleId = roles.FirstOrDefault(user => user.Id == role.RoleId).Id;
            }

            users.RoleList = _db.Roles.Select(user => new SelectListItem
            {
                Text = user.Name,
                Value = user.Id
            });

            return View(users);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ApplicationUser user)
        {
            if (ModelState.IsValid)
            {
                var users = _db.ApplicationUsers.FirstOrDefault(obj => obj.Id == user.Id);

                if (users == null)
                {
                    return NotFound();
                }

                var userRole = _db.UserRoles.FirstOrDefault(obj => obj.UserId == user.Id);

                if (userRole != null)
                {
                    var previousRoleWas = _db.Roles.Where(obj => obj.Id == userRole.RoleId).Select(u => u.Name).FirstOrDefault();

                    // RemoveFromRoleAsync()는 "현 유저"와 "예전 Role"이라는 파라미터를 가지고 Role을 삭제시켜준다.
                    // 예전 Role을 삭제한다. 
                    await _userMananger.RemoveFromRoleAsync(users, previousRoleWas);
                }

                // AddToRoleAsync()는 "현 유저"와 "새로 선택된 Role의 이름" 파라미터들로 가지고 새로운 Role을 더한다.
                await _userMananger.AddToRoleAsync(users, _db.Roles.FirstOrDefault(u => u.Id == user.RoleId).Name);
                users.Name = user.Name;
                _db.SaveChanges();

                TempData[SD.Success] = "유저 수정이 완료 되었습니다.";

                return RedirectToAction(nameof(Index));
            }

            user.RoleList = _db.Roles.Select(user => new SelectListItem
            {
                Text = user.Name,
                Value = user.Id
            });

            return View(user);

        }

        [HttpPost]
        [HttpDelete]
        public IActionResult Delete(string userId)
        {
            var users = _db.ApplicationUsers.FirstOrDefault(user => user.Id == userId);

            if (users == null)
            {
                return NotFound();
            }

            _db.ApplicationUsers.Remove(users);
            _db.SaveChanges();
            TempData[SD.Success] = "유저 삭제 성공";

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> ManageUserClaims(string userId)
        {
            IdentityUser user = await _userMananger.FindByIdAsync(userId);

            if (user == null)
            {
                return NotFound();
            }

            var existingUserClaims = await _userMananger.GetClaimsAsync(user);

            var model = new UserClaimsIndexModel()
            {
                UserId = userId
            };

            foreach (Claim claim in Claims.claimList)
            {
                UserClaim userClaim = new UserClaim
                {
                    ClaimType = claim.Type
                };

                if (existingUserClaims.Any(obj => obj.Type == claim.Type))
                {
                    userClaim.IsSelected = true;
                }
                model.Claims.Add(userClaim);
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ManageUserClaims(UserClaimsIndexModel userClaimsIndexModel)
        {
            IdentityUser user = await _userMananger.FindByIdAsync(userClaimsIndexModel.UserId);

            if (user == null)
            {
                return NotFound();
            }

            var userClaims = await _userMananger.GetClaimsAsync(user);
            var result = await _userMananger.RemoveClaimsAsync(user, userClaims);

            if(!result.Succeeded)
            {
                TempData[SD.Failed] = "권한을 지우는 동안 에러가 발생하였습니다.";
                return View(userClaimsIndexModel);
            }

            result = await _userMananger.AddClaimsAsync(user,
                      userClaimsIndexModel.Claims
                     .Where(claim => claim.IsSelected)
                     .Select(claim => new Claim(claim.ClaimType, claim.IsSelected.ToString())
                     ));

            if(!result.Succeeded)
            {
                TempData[SD.Failed] = "권한을 더하는 동안 에러가 발생하였습니다.";
                return View(userClaimsIndexModel);
            }

            TempData[SD.Success] = "권한 업데이트에 성공하였습니다.";
            return RedirectToAction(nameof(Index));
        }
    }
}
