using HyperSlackers.Bootstrap.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using HyperSlackers.Bootstrap.Extensions;

namespace HyperSlackers.Bootstrap.Builders
{
    public class TableBuilder<TModel> : DisposableHtmlElement<TModel, Table>
    {
        private bool disposed = false;

        internal TableBuilder(HtmlHelper<TModel> html, Table table)
            : base(html, table)
        {
            Contract.Requires<ArgumentNullException>(html != null, "html");
            Contract.Requires<ArgumentNullException>(table != null, "table");

            textWriter.Write(element.StartTag);

            if (!element.caption.IsNullOrWhiteSpace())
            {
                textWriter.Write(string.Format("<caption>{0}</caption>", element.caption));
            }
        }

        public TableHeaderBuilder<TModel> BeginHeader()
        {
            Contract.Ensures(Contract.Result<TableHeaderBuilder<TModel>>() != null);

            element.wasHeaderTagRendered = true;

            return new TableHeaderBuilder<TModel>(html, new TableHeader());
        }

        public TableHeaderBuilder<TModel> BeginHeader(TableHeader header)
        {
            Contract.Requires<ArgumentNullException>(header != null, "header");
            Contract.Ensures(Contract.Result<TableHeaderBuilder<TModel>>() != null);

            element.wasHeaderTagRendered = true;

            return new TableHeaderBuilder<TModel>(html, header);
        }

        public IHtmlString Header(params string[] columnHeaders)
        {
            Contract.Requires<ArgumentNullException>(columnHeaders != null, "columnHeaders");

            return Header(TableColor.Default, columnHeaders);
        }

        public IHtmlString Header(TableColor style, params string[] columnHeaders)
        {
            Contract.Requires<ArgumentNullException>(columnHeaders != null, "columnHeaders");

            EnsureHeader();

            StringBuilder header = new StringBuilder();
            TableHeaderRow row = new TableHeaderRow();
            TableHeaderCell cell = new TableHeaderCell();

            row.Style(style);

            header.Append(row.StartTag);

            foreach (var item in columnHeaders)
            {
                header.Append(cell.StartTag);
                header.Append(item);
                header.Append(cell.EndTag);
            }

            header.Append(row.EndTag);

            return MvcHtmlString.Create(header.ToString());
        }

        public IHtmlString Header(params IHtmlString[] columnHeaders)
        {
            Contract.Requires<ArgumentNullException>(columnHeaders != null, "columnHeaders");

            return Header(TableColor.Default, columnHeaders);
        }

        public IHtmlString Header(TableColor style, params IHtmlString[] columnHeaders)
        {
            Contract.Requires<ArgumentNullException>(columnHeaders != null, "columnHeaders");

            EnsureHeader();

            StringBuilder header = new StringBuilder();
            TableHeaderRow row = new TableHeaderRow();
            TableHeaderCell cell = new TableHeaderCell();

            row.Style(style);

            header.Append(row.StartTag);

            foreach (var item in columnHeaders)
            {
                header.Append(cell.StartTag);
                header.Append(item);
                header.Append(cell.EndTag);
            }

            header.Append(row.EndTag);

            return MvcHtmlString.Create(header.ToString());
        }

        public TableBodyBuilder<TModel> BeginBody()
        {
            Contract.Ensures(Contract.Result<TableBodyBuilder<TModel>>() != null);

            element.wasBodyTagRendered = true;

            return new TableBodyBuilder<TModel>(html, new TableBody());
        }

        public TableBodyBuilder<TModel> BeginBody(TableBody body)
        {
            Contract.Requires<ArgumentNullException>(body != null, "body");
            Contract.Ensures(Contract.Result<TableBodyBuilder<TModel>>() != null);

            element.wasBodyTagRendered = true;

            return new TableBodyBuilder<TModel>(html, body);
        }

        public TableRowBuilder<TModel> BeginRow()
        {
            Contract.Ensures(Contract.Result<TableRowBuilder<TModel>>() != null);

            EnsureBody();

            return new TableRowBuilder<TModel>(html, new TableRow());
        }

        public TableRowBuilder<TModel> BeginRow(TableRow row)
        {
            Contract.Requires<ArgumentNullException>(row != null, "row");
            Contract.Ensures(Contract.Result<TableRowBuilder<TModel>>() != null);

            EnsureBody();

            return new TableRowBuilder<TModel>(html, row);
        }

        public TableRowBuilder<TModel> BeginRow(TableColor style)
        {
            Contract.Ensures(Contract.Result<TableRowBuilder<TModel>>() != null);

            EnsureBody();

            TableRow tableRow = (new TableRow()).Style(style);

            return new TableRowBuilder<TModel>(html, tableRow);
        }

        public TableRowBuilder<TModel> BeginRow(object htmlAttributes)
        {
            Contract.Requires<ArgumentNullException>(htmlAttributes != null, "htmlAttributes");
            Contract.Ensures(Contract.Result<TableRowBuilder<TModel>>() != null);

            EnsureBody();

            TableRow tableRow = (new TableRow()).HtmlAttributes(htmlAttributes);

            return new TableRowBuilder<TModel>(html, tableRow);
        }

        public TableRowBuilder<TModel> BeginRow(TableColor style, object htmlAttributes)
        {
            Contract.Requires<ArgumentNullException>(htmlAttributes != null, "htmlAttributes");
            Contract.Ensures(Contract.Result<TableRowBuilder<TModel>>() != null);

            EnsureBody();

            TableRow tableRow = (new TableRow()).Style(style).HtmlAttributes(htmlAttributes);

            return new TableRowBuilder<TModel>(html, tableRow);
        }

