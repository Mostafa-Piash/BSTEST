using API.Data.Model;
using API.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Repository.Abstract;

namespace API.Service.Concrete
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _repository;
        public CommentService(ICommentRepository repository)
        {
            _repository = repository;
        }

        public async Task<Comments> AddComment(Comments comment)
        {
            try
            {
                return await _repository.AddComment(comment);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<IEnumerable<Comments>> GetAllComments()
        {
            try
            {
                return await _repository.GetAllComments();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<IEnumerable<Comments>> GetAllComments(int[] postId, int index, int count)
        {
            try
            {
                return await _repository.GetAllComments(postId,index,count);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<Comments> GetComment(int commentId)
        {
            try
            {
                return await _repository.GetComment(commentId);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<bool> RemoveComment(Comments comment)
        {
            try
            {
                return await _repository.RemoveComment(comment);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<Comments> UpdateComment(Comments comment)
        {
            try
            {
                return await _repository.UpdateComment(comment);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}

