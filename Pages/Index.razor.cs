using Blogzor.Model;
using Blogzor.Services;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blogzor.Pages
{
    public partial class Index
    {
        [Inject]
        public BlogPostService BlogPostService { get; set; }

        public IList<BlogPost> Posts { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Posts = await BlogPostService.GetBlogPosts();
            Posts = Posts.OrderByDescending(_ => _.PublishedOn)
                .ToList();
        }
    }
}
