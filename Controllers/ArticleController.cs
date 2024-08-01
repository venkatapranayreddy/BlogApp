using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogApplication.Data;
using BlogApplication.Dtos.Articles;
using BlogApplication.Extensions;
using BlogApplication.Interfaces;
using BlogApplication.Mappers;
using BlogApplication.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogApplication.Controllers
{
    [Route("api/Article")]
    [ApiController]
    public class ArticleController :ControllerBase
    {
        private readonly ApplicationDBContext _applicationDBContext;
        private readonly IArticleRepository _iarticleRepository;
        private readonly UserManager<AppUser> _userManager;
        public ArticleController(ApplicationDBContext applicationDBContext, IArticleRepository iarticleRepository, UserManager<AppUser> userManager)
        {
            _applicationDBContext = applicationDBContext;
            _iarticleRepository = iarticleRepository;
            _userManager = userManager;
        }

        [HttpGet]
        // [Authorize]
        public async Task<IActionResult> GetAllArticles()
        {
            var articles = await _iarticleRepository.GetAllAsync();

            var articleDto = articles.Select(c => c.GetArticlesDto());

            return Ok(articleDto);
        }


        [HttpGet("{id:int}")]
        [Authorize]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var articleById = await _iarticleRepository.GetByIdAsync(id);
            
            if(articleById == null)
            {
                return NotFound();
            }
            return Ok(articleById);
        }






        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateArticle([FromForm] CreateArticleDto createArticleDto, IFormFile file)
        {
            if(!ModelState.IsValid){
            return BadRequest(ModelState);
        }
            

               var user = User.GetUsername();
            var getUser = await _userManager.FindByNameAsync(user);
             if (getUser == null)  return Unauthorized();
             var fileUploader = await _iarticleRepository.Upload(file);
                var article  = createArticleDto.CreateArticleDto();
                article.FilePath = fileUploader;
                article.AppUserId = getUser.Id;
             await _iarticleRepository.CreateArticleAsync(article);
             
            return CreatedAtAction(nameof(GetById), new { id = article.Id }, article.GetArticlesDto());

        }


        [HttpPut]
        [Route("{id:int}")]
        [Authorize]
        public async Task<IActionResult> UpdateArticle([FromRoute] int id, [FromBody] UpdateArticleDto updateArticleDto,IFormFile file)
        {
            
             var fileUploader = await _iarticleRepository.Upload(file);
          var  articles =  await _iarticleRepository.UpdateArticleAsync(id, updateArticleDto);
              articles.FilePath = fileUploader;
          if(articles == null) {
            return NotFound();
          }

           return Ok(articles.GetArticlesDto());
            
            
        }

        [HttpDelete]
        [Route("{id:int}")]
        [Authorize]
        public async Task<IActionResult> DeleteArticle([FromRoute] int id)
        {
            var Deletedarticle = await _iarticleRepository.DeleteArticleAsync(id);
            if(Deletedarticle == null) 
            {
                return NotFound();
            }
        
            return NoContent();
        }



       
        
    }
}