//using System;
//using System.Web.Mvc;
//using System.Diagnostics.Contracts;
//using System.Web;
//using HyperSlackers.Bootstrap.Core;
//using System.Collections.Generic;
//using System.Web.Mvc.Html;
//using HyperSlackers.Bootstrap.Extensions;

//namespace HyperSlackers.Bootstrap.Controls
//{
//    public class TextBoxControl<TModel> : InputControlBase<TextBoxControl<TModel>, TModel>
//	{
//        internal string placeholder;
//        internal List<Tuple<IHtmlString, object>> prependHtml = new List<Tuple<IHtmlString, object>>();
//        internal List<Tuple<IHtmlString, object>> appendHtml = new List<Tuple<IHtmlString, object>>();
//        internal InputSize size = InputSize.Default;
//        internal HyperSlackers.Bootstrap.TypeAhead typeAhead;

//        internal TextBoxControl(HtmlHelper<TModel> html, string htmlFieldName, ModelMetadata metadata) 
//            : base(html, htmlFieldName, metadata)
//		{
//            Contract.Requires<ArgumentNullException>(html != null, "html");
//            Contract.Requires<ArgumentNullException>(htmlFieldName != null, "htmlFieldName");
//            Contract.Requires<ArgumentException>(!htmlFieldName.IsNullOrWhiteSpace());
//            Contract.Requires<ArgumentNullException>(metadata != null, "metadata");
//		}

//        public TextBoxControl<TModel> HelpText()
//        {
//            Contract.Ensures(Contract.Result<TextBoxControl<TModel>>() != null);

//            this.helpText = new HelpTextControl<TModel>(this.html, GetHelpTextText());

//            return this;
//        }

//        public TextBoxControl<TModel> HelpText(string text)
//        {
//            Contract.Requires<ArgumentNullException>(text != null, "text");
//            Contract.Requires<ArgumentException>(!text.IsNullOrWhiteSpace());
//            Contract.Ensures(Contract.Result<TextBoxControl<TModel>>() != null);

//            this.helpText = new HelpTextControl<TModel>(this.html, text);

//            return this;
//        }

//        public TextBoxControl<TModel> HelpText(IHtmlString html)
//        {
//            Contract.Requires<ArgumentNullException>(html != null, "html");
//            Contract.Ensures(Contract.Result<TextBoxControl<TModel>>() != null);

//            this.helpText = new HelpTextControl<TModel>(this.html, html.ToHtmlString());

//            return this;
//        }

//        public TextBoxControl<TModel> Size(InputSize inputSize)
//        {
//            Contract.Ensures(Contract.Result<TextBoxControl<TModel>>() != null);

//            this.size = inputSize;
            
//            return this;
//        }

//        public TextBoxControl<TModel> Append(string htmlString, object containerHtmlAttributes = null)
//        {
//            Contract.Requires<ArgumentException>(!htmlString.IsNullOrWhiteSpace());
//            Contract.Ensures(Contract.Result<TextBoxControl<TModel>>() != null);

//            this.appendHtml.Add(new Tuple<IHtmlString, object>(MvcHtmlString.Create(htmlString), containerHtmlAttributes));

//            return this;
//        }

//        public TextBoxControl<TModel> Append(IHtmlString htmlString, object containerHtmlAttributes = null)
//        {
//            Contract.Requires<ArgumentNullException>(htmlString != null, "htmlString");
//            Contract.Ensures(Contract.Result<TextBoxControl<TModel>>() != null);

//            this.appendHtml.Add(new Tuple<IHtmlString, object>(htmlString, containerHtmlAttributes));

//            return this;
//        }

//        public TextBoxControl<TModel> AppendIcon(GlyphIcon icon, object containerHtmlAttributes = null)
//        {
//            Contract.Requires<ArgumentNullException>(icon != null, "icon");
//            Contract.Ensures(Contract.Result<TextBoxControl<TModel>>() != null);

//            this.appendHtml.Add(new Tuple<IHtmlString, object>(icon, containerHtmlAttributes));

