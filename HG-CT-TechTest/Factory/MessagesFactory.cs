using HG_CT_TechTest.Models;
using System.Collections.Generic;
using System.Linq;

namespace HG_CT_TechTest.Factory
{
    public static class MessagesFactory
    {
        public static Messages ToModel(this HG_CT_TechTest.DatabaseInfrastructure.Messages databaseMessage)
        {
            return new Messages
            {
                 Message = databaseMessage.Message,
                 MessageId = databaseMessage.Id,
                 SentAt = databaseMessage.SentAt,
                 Username = databaseMessage.Username                 
            };
        }

        public static List<Messages> ToResponse(this IEnumerable<HG_CT_TechTest.DatabaseInfrastructure.Messages>  databaseMessages)
        {
            return databaseMessages.Select(x => x.ToModel()).ToList();
        }
    }
}
