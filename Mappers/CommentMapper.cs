using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogApplication.Dtos.Comments;
using BlogApplication.Models;

namespace BlogApplication.Mappers
{
    public static class CommentMapper
    {
        public static CommentsDto GetCommentsDto(this Comments commentsModel)
        {
            return new CommentsDto
            {   Id = commentsModel.Id, 
                Content = commentsModel.Content,
                CreatedOn = commentsModel.CreatedOn,
                createdBy = commentsModel.appUser.UserName,
                ArticleId = commentsModel.ArticleId
            };
        }

        public static Comments createCommentDto(this CreateCommentDto createCommentDto, int ArticleId)
        {
            return new  Comments

            {
                Content = createCommentDto.Content,
                ArticleId = ArticleId
            };
        }


      
    }
}