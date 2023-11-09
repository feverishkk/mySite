using mySite.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace mySite.Data
{
    public interface IComments
    {
        PostComment GetById(int id);

        IEnumerable<PostComment> GetAll();

        IEnumerable<PostComment> GetUserComments(string id);

        IEnumerable<PostComment> GetLatestComments(int? n);


        // CUD
        Task AddComment(PostComment postComment);

        Task EditComment(int id, string newCommentContent);

        Task DeleteComment(int id);

    }
}
