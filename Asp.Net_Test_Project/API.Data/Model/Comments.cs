using System;
using System.Collections.Generic;
using System.Text;

namespace API.Data.Model
{
    public partial class Comments
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public int PostId { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public int InsertedBy { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime InsertedOn { get; set; } = DateTime.Now;
        public DateTime UpdatedOn { get; set; } = DateTime.Now;
    }
}
