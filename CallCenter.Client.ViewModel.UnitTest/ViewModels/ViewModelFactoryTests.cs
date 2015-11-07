using CallCenter.Client.Communication;
using CallCenter.Client.ViewModel.Helpers;
using CallCenter.Client.ViewModel.ViewModels;
using CallCenter.Common.Entities;
using Moq;
using NUnit.Framework;

namespace CallCenter.Client.ViewModel.UnitTests.ViewModels
{
    [TestFixture]
    public class ViewModelFactoryTests
    {
        [SetUp]
        public void Init()
        {
            this.settings = new Mock<ISettings>();
            this.connection = new Mock<IConnection>();
            this.@operator = new Mock<IOperator>();
            this.viewModelFactory = new ViewModelFactory();
            this.windowService = new Mock<IWindowService>();
        }

        private Mock<ISettings> settings;
        private Mock<IConnection> connection;
        private Mock<IOperator> @operator;
        private Mock<IWindowService> windowService;
        private ViewModelFactory viewModelFactory;

        [Test]
        public void TestGetLoginViewModel()
        {
            IViewModel res = this.viewModelFactory.GetLoginViewModel(this.windowService.Object, this.settings.Object,
                this.connection.Object);
            Assert.NotNull(res);
        }

        [Test]
        public void TestGetMainViewModel()
        {
            IViewModel res = this.viewModelFactory.GetMainViewModel(this.windowService.Object, this.settings.Object,
                this.connection.Object, this.@operator.Object);
            Assert.NotNull(res);
        }

        [Test]
        public void TestGetOperatorViewModel()
        {
            IViewModelBase res = this.viewModelFactory.GetOperatorViewModel(this.connection.Object,
                this.@operator.Object);
            Assert.NotNull(res);
        }

        [Test]
        public void TestGetSettingsViewModel()
        {
            IViewModel res = this.viewModelFactory.GetSettingsViewModel(this.windowService.Object, this.settings.Object);
            Assert.NotNull(res);
        }
    }
}