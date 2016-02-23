using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using HyperSlackers.Bootstrap;
using HyperSlackers.Bootstrap.Controls;
using System.Diagnostics.Contracts;
using HyperSlackers.Bootstrap.Core;
using HyperSlackers.Bootstrap.Extensions;

namespace HyperSlackers.Bootstrap.BootstrapMethods
{
    public partial class Bootstrap<TModel>
    {
        internal readonly HtmlHelper<TModel> html;

        internal Bootstrap(HtmlHelper<TModel> html)
		{
            Contract.Requires<ArgumentNullException>(html != null, "html");

            this.html = html;
		}

        public BootstrapHelpers<TModel> Helpers()
        {
            Contract.Ensures(Contract.Result<BootstrapHelpers<TModel>>() != null);

            return new BootstrapHelpers<TModel>(html);
        }

        public RowBuilder<TModel> BeginRow(Row row)
        {
            Contract.Requires<ArgumentNullException>(row != null, "row");
            Contract.Ensures(Contract.Result<RowBuilder<TModel>>() != null);

            return new RowBuilder<TModel>(html, row);
        }

        public RowBuilder<TModel> BeginRow(string id)
        {
            Contract.Requires<ArgumentNullException>(!id.IsNullOrWhiteSpace(), "id");
            Contract.Ensures(Contract.Result<RowBuilder<TModel>>() != null);

            return new RowBuilder<TModel>(html, new Row().Id(id));
        }

        public RowBuilder<TModel> BeginRow()
        {
            Contract.Ensures(Contract.Result<RowBuilder<TModel>>() != null);

            return new RowBuilder<TModel>(html, new Row());
        }

        public ColumnBuilder<TModel> BeginColumn(Column column)
        {
            Contract.Requires<ArgumentNullException>(column != null, "column");
            Contract.Ensures(Contract.Result<ColumnBuilder<TModel>>() != null);

            return new ColumnBuilder<TModel>(html, column);
        }

		public ColClassControl ColClass()
		{
            Contract.Ensures(Contract.Result<ColClassControl>() != null);

			return new ColClassControl();
		}

        public Defaults Defaults()
        {
            Contract.Ensures(Contract.Result<Defaults>() != null);

            return new Defaults(html);
        }

        public bool IsAuthorized<TController>(Expression<Action<TController>> action)
        {
            Contract.Requires<ArgumentNullException>(action != null, "action");

            return html.IsAuthorized(action);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToString()
        {
            return base.ToString();
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public new Type GetType()
        {
            return base.GetType();
        }
    }
}