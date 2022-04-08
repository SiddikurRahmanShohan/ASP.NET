using BusinessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace NewsPortalAPI.Controllers
{
    public class OpinionController : ApiController
    {
        [Route("api/opinion/addopinion")]//coustom routing
        [HttpPost] //Bind for Get only
        public HttpResponseMessage AddOpinion(OpinionModel obj)
        {
            var opn = BusinessLayer.Services.OpinionService.Add(obj);

            var data = new JavaScriptSerializer().Serialize(opn);

            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
    }
}
