using HG_CT_TechTest.Boundaries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HG_CT_TechTest.Interfaces
{
    public interface IPostMessageLogic
    {
        void postMessageRequest(PostMessageRequest postMessageRequest);
    }
}
