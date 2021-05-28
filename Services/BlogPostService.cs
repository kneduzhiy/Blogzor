using Blogzor.Model;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Blogzor.Services
{
    public class BlogPostService
    {
        private const string FilesDirectory = "_BlogzorFiles";
        private string PostsDirectory => $"{FilesDirectory}/posts/";
        private string ConfigFile => $"{FilesDirectory}/blogzor.json";

        private BlogzorConfig _config;
        public BlogzorConfig Config
        {
            get
            {
                _config ??= JsonConvert.DeserializeObject<BlogzorConfig>(File.ReadAllText(this.ConfigFile));
                return _config;
            }
        }

        public async Task<IList<BlogPost>> GetBlogPosts(string byAuthor = null)
        {
            var allPosts = new List<BlogPost>();
            var authors = Directory.GetDirectories(PostsDirectory);

            foreach (string author in authors)
            {
                var posts = Directory.GetFiles($"{author}/");
                foreach (string postFile in posts)
                {
                    var blogPost = await BlogPost.FromFile(postFile);
                    blogPost.Author = author.Replace(PostsDirectory, string.Empty);

                    allPosts.Add(blogPost);
                }
            }

            return allPosts;
        }
    }
}
