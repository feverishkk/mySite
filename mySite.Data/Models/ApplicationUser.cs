using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace mySite.Data.Models
{
    public class ApplicationUser : IdentityUser
    {

        /// <summary>
        /// 회원 이름 & 닉네임
        /// </summary>
        public string Name { get; set; }
        public string NickName { get; set; }


        /// <summary>
        /// 회원 주소
        /// </summary>
        public string StreetAddress_1 { get; set; }
        public string StreetAddress_2 { get; set; }
        public string StreetAddress_3 { get; set; }
        public string PostalCode { get; set; }

        /// <summary>
        /// 회원 정보
        /// </summary>
        public string ProfileImageUrl { get; set; }
        public DateTime RegisteredDate { get; set; }  // 가입한 날짜
        public DateTime LatestLoginDate { get; set; } // 최근 로그인

        public int Points { get; set; }


        /// <summary>
        /// 회원 Role
        /// </summary>
        [NotMapped]
        public string RoleId { get; set; }

        [NotMapped]
        public string Role { get; set; }

        [NotMapped]
        public IEnumerable<SelectListItem> RoleList { get; set; }

    }
}
