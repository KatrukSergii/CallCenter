using System;
using CallCenter.Client.Communication;
using CallCenter.Client.ViewModel.Helpers;
using CallCenter.Client.ViewModel.ViewModels;
using CallCenter.Common.Entities;
using Moq;
using NUnit.Framework;

namespace CallCenter.Client.ViewModel.UnitTests.ViewModels
{
    [TestFixture]
    public class MainWindowViewModelTests : ViewModelBaseTest
    {
        [SetUp]
        public void Init()
        {
            this.settings = new Mock<ISettings>();
            this.connection = new Mock<IConnection>();
            this.@operator = new Mock<IOperator>();
            this.viewModelFactory = new Mock<IViewModelFactory>();
            this.WindowService = new Mock<IWindowService>();
            this.mainWindowViewModel = new MainWindowViewModel(this.viewModelFactory.Object, this.WindowService.Object,
                this.settings.Object, this.connection.Object, this.@operator.Object);
            this.ViewModelBase = this.mainWindowViewModel;
        }

        private Mock<ISettings> settings;
        private Mock<IConnection> connection;
        private Mock<IOperator> @operator;
        private Mock<IViewModelFactory> viewModelFactory;
        private MainWindowViewModel mainWindowViewModel;

        [Test]
        public void InitForOperatorWasCalled()
        {
            Mock<IViewModelBase> operatorViewModel = new Mock<IViewModelBase>();
            this.viewModelFactory.Setup(
                factory => factory.GetOperatorViewModel(this.connection.Object, this.@operator.Object))
                .Returns(operatorViewModel.Object);
            this.mainWindowViewModel.Init();
            operatorViewModel.Verify(@base => @base.Init(), Times.Once);
        }

        [Test]
        public void InitWasCalled()
        {
            this.mainWindowViewModel.Init();
            this.viewModelFactory.Verify(
                factory => factory.GetOperatorViewModel(this.connection.Object, this.@operator.Object), Times.Once);
        }

        [Test]
        public void TestLogoutShowWasCalled()
        {
            Mock<IViewModel> loginViewModel = new Mock<IViewModel>();
            this.viewModelFactory.Setup(
                factory =>
                    factory.GetLoginViewModel(this.WindowService.Object, this.settings.Object, this.connection.Object))
                .Returns(loginViewModel.Object);

            this.mainWindowViewModel.LogOutCommand.Execute(null);

            loginViewModel.Verify(model => model.Show(), Times.Once);
        }

        [Test]
        public void TestLogOutWasCalled()
        {
            this.mainWindowViewModel.LogOutCommand.Execute(null);

            this.viewModelFactory.Verify(
                factory =>
                    factory.GetLoginViewModel(this.WindowService.Object, this.settings.Object, this.connection.Object),
                Times.Once);
        }

        [Test]
        public void TestOpenSettingsShowWasCalled()
        {
            Mock<IViewModel> settingsViewModel = new Mock<IViewModel>();
            this.viewModelFactory.Setup(
                factory => factory.GetSettingsViewModel(this.WindowService.Object, this.settings.Object))
                .Returns(settingsViewModel.Object);

            this.mainWindowViewModel.SettingsCommand.Execute(null);

            settingsViewModel.Verify(model => model.ShowDialog(), Times.Once);
        }

        [Test]
        public void TestOpenSettingsWasCalled()
        {
            this.mainWindowViewModel.SettingsCommand.Execute(null);

            this.viewModelFactory.Verify(
                factory => factory.GetSettingsViewModel(this.WindowService.Object, this.settings.Object), Times.Once);
        }

        [ExpectedException(typeof (ArgumentNullException))]
        [Test]
        public void TestThrowConnectionArgumentNullException()
        {
            new MainWindowViewModel(this.viewModelFactory.Object, this.WindowService.Object, this.settings.Object, null,
                this.@operator.Object);
        }

        [ExpectedException(typeof (ArgumentNullException))]
        [Test]
        public void TestThrowOperatorArgumentNullException()
        {
            new MainWindowViewModel(this.viewModelFactory.Object, this.WindowService.Object, this.settings.Object,
                this.connection.Object, null);
        }

        [ExpectedException(typeof (ArgumentNullException))]
        [Test]
        public void TestThrowSettingsArgumentNullException()
        {
            new MainWindowViewModel(this.viewModelFactory.Object, this.WindowService.Object, null,
                this.connection.Object, this.@operator.Object);
        }

        [ExpectedException(typeof (ArgumentNullException))]
        [Test]
        public void TestThrowViewModelFactoryArgumentNullException()
        {
            new MainWindowViewModel(null, this.WindowService.Object, this.settings.Object, this.connection.Object,
                this.@operator.Object);
        }

        [ExpectedException(typeof (ArgumentNullException))]
        [Test]
        public void TestThrowWindowSeriveArgumentNullException()
        {
            new MainWindowViewModel(this.viewModelFactory.Object, null, this.settings.Object, this.connection.Object,
                this.@operator.Object);
        }

        protected override ViewModelBase ViewModelBase { get; set; }
        protected override Mock<IWindowService> WindowService { get; set; }
    }
}