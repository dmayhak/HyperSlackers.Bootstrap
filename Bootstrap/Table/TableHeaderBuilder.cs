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
    public class TableHeaderBuilder<TModel> : DisposableHtmlElement<TModel, TableHeader>
    {
        internal TableHeaderBuilder(HtmlHelper<TModel> html, TableHeader tableHeader)
            : base(html, tableHeader)
        {
            Contract.Requires<ArgumentNullException>(html != null, "html");
            Contract.Requires<ArgumentNullException>(tableHeader != null, "tableHeader");

            textWriter.Write(element.StartTag);
        }

        public TableHeaderRowBuilder<TModel> BeginRow()
        {
            Contract.Ensures(Contract.Result<TableHeaderRowBuilder<TModel>>() != null);

            return new TableHeaderRowBuilder<TModel>(html, new TableHeaderRow());
        }

        public TableHeaderRowBuilder<TModel> BeginRow(object htmlAttributes)
        {
            Contract.Requires<ArgumentNullException>(htmlAttributes != null, "htmlAttributes");
            Contract.Ensures(Contract.Result<TableHeaderRowBuilder<TModel>>() != null);

            TableHeaderRow row = (new TableHeaderRow()).HtmlAttributes(htmlAttributes);

            return new TableHeaderRowBuilder<TModel>(html, row);
        }

        public TableHeaderRowBuilder<TModel> BeginRow(TableHeaderRow row)
        {
            Contract.Requires<ArgumentNullException>(row != null, "row");
            Contract.Ensures(Contract.Result<TableHeaderRowBuilder<TModel>>() != null);

            return new TableHeaderRowBuilder<TModel>(html, row);
        }
    }
}