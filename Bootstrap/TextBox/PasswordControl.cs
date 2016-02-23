using System;
using System.Web.Mvc;
using System.Diagnostics.Contracts;
using System.Web;
using HyperSlackers.Bootstrap.Core;
using System.Collections.Generic;
using System.Web.Mvc.Html;
using HyperSlackers.Bootstrap.Extensions;

namespace HyperSlackers.Bootstrap.Controls
{
    public class PasswordControl<TModel> : InputControlBase<PasswordControl<TModel>, TModel>
    {
        internal string placeholder;
        internal List<Tuple<IHtmlString, object>> prependHtml = new List<Tuple<IHtmlString, object>>();
        internal List<Tuple<IHtmlString, object>> appendHtml = new List<Tuple<IHtmlString, object>>();
        internal InputSize size = InputSize.Default;

        public PasswordControl(HtmlHelper<TModel> html, string htmlFieldName, ModelMetadata metadata)
            : base(html, htmlFieldName, metadata)
        {
            Contract.Requires<ArgumentNullException>(html != null, "html");
            Contract.Requires<ArgumentNullException>(htmlFieldName != null, "htmlFieldName");
            Contract.Requires<ArgumentException>(!htmlFieldName.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentNullException>(metadata != null, "metadata");
        }

        public PasswordControl<TModel> HelpText()
        {
            Contract.Ensures(Contract.Result<PasswordControl<TModel>>() != null);

            helpText = new HelpTextControl<TModel>(html, GetHelpTextText());

            return this;
        }

        public PasswordControl<TModel> HelpText(string text)
        {
            Contract.Requires<ArgumentNullException>(text != null, "text");
            Contract.Requires<ArgumentException>(!text.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<PasswordControl<TModel>>() != null);

            helpText = new HelpTextControl<TModel>(html, text);

            return this;
        }

        public PasswordControl<TModel> HelpText(IHtmlString html)
        {
            Contract.Requires<ArgumentNullException>(html != null, "html");
            Contract.Ensures(Contract.Result<PasswordControl<TModel>>() != null);

            helpText = new HelpTextControl<TModel>(this.html, html.ToHtmlString());

            return this;
        }

        public PasswordControl<TModel> Size(InputSize inputSize)
        {
            Contract.Ensures(Contract.Result<PasswordControl<TModel>>() != null);

            size = inputSize;

            return this;
        }

        public PasswordControl<TModel> Append(string htmlString, object containerHtmlAttributes = null)
        {
            Contract.Requires<ArgumentException>(!htmlString.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<PasswordControl<TModel>>() != null);

            appendHtml.Add(new Tuple<IHtmlString, object>(MvcHtmlString.Create(htmlString), containerHtmlAttributes));

            return this;
        }

        public PasswordControl<TModel> Append(IHtmlString htmlString, object containerHtmlAttributes = null)
        {
            Contract.Requires<ArgumentNullException>(htmlString != null, "htmlString");
            Contract.Ensures(Contract.Result<PasswordControl<TModel>>() != null);

            appendHtml.Add(new Tuple<IHtmlString, object>(htmlString, containerHtmlAttributes));

            return this;
        }

        public PasswordControl<TModel> AppendIcon(GlyphIcon icon, object containerHtmlAttributes = null)
        {
            Contract.Requires<ArgumentNullException>(icon != null, "icon");
            Contract.Ensures(Contract.Result<PasswordControl<TModel>>() != null);

            appendHtml.Add(new Tuple<IHtmlString, object>(icon, containerHtmlAttributes));

            return this;
        }

        public PasswordControl<TModel> AppendIcon(FontAwesomeIcon icon, object containerHtmlAttributes = null)
        {
            Contract.Requires<ArgumentNullException>(icon != null, "icon");
            Contract.Ensures(Contract.Result<PasswordControl<TModel>>() != null);

            appendHtml.Add(new Tuple<IHtmlString, object>(icon, containerHtmlAttributes));

            return this;
        }

        public PasswordControl<TModel> AppendIcon(GlyphIconType icon, object containerHtmlAttributes = null)
        {
            Contract.Ensures(Contract.Result<PasswordControl<TModel>>() != null);

            appendHtml.Add(new Tuple<IHtmlString, object>(new GlyphIcon(icon), containerHtmlAttributes));

            return this;
        }

        public PasswordControl<TModel> AppendIcon(FontAwesomeIconType icon, object containerHtmlAttributes = null)
        {
            Contract.Ensures(Contract.Result<PasswordControl<TModel>>() != null);

            appendHtml.Add(new Tuple<IHtmlString, object>(new FontAwesomeIcon(icon), containerHtmlAttributes));

            return this;
        }

        public PasswordControl<TModel> AppendIcon(string cssClass, object containerHtmlAttributes = null)
        {
            Contract.Requires<ArgumentException>(!cssClass.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<PasswordControl<TModel>>() != null);

            appendHtml.Add(new Tuple<IHtmlString, object>(new GlyphIcon(cssClass), containerHtmlAttributes));

            return this;
        }

        internal ModelMetadata GetMetadata() // needed?
        {
            Contract.Ensures(Contract.Result<ModelMetadata>() != null);

            return metadata;
        }

        public PasswordControl<TModel> Placeholder()
        {
            Contract.Ensures(Contract.Result<PasswordControl<TModel>>() != null);

            placeholder = GetPlaceholderText();

            return this;
        }

        public PasswordControl<TModel> PlaceHolder(string placeHolder)
        {
            Contract.Requires<ArgumentException>(!placeHolder.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<PasswordControl<TModel>>() != null);

            placeholder = placeHolder;

            return this;
        }

        public PasswordControl<TModel> Prepend(string htmlString, object containerHtmlAttributes = null)
        {
            Contract.Requires<ArgumentNullException>(htmlString != null, "htmlString");
            Contract.Ensures(Contract.Result<PasswordControl<TModel>>() != null);

            prependHtml.Add(new Tuple<IHtmlString, object>(MvcHtmlString.Create(htmlString), containerHtmlAttributes));

            return this;
        }

        public PasswordControl<TModel> Prepend(IHtmlString htmlString, object containerHtmlAttributes = null)
        {
            Contract.Requires<ArgumentNullException>(htmlString != null, "htmlString");
            Contract.Ensures(Contract.Result<PasswordControl<TModel>>() != null);

            prependHtml.Add(new Tuple<IHtmlString, object>(htmlString, containerHtmlAttributes));

            return this;
        }

        public PasswordControl<TModel> PrependIcon(GlyphIcon icon, object containerHtmlAttributes = null)
        {
            Contract.Requires<ArgumentNullException>(icon != null, "icon");
            Contract.Ensures(Contract.Result<PasswordControl<TModel>>() != null);

            prependHtml.Add(new Tuple<IHtmlString, object>(icon, containerHtmlAttributes));

            return this;
        }

        public PasswordControl<TModel> PrependIcon(FontAwesomeIcon icon, object containerHtmlAttributes = null)
        {
            Contract.Requires<ArgumentNullException>(icon != null, "icon");
            Contract.Ensures(Contract.Result<PasswordControl<TModel>>() != null);

            prependHtml.Add(new Tuple<IHtmlString, object>(icon, containerHtmlAttributes));

            return this;
        }

        public PasswordControl<TModel> PrependIcon(GlyphIconType icon, object containerHtmlAttributes = null)
        {
            Contract.Ensures(Contract.Result<PasswordControl<TModel>>() != null);

            prependHtml.Add(new Tuple<IHtmlString, object>(new GlyphIcon(icon), containerHtmlAttributes));

            return this;
        }

        public PasswordControl<TModel> PrependIcon(FontAwesomeIconType icon, object containerHtmlAttributes = null)
        {
            Contract.Ensures(Contract.Result<PasswordControl<TModel>>() != null);

            prependHtml.Add(new Tuple<IHtmlString, object>(new FontAwesomeIcon(icon), containerHtmlAttributes));

            return this;
        }

        public PasswordControl<TModel> PrependIcon(string cssClass, object containerHtmlAttributes = null)
        {
            Contract.Requires<ArgumentException>(!cssClass.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<PasswordControl<TModel>>() != null);

            prependHtml.Add(new Tuple<IHtmlString, object>(new GlyphIcon(cssClass), containerHtmlAttributes));

            return this;
        }

        protected override string RenderControl()
        {
            Contract.Ensures(!Contract.Result<string>().IsNullOrWhiteSpace());

            bool showValidationMessageInline = html.BootstrapDefaults().DefaultShowValidationMessageInline ?? false;
            bool showValidationMessageBeforeInput = html.BootstrapDefaults().DefaultShowValidationMessageBeforeInput ?? false;
            string formatString = showValidationMessageBeforeInput ? "{2}{0}{1}" : "{0}{1}{2}";

            controlHtmlAttributes.AddOrReplaceHtmlAttributes(html.GetUnobtrusiveValidationAttributes(htmlFieldName, metadata));

            if (!id.IsNullOrWhiteSpace())
            {
                controlHtmlAttributes.AddOrReplaceHtmlAttribute("id", id);
            }

            SetDefaultTooltip();
            if (tooltip != null)
            {
                controlHtmlAttributes.AddOrReplaceHtmlAttributes(tooltip.ToDictionary());
            }

            bool alwaysShowPlaceholder = html.BootstrapDefaults().DefaultShowPlaceholder ?? false;

            if (!placeholder.IsNullOrWhiteSpace())
            {
                controlHtmlAttributes.AddOrReplaceHtmlAttribute("placeholder", placeholder);
            }
            else if (alwaysShowPlaceholder)
            {
                controlHtmlAttributes.AddOrReplaceHtmlAttribute("placeholder", GetPlaceholderText());
            }

            controlHtmlAttributes.AddIfNotExistsCssClass((string)Helpers.GetCssClass(html, size));

            controlHtmlAttributes.AddIfNotExistsCssClass("form-control");

            string controlHtml = html.Password(htmlFieldName, null, controlHtmlAttributes.FormatHtmlAttributes()).ToHtmlString();

            formatString = AddPrependAppend(formatString, prependHtml, appendHtml);

            // if formgroup has feedback icon defined, use it
            if (formGroup != null && formGroup.feedbackIcon != null)
            {
                formatString += formGroup.feedbackIcon.ToHtmlString();
            }

            string helpHtml = (helpText != null ? helpText.ToHtmlString() : string.Empty);
            string validationHtml = (showValidationMessageInline ? string.Empty : RenderValidationMessage());

            return MvcHtmlString.Create(string.Format(formatString, controlHtml, helpHtml, validationHtml)).ToString();
        }
    }
}