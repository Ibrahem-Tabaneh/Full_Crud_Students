using EducationPlatform.Application.DTOs;
using EducationPlatform.Application.DTOs.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPlatform.Application.Interfaces
{
    public interface IAuthRepository
    {
        Task<TokenResponse> Login(LoginRequest request);
        Task<TokenResponse> Refresh(RefreshRequest request);
        Task Logout(LogoutRequest request);
    }
}
