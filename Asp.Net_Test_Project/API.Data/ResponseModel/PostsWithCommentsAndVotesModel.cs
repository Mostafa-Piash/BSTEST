using System;
using System.Collections.Generic;
using System.Text;

namespace API.Data.ResponseModel
{
    public class PostsWithCommentsAndVotesModel
    {
        public int TotalPost { get; set; }
        public List<Post> Posts { get; set; }
    }
    public class Post
    {
        public int PostId { get; set; }
        public string PostData { get; set; }
        public string UserName { get; set; }
        public DateTime PostedDate { get; set; }
        public int TotalComment { get; set; }
        public List<Comment> Comments { get; set; }
    }
    public class Comment
    {
        public int CommentId { get; set; }
        public string CommentData { get; set; }
        public string UserName { get; set; }
        public DateTime PostedDate { get; set; }
        public int UpVotes { get; set; }
        public int DownVotes { get; set; }
    }
}
