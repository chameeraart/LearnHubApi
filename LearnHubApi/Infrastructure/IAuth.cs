using LearnHubApi.Dto;
using LearnHubApi.Models;

namespace LearnHubApi.Infrastructure
{
    public interface IAuth
    {
        UserDto Auth(LoginDto loginDto);
    }
}
