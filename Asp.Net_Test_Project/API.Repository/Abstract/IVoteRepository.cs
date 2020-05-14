using API.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace API.Repository.Abstract
{
    public interface IVoteRepository
    {
        Task<bool> AddVote (Votes votes);
        Task<bool>UpdateVote(Votes votes);
        Task<IEnumerable<Votes>> GetVote(int[] commentId);
    }
}
