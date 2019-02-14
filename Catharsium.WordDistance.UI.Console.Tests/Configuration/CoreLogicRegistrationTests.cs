using Catharsium.Util.Testing.Extensions;
using Catharsium.WordDistance.Core.Logic.Configuration;
using Catharsium.WordDistance.Core.Logic.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace Catharsium.WordDistance.Core.Logic.Tests.Configuration
{
    [TestClass]
    public class CoreLogicRegistrationTests
    {
        [TestMethod]
        public void AddFileSync_RegistersDependencies()
        {
            var serviceCollection = Substitute.For<IServiceCollection>();

            serviceCollection.AddWordDistance();
            serviceCollection.ReceivedRegistration<IDistanceCalculator, DistanceCalculator>();
            serviceCollection.ReceivedRegistration<ISimilarityCalculator, SimilarityCalculator>();
        }
    }
}