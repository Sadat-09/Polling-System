using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Services.Description;

namespace Final.Controllers
{
    [RoutePrefix("api/vote")]
    public class VoteController : ApiController
    {
       

        [HttpPost]
        [Route("givevote")]
        public HttpResponseMessage CastVote(VoteDTO obj)
        {
            try
            {
                var userId = HttpContext.Current.Session["UserId"];
                string message;

                if (userId != null)
                {
                    
                    obj.UserId = (int)userId;
                    message = "Vote added ";
                }
                else
                {
                    obj.UserId = null;
                    message = "Anonymous vote added ";
                }
                var data = VoteService.AddVote(obj);
                return Request.CreateResponse(HttpStatusCode.OK, message);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [HttpGet]
        [Route("results/{pollId}")]
        public HttpResponseMessage GetResults(int pollId)
        {
            try
            {
                var data = VoteService.GetResults(pollId);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

    }
}