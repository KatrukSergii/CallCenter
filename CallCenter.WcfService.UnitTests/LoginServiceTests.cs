using System;
using CallCenter.Common;
using CallCenter.Common.Entities;
using NUnit.Framework;
using CallCenterRepository.Controllers;
using Moq;

namespace CallCenter.WcfService.UnitTests
{
    [TestFixture]
    public sealed class LoginServiceTests
    {
        [ExpectedException(typeof(ArgumentNullException))]
        [Test]
        public void ConstructorCheckMethod()
        {
            new OpeartorEventsProcessorService(null);
        }

        [ExpectedException(typeof(ArgumentNullException))]
        [Test]
        public void LoginFail()
        {
            OpeartorEventsProcessorService opeartorEventsProcessorService = new OpeartorEventsProcessorService(Mock.Of<IServerEventsProcessor>());
            opeartorEventsProcessorService.ChangeOperatorState(null);
        }
        
        [Test]
        public void LoginSucces()
        {
            string operatorNumber = "3001";
            Mock<IServerEventsProcessor> controllerFactoryMock = new Mock<IServerEventsProcessor>();
            Mock<IOperatorProcessor> operatorControllerMock = new Mock<IOperatorProcessor>();
            Mock<IOperator> operatorMock = new Mock<IOperator>();
            Mock<IOperatorEventInfo> operatorEventInfoMock = new Mock<IOperatorEventInfo>();
            controllerFactoryMock.Setup(factory => factory.OperatorProcessor).Returns(operatorControllerMock.Object);
            operatorControllerMock.Setup(controller => controller.ChangeOperatorState(operatorEventInfoMock.Object)).Returns(operatorMock.Object);
            OpeartorEventsProcessorService opeartorEventsProcessorService = new OpeartorEventsProcessorService(controllerFactoryMock.Object);
            IOperator returntedOperator = opeartorEventsProcessorService.ChangeOperatorState(operatorEventInfoMock.Object);
            Assert.AreEqual(operatorMock.Object, returntedOperator);
        }

    }
}
