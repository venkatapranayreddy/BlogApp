using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogApplication.Data;
using BlogApplication.Dtos.Articles;
using BlogApplication.Interfaces;
using BlogApplication.Mappers;
using BlogApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogApplication.Repository
{
    
    public class ArticleRepository : IArticleRepository
    {

        private readonly ApplicationDBContext _applicationDBContext;

        public ArticleRepository(ApplicationDBContext applicationDBContext)
        {
            _applicationDBContext = applicationDBContext;

        }

        public async Task<bool> ArticleExists(int id)
        {
            return await _applicationDBContext.Articles.AnyAsync(i => i.Id == id);
        }

        public async Task<Articles> CreateArticleAsync(Articles article)
        {
            await _applicationDBContext.Articles.AddAsync(article);
            await _applicationDBContext.SaveChangesAsync();

            return article;
        }

        public async Task<Articles?> DeleteArticleAsync(int id)
        {
            var DeletingArticle = await _applicationDBContext.Articles
                                        .Include(s => s.Comments)
                                        .FirstOrDefaultAsync(i => i.Id == id);

            if(DeletingArticle == null)
             {
                return null;
            }
            _applicationDBContext.RemoveRange(DeletingArticle.Comments);
            _applicationDBContext.Remove(DeletingArticle);
            await _applicationDBContext.SaveChangesAsync();
            return DeletingArticle;



        }

        public async Task<List<Articles>>  GetAllAsync()
        {
            var article = await _applicationDBContext.Articles
                    .Include(a => a.appUser)
                    .Include(c=> c.Comments)
                    .ThenInclude( a => a.appUser)
                    .ToListAsync();

            return article;
        }

        
        public async Task<Articles?> GetByIdAsync(int id)
        {
           return await _applicationDBContext.Articles
                        .Include(c=> c.Comments)
                        .ThenInclude( a => a.appUser)
                        .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Articles?> UpdateArticleAsync(int id, UpdateArticleDto updateArticleDto)
        {
            var updateArticle = await _applicationDBContext.Articles.Include( a => a.appUser).FirstOrDefaultAsync(i => i.Id == id);

            if(updateArticle == null){
                return null;
            }
            updateArticle.Title = updateArticleDto.Title;
            updateArticle.Description = updateArticleDto.Description;
            updateArticle.Category = updateArticleDto.Category;
            
            
            await _applicationDBContext.SaveChangesAsync();
            return updateArticle;

        }

         public async Task<string>  Upload(IFormFile file)
        {
            //extension
            List<string> validExtentions = new List<string>(){".jpg", ".png", ".gif"};
            var extention =Path.GetExtension(file.FileName);
            if(!validExtentions.Contains(extention))
            {
                return $"Extention is not valid({string.Join(',', validExtentions)})";
            }

            //filesize
            long size = file.Length;
            if(size > (5*1024*1024))
            {return "Max sixe can 5mb";}


            //name changing
            string FileName = Guid.NewGuid().ToString()+extention;
            string path = Path.Combine(Directory.GetCurrentDirectory(), "uploads");
            using FileStream stream = new FileStream(Path.Combine(path, FileName) +  FileName, FileMode.Create);
            await file.CopyToAsync(stream);
            
            return FileName;


        }
       
    }
}