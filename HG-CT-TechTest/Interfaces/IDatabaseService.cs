using HG_CT_TechTest.Boundaries;
using HG_CT_TechTest.DatabaseInfrastructure;
using System.Collections.Generic;

namespace HG_CT_TechTest.Interfaces
{
    public interface IDatabaseService
    {
        List<Messages> GetAllMessages();
        void CreateMessage(PostMessageRequest postMessageRequest);
    }
}
