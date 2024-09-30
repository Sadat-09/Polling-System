using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Final.Controllers
{
    [RoutePrefix("api/user")]
    public class UserController : ApiController
    {
        [HttpPost]
        [Route("register")]
        public HttpResponseMessage Register(UserDTO user)
        {
            try
            {
                var result = UserService.Register(user);
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [HttpPost]
        [Route("login")]
        public HttpResponseMessage Login(LoginDTO obj)
        {
            try
            {
                var user = UserService.Login(obj.UserName, obj.Password);
                if (user != null)
                {
                    
                    if (HttpContext.Current.Session != null)
                    {
                     
                        HttpContext.Current.Session["UserId"] = user.Id;
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.InternalServerError, "Session is not available.");
                    }

                    return Request.CreateResponse(HttpStatusCode.OK, user);
                }
                return Request.CreateResponse(HttpStatusCode.Unauthorized, "Invalid credentials.");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("logout")]
        public HttpResponseMessage Logout()
        {
            try
            {
                
                HttpContext.Current.Session.Abandon();
                return Request.CreateResponse(HttpStatusCode.OK, "Logged out successfully.");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
