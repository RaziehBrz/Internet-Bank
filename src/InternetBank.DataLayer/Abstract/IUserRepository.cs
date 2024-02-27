using System.Threading.Tasks;
using InternetBank.Data;
using InternetBank.Models;
using Microsoft.AspNetCore.Identity;

namespace InternetBank.Repository
{
    public interface IUserRepository
    {
        Task<IdentityResult> SignUp(SignUpDto signUpDto);
        Task<string> Login(LoginDto loginDto);
    }
}