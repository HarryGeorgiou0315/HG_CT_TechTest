using HG_CT_TechTest.Boundaries;
using HG_CT_TechTest.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HG_CT_TechTest.Logic
{
    public class PostMessageLogic : IPostMessageLogic
    {
        IDatabaseService _databaseService;
        public PostMessageLogic(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        public void postMessageRequest(PostMessageRequest postMessageRequest)
        {
            _databaseService.CreateMessage(postMessageRequest);            
        }
    }
}
