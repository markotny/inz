﻿using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ResourceServer.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MetaController : Controller
	{
        [HttpGet("/info")]
        public ActionResult<string> Info()
        {
            var assembly = typeof(Startup).Assembly;

            var creationDate = System.IO.File.GetCreationTime(assembly.Location);
            var version = FileVersionInfo.GetVersionInfo(assembly.Location).ProductVersion;

            return Ok($"Version: {version}, Last Updated: {creationDate}");
        }
    }
}
