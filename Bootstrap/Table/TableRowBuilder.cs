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
    public class TableRowBuilder<TModel> : TableRowBuilderBase<TModel, TableRow, TableCellBuilder<TModel>, TableCellControl, TableCell>
    {
        internal TableRowBuilder(HtmlHelper<TModel> html, TableRow row)
            : base(html, row)
        {
            Contract.Requires<ArgumentNullException>(html != null, "html");
            Contract.Requires<ArgumentNullException>(row != null, "row");
        }

        public override TableCellBuilder<TModel> BeginCell()
        {
            Contract.Ensures(Contract.Result<TableCellBuilder<TModel>>() != null);

            return new TableCellBuilder<TModel>(html, new TableCell());
        }

        public override TableCellBuilder<TModel> BeginCell(object htmlAttributes)
        {
            //x Contract.Requires<ArgumentNullException>(htmlAttributes != null, "htmlAttributes");
            Contract.Ensures(Contract.Result<TableCellBuilder<TModel>>() != null);

            TableCell tableCell = (new TableCell()).HtmlAttributes(htmlAttributes);

            return new TableCellBuilder<TModel>(html, tableCell);
        }

        public override TableCellBuilder<TModel> BeginCell(TableCell tableCell)
        {
            //x Contract.Requires<ArgumentNullException>(tableCell != null, "tableCell");
            Contract.Ensures(Contract.Result<TableCellBuilder<TModel>>() != null);

            return new TableCellBuilder<TModel>(html, tableCell);
        }

        public override TableCellControl Cell(string html)
        {
            //x Contract.Requires<ArgumentNullException>(html != null, "html");
            Contract.Ensures(Contract.Result<TableCellControl>() != null);

            return new TableCellControl(html);
        }

        public override TableCellControl Cell(string html, TextAlign align)
        {
            //x Contract.Requires<ArgumentNullException>(html != null, "html");
            Contract.Ensures(Contract.Result<TableCellControl>() != null);

            return new TableCellControl(html).Align(align);
        }

        public override TableCellControl Cell(string html, TableColor style)
        {
            //x Contract.Requires<ArgumentNullException>(html != null, "html");
            Contract.Ensures(Contract.Result<TableCellControl>() != null);

            return new TableCellControl(html).Style(style);
        }

        public override TableCellControl Cell(string html, int colspan)
        {
            //x Contract.Requires<ArgumentNullException>(html != null, "html");
            //x Contract.Requires<ArgumentException>(colspan > 0);
            Contract.Ensures(Contract.Result<TableCellControl>() != null);

            return new TableCellControl(html).ColSpan(colspan);
        }

        public override TableCellControl Cell(string html, TextAlign align, TableColor style)
        {
            //x Contract.Requires<ArgumentNullException>(html != null, "html");
            Contract.Ensures(Contract.Result<TableCellControl>() != null);

            return new TableCellControl(html).Align(align).Style(style);
        }

        public override TableCellControl Cell(string html, TextAlign align, int colspan)
        {
            //x Contract.Requires<ArgumentNullException>(html != null, "html");
            //x Contract.Requires<ArgumentException>(colspan > 0);
            Contract.Ensures(Contract.Result<TableCellControl>() != null);

            return new TableCellControl(html).Align(align).ColSpan(colspan);
        }

        public override TableCellControl Cell(string html, TableColor style, int colspan)
        {
            //x Contract.Requires<ArgumentNullException>(html != null, "html");
            //x Contract.Requires<ArgumentException>(colspan > 0);
            Contract.Ensures(Contract.Result<TableCellControl>() != null);

            return new TableCellControl(html).Style(style).ColSpan(colspan);
        }

        public override TableCellControl Cell(string html, TextAlign align, TableColor style, int colspan)
        {
            //x Contract.Requires<ArgumentNullException>(html != null, "html");
            //x Contract.Requires<ArgumentException>(colspan > 0);
            Contract.Ensures(Contract.Result<TableCellControl>() != null);

            return new TableCellControl(html).Align(align).Style(style).ColSpan(colspan);
        }

        public override TableCellControl Cell(IHtmlString html)
        {
            //x Contract.Requires<ArgumentNullException>(html != null, "html");
            Contract.Ensures(Contract.Result<TableCellControl>() != null);

            return new TableCellControl(html);
        }

        public override TableCellControl Cell(IHtmlString html, TextAlign align)
        {
            //x Contract.Requires<ArgumentNullException>(html != null, "html");
            Contract.Ensures(Contract.Result<TableCellControl>() != null);

            return new TableCellControl(html).Align(align);
        }

        public override TableCellControl Cell(IHtmlString html, TableColor style)
        {
            //x Contract.Requires<ArgumentNullException>(html != null, "html");
            Contract.Ensures(Contract.Result<TableCellControl>() != null);

            return new TableCellControl(html).Style(style);
        }

        public override TableCellControl Cell(IHtmlString html, int colspan)
        {
            //x Contract.Requires<ArgumentNullException>(html != null, "html");
            //x Contract.Requires<ArgumentException>(colspan > 0);
            Contract.Ensures(Contract.Result<TableCellControl>() != null);

            return new TableCellControl(html).ColSpan(colspan);
        }

        public override TableCellControl Cell(IHtmlString html, TextAlign align, TableColor style)
        {
            //x Contract.Requires<ArgumentNullException>(html != null, "html");
            Contract.Ensures(Contract.Result<TableCellControl>() != null);

            return new TableCellControl(html).Align(align).Style(style);
        }

        public override TableCellControl Cell(IHtmlString html, TextAlign align, int colspan)
        {
            //x Contract.Requires<ArgumentNullException>(html != null, "html");
            //x Contract.Requires<ArgumentException>(colspan > 0);
            Contract.Ensures(Contract.Result<TableCellControl>() != null);

            return new TableCellControl(html).Align(align).ColSpan(colspan);
        }

        public override TableCellControl Cell(IHtmlString html, TableColor style, int colspan)
        {
            //x Contract.Requires<ArgumentNullException>(html != null, "html");
            //x Contract.Requires<ArgumentException>(colspan > 0);
            Contract.Ensures(Contract.Result<TableCellControl>() != null);

            return new TableCellControl(html).Style(style).ColSpan(colspan);
        }

        public override TableCellControl Cell(IHtmlString html, TextAlign align, TableColor style, int colspan)
        {
            //x Contract.Requires<ArgumentNullException>(html != null, "html");
            //x Contract.Requires<ArgumentException>(colspan > 0);
            Contract.Ensures(Contract.Result<TableCellControl>() != null);

            return new TableCellControl(html).Align(align).Style(style).ColSpan(colspan);
        }
    }
}