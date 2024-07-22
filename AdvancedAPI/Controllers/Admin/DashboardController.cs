// <copyright file="DashboardController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using AdvancedAPI.BaseControllers;
using Microsoft.AspNetCore.Mvc;

namespace AdvancedAPI.Controllers.Admin;

/// <summary>
/// Dashboard endpoints.
/// </summary>
[Microsoft.AspNetCore.Components.Route("dashboard")]
public class DashboardController : AdminBaseController
{
    /// <summary>
    /// Constructor.
    /// </summary>
    public DashboardController()
    {
    }

    [HttpGet]
    [Route("overview")]
    public async Task<IActionResult> GetOverview()
    {
        return Ok();
    }
}
