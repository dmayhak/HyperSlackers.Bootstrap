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
    public class ButtonGroupBuilder<TModel> : DisposableHtmlElement<TModel, ButtonGroup>
	{
		private bool disposed = false;

		internal ButtonGroupBuilder(HtmlHelper<TModel> html, ButtonGroup buttonGroup) 
			: base(html, buttonGroup)
		{
			Contract.Requires<ArgumentNullException>(html != null, "html");
			Contract.Requires<ArgumentNullException>(buttonGroup != null, "buttonGroup");

			TagBuilder tagBuilder = new TagBuilder("div");
			tagBuilder.AddCssClass("btn-group");
			tagBuilder.MergeAttributes<string, object>(buttonGroup.htmlAttributes);

			if (this.element.justified)
			{
				tagBuilder.AddCssClass("btn-group-justified");
			}

			if (this.element.vertical)
			{
				tagBuilder.AddCssClass("btn-group-vertical");
			}

			this.textWriter.Write(tagBuilder.ToString(TagRenderMode.StartTag));
		}

        public ActionLinkButtonControl<TModel> ActionLinkButton(string linkText, ActionResult result)
		{
            Contract.Requires<ArgumentException>(!linkText.IsNullOrWhiteSpace());
			Contract.Requires<ArgumentNullException>(result != null, "result");
            Contract.Ensures(Contract.Result<ActionLinkButtonControl<TModel>>() != null);

            return new ActionLinkButtonControl<TModel>(this.html, linkText, result).Style(this.element.style).Size(this.element.size);
		}

        public ActionLinkButtonControl<TModel> ActionLinkButton(string linkText, string actionName)
		{
            Contract.Requires<ArgumentException>(!linkText.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentException>(!actionName.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<ActionLinkButtonControl<TModel>>() != null);

            return new ActionLinkButtonControl<TModel>(this.html, linkText, actionName).Style(this.element.style).Size(this.element.size);
		}

        public ActionLinkButtonControl<TModel> ActionLinkButton(string linkText, string actionName, string controllerName)
		{
            Contract.Requires<ArgumentException>(!linkText.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentException>(!actionName.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentException>(!controllerName.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<ActionLinkButtonControl<TModel>>() != null);

            return new ActionLinkButtonControl<TModel>(this.html, linkText, actionName, controllerName).Style(this.element.style).Size(this.element.size);
		}

        public DropDownBuilder<TModel> BeginDropDown(DropDown dropDown)
		{
			Contract.Requires<ArgumentNullException>(dropDown != null, "dropDown");
            Contract.Ensures(Contract.Result<DropDownBuilder<TModel>>() != null);

            if (dropDown.buttonStyle == ButtonStyle.Default)
            {
                dropDown.Style(this.element.style);
            }

            if (dropDown.buttonSize == ButtonSize.Default)
            {
                dropDown.Size(this.element.size);
            }

            return new DropDownBuilder<TModel>(this.html, dropDown, "div", new { @class = "btn-group" }, true);
		}

		public ButtonControl<TModel> Button()
		{
			Contract.Ensures(Contract.Result<ButtonControl<TModel>>() != null);

            return new ButtonControl<TModel>(this.html, ButtonType.Button).Style(this.element.style).Size(this.element.size);
		}

        public ButtonControl<TModel> Button(string text)
        {
            Contract.Ensures(Contract.Result<ButtonControl<TModel>>() != null);

            return new ButtonControl<TModel>(this.html, ButtonType.Button).Style(this.element.style).Size(this.element.size).Text(text);
        }

        protected override void Dispose(bool disposing)
		{
			if (!this.disposed)
			{
				if (disposing)
				{
					this.textWriter.Write("</div>");

				    this.disposed = true;
				}
			}

			base.Dispose(disposing);
		}
	}
}