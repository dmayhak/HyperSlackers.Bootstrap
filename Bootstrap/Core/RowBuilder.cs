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
    /// Builder for a Bootstrap Row.
    /// </summary>
    /// <typeparam name="TModel">The type of the model.</typeparam>
    public class RowBuilder<TModel> : DisposableHtmlElement<TModel, Row>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RowBuilder{TModel}"/> class.
        /// </summary>
        /// <param name="html">The HTML.</param>
        /// <param name="row">The row.</param>
        internal RowBuilder(HtmlHelper<TModel> html, Row row)
            : base(html, row)
		{
            Contract.Requires<ArgumentNullException>(html != null, "html");
            Contract.Requires<ArgumentNullException>(row != null, "row");

            this.textWriter.Write(this.element.StartTag);
		}

        /// <summary>
        /// Begins a new Bootstrap Column.
        /// </summary>
        /// <param name="column">The column.</param>
        /// <returns></returns>
        public ColumnBuilder<TModel> BeginColumn(Column column)
        {
            Contract.Requires<ArgumentNullException>(column != null, "column");
            Contract.Ensures(Contract.Result<ColumnBuilder<TModel>>() != null);

            return new ColumnBuilder<TModel>(this.html, column);
        }
    }
}
