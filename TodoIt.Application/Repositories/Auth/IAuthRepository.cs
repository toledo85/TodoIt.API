using TodoIt.Application.Dtos;
using TodoIt.Application.Dtos.User;

namespace TodoIt.Application.Repositories.Auth;

public interface IAuthRepository {
    Task<ServiceResponse<string>> Register(UserRegisterDto user);
    Task<ServiceResponse<string>> Login(string username, string password);
    Task<bool> UserExists(string username);
}