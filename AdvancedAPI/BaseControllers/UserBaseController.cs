using Microsoft.AspNetCore.Authorization;

namespace AdvancedAPI.BaseControllers;

/// <summary>
/// Controller for admin related endpoints.
/// </summary>
[Authorize(Policy = "UserOrAdmin")]
public class UserBaseController : BaseController
{
    /// <summary>
    /// Constructor.
    /// </summary>
    public UserBaseController()
    {
    }
}