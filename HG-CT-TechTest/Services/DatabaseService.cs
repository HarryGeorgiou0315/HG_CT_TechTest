using System;
using System.Collections.Generic;
using System.Linq;
using HG_CT_TechTest.Boundaries;
using HG_CT_TechTest.DatabaseInfrastructure;
using HG_CT_TechTest.Interfaces;

namespace HG_CT_TechTest.Services
{
    public class DatabaseService : IDatabaseService
    {
        private readonly DatabaseContext _databaseContext;

        public DatabaseService(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public void CreateMessage(PostMessageRequest postMessageRequest)
        {
            var messageToInsert = new Messages
            {
                Message = postMessageRequest.Message,
                SentAt = DateTime.Now,
                Username = !string.IsNullOrEmpty(postMessageRequest.Username) ? postMessageRequest.Username : "Anonymous",
                UserId = postMessageRequest.UserId
            };

            try
            {
                _databaseContext.Messages.Add(messageToInsert);
                _databaseContext.SaveChanges();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Messages> GetAllMessages()
        {
           return _databaseContext.Messages.ToList();
        }
    }
}
