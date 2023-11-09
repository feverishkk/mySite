using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using mySite.Data;
using mySite.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mySite.Areas.App.Controllers
{
    [Area("App")]
    [Authorize(Roles = SD.Admin)]
    public class RoleController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleController(ApplicationDbContext db,
                              UserManager<IdentityUser> userManager,
                              RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            // DB에 연동되어 있는 테이블 Roles 이다.
            var roles = _db.Roles.ToList();
            return View(roles);
        }

        [HttpGet]
        public IActionResult Upsert(string roleId)
        {
            if (String.IsNullOrEmpty(roleId))
            {
                return View();
            }
            else
            {
                var objFromDb = _db.Roles.FirstOrDefault(u => u.Id == roleId);
                return View(objFromDb);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpsertAsync(IdentityRole role)
        {
            // 생성할 때 Role의 이름이 이미 존재한다면 => 실패
            if (await _roleManager.RoleExistsAsync(role.Name))
            {
                TempData[SD.Failed] = "Role이 이미 존재 합니다.";
                return RedirectToAction(nameof(Index));
            }

            // 생성할 때 Role의 Id가 존재하지 않는다면 => 성공
            if (string.IsNullOrEmpty(role.Id))
            {
                await _roleManager.CreateAsync(new IdentityRole() { Name = role.Name });
                TempData[SD.Success] = "Role 생성에 성공하였습니다.";
            }

            // 업데이트할 때
            else
            {
                // 업데이트
                var roleObj = _db.Roles.FirstOrDefault(user => user.Id == role.Id);

                if (roleObj == null)
                {
                    TempData[SD.Failed] = "Role을 찾을 수 없습니다.";
                    return RedirectToAction(nameof(Index));
                }

                roleObj.Name = role.Name;
                roleObj.NormalizedName = role.NormalizedName;

                var reuslt = await _roleManager.UpdateAsync(roleObj);
            }


            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(string roleId)
        {
            var roles = _db.Roles.FirstOrDefault(role => role.Id == roleId);

            // 몇 명이 해당 Role에 존재하는지 Count하는 변수
            var userRoles = _db.UserRoles.Where(role => role.RoleId == roleId).Count();

            if (roles == null)
            {
                TempData[SD.Failed] = "Role이 존재하지 않습니다.";
                return RedirectToAction(nameof(Index));
            }

            if (userRoles > 0)
            {
                TempData[SD.Failed] = "해당 Role에 유저가 존재합니다.";
                return RedirectToAction(nameof(Index));
            }

            await _roleManager.DeleteAsync(roles);

            TempData[SD.Success] = "삭제 성공";

            return RedirectToAction(nameof(Index));

        }
    }
}
