using System;
using System.Web.Mvc;
using System.Diagnostics.Contracts;
using HyperSlackers.Bootstrap.Core;
using System.ComponentModel;
using System.Text;
using System.Web;
using HyperSlackers.Bootstrap.Extensions;

namespace HyperSlackers.Bootstrap.Controls
{
    public class ButtonControl<TModel> : ControlBase<ButtonControl<TModel>, TModel>
    {
        internal bool buttonBlock;
        internal bool disabled;
        internal Icon iconAppend;
        internal Icon iconPrepend;
        internal bool isDropDownToggle;
        internal string loadingText;
        internal string name;
        internal ButtonSize size = ButtonSize.Default;
        internal ButtonStyle style = ButtonStyle.Default;
        internal string text;
        internal Tooltip tooltip;
        internal string modalId;
        internal string modalUrl;
        internal ButtonType type;
        internal string value;
        internal bool withCaret;
        internal bool dismissModal;

        internal ButtonControl(HtmlHelper<TModel> html, ButtonType type) 
            : base(html)
        {
            Contract.Requires<ArgumentNullException>(html != null, "html");

            this.type = type;
            this.text = "Submit"; // localization left up to user...
        }

        public ButtonControl<TModel> AppendIcon(GlyphIcon icon)
        {
            Contract.Requires<ArgumentNullException>(icon != null, "icon");
            Contract.Ensures(Contract.Result<ButtonControl<TModel>>() != null);

            this.iconAppend = icon;

            return this;
        }

        public ButtonControl<TModel> Active()
        {
            Contract.Ensures(Contract.Result<ButtonControl<TModel>>() != null);

            this.ControlClass("active");

            return this;
        }
        
        public ButtonControl<TModel> AppendIcon(GlyphIconType icon, bool isWhite = false)
        {
            Contract.Ensures(Contract.Result<ButtonControl<TModel>>() != null);

            this.iconAppend = new GlyphIcon(icon, isWhite);

            return this;
        }

        public ButtonControl<TModel> AppendIcon(FontAwesomeIcon icon)
        {
            Contract.Requires<ArgumentNullException>(icon != null, "icon");
            Contract.Ensures(Contract.Result<ButtonControl<TModel>>() != null);

            this.iconAppend = icon;

            return this;
        }

        public ButtonControl<TModel> AppendIcon(FontAwesomeIconType icon, bool isWhite = false)
        {
            Contract.Ensures(Contract.Result<ButtonControl<TModel>>() != null);

            this.iconAppend = new FontAwesomeIcon(icon, isWhite);

            return this;
        }

        public ButtonControl<TModel> AppendIcon(string cssClass)
        {
            Contract.Requires<ArgumentException>(!cssClass.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<ButtonControl<TModel>>() != null);

            this.iconAppend = new GlyphIcon(cssClass);

            return this;
        }

        public ButtonControl<TModel> AutoFocus(bool isFocused = true)
        {
            Contract.Ensures(Contract.Result<ButtonControl<TModel>>() != null);

            if (isFocused)
            {
                this.controlHtmlAttributes.AddIfNotExist("autofocus", null);
            }
            else
            {
                this.controlHtmlAttributes.Remove("autofocus");
            }

            return this;
        }

        public ButtonControl<TModel> ButtonBlock()
        {
            Contract.Ensures(Contract.Result<ButtonControl<TModel>>() != null);

            this.buttonBlock = true;

            return this;
        }

        public ButtonControl<TModel> Disabled(bool isDisabled = true)
        {
            Contract.Ensures(Contract.Result<ButtonControl<TModel>>() != null);

            this.disabled = isDisabled;

            return this;
        }

        public ButtonControl<TModel> DismissModal()
        {
            Contract.Ensures(Contract.Result<ButtonControl<TModel>>() != null);

            this.dismissModal = true;

            return this;
        }

        public ButtonControl<TModel> DropDownToggle()
        {
            Contract.Ensures(Contract.Result<ButtonControl<TModel>>() != null);

            this.isDropDownToggle = true;

            return this;
        }

        public ButtonControl<TModel> LoadingText(string loadingText)
        {
            Contract.Requires<ArgumentException>(!loadingText.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<ButtonControl<TModel>>() != null);

            this.loadingText = loadingText;

            return this;
        }

        public ButtonControl<TModel> Name(string name)
        {
            Contract.Requires<ArgumentException>(!name.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<ButtonControl<TModel>>() != null);

            this.name = name;

            return this;
        }

        public ButtonControl<TModel> PrependIcon(GlyphIcon icon)
        {
            Contract.Requires<ArgumentNullException>(icon != null, "icon");
            Contract.Ensures(Contract.Result<ButtonControl<TModel>>() != null);

            this.iconPrepend = icon;

            return this;
        }

        public ButtonControl<TModel> PrependIcon(GlyphIconType icon, bool isWhite = false)
        {
            Contract.Ensures(Contract.Result<ButtonControl<TModel>>() != null);

            this.iconPrepend = new GlyphIcon(icon, isWhite);

            return this;
        }

        public ButtonControl<TModel> PrependIcon(FontAwesomeIcon icon)
        {
            Contract.Requires<ArgumentNullException>(icon != null, "icon");
            Contract.Ensures(Contract.Result<ButtonControl<TModel>>() != null);

            this.iconPrepend = icon;

            return this;
        }

        public ButtonControl<TModel> PrependIcon(FontAwesomeIconType icon, bool isWhite = false)
        {
            Contract.Ensures(Contract.Result<ButtonControl<TModel>>() != null);

            this.iconPrepend = new FontAwesomeIcon(icon, isWhite);

            return this;
        }

