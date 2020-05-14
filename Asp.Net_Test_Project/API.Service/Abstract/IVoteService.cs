using API.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace API.Service.Abstract
{
    public interface IVoteService
    {
        Task<bool> GiveVote(Votes votes);
        Task<IEnumerable<Votes>> GetVote(int[] commentId);
    }
}
