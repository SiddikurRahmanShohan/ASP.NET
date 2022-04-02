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
    public class NewsController : ApiController
    {
        [Route("api/news/getnewes")]//coustom routing
        [HttpGet] //Bind for Get only
        public HttpResponseMessage GetNewses()
        {
            var nwses = BusinessLayer.Services.NewsService.Get();

            var data = new JavaScriptSerializer().Serialize(nwses);

            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/news/getnews/{id}")]//coustom routing
        [HttpGet] //Bind for Get only
        public HttpResponseMessage GetNews(int id)
        {
            var nws = BusinessLayer.Services.NewsService.Get(id);

            var data = new JavaScriptSerializer().Serialize(nws);

            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/news/addnews")]//coustom routing
        [HttpPost] //Bind for Get only
        public HttpResponseMessage AddNews(NewsModel obj)
        {
            var nws = BusinessLayer.Services.NewsService.Add(obj);

            var data = new JavaScriptSerializer().Serialize(nws);

            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/news/editnews")]//coustom routing
        [HttpPost] //Bind for post only
        public HttpResponseMessage EditNews(NewsModel obj)
        {
            BusinessLayer.Services.NewsService.Edit(obj);
            return Request.CreateResponse(HttpStatusCode.OK, (obj.NewsId + " has been Updated"));
        }

        [Route("api/news/deletenews/{id}")]//coustom routing
        [HttpGet] //Bind for get only
        public HttpResponseMessage DeleteNews(int id)
        {
            BusinessLayer.Services.NewsService.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK, ("News has been Deleted"));
        }
    }
}
