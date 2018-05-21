using AutoMapper;
using BusinessLogicLayer.DataTransferObjects;
using BusinessLogicLayer.Exceptions;
using BusinessLogicLayer.Interfaces;
using Data_Access_Layer.Entities;
using Data_Access_Layer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogicLayer.Services
{
    public class CommentService : ICommentService
    {
        IUnitOfWork db { get; set; }

        public CommentService(IUnitOfWork uow)
        {
            db = uow;
        }

        public void Create(CommentDto item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            db.Comments.Delete(id);
        }

        public IEnumerable<CommentDto> FindByCriteria(Func<CommentDto, bool> predicate)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Comment, CommentDto>()).CreateMapper();
            var result = mapper.Map<IEnumerable<Comment>, List<CommentDto>>(db.Comments.GetAll());
            return result.Where(predicate);
        }

        public CommentDto GetComment(int id)
        {          
            var comment = db.Comments.Get(id);
            if (comment == null)
                throw new ValidationException("Comment is not found", "");

            return new CommentDto { CommentID = comment.CommentID, Body = comment.Body, ClientProfileID = (int)comment.ClientProfileID,   };
        }

        public IEnumerable<CommentDto> GetComments()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Comment, CommentDto>()).CreateMapper();
            return mapper.Map<IEnumerable<Comment>, List<CommentDto>>(db.Comments.GetAll());
        }

        public void Update(CommentDto item)
        {
            throw new NotImplementedException();
        }
    }
}
