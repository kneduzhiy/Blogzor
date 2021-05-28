using System.Collections.Generic;

namespace Blogzor.Model
{
    public class Blog
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public IList<BlogPost> Posts { get; set; }
    }
}
