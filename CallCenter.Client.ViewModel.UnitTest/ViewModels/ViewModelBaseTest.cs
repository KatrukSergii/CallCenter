using CallCenter.Client.ViewModel.Helpers;
using Moq;
using NUnit.Framework;

namespace CallCenter.Client.ViewModel.UnitTests.ViewModels
{
    [TestFixture]
    public abstract class ViewModelBaseTest
    {
        protected abstract ViewModelBase ViewModelBase { get; set; }
        protected abstract Mock<IWindowService> WindowService { get; set; }

        [Test]
        public void AskUserTest()
        {
            this.ViewModelBase.AskUser(string.Empty, string.Empty);
            this.WindowService.Verify(service => service.AskUser(string.Empty, string.Empty), Times.Once);
        }

        [Test]
        public void CloseSuccesfulTest()
        {
            this.ViewModelBase.WindowId = 1;
            this.ViewModelBase.Close();
            this.WindowService.Verify(service => service.Close(1), Times.Once);
        }

        [Test]
        public void CloseFailTest()
        {
            this.ViewModelBase.Close();
            this.WindowService.Verify(service => service.Close(1), Times.Never);
        }

        [Test]
        public void InitTest()
        {
            this.ViewModelBase.Init();
        }

        [Test]
        public void ShowTestWasNotCalled()
        {
            this.ViewModelBase.WindowId = 1;
            this.ViewModelBase.Show();
            this.WindowService.Verify(service => service.ShowWindow(this.ViewModelBase.Type, this.ViewModelBase), Times.Never);
        }

        [Test]
        public void ShowTestWasCalled()
        {
            this.ViewModelBase.WindowId = 0;
            this.ViewModelBase.Show();
            this.WindowService.Verify(service => service.ShowWindow(this.ViewModelBase.Type, this.ViewModelBase), Times.Once);
        }

        [Test]
        public void ShowDialogTestWasNotCalled()
        {
            this.ViewModelBase.WindowId = 1;
            this.ViewModelBase.ShowDialog();
            this.WindowService.Verify(service => service.ShowDialogWindow(this.ViewModelBase.Type, this.ViewModelBase), Times.Never);
        }

        [Test]
        public void ShowDialogTestCalled()
        {
            this.ViewModelBase.WindowId = 0;
            this.ViewModelBase.ShowDialog();
            this.WindowService.Verify(service => service.ShowDialogWindow(this.ViewModelBase.Type, this.ViewModelBase), Times.AtLeastOnce);
        }

        [Test]
        public void ShowMessageTest()
        {
            this.ViewModelBase.ShowMessage("", "", MessageType.Error);
            this.WindowService.Verify(service => service.ShowMessage("", "", MessageType.Error), Times.AtLeastOnce);
        }

        [Test]
        public void TestVisibFalse()
        {
            this.ViewModelBase.IsVisible = false;
            Assert.IsFalse(this.ViewModelBase.IsVisible);
        }

        [Test]
        public void TestVisibTrue()
        {
            this.ViewModelBase.IsVisible = true;
            Assert.IsTrue(this.ViewModelBase.IsVisible);
        }
    }
}
