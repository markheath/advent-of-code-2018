using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AzureFromTheTrenches.Commanding.Abstractions;
using FunctionApp.Command;
using Solvers;

namespace FunctionApp.Handlers
{
    internal class SolveCommandHandler : ICommandHandler<SolveCommand, (string,string)>
    {
        public Task<(string, string)> ExecuteAsync(SolveCommand command, (string, string) previousResult)
        {
            var input = Regex.Split(command.Input, "\r\n|\n")
                .Where(s => !string.IsNullOrEmpty(s))
                .ToArray(); 
            switch (command.Day)
            {
                case 1:
                    return Task.FromResult(($"{Day1.Part1Solver(input)}", $"{Day1.Part2Solver(input)}"));
                case 2:
                    return Task.FromResult(($"{Day2.Part1Solver(input)}", $"{Day2.Part2Solver(input)}"));
                case 3:
                    return Task.FromResult(($"{Day3.Part1Solver(input)}", $"{Day3.Part2Solver(input)}"));
            }
            throw new ArgumentException("Invalid Day");
        }
    }
}
