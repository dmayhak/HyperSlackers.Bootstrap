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
    public class TableBodyBuilder<TModel> : DisposableHtmlElement<TModel, TableBody>
    {
        internal TableBodyBuilder(HtmlHelper<TModel> html, TableBody tableBody)
            : base(html, tableBody)
        {
            Contract.Requires<ArgumentNullException>(html != null, "html");
            Contract.Requires<ArgumentNullException>(tableBody != null, "tableBody");

            this.textWriter.Write(this.element.StartTag);
        }

        public TableRowBuilder<TModel> BeginRow(TableRow row)
        {
            Contract.Requires<ArgumentNullException>(row != null, "row");
            Contract.Ensures(Contract.Result<TableRowBuilder<TModel>>() != null);

            return new TableRowBuilder<TModel>(this.html, row);
        }

        public TableRowBuilder<TModel> BeginRow()
        {
            Contract.Ensures(Contract.Result<TableRowBuilder<TModel>>() != null);

            return new TableRowBuilder<TModel>(this.html, new TableRow());
        }

        public TableRowBuilder<TModel> BeginRow(TableColor style)
        {
            Contract.Ensures(Contract.Result<TableRowBuilder<TModel>>() != null);

            TableRow row = (new TableRow()).Style(style);

            return new TableRowBuilder<TModel>(this.html, row);
        }

        public TableRowBuilder<TModel> BeginRow(object htmlAttributes)
        {
            Contract.Requires<ArgumentNullException>(htmlAttributes != null, "htmlAttributes");
            Contract.Ensures(Contract.Result<TableRowBuilder<TModel>>() != null);

            TableRow tableRow = (new TableRow()).HtmlAttributes(htmlAttributes);

            return new TableRowBuilder<TModel>(this.html, tableRow);
        }

        public TableRowBuilder<TModel> BeginRow(TableColor style, object htmlAttributes)
        {
            Contract.Requires<ArgumentNullException>(htmlAttributes != null, "htmlAttributes");
            Contract.Ensures(Contract.Result<TableRowBuilder<TModel>>() != null);

            TableRow row = (new TableRow()).Style(style).HtmlAttributes(htmlAttributes);

            return new TableRowBuilder<TModel>(this.html, row);
        }
    }
}