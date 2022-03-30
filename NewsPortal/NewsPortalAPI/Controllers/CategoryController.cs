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
    public class CategoryController : ApiController
    {
        [Route("api/category/getcategories")]//coustom routing
        [HttpGet] //Bind for Get only
        public HttpResponseMessage GetCategories()
        {
            var ct = BusinessLayer.Services.CategoryService.Get();

            var data = new JavaScriptSerializer().Serialize(ct);

            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/category/getcategory/{id}")]//coustom routing
        [HttpGet] //Bind for Get only
        public HttpResponseMessage GetCategory(int id)
        {
            var cat = BusinessLayer.Services.CategoryService.Get(id);

            var data = new JavaScriptSerializer().Serialize(cat);

            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/category/editcategory")]//coustom routing
        [HttpPost] //Bind for post only
        public HttpResponseMessage EditCategory(CategoryModel obj)
        {
            BusinessLayer.Services.CategoryService.Edit(obj);
            return Request.CreateResponse(HttpStatusCode.OK, (obj.CategoryId + " has been Updated"));
        }

        [Route("api/category/deletecategory/{id}")]//coustom routing
        [HttpGet] //Bind for get only
        public HttpResponseMessage DeleteCategory(int id)
        {
            BusinessLayer.Services.CategoryService.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK, ("Category has been Deleted"));
        }
    }
}
