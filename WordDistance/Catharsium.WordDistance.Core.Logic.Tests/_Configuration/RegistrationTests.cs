using Catharsium.Util.Testing.Extensions;
using Catharsium.WordDistance.Core.Logic.Configuration;
using Catharsium.WordDistance.Core.Logic.Interfaces;
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
    public void AddWordDistanceLogic_RegistersDependencies()
    {
        var serviceCollection = Substitute.For<IServiceCollection>();
        var configuration = Substitute.For<IConfiguration>();

        serviceCollection.AddWordDistanceLogic(configuration);
        serviceCollection.ReceivedRegistration<IDistanceCalculator, DistanceCalculator>();
        serviceCollection.ReceivedRegistration<ISimilarityCalculator, SimilarityCalculator>();
    }


    [TestMethod]
    public void AddWordDistanceLogic_RegistersPackages()
    {
        var serviceCollection = Substitute.For<IServiceCollection>();
        var configuration = Substitute.For<IConfiguration>();

        serviceCollection.AddWordDistanceLogic(configuration);
    }
}