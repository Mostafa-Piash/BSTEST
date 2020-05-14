using API.Data.Model;
using API.Data.ResponseModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace API.Service.Abstract
{
    public interface IPostService
    {
        Task<IEnumerable<Posts>> GetAllPosts();
        Task<Posts> GetPost(int postId);
        Task<Posts> AddPost(Posts post);
        Task<Posts> UpdatePost(Posts post);
        Task<bool> RemovePost(Posts post);
        Task<PostsWithCommentsAndVotesModel> GetPostWithCommentsAndVotes(int postPage, int commentPage);

    }
}
