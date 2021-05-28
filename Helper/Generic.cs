using Microsoft.AspNetCore.Components;

namespace Blogzor.Helper
{
    public static class Generic
    {
        public static MarkupString AsHtml(this string content) => new MarkupString(content);
    }
}
