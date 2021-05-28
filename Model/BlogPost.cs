using System;
using System.IO;
using System.Threading.Tasks;

namespace Blogzor.Model
{
    public class BlogPost
    {
        public DateTime PublishedOn { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string Content { get; set; }

        public static async Task<BlogPost> FromFile(string postFilePath)
        {
            if (!File.Exists(postFilePath))
            {
                throw new Exception($"{postFilePath} file not found.");
            }

            var lastUpdated = File.GetLastWriteTime(postFilePath);
            var content = await File.ReadAllTextAsync(postFilePath);
            var lines = content.Split(Environment.NewLine);

            content = content.Replace(lines[0], string.Empty)
                .Replace(lines[1], string.Empty)
                .TrimStart();

            return new BlogPost
            {
                PublishedOn = lastUpdated,
                Title = lines[0].Replace("# ", string.Empty),
                Description = lines[1].Replace("## ", string.Empty),
                Content = content.Replace("\r\n", "<br/>")
            };
        }
    }
}
