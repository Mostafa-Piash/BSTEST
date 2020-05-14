using System;
using System.Collections.Generic;
using System.Text;

namespace API.Data.Model
{
    public partial class Votes
    {
        public int Id { get; set; }
        public bool IsUpVoted { get; set; }
        public int CommentId { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public int InsertedBy { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime InsertedOn { get; set; } = DateTime.Now;
        public DateTime UpdatedOn { get; set; } = DateTime.Now;
    }
}
