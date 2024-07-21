using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using BlogApplication.Data;
using BlogApplication.Dtos.Comments;
using BlogApplication.Interfaces;
using BlogApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogApplication.Repository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDBContext _applicationDBContext;
        public CommentRepository(ApplicationDBContext applicationDBContext)
        {
            _applicationDBContext = applicationDBContext;

        }

        public async Task<Comments> CreateCommentAsync(Comments comments)
        {
            await _applicationDBContext.Comments.AddAsync(comments);
            await _applicationDBContext.SaveChangesAsync();

            return comments;
        }

        public async Task<Comments> DeleteCommentByIdAsync(int id)
        {
            var deleteComments  =  await _applicationDBContext.Comments.FirstOrDefaultAsync(c => c.Id == id);
            if (deleteComments == null) return null;

             _applicationDBContext.Remove(deleteComments);
            await _applicationDBContext.SaveChangesAsync();
            return deleteComments;
        }

        public async Task<Comments?> GetCommentByIdAsync(int id)
        {
            var commentId = await _applicationDBContext.Comments.FirstOrDefaultAsync(c => c.Id == id);

            return commentId;
        }

        public async Task<List<Comments>> GetCommentsAsync()
        {
            var Comments =  await _applicationDBContext.Comments.Include(a => a.appUser).ToListAsync();
            
             return Comments;
        }

        public async Task<Comments> UpdateCommentAsync(int id, UpdateCommentDto updateCommentDto)
        {
            var existingcomment = await _applicationDBContext.Comments.FindAsync(id);

            if (existingcomment == null) return null;

            existingcomment.Content = updateCommentDto.Content;

            await _applicationDBContext.SaveChangesAsync();

            return existingcomment;
        }


       

       
    }
}

//BASE REPOSITORY WORK ON IT
