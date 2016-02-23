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

			if (element.justified)
			{
				tagBuilder.AddCssClass("btn-group-justified");
			}

			if (element.vertical)
			{
				tagBuilder.AddCssClass("btn-group-vertical");
			}

            textWriter.Write(tagBuilder.ToString(TagRenderMode.StartTag));
		}

        public ActionLinkButtonControl<TModel> ActionLinkButton(string linkText, ActionResult result)
		{
            Contract.Requires<ArgumentException>(!linkText.IsNullOrWhiteSpace());
			Contract.Requires<ArgumentNullException>(result != null, "result");
            Contract.Ensures(Contract.Result<ActionLinkButtonControl<TModel>>() != null);

            return new ActionLinkButtonControl<TModel>(html, linkText, result).Style(element.style).Size(element.size);
		}

        public ActionLinkButtonControl<TModel> ActionLinkButton(string linkText, string actionName)
		{
            Contract.Requires<ArgumentException>(!linkText.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentException>(!actionName.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<ActionLinkButtonControl<TModel>>() != null);

            return new ActionLinkButtonControl<TModel>(html, linkText, actionName).Style(element.style).Size(element.size);
		}

        public ActionLinkButtonControl<TModel> ActionLinkButton(string linkText, string actionName, string controllerName)
		{
            Contract.Requires<ArgumentException>(!linkText.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentException>(!actionName.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentException>(!controllerName.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<ActionLinkButtonControl<TModel>>() != null);

            return new ActionLinkButtonControl<TModel>(html, linkText, actionName, controllerName).Style(element.style).Size(element.size);
        }

        public DropDownBuilder<TModel> BeginDropDown(string actionText)
        {
            Contract.Ensures(Contract.Result<DropDownBuilder<TModel>>() != null);

            DropDown dropDown = new DropDown(actionText);

            dropDown.Style(element.style);
            dropDown.Size(element.size);

            return BeginDropDown(dropDown);
        }

        public DropDownBuilder<TModel> BeginDropDown(DropDown dropDown)
		{
			Contract.Requires<ArgumentNullException>(dropDown != null, "dropDown");
            Contract.Ensures(Contract.Result<DropDownBuilder<TModel>>() != null);

            if (dropDown.buttonStyle == ButtonStyle.Default)
            {
                dropDown.Style(element.style);
            }

            if (dropDown.buttonSize == ButtonSize.Default)
            {
                dropDown.Size(element.size);
            }

            return new DropDownBuilder<TModel>(html, dropDown, "div", new { @class = "btn-group" }, true);
        }

        public DropDownBuilder<TModel> BeginSplitDropDown(string actionText)
        {
            Contract.Ensures(Contract.Result<DropDownBuilder<TModel>>() != null);

            DropDown dropDown = new DropDown(actionText);

            dropDown.Style(element.style);
            dropDown.Size(element.size);

            return BeginSplitDropDown(dropDown);
        }

        public DropDownBuilder<TModel> BeginSplitDropDown(DropDown dropDown)
        {
            Contract.Requires<ArgumentNullException>(dropDown != null, "dropDown");
            Contract.Ensures(Contract.Result<DropDownBuilder<TModel>>() != null);

            if (dropDown.buttonStyle == ButtonStyle.Default)
            {
                dropDown.Style(element.style);
            }

            if (dropDown.buttonSize == ButtonSize.Default)
            {
                dropDown.Size(element.size);
            }

            return new DropDownBuilder<TModel>(html, dropDown, "", null, true);
        }

        public ButtonControl<TModel> Button()
		{
			Contract.Ensures(Contract.Result<ButtonControl<TModel>>() != null);

            return new ButtonControl<TModel>(html, ButtonType.Button).Style(element.style).Size(element.size);
		}

        public ButtonControl<TModel> Button(string text)
        {
            Contract.Ensures(Contract.Result<ButtonControl<TModel>>() != null);

            if (element.justified)
            {
                return new ButtonControl<TModel>(html, ButtonType.Button).Style(element.style).Size(element.size).Text(text).WrapInto(new WrapperTag("div").Class("btn-group").Role("group"));
            }
            else
            {
                return new ButtonControl<TModel>(html, ButtonType.Button).Style(element.style).Size(element.size).Text(text);
            }
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