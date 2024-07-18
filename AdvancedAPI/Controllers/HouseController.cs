using AdvancedAPI.Data.ViewModels;
using AdvancedAPI.Data.ViewModels.Houses;
using Business.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AdvancedAPI.Controllers;

/// <summary>
/// House api provided operation to main the houses.
/// </summary>
[ApiController]
[Route("api/house")]
public class HouseController : ControllerBase
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
            return NotFound(
                new ErrorResponseModel
                {
                    Code = 404,
                    Message = "No houses found",
                });
        }

        return Ok(new List<HouseResponseModel>());
    }
}
