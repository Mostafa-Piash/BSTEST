using API.Data;
using API.Data.Model;
using API.Repository.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Repository.Concrete
{
    public class CommentRepository : ICommentRepository
    {
        private readonly DatabaseContext _context;
        public CommentRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<Comments> AddComment(Comments comment)
        {
            try
            {
                _context.Comments.Add(comment);
                await _context.SaveChangesAsync();
                return comment;
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
                var res = await _context.Comments.ToListAsync();
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<IEnumerable<Comments>> GetAllComments(int[] postId,int index,int count)
        {
            try
            {
                var res = await _context.Comments.Where(w=> postId.Contains(w.PostId) && w.IsActive && !w.IsDeleted).Skip(index).Take(count).ToListAsync();
                return res;
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
                var res = await _context.Comments.FirstOrDefaultAsync(w => w.Id == commentId);
                return res;
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
                _context.Comments.Remove(comment);
                await _context.SaveChangesAsync();
                return true;
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
                _context.Comments.Update(comment);
                await _context.SaveChangesAsync();
                return comment;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
