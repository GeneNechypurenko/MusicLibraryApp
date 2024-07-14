using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace MusicLibraryApp.TagHelpers
{
    [HtmlTargetElement("pagination", Attributes = "current-page, total-pages, action, route-params")]
    public class PaginationTagHelper : TagHelper
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public string Action { get; set; }
        public string RouteParams { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.TagMode = TagMode.StartTagAndEndTag;

            if (CurrentPage > 1)
            {
                var prevAnchor = new TagBuilder("a");
                prevAnchor.Attributes.Add("href", $"?{RouteParams}&pageNumber={CurrentPage - 1}");
                prevAnchor.InnerHtml.Append("Previous");
                output.Content.AppendHtml(prevAnchor);
            }

            if (CurrentPage < TotalPages)
            {
                var nextAnchor = new TagBuilder("a");
                nextAnchor.Attributes.Add("href", $"?{RouteParams}&pageNumber={CurrentPage + 1}");
                nextAnchor.InnerHtml.Append("Next");
                output.Content.AppendHtml(nextAnchor);
            }
        }
    }
}
