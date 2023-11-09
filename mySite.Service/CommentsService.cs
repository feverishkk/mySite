using Microsoft.EntityFrameworkCore;
using mySite.Data;
using mySite.Data.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mySite.Service
{
    public class CommentsService : IComments
    {
        private readonly ApplicationDbContext _db;

        public CommentsService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task AddComment(PostComment comment)
        {
            _db.PostComments.Add(comment);
            await _db.SaveChangesAsync();
        }

        public async Task EditComment(int id, string newCommentContent)
        {
            var postComment = GetById(id);
            postComment.Content = newCommentContent;

            _db.PostComments.Update(postComment);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteComment(int id)
        {
            var comment = GetById(id);
            _db.PostComments.Remove(comment);
            await _db.SaveChangesAsync();
        }

        public IEnumerable<PostComment> GetAll()
        {
            return _db.PostComments.Include(pc => pc.Post).ThenInclude(pc => pc.User)
                                   .Include(pc => pc.User);
        }

        public PostComment GetById(int id)
        {
            return _db.PostComments.Where(pc => pc.Id == id)
                                   .Include(pc => pc.Post)
                                   .Include(pc => pc.Post).ThenInclude(pc => pc.User)
                                   .FirstOrDefault();
        }


        public IEnumerable<PostComment> GetLatestComments(int? n)
        {
            return GetAll().OrderByDescending(pc => pc.Created).Take((int)n);
        }


        public IEnumerable<PostComment> GetUserComments(string id)
        {
            return GetAll().Where(pc => pc.User.Id == id);
        }

        
    }
}
