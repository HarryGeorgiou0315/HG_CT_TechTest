using System;
using System.Collections.Generic;
using HG_CT_TechTest.Boundaries;
using HG_CT_TechTest.Interfaces;
using HG_CT_TechTest.Logic;
using HG_CT_TechTest.Models;
using Moq;
using NUnit.Framework;

namespace HG_CT_TechTest.Tests.Logic
{
    public class GetAllMessagesLogicTests
    {
        private Mock<IDatabaseService> _moqDatabaseService;
        private GetAllMessagesLogic _classUnderTest;

        [SetUp]
        public void Setup()
        {
            _moqDatabaseService = new Mock<IDatabaseService>();
            _classUnderTest = new GetAllMessagesLogic(_moqDatabaseService.Object);
        }

        [Test]
        public void EnsureCorrectMethodsAreBeingCalledBasedOnUserInput()
        {
            var expectedDatabaseResponse = new List<HG_CT_TechTest.DatabaseInfrastructure.Messages>()
            {
                new HG_CT_TechTest.DatabaseInfrastructure.Messages
                {
                     Message = "test1",
                     SentAt = DateTime.Now,
                     Id = 1,
                     Username = ""
                }
            };

            _moqDatabaseService.Setup(x => x.GetAllMessages()).Returns(expectedDatabaseResponse);
            _classUnderTest.getAllMessagesResponse();

            _moqDatabaseService.Verify(x => x.GetAllMessages(), Times.Once);
        }


        [Test]
        public void GetAllMessagesReturnsListOfMessages()
        {
            var expectedResponse = new List<Messages>
            {
                new Messages
                {
                     Message = "test1",
                     SentAt = DateTime.Now,
                     MessageId = 1,
                     Username = ""
                }
            };

            var expectedDatabaseResponse = new List<HG_CT_TechTest.DatabaseInfrastructure.Messages>()
            {
                new HG_CT_TechTest.DatabaseInfrastructure.Messages
                {
                     Message = "test1",
                     SentAt = DateTime.Now,
                     Id = 1,
                     Username = ""
                }
            };

            _moqDatabaseService.Setup(x => x.GetAllMessages()).Returns(expectedDatabaseResponse);

            var result = _classUnderTest.getAllMessagesResponse();

            Assert.AreEqual(expectedResponse[0].Message, result.Messages[0].Message);
            Assert.AreEqual(expectedResponse[0].MessageId, result.Messages[0].MessageId);
            Assert.AreEqual(expectedResponse[0].SentAt.Date, result.Messages[0].SentAt.Date);
            Assert.AreEqual(expectedResponse[0].Username, result.Messages[0].Username);
            Assert.IsInstanceOf<GetMessagesResponse>(result);
        }
    }
}
