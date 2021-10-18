using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.AspNetCore.Routing;

namespace WEB_953505_MANKEVICH.TagHelpers
{
    public class PagerTagHelper : TagHelper
    {
        private LinkGenerator _linkGenerator;

        public PagerTagHelper(LinkGenerator linkGenerator)
        {
            _linkGenerator = linkGenerator;
        }

        public int PageCurrent { get; set; }

        public int PageTotal { get; set; }

        public string PagerClass { get; set; }

        public string Action { get; set; }

        public string Controller { get; set; }
        public int? GroupId { get; set; }

        public override void Process(TagHelperContext context,
            TagHelperOutput output)
        {
            output.TagName = "nav";
            var ulTag = new TagBuilder("ul");
            ulTag.AddCssClass("pagination");
            ulTag.AddCssClass(PagerClass);
            for (var i = 1; i <= PageTotal; i++)
            {
                var url = _linkGenerator.GetPathByAction(Action,
                    Controller,
                    new
                    {
                        pageNo = i,
                        group = GroupId == 0
                            ? null
                            : GroupId
                    });
                var item = GetPagerItem(
                    url, i.ToString(),
                    i == PageCurrent,
                    i == PageCurrent
                );
                ulTag.InnerHtml.AppendHtml(item);
            }

            output.Content.AppendHtml(ulTag);
        }

        private TagBuilder GetPagerItem(string url, string text,
            bool active = false,
            bool disabled = false)
        {
            var liTag = new TagBuilder("li");
            liTag.AddCssClass("page-item");
            liTag.AddCssClass(active ? "active" : "");
            var aTag = new TagBuilder("a");
            aTag.AddCssClass("page-link");
            aTag.Attributes.Add("href", url);
            aTag.InnerHtml.Append(text);
            liTag.InnerHtml.AppendHtml(aTag);
            return liTag;
        }
    }
}