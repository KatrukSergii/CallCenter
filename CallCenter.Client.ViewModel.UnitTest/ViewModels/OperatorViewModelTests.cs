using System;
using CallCenter.Client.Communication;
using CallCenter.Client.ViewModel.Helpers;
using CallCenter.Client.ViewModel.ViewModels;
using CallCenter.Common.Entities;
using CallCenter.ServiceContracts.Services;
using Moq;
using NUnit.Framework;

namespace CallCenter.Client.ViewModel.UnitTests.ViewModels
{
    [TestFixture]
    public class OperatorViewModelTests
    {
        [SetUp]
        public void Init()
        {
            this.settings = new Mock<ISettings>();
            this.connection = new Mock<IConnection>();
            this.@operator = new Mock<IOperator>();
            this.viewModelFactory = new Mock<IViewModelFactory>();
            this.windowService = new Mock<IWindowService>();
            this.chatService = new Mock<IChatService>();
            this.connection.Setup(connection1 => connection1.ChatService).Returns(this.chatService.Object);
            this.operatorViewModel = new OperatorViewModel(this.@operator.Object, this.connection.Object);
        }

        private Mock<ISettings> settings;
        private Mock<IConnection> connection;
        private Mock<IOperator> @operator;
        private Mock<IViewModelFactory> viewModelFactory;
        private Mock<IWindowService> windowService;
        private Mock<IChatService> chatService;
        private OperatorViewModel operatorViewModel;

        [Test]
        public void ChekAgentId()
        {
            int operatorId = 1;
            this.@operator.Setup(@operator => @operator.Id).Returns(operatorId);
            Assert.AreEqual(this.operatorViewModel.Id, operatorId);
        }

        [Test]
        public void ChekAgentNumber()
        {
            string operatorNumber = "3001";
            this.@operator.Setup(@operator => @operator.Number).Returns(operatorNumber);
            Assert.AreEqual(this.operatorViewModel.Number, operatorNumber);
        }

        [Test]
        public void TestInitGetChatServiceWasCalled()
        {
            this.operatorViewModel.Init();
            this.connection.Verify(connection1 => connection1.ChatService, Times.Once);
        }

        [ExpectedException(typeof (ArgumentNullException))]
        [Test]
        public void TestThrowViewModelFactoryArgumentNullException()
        {
            new OperatorViewModel(null, this.connection.Object);
        }

        [ExpectedException(typeof (ArgumentNullException))]
        [Test]
        public void TestThrowWindowSeriveArgumentNullException()
        {
            new OperatorViewModel(this.@operator.Object, null);
        }
    }
}