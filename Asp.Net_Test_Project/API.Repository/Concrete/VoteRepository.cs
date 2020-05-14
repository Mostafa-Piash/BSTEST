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
    public class VoteRepository : IVoteRepository
    {
        private readonly DatabaseContext _context;
        public VoteRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<bool> AddVote(Votes votes)
        {
            try
            {
                _context.Votes.Add(votes);
                var rowUpdate = await _context.SaveChangesAsync();
                return rowUpdate > 0 ? true : false;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<IEnumerable<Votes>> GetVote(int[] commentId)
        {
            try
            {
                var res = await _context.Votes.Where(w=> commentId.Contains(w.CommentId) && w.IsActive && !w.IsDeleted).ToListAsync();
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<bool> UpdateVote(Votes votes)
        {
            try
            {
                _context.Votes.Update(votes);
                var rowUpdate = await _context.SaveChangesAsync();
                return rowUpdate > 0 ? true : false; ;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
