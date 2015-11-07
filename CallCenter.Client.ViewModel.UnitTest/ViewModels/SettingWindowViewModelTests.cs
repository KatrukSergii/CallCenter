using System;
using CallCenter.Client.ViewModel.Helpers;
using CallCenter.Client.ViewModel.ViewModels;
using Moq;
using NUnit.Framework;

namespace CallCenter.Client.ViewModel.UnitTests.ViewModels
{
    [TestFixture]
    public class SettingWindowViewModelTests:ViewModelBaseTest
    {
        [SetUp]
        public void Init()
        {
            this.settings = new Mock<ISettings>();
            this.WindowService = new Mock<IWindowService>();
            this.settingsViewModel = new SettingWindowViewModel(this.WindowService.Object, this.settings.Object);
            this.ViewModelBase = this.settingsViewModel;
        }

        private Mock<ISettings> settings;
        private SettingWindowViewModel settingsViewModel;

        [Test]
        public void TestServerName()
        {
            string serverName = "serverName";
            this.settings.Setup(settings1 => settings1.ServerName).Returns(serverName);
            Assert.AreEqual(serverName, this.settingsViewModel.ServerName);
        }

        [Test]
        public void TestServerNameWasNotSaved()
        {
            string serverName = "ServerName";
            this.settingsViewModel.ServerName = serverName;
            this.settingsViewModel.CancelCommand.Execute(null);
            this.settings.VerifySet(settings1 => settings1.ServerName = serverName, Times.Never);
        }

        [Test]
        public void TestServerNameWasSaved()
        {
            string serverName = "ServerName";
            this.settingsViewModel.ServerName = serverName;
            this.settingsViewModel.OkCommand.Execute(null);
            this.settings.VerifySet(settings1 => settings1.ServerName = serverName, Times.AtLeastOnce);
        }

        [Test]
        public void TestServerPort()
        {
            int serverPort = 8080;
            this.settings.Setup(settings1 => settings1.ServerPort).Returns(serverPort);
            Assert.AreEqual(serverPort, this.settingsViewModel.ServerPort);
        }

        [Test]
        public void TestServerPortWasNotSaved()
        {
            int serverPort = 8080;
            this.settingsViewModel.ServerPort = serverPort;
            this.settingsViewModel.CancelCommand.Execute(null);
            this.settings.VerifySet(settings1 => settings1.ServerPort = serverPort, Times.Never);
        }

        [Test]
        public void TestServerPortWasSaved()
        {
            int serverPort = 8080;
            this.settingsViewModel.ServerPort = serverPort;
            this.settingsViewModel.OkCommand.Execute(null);
            this.settings.VerifySet(settings1 => settings1.ServerPort = serverPort, Times.AtLeastOnce);
        }

        [ExpectedException(typeof (ArgumentNullException))]
        [Test]
        public void TestThrowSettingsArgumentNullException()
        {
            new SettingWindowViewModel(this.WindowService.Object, null);
        }

        [ExpectedException(typeof (ArgumentNullException))]
        [Test]
        public void TestThrowWindowServiceArgumentNullException()
        {
            new SettingWindowViewModel(null, this.settings.Object);
        }

        protected override ViewModelBase ViewModelBase { get; set; }
        protected override Mock<IWindowService> WindowService { get; set; }
    }
}