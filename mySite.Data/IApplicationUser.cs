using Microsoft.AspNetCore.Identity;
using mySite.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace mySite.Data
{
    public interface IApplicationUser
    {
        ApplicationUser GetById(string id);

        IEnumerable<ApplicationUser> GetAll();
        

        Task SetProfileImage(string id, Uri uri);
        Task UpdateUserRating(string userId, Type type);

        Task GetLatestLoginDate(string userId);

    }
}
