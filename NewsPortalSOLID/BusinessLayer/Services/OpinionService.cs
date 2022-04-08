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
    public class OpinionService
    {
        public static OpinionModel Add(OpinionModel obj)
        {
            var OpnMod = new Opinion { Comment = obj.Comment, UserId = obj.UserId, NewsId = obj.NewsId, Reaction = obj.Reaction};
            var opn = FactoryDataAccess.OpinionDataAccess().Add(OpnMod);
            var o = new OpinionModel() { OpinionId =opn.OpinionId, Comment = opn.Comment, UserId = opn.UserId, NewsId = opn.NewsId, Reaction = opn.Reaction };
            return o;

        }
    }
}
