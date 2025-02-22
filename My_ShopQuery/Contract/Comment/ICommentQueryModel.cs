using System.Collections.Generic;

namespace My_ShopQuery.Contract.Comment
{
    public interface ICommentQueryModel
    {
        List<CommentQueryModel> GetCommentQuery(long parentId);
    }
}