using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogApplication.Data;
using BlogApplication.Dtos.Comments;
using BlogApplication.Extensions;
using BlogApplication.Interfaces;
using BlogApplication.Mappers;
using BlogApplication.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogApplication.Controllers
{
    [Route("api/Comment")]
    [ApiController]
    public class CommentController :ControllerBase
    {
       
        private readonly ICommentRepository _icommentRepository;
        private readonly IArticleRepository _iarticleRepository;
        private readonly UserManager<AppUser> _userManager;


        public CommentController( ICommentRepository icommentRepository, IArticleRepository iarticleRepository, UserManager<AppUser> userManager )
        {
            
             _icommentRepository = icommentRepository;
             _iarticleRepository =iarticleRepository;
             _userManager = userManager;

        }

        [HttpGet]
        public async Task<IActionResult> GetAllComment()
        {
            var comment = await _icommentRepository.GetCommentsAsync();

            var commentDto = comment.Select(c => c.GetCommentsDto());

            return Ok(commentDto);
        }

        [HttpPost("{articleId:int}")]
        public async Task<IActionResult> CreateComment([FromRoute] int articleId,[FromBody] CreateCommentDto createCommentDto)
        {
            var user = User.GetUsername();
            var getUser = await _userManager.FindByNameAsync(user);
            if(!await _iarticleRepository.ArticleExists(articleId))
            {
                return BadRequest("Article is not posted yet");
            }

            var comment =  createCommentDto.createCommentDto(articleId);
            comment.AppUserId = getUser.Id;
            await _icommentRepository.CreateCommentAsync(comment);

            return CreatedAtAction(nameof(GetCommentById), new {id = comment.Id}, comment.GetCommentsDto());
        }

         
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetCommentById([FromRoute] int id)
        {
            var commentId = await  _icommentRepository.GetCommentByIdAsync(id);
            if(commentId == null)
            {
                return NotFound();
            }
            return Ok(commentId.GetCommentsDto());

        }

        [HttpPut("{articleId:int}")]
        public async Task<IActionResult> UpdateCommentById([FromRoute] int articleId,[FromBody] UpdateCommentDto updateCommentDto)
        {
            
            var updateComment = await _icommentRepository.UpdateCommentAsync(articleId, updateCommentDto);

            if(updateComment == null)  return NotFound ("Comment not found");

            return Ok(updateComment.GetCommentsDto());
        }

        [HttpDelete]
        [Route("{id:int}")]
         public async Task<IActionResult> DeleteCommentById([FromRoute] int id)
         {
            var commentId = await _icommentRepository.DeleteCommentByIdAsync(id);
            if(commentId == null)  return NotFound ("Comment not found");

            return NoContent();
         }







    }
}