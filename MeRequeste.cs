using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace StudyAzureFunctions
{
    public class MeRequeste
    {
        private readonly ILogger<MeRequeste> _logger;

        public MeRequeste(ILogger<MeRequeste> logger)
        {
            _logger = logger;
        }

        [Function("MeRequeste")]
        public IActionResult RunMeRequeste([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequest req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");
            return new OkObjectResult("Welcome to Azure Functions!");
        }

        [Function("OLoboPede")]
        public IActionResult RunOLoboPede([HttpTrigger(AuthorizationLevel.Function, "post")] HttpRequest Mimde)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            string lobo = Mimde.Query["lobo"];
            string minde = Mimde.Query["mimde"];

            if (string.IsNullOrEmpty(lobo) || string.IsNullOrEmpty(minde))
            {
                return new BadRequestObjectResult("Por favor, forneça os parâmetros.");
            }
            if (string.Equals(lobo, "pidao") && minde == "papai")
                return new OkObjectResult("MIM DEEEE PAPAAAIIIII!!!");

            return new OkObjectResult($"NÃO DÊ PAPAI >:C!!!");
        }
    }
}
