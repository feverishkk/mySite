using Microsoft.AspNetCore.Identity;
using mySite.Data;
using mySite.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mySite.Service
{
    public class ApplicationUserService : IApplicationUser
    {
        private readonly ApplicationDbContext _db;

        public ApplicationUserService(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<ApplicationUser> GetAll()
        {
            return _db.ApplicationUsers;
        }

        public ApplicationUser GetById(string id)
        {
            return GetAll().FirstOrDefault(user => user.Id == id);
        }

        public async Task SetProfileImage(string id, Uri uri)
        {
            var user = GetById(id);
            user.ProfileImageUrl = uri.AbsoluteUri;

            _db.Update(user);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateUserRating(string userId, Type type)
        {
            var user = GetById(userId);
            user.Points = CalculateUserRating(type, user.Points);
            await _db.SaveChangesAsync();
        }

        private int CalculateUserRating(Type type, int userPoints)
        {
            int inc = 0;
            if(type==typeof(Post))
            {
                inc = 3;
            }
            if(type==typeof(PostComment))
            {
                inc = 1;
            }
            return userPoints + inc;
        }

        public async Task GetLatestLoginDate(string userId)
        {
            var user = GetById(userId);
            user.LatestLoginDate = DateTime.Now;
            await _db.SaveChangesAsync();
        }
    }
}
