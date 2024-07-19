using AdvancedAPI.BaseControllers;
using AdvancedAPI.Data.ViewModels;
using AdvancedAPI.Data.ViewModels.Houses;
using Business.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AdvancedAPI.Controllers;

/// <summary>
/// House api provided operation to main the houses.
/// </summary>
[Route("house")]
public class HouseController : BaseController
{
    private readonly IHouseService _houseService;

    private HouseController(IHouseService houseService)
    {
        _houseService = houseService;
    }

    /// <summary>
    /// Obtains a list of houses.
    /// </summary>
    /// <returns>List of  houses.</returns>
    [HttpGet]
    [Route("overview")]
    [ProducesResponseType(typeof(List<HouseResponseModel>), 200)]
    [ProducesResponseType(typeof(ErrorResponseModel), 401)]
    [ProducesResponseType(typeof(ErrorResponseModel), 404)]
    [ProducesResponseType(typeof(ErrorResponseModel), 500)]
    public async Task<IActionResult> Overview(CancellationToken cancellationToken = default)
    {
        List<HouseResponseModel>? houseResponseModels = await _houseService.GetAllHouses(cancellationToken);

        if (houseResponseModels == null || !houseResponseModels.Any())
        {
            return NotFoundResult("Could not find any houses");
        }

        return Ok(new List<HouseResponseModel>());
    }
}
