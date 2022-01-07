using Catharsium.Util.Testing.Extensions;
using Catharsium.WordCloud._Configuration;
using Catharsium.WordCloud.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
namespace Catharsium.WordCloud.Logic.Tests._Configuration;

[TestClass]
public class RegistrationTests
{
    [TestMethod]
    public void AddWordDistanceLogic_RegistersDependencies()
    {
        var serviceCollection = Substitute.For<IServiceCollection>();
        var configuration = Substitute.For<IConfiguration>();

        serviceCollection.AddWordCloudLogic(configuration);
        serviceCollection.ReceivedRegistration<IWordCounter, WordCounter>();
        serviceCollection.ReceivedRegistration<IWordSanitizer, WordSanitizer>();
    }


    [TestMethod]
    public void AddWordDistanceLogic_RegistersPackages()
    {
        var serviceCollection = Substitute.For<IServiceCollection>();
        var configuration = Substitute.For<IConfiguration>();

        serviceCollection.AddWordCloudLogic(configuration);
    }
}