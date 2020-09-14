using HG_CT_TechTest.Boundaries;
using HG_CT_TechTest.Factory;
using HG_CT_TechTest.Interfaces;

namespace HG_CT_TechTest.Logic
{
    public class GetAllMessagesLogic : IGetAllMessagesLogic
    {
        IDatabaseService _databaseService;
        public GetAllMessagesLogic(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        public GetMessagesResponse getAllMessagesResponse()
        {
            var result = _databaseService.GetAllMessages();
            return new GetMessagesResponse
            {
                Messages = result.ToResponse()
            };        
        }
    }
}
