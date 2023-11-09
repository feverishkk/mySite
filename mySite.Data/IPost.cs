using mySite.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace mySite.Data
{
    public interface IPost
    {
        Post GetById(int id);

        IEnumerable<Post> GetAll();

        IEnumerable<Post> GetUserPosts(string id);

        IEnumerable<Post> SearchingInPosts(string searchQuery);

        IEnumerable<Post> GetLatestPosts(int items);

        // CRUD
        Task Add(Post post);
        Task Delete(int id);
        Task EditPostTitle(int id, string newTitle);
        Task EditPostContent(int id, string newContent);


        Task ViewCount(int id);

    }
}
