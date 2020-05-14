using API.Data.Model;
using API.Repository.Abstract;
using API.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace API.Service.Concrete
{
    public class VoteService : IVoteService
    {
        private readonly IVoteRepository _repository;
        public VoteService(IVoteRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<Votes>> GetVote(int[] commentId)
        {
            
            try
            {
                return _repository.GetVote(commentId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> GiveVote(Votes votes)
        {
            try
            {
                bool res = false;
                if (votes.Id == 0)
                {
                     res = await _repository.AddVote(votes);
                }
                else
                {
                     res = await _repository.UpdateVote(votes);
                }
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
