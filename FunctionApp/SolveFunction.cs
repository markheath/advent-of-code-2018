using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Solvers;

namespace FunctionApp
{
    public static class SolveFunction
    {
        [FunctionName("Solve")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = "solve/{day}")] HttpRequest req,
            int day, ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var input = Regex.Split(requestBody, "\r\n|\n")
                .Where(s => !string.IsNullOrEmpty(s))
                .ToArray();
            string part1 = null;
            string part2 = null;
            switch (day)
            {
                case 1:
                    part1 = Day1.Part1Solver(input).ToString();
                    part2 = Day1.Part2Solver(input).ToString();
                    break;
                case 2:
                    part1 = Day2.Part1Solver(input).ToString();
                    part2 = Day2.Part2Solver(input);
                    break;
                case 3:
                    part1 = Day3.Part1Solver(input).ToString();
                    part2 = Day3.Part2Solver(input).ToString();
                    break;
            }
            

            return part1 != null
                ? (ActionResult)new OkObjectResult(new { part1, part2 })
                : new BadRequestObjectResult("Provide a valid day");
        }
    }
}
