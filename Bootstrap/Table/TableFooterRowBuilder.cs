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
    public class TableFooterRowBuilder<TModel> : TableRowBuilderBase<TModel, TableFooterRow, TableFooterCellBuilder<TModel>, TableFooterCellControl, TableFooterCell>
    {
        internal TableFooterRowBuilder(HtmlHelper<TModel> html, TableFooterRow tableFooterRow)
            : base(html, tableFooterRow)
        {
            Contract.Requires<ArgumentNullException>(html != null, "html");
            Contract.Requires<ArgumentNullException>(tableFooterRow != null, "tableFooterRow");
        }

        public override TableFooterCellBuilder<TModel> BeginCell()
        {
            Contract.Ensures(Contract.Result<TableFooterCellBuilder<TModel>>() != null);

            return new TableFooterCellBuilder<TModel>(html, new TableFooterCell());
        }

        public override TableFooterCellBuilder<TModel> BeginCell(object htmlAttributes)
        {
            //x Contract.Requires<ArgumentNullException>(htmlAttributes != null, "htmlAttributes");
            Contract.Ensures(Contract.Result<TableFooterCellBuilder<TModel>>() != null);

            TableFooterCell TableFooterCell = (new TableFooterCell()).HtmlAttributes(htmlAttributes);

            return new TableFooterCellBuilder<TModel>(html, TableFooterCell);
        }

        public override TableFooterCellBuilder<TModel> BeginCell(TableFooterCell TableFooterCell)
        {
            //x Contract.Requires<ArgumentNullException>(TableFooterCell != null, "TableFooterCell");
            Contract.Ensures(Contract.Result<TableFooterCellBuilder<TModel>>() != null);

            return new TableFooterCellBuilder<TModel>(html, TableFooterCell);
        }

        public override TableFooterCellControl Cell(string html)
        {
            //x Contract.Requires<ArgumentNullException>(html != null, "html");
            Contract.Ensures(Contract.Result<TableFooterCellControl>() != null);

            return new TableFooterCellControl(html);
        }

        public override TableFooterCellControl Cell(string html, TextAlign align)
        {
            //x Contract.Requires<ArgumentNullException>(html != null, "html");
            Contract.Ensures(Contract.Result<TableFooterCellControl>() != null);

            return new TableFooterCellControl(html).Align(align);
        }

        public override TableFooterCellControl Cell(string html, TableColor style)
        {
            //x Contract.Requires<ArgumentNullException>(html != null, "html");
            Contract.Ensures(Contract.Result<TableFooterCellControl>() != null);

            return new TableFooterCellControl(html).Style(style);
        }

        public override TableFooterCellControl Cell(string html, int colspan)
        {
            //x Contract.Requires<ArgumentNullException>(html != null, "html");
            //x Contract.Requires<ArgumentException>(colspan > 0);
            Contract.Ensures(Contract.Result<TableFooterCellControl>() != null);

            return new TableFooterCellControl(html).ColSpan(colspan);
        }

        public override TableFooterCellControl Cell(string html, TextAlign align, TableColor style)
        {
            //x Contract.Requires<ArgumentNullException>(html != null, "html");
            Contract.Ensures(Contract.Result<TableFooterCellControl>() != null);

            return new TableFooterCellControl(html).Align(align).Style(style);
        }

        public override TableFooterCellControl Cell(string html, TextAlign align, int colspan)
        {
            //x Contract.Requires<ArgumentNullException>(html != null, "html");
            //x Contract.Requires<ArgumentException>(colspan > 0);
            Contract.Ensures(Contract.Result<TableFooterCellControl>() != null);

            return new TableFooterCellControl(html).Align(align).ColSpan(colspan);
        }

        public override TableFooterCellControl Cell(string html, TableColor style, int colspan)
        {
            //x Contract.Requires<ArgumentNullException>(html != null, "html");
            //x Contract.Requires<ArgumentException>(colspan > 0);
            Contract.Ensures(Contract.Result<TableFooterCellControl>() != null);

            return new TableFooterCellControl(html).Style(style).ColSpan(colspan);
        }

        public override TableFooterCellControl Cell(string html, TextAlign align, TableColor style, int colspan)
        {
            //x Contract.Requires<ArgumentNullException>(html != null, "html");
            //x Contract.Requires<ArgumentException>(colspan > 0);
            Contract.Ensures(Contract.Result<TableFooterCellControl>() != null);

            return new TableFooterCellControl(html).Align(align).Style(style).ColSpan(colspan);
        }

        public override TableFooterCellControl Cell(IHtmlString html)
        {
            //x Contract.Requires<ArgumentNullException>(html != null, "html");
            Contract.Ensures(Contract.Result<TableFooterCellControl>() != null);

            return new TableFooterCellControl(html);
        }

        public override TableFooterCellControl Cell(IHtmlString html, TextAlign align)
        {
            //x Contract.Requires<ArgumentNullException>(html != null, "html");
            Contract.Ensures(Contract.Result<TableFooterCellControl>() != null);

            return new TableFooterCellControl(html).Align(align);
        }

        public override TableFooterCellControl Cell(IHtmlString html, TableColor style)
        {
            //x Contract.Requires<ArgumentNullException>(html != null, "html");
            Contract.Ensures(Contract.Result<TableFooterCellControl>() != null);

            return new TableFooterCellControl(html).Style(style);
        }

        public override TableFooterCellControl Cell(IHtmlString html, int colspan)
        {
            //x Contract.Requires<ArgumentNullException>(html != null, "html");
            //x Contract.Requires<ArgumentException>(colspan > 0);
            Contract.Ensures(Contract.Result<TableFooterCellControl>() != null);

            return new TableFooterCellControl(html).ColSpan(colspan);
        }

        public override TableFooterCellControl Cell(IHtmlString html, TextAlign align, TableColor style)
        {
            //x Contract.Requires<ArgumentNullException>(html != null, "html");
            Contract.Ensures(Contract.Result<TableFooterCellControl>() != null);

            return new TableFooterCellControl(html).Align(align).Style(style);
        }

        public override TableFooterCellControl Cell(IHtmlString html, TextAlign align, int colspan)
        {
            //x Contract.Requires<ArgumentNullException>(html != null, "html");
            //x Contract.Requires<ArgumentException>(colspan > 0);
            Contract.Ensures(Contract.Result<TableFooterCellControl>() != null);

            return new TableFooterCellControl(html).Align(align).ColSpan(colspan);
        }

        public override TableFooterCellControl Cell(IHtmlString html, TableColor style, int colspan)
        {
            //x Contract.Requires<ArgumentNullException>(html != null, "html");
            //x Contract.Requires<ArgumentException>(colspan > 0);
            Contract.Ensures(Contract.Result<TableFooterCellControl>() != null);

            return new TableFooterCellControl(html).Style(style).ColSpan(colspan);
        }

        public override TableFooterCellControl Cell(IHtmlString html, TextAlign align, TableColor style, int colspan)
        {
            //x Contract.Requires<ArgumentNullException>(html != null, "html");
            //x Contract.Requires<ArgumentException>(colspan > 0);
            Contract.Ensures(Contract.Result<TableFooterCellControl>() != null);

            return new TableFooterCellControl(html).Align(align).Style(style).ColSpan(colspan);
        }
    }
}