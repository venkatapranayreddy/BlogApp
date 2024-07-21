using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogApplication.Models;

namespace BlogApplication.Interfaces
{
    public interface ITokenService
    {
        string createToken(AppUser appUser);
    }
}