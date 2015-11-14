using System;
using System.Collections.Generic;
using CallCenter.Common;
using CallCenter.Common.DataContracts;
using CallCenterRepository.Controllers;
using NUnit.Framework;
using Moq;

namespace CallCenter.WcfService.UnitTests
{
    [TestFixture]
    public sealed class ChatServiceTests
    {

        [ExpectedException(typeof(ArgumentNullException))]
        [Test]
        public void ConstructorThrowException()
        {
            new ChatService(null);
        }

        [Test]
        public void GetChatHistory()
        {
            int agentId = 1;
            int count = 2;
            DateTime date = new DateTime(2000, 1, 1);
            Mock<IServerEventsProcessor> controllerFactoryMock = new Mock<IServerEventsProcessor>();
            Mock<IChatProcessor> chatControllerMock = new Mock<IChatProcessor>();
            Mock<IOperatorChatHistoryRecord> chatRecordMock = new Mock<IOperatorChatHistoryRecord>();
            List<IOperatorChatHistoryRecord> expectedResult = new List<IOperatorChatHistoryRecord> {chatRecordMock.Object};
            controllerFactoryMock.Setup(factory => factory.ChatProcessor).Returns(chatControllerMock.Object);
            chatControllerMock.Setup(controller => controller.GetChatHistory(agentId, date, count))
                .Returns(expectedResult);

            ChatService chatService = new ChatService(controllerFactoryMock.Object);
            IEnumerable<IOperatorChatHistoryRecord> res = chatService.GetChatHistory(agentId, date, count);
            Assert.AreEqual(res, expectedResult);
        }

    }
}