        public IHtmlString Row(params string[] cellContents)
        {
            Contract.Requires<ArgumentNullException>(cellContents != null, "cellContents");

            return Row(TableColor.Default, cellContents);
        }

        public IHtmlString Row(TableColor style, params string[] cellContents)
        {
            Contract.Requires<ArgumentNullException>(cellContents != null, "cellContents");

            EnsureBody();

            StringBuilder tableRow = new StringBuilder();
            TableRow row = new TableRow();
            TableCell cell = new TableCell();

            row.Style(style);

            tableRow.Append(row.StartTag);

            foreach (var item in cellContents)
            {
                tableRow.Append(cell.StartTag);
                tableRow.Append(item);
                tableRow.Append(cell.EndTag);
            }

            tableRow.Append(row.EndTag);

            return MvcHtmlString.Create(tableRow.ToString());
        }

        public IHtmlString Row(params IHtmlString[] cellContents)
        {
            Contract.Requires<ArgumentNullException>(cellContents != null, "cellContents");

            return Row(TableColor.Default, cellContents);
        }

        public IHtmlString Row(TableColor style, params IHtmlString[] cellContents)
        {
            Contract.Requires<ArgumentNullException>(cellContents != null, "cellContents");

            EnsureBody();

            StringBuilder tableRow = new StringBuilder();
            TableRow row = new TableRow();
            TableCell cell = new TableCell();

            row.Style(style);

            tableRow.Append(row.StartTag);

            foreach (var item in cellContents)
            {
                tableRow.Append(cell.StartTag);
                tableRow.Append(item);
                tableRow.Append(cell.EndTag);
            }

            tableRow.Append(row.EndTag);

            return MvcHtmlString.Create(tableRow.ToString());
        }

        public TableFooterBuilder<TModel> BeginFooter()
        {
            Contract.Ensures(Contract.Result<TableFooterBuilder<TModel>>() != null);

            return new TableFooterBuilder<TModel>(html, new TableFooter());
        }

        public TableFooterBuilder<TModel> BeginFooter(TableFooter footer)
        {
            Contract.Requires<ArgumentNullException>(footer != null, "footer");
            Contract.Ensures(Contract.Result<TableFooterBuilder<TModel>>() != null);

            return new TableFooterBuilder<TModel>(html, footer);
        }

        public IHtmlString Footer(params string[] columnFooters)
        {
            Contract.Requires<ArgumentNullException>(columnFooters != null, "columnFooters");

            EnsureFooter();

            StringBuilder footer = new StringBuilder();
            TableFooterRow row = new TableFooterRow();
            TableFooterCell cell = new TableFooterCell();

            footer.Append(row.StartTag);

            foreach (var item in columnFooters)
            {
                footer.Append(cell.StartTag);
                footer.Append(item);
                footer.Append(cell.EndTag);
            }

            footer.Append(row.EndTag);

            return MvcHtmlString.Create(footer.ToString());
        }

        public IHtmlString Footer(params IHtmlString[] columnFooters)
        {
            Contract.Requires<ArgumentNullException>(columnFooters != null, "columnFooters");

            EnsureFooter();

            StringBuilder footer = new StringBuilder();
            TableFooterRow row = new TableFooterRow();
            TableFooterCell cell = new TableFooterCell();

            footer.Append(row.StartTag);

            foreach (var item in columnFooters)
            {
                footer.Append(cell.StartTag);
                footer.Append(item);
                footer.Append(cell.EndTag);
            }

            footer.Append(row.EndTag);

            return MvcHtmlString.Create(footer.ToString());
        }

        private void EnsureHeader()
        {
            if (!element.wasHeaderTagRendered && !element.isHeaderTagOpen)
            {
                element.isHeaderTagOpen = true;

                textWriter.Write("<thead>");
            }
        }

        private void EnsureHeaderClosed()
        {
            if (element.isHeaderTagOpen)
            {
                element.isHeaderTagOpen = false;
                element.wasHeaderTagRendered = true;

                textWriter.Write("</thead>");
            }
        }

        private void EnsureBody()
        {
            EnsureHeaderClosed();

            if (!element.wasBodyTagRendered && !element.isBodyTagOpen)
            {
                element.isBodyTagOpen = true;

                textWriter.Write("<tbody>");
            }
        }

        private void EnsureBodyClosed()
        {
            if (element.isBodyTagOpen)
            {
                element.isBodyTagOpen = false;
                element.wasBodyTagRendered = true;

                textWriter.Write("</tbody>");
            }
        }

        private void EnsureFooter()
        {
            EnsureHeaderClosed();
            EnsureBodyClosed();

            if (!element.wasFooterTagRendered && !element.isFooterTagOpen)
            {
                element.isFooterTagOpen = true;

                textWriter.Write("<tfoot>");
            }
        }

        private void EnsureFooterClosed()
        {
            if (element.isFooterTagOpen)
            {
                element.isFooterTagOpen = false;
                element.wasFooterTagRendered = true;

                textWriter.Write("</tfoot>");
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    EnsureHeaderClosed();
                    EnsureBodyClosed();
                    EnsureFooterClosed();

                    disposed = true;
                }
            }

            base.Dispose(true);
        }
    }
}