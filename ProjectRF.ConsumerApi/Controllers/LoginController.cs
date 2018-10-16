using ProjectRF.ConsumerApi.Controllers.api;
using ProjectRF.ConsumerApi.Interfaces;
using ProjectRF.ConsumerApi.Models;
using ProjectRF.ConsumerApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace ProjectRF.ConsumerApi.Controllers
{
    [RoutePrefix("api/user")]
    public class LoginController : ApiController
    {
        ILogin _login = new LoginService();

        [HttpPost]
        [Route("login")]
        public HttpResponseMessage LogIn(LoginRequest loginRequest)
        {
            ItemResponse<bool> resp = new ItemResponse<bool>();
            resp.Item = (_login.Login(loginRequest));

            return Request.CreateResponse(HttpStatusCode.OK, resp);
        }
    }
}