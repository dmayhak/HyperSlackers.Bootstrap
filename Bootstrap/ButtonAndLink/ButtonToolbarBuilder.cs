using System;
using System.ComponentModel;
using System.IO;
using System.Web.Mvc;
using HyperSlackers.Bootstrap;
using System.Diagnostics.Contracts;
using HyperSlackers.Bootstrap.Core;
using HyperSlackers.Bootstrap.Extensions;

namespace HyperSlackers.Bootstrap.Controls
{
    public class ButtonToolbarBuilder<TModel> : DisposableHtmlElement<TModel, ButtonToolbar>
	{
		private bool disposed = false;

		internal ButtonToolbarBuilder(HtmlHelper<TModel> html, ButtonToolbar buttonToolbar)
			: base(html, buttonToolbar)
		{
			Contract.Requires<ArgumentNullException>(html != null, "html");
			Contract.Requires<ArgumentNullException>(buttonToolbar != null, "buttonToolbar");

			TagBuilder tagBuilder = new TagBuilder("div");
			tagBuilder.AddCssClass("btn-toolbar");
			tagBuilder.MergeAttributes<string, object>(buttonToolbar.htmlAttributes);

            textWriter.Write(tagBuilder.ToString(TagRenderMode.StartTag));
        }

        public ButtonGroupBuilder<TModel> BeginButtonGroup()
        {
            Contract.Ensures(Contract.Result<ButtonGroupBuilder<TModel>>() != null);

            return BeginButtonGroup(new ButtonGroup());
        }

        public ButtonGroupBuilder<TModel> BeginButtonGroup(ButtonGroup buttonGroup)
        {
            Contract.Requires<ArgumentNullException>(buttonGroup != null, "buttonGroup");
            Contract.Ensures(Contract.Result<ButtonGroupBuilder<TModel>>() != null);

            if (buttonGroup.style == ButtonStyle.Default)
            {
                buttonGroup.Style(element.style);
            }

            if (buttonGroup.size == ButtonSize.Default)
            {
                buttonGroup.Size(element.size);
            }

            return new ButtonGroupBuilder<TModel>(html, buttonGroup);
        }

        protected override void Dispose(bool disposing)
		{
			if (!disposed)
			{
				if (disposing)
				{
                    textWriter.Write("</div>");

                    disposed = true;
				}
			}

			base.Dispose(disposing);
		}
	}
}