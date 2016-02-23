using System;
using System.Web.Mvc;
using HyperSlackers.Bootstrap;
using System.Diagnostics.Contracts;
using HyperSlackers.Bootstrap.Core;
using HyperSlackers.Bootstrap.Extensions;

namespace HyperSlackers.Bootstrap.Controls
{
	public class ToolBarBuilder<TModel> : BuilderBase<TModel, ToolBar>
	{
		internal ToolBarBuilder(HtmlHelper<TModel> html, ToolBar toolbar) 
            : base(html, toolbar)
		{
            Contract.Requires<ArgumentNullException>(html != null, "html");
            Contract.Requires<ArgumentNullException>(toolbar != null, "toolbar");
        }

        public ButtonGroupBuilder<TModel> BeginButtonGroup()
        {
            Contract.Ensures(Contract.Result<ButtonGroupBuilder<TModel>>() != null);

            return new ButtonGroupBuilder<TModel>(html, new ButtonGroup());
        }

        public ButtonGroupBuilder<TModel> BeginButtonGroup(ButtonGroup buttonGroup)
		{
            Contract.Requires<ArgumentNullException>(buttonGroup != null, "buttonGroup");
            Contract.Ensures(Contract.Result<ButtonGroupBuilder<TModel>>() != null);

			return new ButtonGroupBuilder<TModel>(html, buttonGroup);
		}
	}
}