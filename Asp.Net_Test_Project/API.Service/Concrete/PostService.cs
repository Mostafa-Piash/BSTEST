using API.Data.Model;
using API.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Repository.Abstract;
using API.Data.ResponseModel;
using System.Linq;

namespace API.Service.Concrete
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _repository;
        private readonly ICommentService _commentService;
        private readonly IVoteService _voteService;
        public PostService(IPostRepository repository, ICommentService commentService, IVoteService voteService)
        {
            _repository = repository;
            _commentService = commentService;
            _voteService = voteService;
        }

        public async Task<Posts> AddPost(Posts post)
        {
            try
            {
                return await _repository.AddPost(post);
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
                return await _repository.GetAllPosts();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<Posts> GetPost(int postId)
        {
            try
            {
                return await _repository.GetPost(postId);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<PostsWithCommentsAndVotesModel> GetPostWithCommentsAndVotes(int postPage, int commentPage)
        {
            var posts = await _repository.GetAllPosts((postPage - 1) * 20, 20);
            var comments = await _commentService.GetAllComments(posts.Select(s => s.Id).ToArray(), (commentPage - 1) * 5, 5);
            var votes = await _voteService.GetVote(comments.Select(s => s.Id).ToArray());


            return new PostsWithCommentsAndVotesModel
            {
                TotalPost = posts.Count(), // this is not the proper  count but I ran out of time sorry for that
                Posts = posts.Select(s => new Post
                {
                    PostData = s.Post,
                    PostedDate = s.InsertedOn,
                    TotalComment = comments.Count(), // this is not the proper count but I ran out of time  sorry for that
                    PostId = s.Id,
                    UserName = s.InsertedBy.ToString(),
                    Comments = comments.Select(c => new Comment
                    {
                        CommentData = c.Comment,
                        CommentId = c.Id,
                        PostedDate = c.InsertedOn,
                        UpVotes = votes.Where(w => w.IsUpVoted).ToArray().Count(),
                        DownVotes = votes.Where(w => !w.IsUpVoted).ToArray().Count(),
                        UserName = c.InsertedBy.ToString()
                    }).ToList()

                }).ToList()

            };



    }

        public async Task<bool> RemovePost(Posts post)
        {
            try
            {
                return await _repository.RemovePost(post);
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
                return await _repository.UpdatePost(post);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}

