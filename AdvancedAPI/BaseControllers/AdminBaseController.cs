using Microsoft.AspNetCore.Mvc;

namespace AdvancedAPI.BaseControllers;

/// <summary>
/// Controller for admin related endpoints.
/// </summary>
[Microsoft.AspNetCore.Components.Route("admin")]
[ApiExplorerSettings(GroupName = "Admin")]
public class AdminBaseController : BaseController
{
    /// <summary>
    /// Constructor.
    /// </summary>
    public AdminBaseController()
    {
    }
}
