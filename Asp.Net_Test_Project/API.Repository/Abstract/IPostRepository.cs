using API.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace API.Repository.Abstract
{
    public interface IPostRepository
    {
        Task<IEnumerable<Posts>> GetAllPosts();
        Task<Posts> GetPost(int postId);
        Task<Posts> AddPost(Posts post);
        Task<Posts> UpdatePost(Posts post);
        Task<bool> RemovePost(Posts post);
        Task<IEnumerable<Posts>> GetAllPosts(int index,int count);
        Task<int> AllPostCount();
    }
}
