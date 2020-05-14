using API.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace API.Repository.Abstract
{
    public interface ICommentRepository
    {
        Task<IEnumerable<Comments>> GetAllComments();
        Task<Comments> GetComment(int commentId);
        Task<Comments> AddComment(Comments comment);
        Task<Comments> UpdateComment(Comments comment);
        Task<bool> RemoveComment(Comments comment);
        Task<IEnumerable<Comments>> GetAllComments(int[] postId, int index, int count);
        Task<int> GetCommentCount(int[] postIds);
    }
}
