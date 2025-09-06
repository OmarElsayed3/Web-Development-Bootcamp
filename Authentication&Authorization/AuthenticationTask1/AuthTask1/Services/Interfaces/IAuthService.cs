using AuthTask1.Models;
using AuthTask1.Dto;
namespace AuthTask1.Services.Interfaces;


public interface IAuthService
{
    public Task<Response<AuthModel>> Register(RegisterModel model);
    public Task<Response<AuthModel>> Login(LoginModel model);
}