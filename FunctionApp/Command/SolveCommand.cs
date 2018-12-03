using System;
using System.Collections.Generic;
using System.Text;
using AzureFromTheTrenches.Commanding.Abstractions;

namespace FunctionApp.Command
{
    public class SolveCommand : ICommand<(string,string)>
    {
        public int Day { get; set; }
        public string Input { get; set; }
    }
}
