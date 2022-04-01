using BusinessLayer.Entities;
using DataLayer;
using DataLayer.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class NewsService
    {
        public static List<NewsModel> Get()
        {
            var nwses = FactoryDataAccess.NewsDataAccess().Get();
            List<NewsModel> data = new List<NewsModel>();
            foreach (var n in nwses)
            {
                NewsModel news = new NewsModel();
                news.NewsId = n.NewsId;
                news.Title = n.Title;
                news.Description = n.Description;
                news.PostDate = n.PostDate;
                news.PostedBy = FactoryDataAccess.UserDataAccess().Get(n.PostedById);
                news.Division = FactoryDataAccess.CategoryDataAccess().Get(n.CategoryId);
                List<OpinionModel> opinions = new List<OpinionModel>();
                var odata = FactoryDataAccess.NewsOpinionDataAccess().GetByNews(n.NewsId);
                foreach (var o in odata)
                {
                    OpinionModel opinion = new OpinionModel();
                    opinion.OpinionId = o.OpinionId;
                    opinion.Comment = o.Comment;
                    opinion.Reaction = o.Reaction;
                    opinion.UserDetail = FactoryDataAccess.UserDataAccess().Get(o.UserId);
                    opinions.Add(opinion);

                }
                data.Add(news);

            }
            return data;

        }

        //public static NewsModel Get(int id)
        //{
        //    var nws = FactoryDataAccess.NewsDataAccess().Get(id);
        //    var n = new NewsModel() { NewsId = nws.NewsId, Title = nws.Title };
        //    return c;

        //}

        public static NewsModel Add(NewsModel obj)
        {
            var NwsMod = new News { Title = obj.Title, Description = obj.Description, PostDate = obj.PostDate, 
                PostedById = obj.UserId, CategoryId = obj.CategoryId};
            var nws = FactoryDataAccess.NewsDataAccess().Add(NwsMod);
            var n = new NewsModel()
            {
                NewsId = nws.CategoryId,
                Title = nws.Title,
                Description = nws.Description,
                PostDate = nws.PostDate,
                UserId = nws.PostedById,
                CategoryId = obj.CategoryId
            };
            return n;

        }

        public static bool Edit(NewsModel obj)
        {
            var NwsMod = new News
            {
                NewsId = obj.NewsId,
                Title = obj.Title,
                Description = obj.Description,
                PostDate = obj.PostDate,
                PostedById = obj.PostedBy.UserId,
                CategoryId = obj.Division.CategoryId
            };
            var editn = FactoryDataAccess.NewsDataAccess().Edit(NwsMod);
            return editn;

        }

        public static bool Delete(int id)
        {
            var msg = FactoryDataAccess.NewsDataAccess().Delete(id);
            return msg;

        }
    }
}
