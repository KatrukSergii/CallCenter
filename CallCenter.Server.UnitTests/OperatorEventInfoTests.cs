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
    public class OperatorEventInfoTests
    {
        [Test]
        public void TestHostInfo()
        {
            IHostInfo hostInfo = Mock.Of<IHostInfo>();
            OperatorEventInfo operatorEventInfo = new OperatorEventInfo("1", EventReason.Busy, hostInfo);
            Assert.AreEqual(hostInfo, operatorEventInfo.HostInfo);
        }

        [Test]
        public void TestEventReason()
        {
            EventReason eventReason = EventReason.Busy;
            OperatorEventInfo operatorEventInfo = new OperatorEventInfo("1", eventReason, Mock.Of<IHostInfo>());
            Assert.AreEqual(eventReason, operatorEventInfo.Reason);
        }

        [Test]
        public void TestOperatorNumber()
        {
            string operatorNumber = "3001";
            OperatorEventInfo operatorEventInfo = new OperatorEventInfo(operatorNumber, EventReason.Busy, Mock.Of<IHostInfo>());
            Assert.AreEqual(operatorNumber, operatorEventInfo.OperatorNumber);
        }

        [ExpectedException(typeof(ArgumentNullException))]
        [Test]
        public void TestOperatornumberNull()
        {
            new OperatorEventInfo(null, EventReason.Busy, Mock.Of<IHostInfo>());
        }

        [ExpectedException(typeof(ArgumentNullException))]
        [Test]
        public void TestHostInfoNull()
        {
            new OperatorEventInfo("3001", EventReason.Busy, null);
        }
    }
}
