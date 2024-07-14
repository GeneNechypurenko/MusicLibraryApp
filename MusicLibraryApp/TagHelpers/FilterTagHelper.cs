using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace MusicLibraryApp.TagHelpers
{
    [HtmlTargetElement("filter", Attributes = "items, selected-value, action")]
    public class FilterTagHelper : TagHelper
    {
        public SelectList Items { get; set; }
        public int SelectedValue { get; set; }
        public string Action { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "form";
            output.TagMode = TagMode.StartTagAndEndTag;
            output.Attributes.SetAttribute("method", "get");
            output.Attributes.SetAttribute("asp-action", Action);

            var select = new TagBuilder("select");
            select.Attributes.Add("name", "selectedGenreId");

            foreach (var item in Items)
            {
                var option = new TagBuilder("option");
                option.Attributes.Add("value", item.Value);
                option.InnerHtml.Append(item.Text);
                if (item.Value == SelectedValue.ToString())
                {
                    option.Attributes.Add("selected", "selected");
                }
                select.InnerHtml.AppendHtml(option);
            }

            output.Content.AppendHtml(select);

            var button = new TagBuilder("button");
            button.Attributes.Add("type", "submit");
            button.InnerHtml.Append("Filter");
            output.Content.AppendHtml(button);
        }
    }
}
