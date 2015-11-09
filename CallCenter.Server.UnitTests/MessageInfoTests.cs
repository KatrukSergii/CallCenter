using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace CallCenter.Server.UnitTests
{
    [TestFixture]
    public class MessageInfoTests
    {
        [Test]
        public void TestFromId()
        {
            int fromId = 1;
            MessageInfo messageInfo = new MessageInfo(fromId, 1);
            Assert.AreEqual(fromId, messageInfo.FromId);
        }

        [Test]
        public void TestToId()
        {
            int toId = 1;
            MessageInfo messageInfo = new MessageInfo(1, toId);
            Assert.AreEqual(toId, messageInfo.ToId);
        }

        [ExpectedException(typeof(ArgumentException))]
        [Test]
        public void TestFromIdLessZero()
        {
            new MessageInfo(-1, 1);
        }

        [ExpectedException(typeof(ArgumentException))]
        [Test]
        public void TestToIdLessZero()
        {
            new MessageInfo(1, -1);
        }
    }
}
