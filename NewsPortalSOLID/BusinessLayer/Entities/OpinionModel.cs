using DataLayer.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Entities
{
    public class OpinionModel
    {
        public int OpinionId { get; set; }
        public string Comment { get; set; }
        public string Reaction { get; set; }
        public News NewsDetail { get; set; }
        public User UserDetail { get; set; }
    }
}
