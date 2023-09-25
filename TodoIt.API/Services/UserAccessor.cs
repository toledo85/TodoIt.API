using System.Security.Claims;
using Todoit.Application.Interfaces;

namespace TodoIt.API.Services;

public class UserAccessor : IUserAccessor {
    private readonly IHttpContextAccessor _httpContextAccessor;

    public UserAccessor(IHttpContextAccessor httpContextAccessor) {
        _httpContextAccessor = httpContextAccessor;
    }

    public int GetUserName() {
        var claim = _httpContextAccessor.HttpContext!.User.FindFirst(ClaimTypes.NameIdentifier)!;
        return int.Parse(claim.Value);
    }
}