//            return this;
//        }

//        public TextBoxControl<TModel> AppendIcon(GlyphIconType icon, object containerHtmlAttributes = null)
//        {
//            Contract.Ensures(Contract.Result<TextBoxControl<TModel>>() != null);

//            this.appendHtml.Add(new Tuple<IHtmlString, object>(new GlyphIcon(icon), containerHtmlAttributes));

//            return this;
//        }

//        public TextBoxControl<TModel> AppendIcon(FontAwesomeIconType icon, object containerHtmlAttributes = null)
//        {
//            Contract.Ensures(Contract.Result<TextBoxControl<TModel>>() != null);

//            this.appendHtml.Add(new Tuple<IHtmlString, object>(new FontAwesomeIcon(icon), containerHtmlAttributes));

//            return this;
//        }

//        public TextBoxControl<TModel> AppendIcon(string cssClass, object containerHtmlAttributes = null)
//        {
//            Contract.Requires<ArgumentException>(!cssClass.IsNullOrWhiteSpace());
//            Contract.Ensures(Contract.Result<TextBoxControl<TModel>>() != null);

//            this.appendHtml.Add(new Tuple<IHtmlString, object>(new GlyphIcon(cssClass), containerHtmlAttributes));

//            return this;
//        }

//        public TextBoxControl<TModel> Format(string format)
//        {
//            Contract.Requires<ArgumentException>(!format.IsNullOrWhiteSpace());
//            Contract.Ensures(Contract.Result<TextBoxControl<TModel>>() != null);

//            this.format = format;

//            return this;
//        }

//        public TextBoxControl<TModel> Placeholder()
//        {
//            Contract.Ensures(Contract.Result<TextBoxControl<TModel>>() != null);

//            this.placeholder = GetPlaceholderText();

//            return this;
//        }

//        public TextBoxControl<TModel> Placeholder(string placeHolder)
//        {
//            Contract.Requires<ArgumentException>(!placeHolder.IsNullOrWhiteSpace());
//            Contract.Ensures(Contract.Result<TextBoxControl<TModel>>() != null);

//            this.placeholder = placeHolder;

//            return this;
//        }

//        public TextBoxControl<TModel> Prepend(string htmlString, object containerHtmlAttributes = null)
//        {
//            Contract.Requires<ArgumentException>(!htmlString.IsNullOrWhiteSpace());
//            Contract.Ensures(Contract.Result<TextBoxControl<TModel>>() != null);

//            this.prependHtml.Add(new Tuple<IHtmlString, object>(MvcHtmlString.Create(htmlString), containerHtmlAttributes));

//            return this;
//        }

//        public TextBoxControl<TModel> Prepend(IHtmlString htmlString, object containerHtmlAttributes = null)
//        {
//            Contract.Requires<ArgumentNullException>(htmlString != null, "htmlString");
//            Contract.Ensures(Contract.Result<TextBoxControl<TModel>>() != null);

//            this.prependHtml.Add(new Tuple<IHtmlString, object>(htmlString, containerHtmlAttributes));

//            return this;
//        }

//        public TextBoxControl<TModel> PrependIcon(GlyphIcon icon, object containerHtmlAttributes = null)
//        {
//            Contract.Requires<ArgumentNullException>(icon != null, "icon");
//            Contract.Ensures(Contract.Result<TextBoxControl<TModel>>() != null);

//            this.prependHtml.Add(new Tuple<IHtmlString, object>(icon, containerHtmlAttributes));

//            return this;
//        }

//        public TextBoxControl<TModel> PrependIcon(GlyphIconType icon, object containerHtmlAttributes = null)
//        {
//            Contract.Ensures(Contract.Result<TextBoxControl<TModel>>() != null);

//            this.prependHtml.Add(new Tuple<IHtmlString, object>(new GlyphIcon(icon), containerHtmlAttributes));

//            return this;
//        }

//        public TextBoxControl<TModel> PrependIcon(FontAwesomeIconType icon, object containerHtmlAttributes = null)
//        {
//            Contract.Ensures(Contract.Result<TextBoxControl<TModel>>() != null);

