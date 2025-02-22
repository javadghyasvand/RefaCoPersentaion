using System;

namespace My_ShopQuery.Contract.Comment
{
    public class CommentQueryModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public string CommentDate { get; set; }
        public DateTime Date { get; set; }
        public bool IsConfirmed { get; set; }
        public bool IsCancel { get; set; }
        public long ParentId { get; set; }
        public long OwnerId { get; set; }
        public string ParentName { get; set; }
        

    }
}