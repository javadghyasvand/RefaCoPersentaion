using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using CommentManagement.Infrastructure.EFCore;
using GeneralManagement.Infrastructure.EFCore;
using My_Shop_Framework.Application;
using My_ShopQuery.Contract.Comment;

namespace My_ShopQuery.Query
{
    public class CommentQuery:ICommentQueryModel
    {
        private readonly CommentContext _commentContext;

        public CommentQuery(CommentContext commentContext)
        {
            _commentContext = commentContext;
        }

        public List<CommentQueryModel> GetCommentQuery(long ownerId)
        {
            
            new List<CommentQueryModel>();
            var comments = _commentContext.Comments.Where(c => c.OwnerId == ownerId && c.IsConfirmed)
                .Select(c => new CommentQueryModel
                {
                    Name = c.Name,
                    Email = c.Email,
                    Date = c.CreationDateTime,
                    Message = c.Message
                })
                .ToList();
            return comments;
        }
    }
}