using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AdvancedAPI.BaseControllers;

/// <summary>
/// Controller for admin related endpoints.
/// </summary>
[Authorize(Policy = "AdminPolicy")]
[Route("api/admin/[controller]")]
public class AdminBaseController : BaseController
{
    /// <summary>
    /// Constructor.
    /// </summary>
    public AdminBaseController()
    {
    }
}
