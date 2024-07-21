using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogApplication.Dtos.Articles;
using BlogApplication.Models;

namespace BlogApplication.Mappers
{
    public static class ArticleMapper
    {

        public static ArticlesDto GetArticlesDto(this Articles articlesModel)
        {
            return new ArticlesDto 
            {
                Id = articlesModel.Id,
                Title = articlesModel.Title,
                Description = articlesModel.Description,
                Category = articlesModel.Category,
                CreatedBy = articlesModel.appUser.UserName,
                FilePath = articlesModel.FilePath,
                Comments = articlesModel.Comments.Select(c => c.GetCommentsDto()).ToList()
            };
        }


        public static Articles CreateArticleDto(this CreateArticleDto createArticleDto)

        {
            return new Articles
            {
                Title = createArticleDto.Title,
                Description = createArticleDto.Description,
                Category = createArticleDto.Category
            };
        }

        


       
    }
}