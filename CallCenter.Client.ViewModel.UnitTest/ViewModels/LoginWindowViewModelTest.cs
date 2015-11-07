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
    public class LoginWindowViewModelTest:ViewModelBaseTest
    {
        private Mock<ISettings> settings;
        private Mock<IConnection> connection;
        private Mock<ILoginService> logiService;
        private Mock<IOperator> @operator;
        private Mock<IViewModelFactory> viewModelFactory;
        private Mock<IViewModel> mainWindow;
        private string operatorNumber;
        private LoginWindowViewModel loginWindowViewModel;

        [SetUp]
        public void Init()
        {
            this.settings = new Mock<ISettings>();
            this.connection = new Mock<IConnection>();
            this.logiService = new Mock<ILoginService>();
            this.@operator = new Mock<IOperator>();
            this.viewModelFactory = new Mock<IViewModelFactory>();
            this.WindowService = new Mock<IWindowService>();
            this.mainWindow = new Mock<IViewModel>();
            this.connection.Setup(connection1 => connection1.LoginService).Returns(this.logiService.Object);
            this.logiService.Setup(service => service.Login(this.operatorNumber)).Returns(this.@operator.Object);
            this.viewModelFactory.Setup(
                factory =>
                    factory.GetMainViewModel(this.WindowService.Object, this.settings.Object, this.connection.Object,
                        It.IsAny<IOperator>())).Returns(this.mainWindow.Object);
            this.viewModelFactory.Setup(
                factory =>
                    factory.GetSettingsViewModel(this.WindowService.Object, this.settings.Object)).Returns(this.mainWindow.Object);
            this.operatorNumber = "3001";
            this.loginWindowViewModel = new LoginWindowViewModel(this.viewModelFactory.Object, this.WindowService.Object, this.settings.Object, this.connection.Object);
            this.ViewModelBase = this.loginWindowViewModel;
        }

        [Test]
        public void TestType()
        {
            Assert.AreEqual(this.loginWindowViewModel.Type, ViewModelType.LoginWindow);
        }

        [Test]
        public void TestOpenSettingsWasCalled()
        {
            this.loginWindowViewModel.SettingsCommand.Execute(null);

            this.viewModelFactory.Verify(factory => factory.GetSettingsViewModel(this.WindowService.Object, this.settings.Object), Times.Once);
        }

        [Test]
        public void TestOpenSettingsShowWasCalled()
        {
            Mock<IViewModel> settingsViewModel = new Mock<IViewModel>();
            this.viewModelFactory.Setup(factory => factory.GetSettingsViewModel(this.WindowService.Object, this.settings.Object))
                .Returns(settingsViewModel.Object);

            this.loginWindowViewModel.SettingsCommand.Execute(null);

            settingsViewModel.Verify(model => model.ShowDialog(), Times.Once);
        }

        [Test]
        public void TestLoginCommandGetLoginServiceWasCalled()
        {
            this.loginWindowViewModel.LoginCommand.Execute(this.operatorNumber);

            this.connection.Verify(connection1 => connection1.LoginService, Times.Once);
        }

        [Test]
        public void TestLoginCommandGetLoginServiceWasNotCalled()
        {
            this.loginWindowViewModel.LoginCommand.Execute(string.Empty);

            this.connection.Verify(connection1 => connection1.LoginService, Times.Once);
        }

        [Test]
        public void TestLoginCommandLoginServiceLoginWasCalled()
        {
            this.loginWindowViewModel.LoginCommand.Execute(this.operatorNumber);

            this.logiService.Verify(service => service.Login(this.operatorNumber), Times.Once);
        }

        [Test]
        public void TestLoginCommandLoginServiceLoginWasNotCalled()
        {
            this.loginWindowViewModel.LoginCommand.Execute(null);

            this.viewModelFactory.Verify(
                factory =>
                    factory.GetMainViewModel(this.WindowService.Object, this.settings.Object, this.connection.Object,
                        this.@operator.Object), Times.Never);
        }
        
        [Test]
        public void TestLoginCommandLoginServiceLoginWasNotCalledWhenException()
        {
            this.logiService.Setup(service => service.Login(It.IsAny<string>())).Throws(new ArgumentNullException());
            this.loginWindowViewModel.LoginCommand.Execute(null);

            this.viewModelFactory.Verify(
                factory =>
                    factory.GetMainViewModel(this.WindowService.Object, this.settings.Object, this.connection.Object,
                        this.@operator.Object), Times.Never);
        }

        [Test]
        public void TestLoginCommandFactoryGetMainWasCalled()
        {
            this.loginWindowViewModel.LoginCommand.Execute(this.operatorNumber);

            this.viewModelFactory.Verify(
                factory =>
                    factory.GetMainViewModel(this.WindowService.Object, this.settings.Object, this.connection.Object,
                        It.IsAny<IOperator>()), Times.Once);
        }

        [Test]
        public void TestLoginCommandFactoryMainShowWasCalled()
        {
            this.loginWindowViewModel.LoginCommand.Execute(this.operatorNumber);

            this.mainWindow.Verify(model => model.Show(), Times.Once);
        }

        [Test]
        public void TestLoginCommandFactoryGetMainWasNotCalled()
        {
            this.loginWindowViewModel.LoginCommand.Execute(string.Empty);

            this.viewModelFactory.Verify(
                factory =>
                    factory.GetMainViewModel(this.WindowService.Object, this.settings.Object, this.connection.Object,
                        this.@operator.Object), Times.Never);
        }

        [ExpectedException(typeof(ArgumentNullException))]
        [Test]
        public void TestThrowViewModelFactoryArgumentNullException()
        {
            new LoginWindowViewModel(null, this.WindowService.Object, this.settings.Object, this.connection.Object);
        }

        [ExpectedException(typeof(ArgumentNullException))]
        [Test]
        public void TestThrowWindowSeriveArgumentNullException()
        {
            new LoginWindowViewModel(this.viewModelFactory.Object, null, this.settings.Object, this.connection.Object);
        }

        [ExpectedException(typeof(ArgumentNullException))]
        [Test]
        public void TestThrowSettingsArgumentNullException()
        {
            new LoginWindowViewModel(this.viewModelFactory.Object, this.WindowService.Object, null, this.connection.Object);
        }

        [ExpectedException(typeof(ArgumentNullException))]
        [Test]
        public void TestThrowConnectionArgumentNullException()
        {
            new LoginWindowViewModel(this.viewModelFactory.Object, this.WindowService.Object, this.settings.Object, null);
        }

        [Test]
        public void TestOperatorNumber()
        {
            Assert.AreEqual(true, string.IsNullOrWhiteSpace(this.loginWindowViewModel.OperatorNumber));
        }

        [Test]
        public void TestOperatorNumberSet()
        {
            string operatorNumber = "3001";
            this.loginWindowViewModel.OperatorNumber = operatorNumber;
            Assert.AreEqual(operatorNumber, this.loginWindowViewModel.OperatorNumber);
        }

        [Test]
        public void TestOperatorNumberSetTwice()
        {
            string operatorNumber = "3001";
            this.loginWindowViewModel.OperatorNumber = operatorNumber;
            this.loginWindowViewModel.OperatorNumber = operatorNumber;
            Assert.AreEqual(operatorNumber, this.loginWindowViewModel.OperatorNumber);
        }

        [Test]
        public void OnCancelTest()
        {
            this.loginWindowViewModel.CancelCommand.Execute(null);
        }

        protected override ViewModelBase ViewModelBase { get; set; }
        protected override Mock<IWindowService> WindowService { get; set; }
    }
}
