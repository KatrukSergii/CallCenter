using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CallCenter.Client.ViewModel.Helpers;
using Moq;
using NUnit.Framework;

namespace CallCenter.Client.ViewModel.UnitTests.Helpers
{
    [TestFixture]
    public class CommandTests
    {
        [Test]
        public void TestCanExecIfNull()
        {
            Command<object> command = new Command<object>(Mock.Of<Action<object>>());
            Assert.IsTrue(command.CanExecute(null));
        }

        [Test]
        public void TestCanExecIfFalse()
        {
            Command<object> command = new Command<object>(Mock.Of<Action<object>>(), () => false);
            Assert.IsFalse(command.CanExecute(null));
        }

        [Test]
        public void TestCanExecIfTrue()
        {
            Command<object> command = new Command<object>(Mock.Of<Action<object>>(), () => true);
            Assert.IsTrue(command.CanExecute(null));
        }
    }
}
