using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using mySite.Data;
using mySite.Data.Models;

namespace mySite.Service
{
    public class PostService : IPost
    {
        private readonly ApplicationDbContext _db;

        public PostService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task Add(Post post)
        {
            _db.Posts.Add(post);
            await _db.SaveChangesAsync();
        }
        public async Task EditPostTitle(int id, string newTitle)
        {
            var post = GetById(id);
            post.Title = newTitle;
            //_db.Entry(post).State = EntityState.Modified;

            _db.Posts.Update(post);
            await _db.SaveChangesAsync();
        }

        public async Task EditPostContent(int id, string newContent)
        {
            var post = GetById(id);
            post.Content = newContent;

            _db.Posts.Update(post);
            await _db.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var postId = GetById(id);
            _db.Posts.Remove(postId);

            await _db.SaveChangesAsync();
        }

        public IEnumerable<Post> GetAll()
        {
            var post = _db.Posts.Include(post => post.User)
                                .Include(post => post.Comments).ThenInclude(comment => comment.User);
            return post;
        }

        public Post GetById(int id)
        {
            return _db.Posts.Where(post => post.Id == id)
                            .Include(post => post.User)
                            .Include(post => post.Comments).ThenInclude(post => post.User)
                            .FirstOrDefault();
        }
        public IEnumerable<Post> GetLatestPosts(int items)
        {
            return GetAll().OrderByDescending(post => post.Created).Take(items);
        }
        


        public IEnumerable<Post> SearchingInPosts(string searchQuery)
        {
            var queries = searchQuery.ToLower();
            
            return GetAll().Where(post => post.Title.Contains(queries, StringComparison.CurrentCultureIgnoreCase) 
                                       || post.Content.Contains(queries, StringComparison.CurrentCultureIgnoreCase));
        }


        public async Task ViewCount(int id)
        {
            var post = GetById(id);
            int counter = 1;
            post.ViewCount += counter;

            await _db.SaveChangesAsync();
        }

        /// <summary>
        /// userId는 내가 누른 user의 Id이며 db에 저장된 유저의id와 비교한다.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public IEnumerable<Post> GetUserPosts(string userId)
        {
            return GetAll().Where(post => post.User.Id == userId);
        }
    }
}
