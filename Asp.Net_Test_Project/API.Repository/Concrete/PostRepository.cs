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
    public class PostRepository: IPostRepository
    {
        private readonly DatabaseContext _context;
        public PostRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<Posts> AddPost(Posts post)
        {
            try
            {
                _context.Posts.Add(post);
                await _context.SaveChangesAsync();
                return post;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<IEnumerable<Posts>> GetAllPosts()
        {
            try
            {
                var res = await _context.Posts.Select(s => s).ToListAsync();
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<IEnumerable<Posts>> GetAllPosts(int index, int count)
        {
            try
            {
                var res = await _context.Posts.Select(s => s).Skip(index).Take(count).ToListAsync();
                return res;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Posts> GetPost(int postId)
        {
            try
            {
                var res = await _context.Posts.FirstOrDefaultAsync(w => w.Id == postId);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<bool> RemovePost(Posts post)
        {
            try
            {
                _context.Posts.Remove(post);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<Posts> UpdatePost(Posts post)
        {
            try
            {
                _context.Posts.Update(post);
                await _context.SaveChangesAsync();
                return post;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
