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
                User usr = new User();
                var postBy = FactoryDataAccess.UserDataAccess().Get(n.PostedById);
                usr.FullName = postBy.FullName;
                usr.Occupation = postBy.Occupation;
                usr.UserId = postBy.UserId;
                news.PostedBy = usr;
                Category cate = new Category();
                var c = FactoryDataAccess.CategoryDataAccess().Get(n.CategoryId);
                cate.CategoryId = c.CategoryId;
                cate.CategoryName = c.CategoryName;
                news.Division = cate;
                List<OpinionModel> opinions = new List<OpinionModel>();
                var odata = FactoryDataAccess.NewsOpinionDataAccess().GetByNews(n.NewsId);
                foreach (var o in odata)
                {
                    OpinionModel opinion = new OpinionModel();
                    opinion.OpinionId = o.OpinionId;
                    opinion.Comment = o.Comment;
                    opinion.Reaction = o.Reaction;
                    User us = new User();
                    var u = FactoryDataAccess.UserDataAccess().Get(o.UserId);
                    us.UserId = u.UserId;
                    us.FullName = u.FullName;
                    us.Occupation = u.Occupation;
                    opinion.UserDetail = us;
                    opinions.Add(opinion);

                }
                news.Comments = opinions;
                data.Add(news);

            }
            return data;

        }

        public static List<NewsModel> SearchNews(Search obj)
        {
            if (obj.cname != null && obj.sdate != null)
            {
                var nwses = FactoryDataAccess.SearchNews().GetNewsByCatDate(obj.cname, obj.sdate.Date);
                List<NewsModel> data = new List<NewsModel>();
                foreach (var n in nwses)
                {
                    NewsModel news = new NewsModel();
                    news.NewsId = n.NewsId;
                    news.Title = n.Title;
                    news.Description = n.Description;
                    news.PostDate = n.PostDate;
                    User usr = new User();
                    var postBy = FactoryDataAccess.UserDataAccess().Get(n.PostedById);
                    usr.FullName = postBy.FullName;
                    usr.Occupation = postBy.Occupation;
                    usr.UserId = postBy.UserId;
                    news.PostedBy = usr;
                    Category cate = new Category();
                    var c = FactoryDataAccess.CategoryDataAccess().Get(n.CategoryId);
                    cate.CategoryId = c.CategoryId;
                    cate.CategoryName = c.CategoryName;
                    news.Division = cate;
                    List<OpinionModel> opinions = new List<OpinionModel>();
                    var odata = FactoryDataAccess.NewsOpinionDataAccess().GetByNews(n.NewsId);
                    foreach (var o in odata)
                    {
                        OpinionModel opinion = new OpinionModel();
                        opinion.OpinionId = o.OpinionId;
                        opinion.Comment = o.Comment;
                        opinion.Reaction = o.Reaction;
                        User us = new User();
                        var u = FactoryDataAccess.UserDataAccess().Get(o.UserId);
                        us.UserId = u.UserId;
                        us.FullName = u.FullName;
                        us.Occupation = u.Occupation;
                        opinion.UserDetail = us;
                        opinions.Add(opinion);

                    }
                    news.Comments = opinions;
                    data.Add(news);

                }
                return data;
            }
            else if (obj.cname != null && obj.sdate == null)
            {
                var nwses = FactoryDataAccess.SearchNews().GetNewsByCat(obj.cname);
                List<NewsModel> data = new List<NewsModel>();
                foreach (var n in nwses)
                {
                    NewsModel news = new NewsModel();
                    news.NewsId = n.NewsId;
                    news.Title = n.Title;
                    news.Description = n.Description;
                    news.PostDate = n.PostDate;
                    User usr = new User();
                    var postBy = FactoryDataAccess.UserDataAccess().Get(n.PostedById);
                    usr.FullName = postBy.FullName;
                    usr.Occupation = postBy.Occupation;
                    usr.UserId = postBy.UserId;
                    news.PostedBy = usr;
                    Category cate = new Category();
                    var c = FactoryDataAccess.CategoryDataAccess().Get(n.CategoryId);
                    cate.CategoryId = c.CategoryId;
                    cate.CategoryName = c.CategoryName;
                    news.Division = cate;
                    List<OpinionModel> opinions = new List<OpinionModel>();
                    var odata = FactoryDataAccess.NewsOpinionDataAccess().GetByNews(n.NewsId);
                    foreach (var o in odata)
                    {
                        OpinionModel opinion = new OpinionModel();
                        opinion.OpinionId = o.OpinionId;
                        opinion.Comment = o.Comment;
                        opinion.Reaction = o.Reaction;
                        User us = new User();
                        var u = FactoryDataAccess.UserDataAccess().Get(o.UserId);
                        us.UserId = u.UserId;
                        us.FullName = u.FullName;
                        us.Occupation = u.Occupation;
                        opinion.UserDetail = us;
                        opinions.Add(opinion);

                    }
                    news.Comments = opinions;
                    data.Add(news);

                }
                return data;
            }
            else {
                var nwses = FactoryDataAccess.SearchNews().GetNewsByDate(obj.sdate.Date);
                List<NewsModel> data = new List<NewsModel>();
                foreach (var n in nwses)
                {
                    NewsModel news = new NewsModel();
                    news.NewsId = n.NewsId;
                    news.Title = n.Title;
                    news.Description = n.Description;
                    news.PostDate = n.PostDate;
                    User usr = new User();
                    var postBy = FactoryDataAccess.UserDataAccess().Get(n.PostedById);
                    usr.FullName = postBy.FullName;
                    usr.Occupation = postBy.Occupation;
                    usr.UserId = postBy.UserId;
                    news.PostedBy = usr;
                    Category cate = new Category();
                    var c = FactoryDataAccess.CategoryDataAccess().Get(n.CategoryId);
                    cate.CategoryId = c.CategoryId;
                    cate.CategoryName = c.CategoryName;
                    news.Division = cate;
                    List<OpinionModel> opinions = new List<OpinionModel>();
                    var odata = FactoryDataAccess.NewsOpinionDataAccess().GetByNews(n.NewsId);
                    foreach (var o in odata)
                    {
                        OpinionModel opinion = new OpinionModel();
                        opinion.OpinionId = o.OpinionId;
                        opinion.Comment = o.Comment;
                        opinion.Reaction = o.Reaction;
                        User us = new User();
                        var u = FactoryDataAccess.UserDataAccess().Get(o.UserId);
                        us.UserId = u.UserId;
                        us.FullName = u.FullName;
                        us.Occupation = u.Occupation;
                        opinion.UserDetail = us;
                        opinions.Add(opinion);

                    }
                    news.Comments = opinions;
                    data.Add(news);

                }
                return data;
            }
            

        }

        public static NewsModel Get(int id)
        {
            var nws = FactoryDataAccess.NewsDataAccess().Get(id);
            var n = new NewsModel();
            n.NewsId = nws.NewsId; 
            n.Title = nws.Title;
            n.Description = nws.Description;
            n.PostDate = nws.PostDate;
            var postBy = FactoryDataAccess.UserDataAccess().Get(nws.PostedById);
            var u = new User();
             u.FullName = postBy.FullName;
             u.Occupation = postBy.Occupation;
             u.UserId = postBy.UserId;
             n.PostedBy = u;
             Category cate = new Category();
             var c = FactoryDataAccess.CategoryDataAccess().Get(nws.CategoryId);
             cate.CategoryId = c.CategoryId;
             cate.CategoryName = c.CategoryName;
             n.Division = cate;
             List<OpinionModel> opinions = new List<OpinionModel>();
             var odata = FactoryDataAccess.NewsOpinionDataAccess().GetByNews(nws.NewsId);
             foreach (var o in odata)
             {
                 OpinionModel opinion = new OpinionModel();
                 opinion.OpinionId = o.OpinionId;
                 opinion.Comment = o.Comment;
                 opinion.Reaction = o.Reaction;
                 User us = new User();
                 var ur = FactoryDataAccess.UserDataAccess().Get(o.UserId);
                 us.UserId = ur.UserId;
                 us.FullName = ur.FullName;
                 us.Occupation = ur.Occupation;
                 opinion.UserDetail = us;
                 opinions.Add(opinion);

             }
             n.Comments = opinions;

            return n;

        }

        public static NewsModel Add(NewsModel obj)
        {
            var NwsMod = new News { Title = obj.Title, Description = obj.Description, PostDate = obj.PostDate, 
                PostedById = obj.UserId, CategoryId = obj.CategoryId};
            var nws = FactoryDataAccess.NewsDataAccess().Add(NwsMod);
            var n = new NewsModel()
            {
                NewsId = nws.NewsId,
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
                PostedById = obj.UserId,
                CategoryId = obj.CategoryId
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
