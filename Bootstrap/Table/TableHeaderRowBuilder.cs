using HyperSlackers.Bootstrap.Controls;
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
    public class TableHeaderRowBuilder<TModel> : TableRowBuilderBase<TModel, TableHeaderRow, TableHeaderCellBuilder<TModel>, TableHeaderCellControl, TableHeaderCell>
    {
        internal TableHeaderRowBuilder(HtmlHelper<TModel> html, TableHeaderRow tableHeaderRow)
            : base(html, tableHeaderRow)
        {
            Contract.Requires<ArgumentNullException>(html != null, "html");
            Contract.Requires<ArgumentNullException>(tableHeaderRow != null, "tableHeaderRow");
        }

        public override TableHeaderCellBuilder<TModel> BeginCell()
        {
            Contract.Ensures(Contract.Result<TableHeaderCellBuilder<TModel>>() != null);

            return new TableHeaderCellBuilder<TModel>(html, new TableHeaderCell());
        }

        public override TableHeaderCellBuilder<TModel> BeginCell(object htmlAttributes)
        {
            //x Contract.Requires<ArgumentNullException>(htmlAttributes != null, "htmlAttributes");
            Contract.Ensures(Contract.Result<TableHeaderCellBuilder<TModel>>() != null);

            TableHeaderCell TableHeaderCell = (new TableHeaderCell()).HtmlAttributes(htmlAttributes);

            return new TableHeaderCellBuilder<TModel>(html, TableHeaderCell);
        }

        public override TableHeaderCellBuilder<TModel> BeginCell(TableHeaderCell TableHeaderCell)
        {
            //x Contract.Requires<ArgumentNullException>(TableHeaderCell != null, "TableHeaderCell");
            Contract.Ensures(Contract.Result<TableHeaderCellBuilder<TModel>>() != null);

            return new TableHeaderCellBuilder<TModel>(html, TableHeaderCell);
        }

        public override TableHeaderCellControl Cell(string html)
        {
            //x Contract.Requires<ArgumentNullException>(html != null, "html");
            Contract.Ensures(Contract.Result<TableHeaderCellControl>() != null);

            return new TableHeaderCellControl(html);
        }

        public override TableHeaderCellControl Cell(string html, TextAlign align)
        {
            //x Contract.Requires<ArgumentNullException>(html != null, "html");
            Contract.Ensures(Contract.Result<TableHeaderCellControl>() != null);

            return new TableHeaderCellControl(html).Align(align);
        }

        public override TableHeaderCellControl Cell(string html, TableColor style)
        {
            //x Contract.Requires<ArgumentNullException>(html != null, "html");
            Contract.Ensures(Contract.Result<TableHeaderCellControl>() != null);

            return new TableHeaderCellControl(html).Style(style);
        }

        public override TableHeaderCellControl Cell(string html, int colspan)
        {
            //x Contract.Requires<ArgumentNullException>(html != null, "html");
            //x Contract.Requires<ArgumentException>(colspan > 0);
            Contract.Ensures(Contract.Result<TableHeaderCellControl>() != null);

            return new TableHeaderCellControl(html).ColSpan(colspan);
        }

        public override TableHeaderCellControl Cell(string html, TextAlign align, TableColor style)
        {
            //x Contract.Requires<ArgumentNullException>(html != null, "html");
            Contract.Ensures(Contract.Result<TableHeaderCellControl>() != null);

            return new TableHeaderCellControl(html).Align(align).Style(style);
        }

        public override TableHeaderCellControl Cell(string html, TextAlign align, int colspan)
        {
            //x Contract.Requires<ArgumentNullException>(html != null, "html");
            //x Contract.Requires<ArgumentException>(colspan > 0);
            Contract.Ensures(Contract.Result<TableHeaderCellControl>() != null);

            return new TableHeaderCellControl(html).Align(align).ColSpan(colspan);
        }

        public override TableHeaderCellControl Cell(string html, TableColor style, int colspan)
        {
            //x Contract.Requires<ArgumentNullException>(html != null, "html");
            //x Contract.Requires<ArgumentException>(colspan > 0);
            Contract.Ensures(Contract.Result<TableHeaderCellControl>() != null);

            return new TableHeaderCellControl(html).Style(style).ColSpan(colspan);
        }

        public override TableHeaderCellControl Cell(string html, TextAlign align, TableColor style, int colspan)
        {
            //x Contract.Requires<ArgumentNullException>(html != null, "html");
            //x Contract.Requires<ArgumentException>(colspan > 0);
            Contract.Ensures(Contract.Result<TableHeaderCellControl>() != null);

            return new TableHeaderCellControl(html).Align(align).Style(style).ColSpan(colspan);
        }

        public override TableHeaderCellControl Cell(IHtmlString html)
        {
            //x Contract.Requires<ArgumentNullException>(html != null, "html");
            Contract.Ensures(Contract.Result<TableHeaderCellControl>() != null);

            return new TableHeaderCellControl(html);
        }

        public override TableHeaderCellControl Cell(IHtmlString html, TextAlign align)
        {
            //x Contract.Requires<ArgumentNullException>(html != null, "html");
            Contract.Ensures(Contract.Result<TableHeaderCellControl>() != null);

            return new TableHeaderCellControl(html).Align(align);
        }

        public override TableHeaderCellControl Cell(IHtmlString html, TableColor style)
        {
            //x Contract.Requires<ArgumentNullException>(html != null, "html");
            Contract.Ensures(Contract.Result<TableHeaderCellControl>() != null);

            return new TableHeaderCellControl(html).Style(style);
        }

        public override TableHeaderCellControl Cell(IHtmlString html, int colspan)
        {
            //x Contract.Requires<ArgumentNullException>(html != null, "html");
            //x Contract.Requires<ArgumentException>(colspan > 0);
            Contract.Ensures(Contract.Result<TableHeaderCellControl>() != null);

            return new TableHeaderCellControl(html).ColSpan(colspan);
        }

        public override TableHeaderCellControl Cell(IHtmlString html, TextAlign align, TableColor style)
        {
            //x Contract.Requires<ArgumentNullException>(html != null, "html");
            Contract.Ensures(Contract.Result<TableHeaderCellControl>() != null);

            return new TableHeaderCellControl(html).Align(align).Style(style);
        }

        public override TableHeaderCellControl Cell(IHtmlString html, TextAlign align, int colspan)
        {
            //x Contract.Requires<ArgumentNullException>(html != null, "html");
            //x Contract.Requires<ArgumentException>(colspan > 0);
            Contract.Ensures(Contract.Result<TableHeaderCellControl>() != null);

            return new TableHeaderCellControl(html).Align(align).ColSpan(colspan);
        }

        public override TableHeaderCellControl Cell(IHtmlString html, TableColor style, int colspan)
        {
            //x Contract.Requires<ArgumentNullException>(html != null, "html");
            //x Contract.Requires<ArgumentException>(colspan > 0);
            Contract.Ensures(Contract.Result<TableHeaderCellControl>() != null);

            return new TableHeaderCellControl(html).Style(style).ColSpan(colspan);
        }

        public override TableHeaderCellControl Cell(IHtmlString html, TextAlign align, TableColor style, int colspan)
        {
            //x Contract.Requires<ArgumentNullException>(html != null, "html");
            //x Contract.Requires<ArgumentException>(colspan > 0);
            Contract.Ensures(Contract.Result<TableHeaderCellControl>() != null);

            return new TableHeaderCellControl(html).Align(align).Style(style).ColSpan(colspan);
        }
    }
}