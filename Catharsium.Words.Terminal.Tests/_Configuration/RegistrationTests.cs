using Catharsium.Util.IO.Console.Interfaces;
using Catharsium.Util.Testing.Extensions;
using Catharsium.WordDistance.Interfaces;
using Catharsium.Words.Terminal._Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
namespace Catharsium.Words.TerminalTests._Configuration;

[TestClass]
public class RegistrationTests
{
    [TestMethod]
    public void AddWordDistanceCommand_RegistersDependencies()
    {
        var serviceCollection = Substitute.For<IServiceCollection>();
        var configuration = Substitute.For<IConfiguration>();

        serviceCollection.AddWordDistanceCommand(configuration);
    }


    [TestMethod]
    public void AddWordDistanceCommand_RegistersPackages()
    {
        var serviceCollection = Substitute.For<IServiceCollection>();
        var configuration = Substitute.For<IConfiguration>();

        serviceCollection.AddWordDistanceCommand(configuration);
        serviceCollection.ReceivedRegistration<IDistanceCalculator>();
        serviceCollection.ReceivedRegistration<IConsole>();
    }
}