using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogApplication.Dtos.Comments;
using BlogApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogApplication.Interfaces
{
    public interface ICommentRepository
    {
        Task<Comments> CreateCommentAsync(Comments comments);
        Task<Comments> DeleteCommentByIdAsync(int id);
        Task<Comments?> GetCommentByIdAsync(int id);
        Task<List<Comments>>  GetCommentsAsync();
        Task<Comments> UpdateCommentAsync(int id, UpdateCommentDto updateCommentDto);
    }
}