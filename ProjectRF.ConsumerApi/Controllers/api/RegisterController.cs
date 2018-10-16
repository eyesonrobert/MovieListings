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

namespace ProjectRF.ConsumerApi.Controllers.api
{
    [RoutePrefix("api/user")]
    public class RegisterController : ApiController
    {
        IRegister _registerService = new RegisterService();

        [HttpPost]
        [Route("register")]
        public HttpResponseMessage Register(RegisterDomain model)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            ItemResponse<int> resp = new ItemResponse<int>();
            resp.Item = _registerService.Insert(model);
            return Request.CreateResponse(HttpStatusCode.OK, resp);
        }
    }
}