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

            this.textWriter.Write(this.element.StartTag);

            if (!this.element.caption.IsNullOrWhiteSpace())
            {
                this.textWriter.Write(string.Format("<caption>{0}</caption>", this.element.caption));
            }
        }

        public TableHeaderBuilder<TModel> BeginHeader()
        {
            Contract.Ensures(Contract.Result<TableHeaderBuilder<TModel>>() != null);

            this.element.wasHeaderTagRendered = true;

            return new TableHeaderBuilder<TModel>(this.html, new TableHeader());
        }

        public TableHeaderBuilder<TModel> BeginHeader(TableHeader header)
        {
            Contract.Requires<ArgumentNullException>(header != null, "header");
            Contract.Ensures(Contract.Result<TableHeaderBuilder<TModel>>() != null);

            this.element.wasHeaderTagRendered = true;

            return new TableHeaderBuilder<TModel>(this.html, header);
        }

        public IHtmlString Header(params string[] columnHeaders)
        {
            Contract.Requires<ArgumentNullException>(columnHeaders != null, "columnHeaders");

            EnsureHeader();

            StringBuilder header = new StringBuilder();
            TableHeaderRow row = new TableHeaderRow();
            TableHeaderCell cell = new TableHeaderCell();

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

            EnsureHeader();

            StringBuilder header = new StringBuilder();
            TableHeaderRow row = new TableHeaderRow();
            TableHeaderCell cell = new TableHeaderCell();

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

            this.element.wasBodyTagRendered = true;

            return new TableBodyBuilder<TModel>(this.html, new TableBody());
        }

        public TableBodyBuilder<TModel> BeginBody(TableBody body)
        {
            Contract.Requires<ArgumentNullException>(body != null, "body");
            Contract.Ensures(Contract.Result<TableBodyBuilder<TModel>>() != null);

            this.element.wasBodyTagRendered = true;

            return new TableBodyBuilder<TModel>(this.html, body);
        }

        public TableRowBuilder<TModel> BeginRow()
        {
            Contract.Ensures(Contract.Result<TableRowBuilder<TModel>>() != null);

            EnsureBody();

            return new TableRowBuilder<TModel>(this.html, new TableRow());
        }

        public TableRowBuilder<TModel> BeginRow(TableRow row)
        {
            Contract.Requires<ArgumentNullException>(row != null, "row");
            Contract.Ensures(Contract.Result<TableRowBuilder<TModel>>() != null);

            EnsureBody();

            return new TableRowBuilder<TModel>(this.html, row);
        }

        public TableRowBuilder<TModel> BeginRow(TableColor style)
        {
            Contract.Ensures(Contract.Result<TableRowBuilder<TModel>>() != null);

            EnsureBody();

            TableRow tableRow = (new TableRow()).Style(style);

            return new TableRowBuilder<TModel>(this.html, tableRow);
        }

        public TableRowBuilder<TModel> BeginRow(object htmlAttributes)
        {
            Contract.Requires<ArgumentNullException>(htmlAttributes != null, "htmlAttributes");
            Contract.Ensures(Contract.Result<TableRowBuilder<TModel>>() != null);

            EnsureBody();

            TableRow tableRow = (new TableRow()).HtmlAttributes(htmlAttributes);

            return new TableRowBuilder<TModel>(this.html, tableRow);
        }

        public TableRowBuilder<TModel> BeginRow(TableColor style, object htmlAttributes)
        {
            Contract.Requires<ArgumentNullException>(htmlAttributes != null, "htmlAttributes");
            Contract.Ensures(Contract.Result<TableRowBuilder<TModel>>() != null);

            EnsureBody();

            TableRow tableRow = (new TableRow()).Style(style).HtmlAttributes(htmlAttributes);

            return new TableRowBuilder<TModel>(this.html, tableRow);
        }

        public IHtmlString Row(params string[] cellContents)
        {
            Contract.Requires<ArgumentNullException>(cellContents != null, "cellContents");

            EnsureBody();

            StringBuilder tableRow = new StringBuilder();
            TableRow row = new TableRow();
            TableCell cell = new TableCell();

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

            EnsureBody();

            StringBuilder tableRow = new StringBuilder();
            TableRow row = new TableRow();
            TableCell cell = new TableCell();

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

            return new TableFooterBuilder<TModel>(this.html, new TableFooter());
        }

        public TableFooterBuilder<TModel> BeginFooter(TableFooter footer)
        {
            Contract.Requires<ArgumentNullException>(footer != null, "footer");
            Contract.Ensures(Contract.Result<TableFooterBuilder<TModel>>() != null);

            return new TableFooterBuilder<TModel>(this.html, footer);
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
            if (!this.element.wasHeaderTagRendered && !this.element.isHeaderTagOpen)
            {
                this.element.isHeaderTagOpen = true;

                this.textWriter.Write("<thead>");
            }
        }

        private void EnsureHeaderClosed()
        {
            if (this.element.isHeaderTagOpen)
            {
                this.element.isHeaderTagOpen = false;
                this.element.wasHeaderTagRendered = true;

                this.textWriter.Write("</thead>");
            }
        }

        private void EnsureBody()
        {
            EnsureHeaderClosed();

            if (!this.element.wasBodyTagRendered && !this.element.isBodyTagOpen)
            {
                this.element.isBodyTagOpen = true;

                this.textWriter.Write("<tbody>");
            }
        }

        private void EnsureBodyClosed()
        {
            if (this.element.isBodyTagOpen)
            {
                this.element.isBodyTagOpen = false;
                this.element.wasBodyTagRendered = true;

                this.textWriter.Write("</tbody>");
            }
        }

        private void EnsureFooter()
        {
            EnsureHeaderClosed();
            EnsureBodyClosed();

            if (!this.element.wasFooterTagRendered && !this.element.isFooterTagOpen)
            {
                this.element.isFooterTagOpen = true;

                this.textWriter.Write("<tfoot>");
            }
        }

        private void EnsureFooterClosed()
        {
            if (this.element.isFooterTagOpen)
            {
                this.element.isFooterTagOpen = false;
                this.element.wasFooterTagRendered = true;

                this.textWriter.Write("</tfoot>");
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    EnsureHeaderClosed();
                    EnsureBodyClosed();
                    EnsureFooterClosed();

                    this.disposed = true;
                }
            }

            base.Dispose(true);
        }
    }
}