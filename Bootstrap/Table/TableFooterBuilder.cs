using HyperSlackers.Bootstrap.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using HyperSlackers.Bootstrap.Extensions;

namespace HyperSlackers.Bootstrap.Builders
{
    public class TableFooterBuilder<TModel> : DisposableHtmlElement<TModel, TableFooter>
    {
        internal TableFooterBuilder(HtmlHelper<TModel> html, TableFooter tableFooter)
            : base(html, tableFooter)
        {
            Contract.Requires<ArgumentNullException>(html != null, "html");
            Contract.Requires<ArgumentNullException>(tableFooter != null, "tableFooter");

            this.textWriter.Write(this.element.StartTag);
        }

        public TableFooterRowBuilder<TModel> BeginRow()
        {
            Contract.Ensures(Contract.Result<TableFooterRowBuilder<TModel>>() != null);

            return new TableFooterRowBuilder<TModel>(this.html, new TableFooterRow());
        }

        public TableFooterRowBuilder<TModel> BeginRow(object htmlAttributes)
        {
            Contract.Requires<ArgumentNullException>(htmlAttributes != null, "htmlAttributes");
            Contract.Ensures(Contract.Result<TableFooterRowBuilder<TModel>>() != null);

            TableFooterRow row = (new TableFooterRow()).HtmlAttributes(htmlAttributes);

            return new TableFooterRowBuilder<TModel>(this.html, row);
        }

        public TableFooterRowBuilder<TModel> BeginRow(TableFooterRow row)
        {
            Contract.Requires<ArgumentNullException>(row != null, "row");
            Contract.Ensures(Contract.Result<TableFooterRowBuilder<TModel>>() != null);

            return new TableFooterRowBuilder<TModel>(this.html, row);
        }
    }
}