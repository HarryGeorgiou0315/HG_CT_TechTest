using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HG_CT_TechTest.Boundaries;
using HG_CT_TechTest.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HG_CT_TechTest.Controllers
{
    [Route("api/v1/messages")]
    [Produces("application/json")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        IPostMessageLogic _postMessageLogic;
        IGetAllMessagesLogic _getAllMessagesLogic;

        public MessagesController(IGetAllMessagesLogic getAllMessagesLogic, IPostMessageLogic postMessageLogic)
        {
            _getAllMessagesLogic = getAllMessagesLogic;
            _postMessageLogic = postMessageLogic;
        }

        [ProducesResponseType(typeof(GetMessagesResponse), StatusCodes.Status200OK)]
        [HttpGet]
        public ActionResult GetAllMessagesLogic()
        {
            try
            {
                return Ok(_getAllMessagesLogic.getAllMessagesResponse());
            }
            catch(Exception ex)
            {
                //If more time, I would have created a custom exception
                return StatusCode(500, ex.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [HttpPost]
        public ActionResult Post([FromBody] PostMessageRequest request)
        {
            try
            {
                _postMessageLogic.postMessageRequest(request);
                return StatusCode(StatusCodes.Status201Created);
            }
            catch(Exception ex)
            {
                //If more time, I would have created a custom exception
                return StatusCode(500, ex.Message);
            }
        }
        
    }
}
