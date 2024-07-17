using System.Net;
using AdvancedAPI.Data.ViewModels.Houses;
using AdvancedAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace AdvancedAPI.Controllers;
/// <summary>
/// House api provided operation to main the houses.
/// </summary>
[ApiController, Route("api/house")]
public class HouseController : ControllerBase
{

    /// <summary>
    /// Constructor.
    /// </summary>
    public HouseController()
    {
    }

    /// <summary>
    /// Obtains a list of houses.
    /// </summary>
    [HttpGet, Route("overview")]
    [ProducesResponseType(typeof(List<HouseResponseModel>), 200)]
    [ProducesResponseType(typeof(ErrorResponseModel), 401)]
    [ProducesResponseType(typeof(ErrorResponseModel), 404)]
    [ProducesResponseType(typeof(ErrorResponseModel), 500)]
    public async Task<IActionResult> Overview(CancellationToken cancellationToken = default)
    {
        return Ok(new List<HouseResponseModel>());
    }
}