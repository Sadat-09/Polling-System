using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.ApplicationServices;
using System.Web.Http;

namespace Final.Controllers
{
    [RoutePrefix("api/poll")]
    public class PollController : ApiController
    {
       
        
            [HttpGet]
            [Route("all")]
            public HttpResponseMessage Get()
            {
                try
                {
                    var data = PollService.GetAll();
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
                catch (Exception ex)
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
                }
            }

          

            [HttpPost]
            [Route("create")]
            public HttpResponseMessage Create(PollDTO obj)
            {
                try
                {
                    var data = PollService.Create(obj);
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
                catch (Exception ex)
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
                }
            }



        [HttpDelete]
        [Route("delete/{id}")]
            public HttpResponseMessage Delete(int id)
            {
                try
                {
                    var data = PollService.Delete(id);
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
                catch (Exception ex)
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
                }
            }
        [HttpGet]
        [Route("details/{id}")]
        public HttpResponseMessage GetDetails(int id)
        {
            try
            {
                var data = PollService.GetById(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [HttpGet]
        [Route("share/{pollId}")]
        public HttpResponseMessage GetShareableLink(int pollId)
        {
            try
            {
                
                var poll = PollService.GetById(pollId);
                if (poll != null)
                {
                    
                    string shareableLink = $"https://facebook.com/poll/{pollId}";

                  
                    return Request.CreateResponse(HttpStatusCode.OK, new { Link = shareableLink });
                }
                return Request.CreateResponse(HttpStatusCode.NotFound, "Poll not found.");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
