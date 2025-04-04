using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using api.Models;
using System.Linq;

namespace Motown.API
{
    public static class GetArtists
    {
        [FunctionName("GetArtists")]
public static async Task<IActionResult> Run(
    [HttpTrigger(AuthorizationLevel.Anonymous, "get",  Route = null)] HttpRequest req,
    ILogger log)
{
    using (var db = new MotownDbContext())
    {
        return new OkObjectResult(db.Artists.ToList());
    }
}
    }
}
