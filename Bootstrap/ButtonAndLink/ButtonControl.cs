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
        internal bool active;
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
            text = "";
        }

        public ButtonControl<TModel> Active(bool active = true)
        {
            Contract.Ensures(Contract.Result<ButtonControl<TModel>>() != null);

            this.active = active;

            return this;
        }

        public ButtonControl<TModel> AppendIcon(GlyphIcon icon)
        {
            Contract.Requires<ArgumentNullException>(icon != null, "icon");
            Contract.Ensures(Contract.Result<ButtonControl<TModel>>() != null);

            iconAppend = icon;

            return this;
        }

        public ButtonControl<TModel> AppendIcon(GlyphIconType icon, bool isWhite = false)
        {
            Contract.Ensures(Contract.Result<ButtonControl<TModel>>() != null);

            iconAppend = new GlyphIcon(icon, isWhite);

            return this;
        }

        public ButtonControl<TModel> AppendIcon(FontAwesomeIcon icon)
        {
            Contract.Requires<ArgumentNullException>(icon != null, "icon");
            Contract.Ensures(Contract.Result<ButtonControl<TModel>>() != null);

            iconAppend = icon;

            return this;
        }

        public ButtonControl<TModel> AppendIcon(FontAwesomeIconType icon, bool isWhite = false)
        {
            Contract.Ensures(Contract.Result<ButtonControl<TModel>>() != null);

            iconAppend = new FontAwesomeIcon(icon, isWhite);

            return this;
        }

        public ButtonControl<TModel> AppendIcon(string cssClass)
        {
            Contract.Requires<ArgumentException>(!cssClass.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<ButtonControl<TModel>>() != null);

            iconAppend = new GlyphIcon(cssClass);

            return this;
        }

        public ButtonControl<TModel> AutoFocus(bool isFocused = true)
        {
            Contract.Ensures(Contract.Result<ButtonControl<TModel>>() != null);

            if (isFocused)
            {
                controlHtmlAttributes.AddIfNotExist("autofocus", null);
            }
            else
            {
                controlHtmlAttributes.Remove("autofocus");
            }

            return this;
        }

        public ButtonControl<TModel> ButtonBlock()
        {
            Contract.Ensures(Contract.Result<ButtonControl<TModel>>() != null);

            buttonBlock = true;

            return this;
        }

        public ButtonControl<TModel> Disabled(bool isDisabled = true)
        {
            Contract.Ensures(Contract.Result<ButtonControl<TModel>>() != null);

            disabled = isDisabled;

            return this;
        }

        public ButtonControl<TModel> DismissModal()
        {
            Contract.Ensures(Contract.Result<ButtonControl<TModel>>() != null);

            dismissModal = true;

            return this;
        }

        public ButtonControl<TModel> DropDownToggle()
        {
            Contract.Ensures(Contract.Result<ButtonControl<TModel>>() != null);

            isDropDownToggle = true;

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

            iconPrepend = icon;

            return this;
        }

        public ButtonControl<TModel> PrependIcon(GlyphIconType icon, bool isWhite = false)
        {
            Contract.Ensures(Contract.Result<ButtonControl<TModel>>() != null);

            iconPrepend = new GlyphIcon(icon, isWhite);

            return this;
        }

        public ButtonControl<TModel> PrependIcon(FontAwesomeIcon icon)
        {
            Contract.Requires<ArgumentNullException>(icon != null, "icon");
            Contract.Ensures(Contract.Result<ButtonControl<TModel>>() != null);

            iconPrepend = icon;

            return this;
        }

        public ButtonControl<TModel> PrependIcon(FontAwesomeIconType icon, bool isWhite = false)
        {
            Contract.Ensures(Contract.Result<ButtonControl<TModel>>() != null);

            iconPrepend = new FontAwesomeIcon(icon, isWhite);

            return this;
        }

        public ButtonControl<TModel> PrependIcon(string cssClass)
        {
            Contract.Requires<ArgumentException>(!cssClass.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<ButtonControl<TModel>>() != null);

            iconPrepend = new GlyphIcon(cssClass);

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

            modalUrl = url;

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

            tooltip = new Tooltip(text);

            return this;
        }

        public ButtonControl<TModel> Tooltip(IHtmlString html)
        {
            Contract.Requires<ArgumentNullException>(html != null, "html");
            Contract.Ensures(Contract.Result<ButtonControl<TModel>>() != null);

            tooltip = new Tooltip(html);

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

            withCaret = true;

            return this;
        }

        /// <summary>
        /// Renders this instance.
        /// </summary>
        /// <returns></returns>
        protected override string Render()
        {
            return base.Render();
        }

        protected override string RenderControl()
        {
            Contract.Ensures(!Contract.Result<string>().IsNullOrWhiteSpace());

            TagBuilder tagBuilder = new TagBuilder("button");

            tagBuilder.Attributes.Add("type", type.ToString().ToLowerInvariant());

            if (!name.IsNullOrWhiteSpace())
            {
                tagBuilder.Attributes.Add("name", name);
            }

            if (!id.IsNullOrWhiteSpace())
            {
                tagBuilder.Attributes.Add("id", id);
            }

            if (!value.IsNullOrWhiteSpace())
            {
                tagBuilder.Attributes.Add("value", value);
            }

            tagBuilder.AddCssClass("btn");

            if (tooltip != null) // TODO: if disabled, wrap control in div and apply tooltip to the div instead...  or always?  in case it gets disabled by code?
            {
                controlHtmlAttributes.AddOrReplaceHtmlAttributes(tooltip.ToDictionary());
            }

            tagBuilder.MergeHtmlAttributes(controlHtmlAttributes.FormatHtmlAttributes());
            tagBuilder.AddCssClass(Helpers.GetCssClass(size));
            tagBuilder.AddCssClass(Helpers.GetCssClass(this.html, style));

            if (buttonBlock)
            {
                tagBuilder.AddCssClass("btn-block");
            }

            if (isDropDownToggle)
            {
                tagBuilder.AddCssClass("dropdown-toggle");
                tagBuilder.AddOrMergeAttribute("data-toggle", "dropdown");
            }

            if (active)
            {
                tagBuilder.AddCssClass("active");
            }

            if (disabled)
            {
                tagBuilder.AddCssClass("disabled");
            }

            if (!modalId.IsNullOrWhiteSpace())
            {
                tagBuilder.AddOrMergeAttribute("data-target", "#" + modalId);
                tagBuilder.AddOrMergeAttribute("data-toggle", "modal");

                if (!modalUrl.IsNullOrWhiteSpace())
                {
                    tagBuilder.AddOrMergeAttribute("data-remote", modalUrl);
                }
            }

            if (dismissModal)
            {
                tagBuilder.AddOrMergeAttribute("data-dismiss", "modal");
            }

            if (!string.IsNullOrEmpty(loadingText))
            {
                tagBuilder.AddOrMergeAttribute("data-loading-text", loadingText);
            }

            string prepend = string.Empty;
            string append = string.Empty;
            if (iconPrepend != null)
            {
                prepend = iconPrepend.ToHtmlString();
            }
            if (iconAppend != null)
            {
                append = iconAppend.ToHtmlString();
            }

            StringBuilder html = new StringBuilder();
            html.Append(prepend);
            if (html.Length > 0 && !text.IsNullOrWhiteSpace())
            {
                html.Append(" ");
            }
            html.Append(text);
            if (withCaret)
            {
                if (!text.IsNullOrWhiteSpace())
                {
                    html.Append(" ");
                }

                html.Append("<span class='caret'></span>");
            }
            if (html.Length > 0 && iconAppend != null)
            {
                html.Append(" ");
            }
            html.Append(append);

            tagBuilder.InnerHtml = html.ToString();

            return WrapperTagFromatString().FormatWith(tagBuilder.ToString());
        }
    }
}