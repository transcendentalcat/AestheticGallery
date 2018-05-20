using BusinessLogicLayer.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    public interface ICommentService
    {
        CommentDto GetComment(int id);
        IEnumerable<CommentDto> GetComments();
        IEnumerable<CommentDto> Find(Func<CommentDto, Boolean> predicate);
        void Create(CommentDto item);
        void Update(CommentDto item);
        void Delete(int id);
    }
}
