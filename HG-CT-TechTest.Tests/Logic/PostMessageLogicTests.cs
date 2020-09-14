using HG_CT_TechTest.Boundaries;
using HG_CT_TechTest.Interfaces;
using HG_CT_TechTest.Logic;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace HG_CT_TechTest.Tests.Logic
{
    public class PostMessageLogicTests
    {
        private Mock<IDatabaseService> _moqDatabaseService;
        private PostMessageLogic _classUnderTest;

        [SetUp]
        public void Setup()
        {
            _moqDatabaseService = new Mock<IDatabaseService>();
            _classUnderTest = new PostMessageLogic(_moqDatabaseService.Object);
        }

        [Test]
        public void EnsureCorrectMethodsAreBeingCalledBasedOnUserInput()
        {
            var examplePostRequest = new PostMessageRequest
            {
                Message = "test",
                Username = "test"
            };

            _classUnderTest.postMessageRequest(examplePostRequest);
            _moqDatabaseService.Verify(x => x.CreateMessage(examplePostRequest), Times.Once);
        }
        //TODO add more test coverage
    }
}
