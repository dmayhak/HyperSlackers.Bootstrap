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
        private bool disposed;

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

            element.Class(Helpers.CssColClassWidth(element.widthXs, element.widthSm, element.widthMd, element.widthLg));
            element.Class(Helpers.CssColClassOffset(element.offsetXs, element.offsetSm, element.offsetMd, element.offsetLg));
            element.Class(Helpers.CssColClassPush(element.pushXs, element.pushSm, element.pushMd, element.pushLg));
            element.Class(Helpers.CssColClassPull(element.pullXs, element.pullSm, element.pullMd, element.pullLg));
            element.Class(Helpers.CssColClassHidden(element.hiddenXs, element.hiddenSm, element.hiddenMd, element.hiddenLg));
            element.Class(Helpers.CssColClassVisible(element.visibleXs, element.visibilityTypeXs, element.visibleSm, element.visibilityTypeSm, element.visibleMd, element.visibilityTypeMd, element.visibleLg, element.visibilityTypeLg));

            textWriter.Write(element.StartTag);
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

            return new RowBuilder<TModel>(html, row);
        }

        /// <summary>
        /// Begins a new child row.
        /// </summary>
        /// <returns></returns>
        public RowBuilder<TModel> BeginRow()
        {
            Contract.Ensures(Contract.Result<RowBuilder<TModel>>() != null);

            return new RowBuilder<TModel>(html, new Row());
        }

        protected override void Dispose(bool disposing)
        {
            // build clearfix div if needed
            TagBuilder clearfixDiv = null;
            if (element.clearfixXs || element.clearfixSm || element.clearfixMd || element.clearfixLg)
            {
                clearfixDiv = new TagBuilder("div");

                clearfixDiv.AddCssClass("clearfix");

                if (element.clearfixXs)
                {
                    clearfixDiv.AddCssClass("visible-xs-block");
                }
                if (element.clearfixSm)
                {
                    clearfixDiv.AddCssClass("visible-sm-block");
                }
                if (element.clearfixMd)
                {
                    clearfixDiv.AddCssClass("visible-md-block");
                }
                if (element.clearfixLg)
                {
                    clearfixDiv.AddCssClass("visible-lg-block");
                }
            }

            // let base class close up first
            base.Dispose(disposing);

            // now we can add a clearfix div if required
            if (!disposed)
            {
                if (disposing)
                {
                    if (!doNotRender)
                    {
                        // done in base classthis.textWriter.Write(this.element.EndTag);

                        if (clearfixDiv != null)
                        {
                            textWriter.Write(clearfixDiv);
                        }
                    }

                    disposed = true;
                }
            }
        }
    }
}