//            this.prependHtml.Add(new Tuple<IHtmlString, object>(new FontAwesomeIcon(icon), containerHtmlAttributes));

//            return this;
//        }

//        public TextBoxControl<TModel> PrependIcon(string cssClass, object containerHtmlAttributes = null)
//        {
//            Contract.Requires<ArgumentException>(!cssClass.IsNullOrWhiteSpace());
//            Contract.Ensures(Contract.Result<TextBoxControl<TModel>>() != null);

//            this.prependHtml.Add(new Tuple<IHtmlString, object>(new GlyphIcon(cssClass), containerHtmlAttributes));

//            return this;
//        }

//        public TextBoxControl<TModel> Align(TextAlign align)
//        {
//            Contract.Ensures(Contract.Result<TextBoxControl<TModel>>() != null);

//            if (align != TextAlign.None)
//            {
//                this.ControlHtmlAttribute("style", "text-align:{0};".FormatWith(align.ToString()));
//            }

//            return this;
//        }

//        public TextBoxControl<TModel> TypeAhead(TypeAhead typeAhead)
//        {
//            Contract.Requires<ArgumentNullException>(typeAhead != null, "typeAhead");
//            Contract.Ensures(Contract.Result<TextBoxControl<TModel>>() != null);

//            this.typeAhead = typeAhead;

//            return this;
//        }

//        protected override string RenderControl()
//        {
//            Contract.Ensures(!Contract.Result<string>().IsNullOrWhiteSpace());

//            bool showValidationMessageInline = html.BootstrapDefaults().DefaultShowValidationMessageInline ?? false;
//            bool showValidationMessageBeforeInput = html.BootstrapDefaults().DefaultShowValidationMessageBeforeInput ?? false;
//            string formatString = showValidationMessageBeforeInput ? "{2}{0}{1}" : "{0}{1}{2}";

//            this.controlHtmlAttributes.AddOrReplaceHtmlAttributes(html.GetUnobtrusiveValidationAttributes(this.htmlFieldName, this.metadata));

//            if (!this.id.IsNullOrWhiteSpace())
//            {
//                this.controlHtmlAttributes.AddOrReplaceHtmlAttribute("id", this.id);
//            }

//            SetDefaultTooltip();
//            if (this.tooltip != null)
//            {
//                this.controlHtmlAttributes.AddOrReplaceHtmlAttributes(this.tooltip.ToDictionary());
//            }

//            if (this.typeAhead != null)
//            {
//                this.controlHtmlAttributes.AddOrReplaceHtmlAttributes(this.typeAhead.ToDictionary(html));
//            }

//            bool alwaysShowPlaceholder = html.BootstrapDefaults().DefaultShowPlaceholder ?? false;

//            if (!this.placeholder.IsNullOrWhiteSpace())
//            {
//                this.controlHtmlAttributes.AddOrReplaceHtmlAttribute("placeholder", this.placeholder);
//            }
//            else if (alwaysShowPlaceholder)
//            {
//                this.controlHtmlAttributes.AddOrReplaceHtmlAttribute("placeholder", GetPlaceholderText());
//            }

//            this.controlHtmlAttributes.AddIfNotExistsCssClass((string)Helpers.GetCssClass(html, this.size));

//            this.controlHtmlAttributes.AddIfNotExistsCssClass("form-control");

//            SetFormatText();

//            string controlHtml = html.TextBox(this.htmlFieldName, this.value, this.format, this.controlHtmlAttributes.FormatHtmlAttributes()).ToHtmlString();

//            formatString = AddPrependAppend(formatString, this.prependHtml, this.appendHtml);
//            string helpHtml = this.helpText != null ? this.helpText.ToHtmlString() : string.Empty;
//            string validationHtml = showValidationMessageInline ? string.Empty : this.RenderValidationMessage();

//            return MvcHtmlString.Create(formatString.FormatWith(controlHtml, helpHtml, validationHtml)).ToString();
//        }
//	}
//}