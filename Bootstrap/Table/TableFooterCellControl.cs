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
    public class TableFooterCellControl : HtmlStringBase<TableFooterCellControl>
    {
        readonly private IHtmlString htmlText;

        public TableFooterCellControl(IHtmlString htmlText)
        {
            this.htmlText = htmlText;
        }

        public TableFooterCellControl ColSpan(int span)
        {
            Contract.Requires<ArgumentOutOfRangeException>(span > 0);
            Contract.Ensures(Contract.Result<TableFooterCellControl>() != null);

            this.attributes.AddOrReplace("colspan", span.ToString());

            return this;
        }

        public TableFooterCellControl Style(TableColor style)
        {
            Contract.Ensures(Contract.Result<TableFooterCellControl>() != null);

            this.attributes.AddClass(Helpers.GetCssClass(style));

            return this;
        }

        public TableFooterCellControl Align(TextAlign align)
        {
            Contract.Ensures(Contract.Result<TableFooterCellControl>() != null);

            if (align != TextAlign.None)
            {
                this.attributes.Add("align", align.ToString().ToLowerInvariant());
            }

            return this;
        }

        public TableFooterCellControl Width(TableCellWidth width)
        {
            Contract.Ensures(Contract.Result<TableFooterCellControl>() != null);

            if (width != TableCellWidth.None)
            {
                this.attributes.AddClass(Helpers.GetCssClass(width));
            }

            return this;
        }

        public TableFooterCellControl Width(string width)
        {
            Contract.Requires<ArgumentNullException>(width != null, "width");
            Contract.Requires<ArgumentException>(!width.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<TableFooterCellControl>() != null);

            this.attributes.AddOrReplace("width", width);

            return this;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToHtmlString()
        {
            Contract.Ensures(!Contract.Result<string>().IsNullOrWhiteSpace());

            IDictionary<string, object> attributes = this.attributes.FormatHtmlAttributes();

            TagBuilder tagBuilder = new TagBuilder("td");

            tagBuilder.MergeHtmlAttributes(attributes);
            tagBuilder.InnerHtml = this.htmlText.ToHtmlString();

            return tagBuilder.ToString(TagRenderMode.Normal);
        }
    }
}