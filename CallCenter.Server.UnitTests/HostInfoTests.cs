using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CallCenter.Server;
using NUnit.Framework;

namespace CallCenter.Server.UnitTests
{
    [TestFixture]
    public class HostInfoTests
    {
        [Test]
        public void CreateHostInfoUnitTest()
        {
            string hostName = "test";
            HostInfo hostInfo = new HostInfo(hostName);
            Assert.AreEqual(hostName, hostInfo.HostName);
        }

        [ExpectedException(typeof(ArgumentNullException))]
        [Test]
        public void CreateHostInfoThroArgumentNullExecptionUnitTest()
        {
            new HostInfo(null);
        }

    }
}
