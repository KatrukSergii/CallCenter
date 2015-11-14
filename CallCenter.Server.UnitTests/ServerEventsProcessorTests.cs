using System;
using NUnit.Framework;
using CallCenter.Server;
using CallCenterRepository.Controllers;
using Moq;

namespace CallCenter.Server.UnitTests
{
    [TestFixture]
    public sealed class ServerEventsProcessorTests
    {

        [ExpectedException(typeof(ArgumentNullException))]
        [Test]
        public void ConstructorThrowException()
        {
            new ServerEventsProcessor(null);
        }

        [Test]
        public void TestChatProcessorWasCreated()
        {
            ServerEventsProcessor serverEventsProcessor = new ServerEventsProcessor(Mock.Of<IControllerFactory>());
            Assert.NotNull(serverEventsProcessor.ChatProcessor);
        }

        [Test]
        public void TestOperatorProcessorWasCreated()
        {
            ServerEventsProcessor serverEventsProcessor = new ServerEventsProcessor(Mock.Of<IControllerFactory>());
            Assert.NotNull(serverEventsProcessor.OperatorProcessor);
        }

    }
}
