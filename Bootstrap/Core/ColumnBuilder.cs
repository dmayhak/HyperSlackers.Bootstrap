using HyperSlackers.Bootstrap.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using HyperSlackers.Bootstrap.Extensions;

namespace HyperSlackers.Bootstrap.Controls
{
    /// <summary>
    /// Builder for a Bootstrap Column.
    /// </summary>
    /// <typeparam name="TModel">The type of the model.</typeparam>
    public class ColumnBuilder<TModel> : DisposableHtmlElement<TModel, Column>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ColumnBuilder{TModel}"/> class.
        /// </summary>
        /// <param name="html">The HTML.</param>
        /// <param name="column">The column.</param>
        internal ColumnBuilder(HtmlHelper<TModel> html, Column column)
            : base(html, column)
		{
            Contract.Requires<ArgumentNullException>(html != null, "html");
            Contract.Requires<ArgumentNullException>(column != null, "column");

            this.element.Class(Helpers.CssColClassWidth(this.element.widthXs, this.element.widthSm, this.element.widthMd, this.element.widthLg));
            this.element.Class(Helpers.CssColClassOffset(this.element.offsetXs, this.element.offsetSm, this.element.offsetMd, this.element.offsetLg));
            this.element.Class(Helpers.CssColClassPush(this.element.pushXs, this.element.pushSm, this.element.pushMd, this.element.pushLg));
            this.element.Class(Helpers.CssColClassPull(this.element.pullXs, this.element.pullSm, this.element.pullMd, this.element.pullLg));
            this.element.Class(Helpers.CssColClassHidden(this.element.hiddenXs, this.element.hiddenSm, this.element.hiddenMd, this.element.hiddenLg));
            this.element.Class(Helpers.CssColClassVisible(this.element.visibleXs, this.element.visibilityTypeXs, this.element.visibleSm, this.element.visibilityTypeSm, this.element.visibleMd, this.element.visibilityTypeMd, this.element.visibleLg, this.element.visibilityTypeLg));

            this.textWriter.Write(this.element.StartTag);
		}

        /// <summary>
        /// Begins a new child row.
        /// </summary>
        /// <param name="row">The row.</param>
        /// <returns></returns>
        public RowBuilder<TModel> BeginRow(Row row)
        {
            Contract.Requires<ArgumentNullException>(row != null, "row");
            Contract.Ensures(Contract.Result<RowBuilder<TModel>>() != null);

            return new RowBuilder<TModel>(this.html, row);
        }

        /// <summary>
        /// Begins a new child row.
        /// </summary>
        /// <returns></returns>
        public RowBuilder<TModel> BeginRow()
        {
            Contract.Ensures(Contract.Result<RowBuilder<TModel>>() != null);

            return new RowBuilder<TModel>(this.html, new Row());
        }
    }
}
