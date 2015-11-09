using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CallCenter.Common;
using Moq;
using NUnit.Framework;

namespace CallCenter.Server.UnitTests
{
    [TestFixture]
    public class MessageTests
    {
        [Test]
        public void TestText()
        {
            string messageText = "test";
            Message message = new Message(messageText, Mock.Of<IMessageInfo>());
            Assert.AreEqual(messageText, message.Text);
        }

        [Test]
        public void TestMessageInfo()
        {
            IMessageInfo messageInfo = Mock.Of<IMessageInfo>();
            Message message = new Message("test", messageInfo);
            Assert.AreEqual(messageInfo, message.MessageInfo);
        }

        [ExpectedException(typeof(ArgumentNullException))]
        [Test]
        public void TestConstructorMessageInfoNull()
        {
            string messageText = "test";
            new Message(messageText, null);
        }
    }
}
