using DataLayer.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Entities
{
    public class NewsModel
    {
        public int NewsId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public System.DateTime PostDate { get; set; }
        public Category Division { get; set; }
        public User PostedBy { get; set; }

        public int UserId { get; set; }

        public int CategoryId { get; set; }
        public List<OpinionModel> Comments { get; set; }
    }
}
