using HG_CT_TechTest.Factory;
using HG_CT_TechTest.Models;
using NUnit.Framework;
using System;

namespace HG_CT_TechTest.Tests.Factory
{
    public class MessagesFactoryTests
    {
        [Test]
        public void CanMapDatabaseMessageToModelClassMessage()
        {
            var databaseMessage = new HG_CT_TechTest.DatabaseInfrastructure.Messages
            {
                Message = "test1",
                SentAt = DateTime.Now,
                Id = 1,
                Username = ""
            };

            var expectedResult = new Messages
            {
                Message = "test1",
                SentAt = DateTime.Now,
                MessageId = 1,
                Username = ""
            };

            var result = databaseMessage.ToModel();

            Assert.IsInstanceOf<Messages>(result);
            Assert.AreEqual(expectedResult.Message, result.Message);
            Assert.AreEqual(expectedResult.MessageId, result.MessageId);
            Assert.AreEqual(expectedResult.SentAt.Date, result.SentAt.Date);
            Assert.AreEqual(expectedResult.Username, result.Username);
        }

        // If I had more time, I would have added further tests to test the other factory class method. 
    }
}
