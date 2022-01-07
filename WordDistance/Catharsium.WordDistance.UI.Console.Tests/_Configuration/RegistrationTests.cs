using Catharsium.Util.IO.Console.Interfaces;
using Catharsium.Util.Testing.Extensions;
using Catharsium.WordDistance.Core.Logic.Configuration;
using Catharsium.WordDistance.Logic.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
namespace Catharsium.WordDistance.Core.Logic.Tests.Configuration;

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