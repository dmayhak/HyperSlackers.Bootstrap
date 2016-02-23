using HyperSlackers.Bootstrap.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HyperSlackers.Bootstrap.Extensions;

namespace HyperSlackers.Bootstrap
{
    public class TreeHeader : HtmlElement<TreeHeader>
    {
        //internal List<HtmlElement> items = new List<HtmlElement>();
        internal string text { get; set; }
        internal bool? collapsed = false;
        internal CursorType cursor = CursorType.Pointer;

        public TreeHeader(string text)
            : base("li")
        {
            Contract.Requires<ArgumentException>(!text.IsNullOrWhiteSpace());

            this.text = text;

            AddClass("tree-toggle");
        }

        public TreeHeader Collapsed(bool collapsed = true)
        {
            Contract.Ensures(Contract.Result<TreeHeader>() != null);

            this.collapsed = collapsed;

            return this;
        }

        public TreeHeader Cursor(CursorType cursor)
        {
            Contract.Ensures(Contract.Result<TreeHeader>() != null);

            this.cursor = cursor;

            return this;
        }

        internal override string StartTag
        {
            get
            {
                StringBuilder startTag = new StringBuilder();

                startTag.Append(base.StartTag);
                if (collapsed.HasValue && collapsed.Value == true)
                {
                    startTag.Append(new FontAwesomeIcon(FontAwesomeIconType.PlusSquare).Class("tree-toggle").HtmlAttribute("style", "cursor: {0};".FormatWith(Helpers.GetCssClass(cursor))));
                    startTag.Append("&nbsp;<label class=\"tree-toggle nav-header\" style=\"cursor: {1};\">{0}</label>".FormatWith(text, Helpers.GetCssClass(cursor)));
                    startTag.Append("<ul class=\"nav nav-list tree\" style=\"display: none;\">");
                }
                else 
                {
                    startTag.Append(new FontAwesomeIcon(FontAwesomeIconType.MinusSquare).Class("tree-toggle").HtmlAttribute("style", "cursor: {0};".FormatWith(Helpers.GetCssClass(cursor))));
                    startTag.Append("&nbsp;<label class=\"tree-toggle nav-header\" style=\"cursor: {1};\">{0}</label>".FormatWith(text, Helpers.GetCssClass(cursor)));
                    startTag.Append("<ul class=\"nav nav-list tree\">");
                }

                return startTag.ToString();
            }
        }

        internal override string EndTag
        {
            get
            {
                return "</ul>" + base.EndTag;
            }
        }

        //public void Add(TreeHeader header)
        //{
        //    items.Add(header);
        //}

        //public void Add(TreeItem item)
        //{
        //    items.Add(item);
        //}
    }
}