        public ButtonControl<TModel> PrependIcon(string cssClass)
        {
            Contract.Requires<ArgumentException>(!cssClass.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<ButtonControl<TModel>>() != null);

            this.iconPrepend = new GlyphIcon(cssClass);

            return this;
        }

        public ButtonControl<TModel> Size(ButtonSize size)
        {
            Contract.Ensures(Contract.Result<ButtonControl<TModel>>() != null);

            this.size = size;

            return this;
        }

        public ButtonControl<TModel> Style(ButtonStyle style)
        {
            Contract.Ensures(Contract.Result<ButtonControl<TModel>>() != null);

            this.style = style;

            return this;
        }

        public ButtonControl<TModel> TriggerModal(string modalId)
        {
            Contract.Requires<ArgumentException>(!modalId.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<ButtonControl<TModel>>() != null);

            this.modalId = modalId;

            return this;
        }

        public ButtonControl<TModel> ModalSourceUrl(string url)
        {
            Contract.Requires<ArgumentException>(!url.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<ButtonControl<TModel>>() != null);

            this.modalUrl = url;

            return this;
        }

        public ButtonControl<TModel> Text(string text)
        {
            Contract.Requires<ArgumentException>(!text.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<ButtonControl<TModel>>() != null);

            this.text = text;

            return this;
        }

        public ButtonControl<TModel> Tooltip(Tooltip tooltip)
        {
            Contract.Requires<ArgumentNullException>(tooltip != null, "tooltip");
            Contract.Ensures(Contract.Result<ButtonControl<TModel>>() != null);

            this.tooltip = tooltip;

            return this;
        }

        public ButtonControl<TModel> Tooltip(string text)
        {
            Contract.Requires<ArgumentException>(!text.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<ButtonControl<TModel>>() != null);

            this.tooltip = new Tooltip(text);

            return this;
        }

        public ButtonControl<TModel> Tooltip(IHtmlString html)
        {
            Contract.Requires<ArgumentNullException>(html != null, "html");
            Contract.Ensures(Contract.Result<ButtonControl<TModel>>() != null);

            this.tooltip = new Tooltip(html);

            return this;
        }

        public ButtonControl<TModel> Value(string value)
        {
            Contract.Ensures(Contract.Result<ButtonControl<TModel>>() != null);

            this.value = value;

            return this;
        }

        public ButtonControl<TModel> WithCaret()
        {
            Contract.Ensures(Contract.Result<ButtonControl<TModel>>() != null);

            this.withCaret = true;

            return this;
        }

        protected override string Render()
        {
            Contract.Ensures(!Contract.Result<string>().IsNullOrWhiteSpace());

            TagBuilder tagBuilder = new TagBuilder("button");

            tagBuilder.Attributes.Add("type", this.type.ToString().ToLowerInvariant());

            if (!this.name.IsNullOrWhiteSpace())
            {
                tagBuilder.Attributes.Add("name", this.name);
            }

            if (!this.id.IsNullOrWhiteSpace())
            {
                tagBuilder.Attributes.Add("id", this.id);
            }

            if (!this.value.IsNullOrWhiteSpace())
            {
                tagBuilder.Attributes.Add("value", this.value);
            }

            tagBuilder.AddCssClass("btn");

            if (this.tooltip != null) // TODO: if disabled, wrap control in div and apply tooltip to the div instead...  or always?  in case it gets disabled by code?
            {
                this.controlHtmlAttributes.MergeHtmlAttributes(this.tooltip.ToDictionary());
            }

            tagBuilder.MergeHtmlAttributes(this.controlHtmlAttributes.FormatHtmlAttributes());
            tagBuilder.AddCssClass(Helpers.GetCssClass(this.size));
            tagBuilder.AddCssClass(Helpers.GetCssClass(this.html, this.style));

            if (this.buttonBlock)
            {
                tagBuilder.AddCssClass("btn-block");
            }

            if (this.isDropDownToggle)
            {
                tagBuilder.AddCssClass("dropdown-toggle");
                tagBuilder.AddOrMergeAttribute("data-toggle", "dropdown");
            }

            if (this.disabled)
            {
                tagBuilder.AddCssClass("disabled");
            }

            if (!this.modalId.IsNullOrWhiteSpace())
            {
                tagBuilder.AddOrMergeAttribute("data-target", "#" + this.modalId);
                tagBuilder.AddOrMergeAttribute("data-toggle", "modal");

                if (!this.modalUrl.IsNullOrWhiteSpace())
                {
                    tagBuilder.AddOrMergeAttribute("data-remote", this.modalUrl);
                }
            }

            if (this.dismissModal)
            {
                tagBuilder.AddOrMergeAttribute("data-dismiss", "modal");
            }
            
            if (!string.IsNullOrEmpty(this.loadingText))
            {
                tagBuilder.AddOrMergeAttribute("data-loading-text", this.loadingText);
            }

            string prepend = string.Empty;
            string append = string.Empty;
            if (this.iconPrepend != null)
            {
                prepend = this.iconPrepend.ToHtmlString();
            }
            if (this.iconAppend != null)
            {
                append = this.iconAppend.ToHtmlString();
            }

            StringBuilder html = new StringBuilder();
            html.Append(prepend);
            if (html.Length > 0 && !this.text.IsNullOrWhiteSpace())
            {
                html.Append(" ");
            }
            html.Append(this.text);
            if (this.withCaret)
            {
                if (!this.text.IsNullOrWhiteSpace())
                {
                    html.Append(" ");
                }

                html.Append("<span class='caret'></span>");
            }
            if (html.Length > 0 && this.iconAppend != null)
            {
                html.Append(" ");
            }
            html.Append(append);

            tagBuilder.InnerHtml = html.ToString();

            return tagBuilder.ToString();
        }
    }
}