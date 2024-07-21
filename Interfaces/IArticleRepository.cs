using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogApplication.Dtos.Articles;
using BlogApplication.Models;

namespace BlogApplication.Interfaces
{
    public interface IArticleRepository
    {
        
        Task<List<Articles>> GetAllAsync();
        Task<Articles?> GetByIdAsync(int id);

        Task<Articles> CreateArticleAsync(Articles article);
        Task<Articles?> UpdateArticleAsync(int id, UpdateArticleDto updateArticleDto);
        Task<Articles?>  DeleteArticleAsync(int id);

        Task<bool> ArticleExists(int id);

        Task<string> Upload(IFormFile file);
    }
}