using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AdvancedAPI.BaseControllers;

/// <summary>
/// Controller for admin related endpoints.
/// </summary>
[Authorize(Policy = "AdminPolicy")]
[Route("admin")]
public class AdminBaseController : BaseController
{
    /// <summary>
    /// Constructor.
    /// </summary>
    public AdminBaseController()
    {
    }
}
