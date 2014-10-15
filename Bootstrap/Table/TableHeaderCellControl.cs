using HyperSlackers.Bootstrap.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using HyperSlackers.Bootstrap.Extensions;

namespace HyperSlackers.Bootstrap.Controls
{
    public class TableHeaderCellControl : HtmlStringBase<TableHeaderCellControl>
    {
        readonly private IHtmlString htmlText;
        readonly internal bool isHeader;

        public TableHeaderCellControl(IHtmlString htmlText)
        {
            this.htmlText = htmlText;
            this.isHeader = false;
        }

        public TableHeaderCellControl ColSpan(int span)
        {
            Contract.Requires<ArgumentOutOfRangeException>(span > 0);
            Contract.Ensures(Contract.Result<TableHeaderCellControl>() != null);

            this.attributes.AddOrReplace("colspan", span.ToString());

            return this;
        }

        public TableHeaderCellControl Style(TableColor style)
        {
            Contract.Ensures(Contract.Result<TableHeaderCellControl>() != null);

            this.attributes.AddClass(Helpers.GetCssClass(style));

            return this;
        }

        public TableHeaderCellControl Align(TextAlign align)
        {
            Contract.Ensures(Contract.Result<TableHeaderCellControl>() != null);

            if (align != TextAlign.None)
            {
                this.attributes.Add("align", align.ToString().ToLowerInvariant());
            }

            return this;
        }

        public TableHeaderCellControl Width(TableCellWidth width)
        {
            Contract.Ensures(Contract.Result<TableHeaderCellControl>() != null);

            if (width != TableCellWidth.None)
            {
                this.attributes.AddClass(Helpers.GetCssClass(width));
            }

            return this;
        }

        public TableHeaderCellControl Width(string width)
        {
            Contract.Requires<ArgumentNullException>(width != null, "width");
            Contract.Requires<ArgumentException>(!width.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<TableHeaderCellControl>() != null);

            this.attributes.AddOrReplace("width", width);

            return this;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToHtmlString()
        {
            Contract.Ensures(!Contract.Result<string>().IsNullOrWhiteSpace());

            IDictionary<string, object> attributes = this.attributes.FormatHtmlAttributes();

            TagBuilder tagBuilder = new TagBuilder("th");

            tagBuilder.MergeHtmlAttributes(attributes);
            tagBuilder.InnerHtml = this.htmlText.ToHtmlString();

            return tagBuilder.ToString(TagRenderMode.Normal);
        }
    }
}