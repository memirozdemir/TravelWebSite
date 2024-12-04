using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelWebSite.Models.Classes
{
    public class BlogComments
    {
        public IEnumerable<Blog> blogs { get; set; }
        public IEnumerable<Blog> recentblogs { get; set; }
        public IEnumerable<Comment> comments { get; set; }
        public IEnumerable<Comment> recentcomments { get; set; }


    }
}