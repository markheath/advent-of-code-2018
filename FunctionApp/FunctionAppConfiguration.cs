using System;
using System.Collections.Generic;
using System.Text;
using FunctionApp.Command;
using FunctionApp.Handlers;
using FunctionMonkey.Abstractions;
using FunctionMonkey.Abstractions.Builders;

namespace FunctionApp
{
    public class FunctionAppConfiguration : IFunctionAppConfiguration
    {
        public void Build(IFunctionHostBuilder builder)
        {
            builder
                .Setup((serviceCollection, commandRegistry) =>
                {
                    commandRegistry.Register<SolveCommandHandler>();
                })
                .Functions(functions => functions
                    .HttpRoute("/api/v1/Solve", route => route
                        .HttpFunction<SolveCommand>()
                    )
                );
        }
    }
}
