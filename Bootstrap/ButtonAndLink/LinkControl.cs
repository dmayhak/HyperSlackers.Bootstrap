using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web;
using System.Web.Mvc;
using HyperSlackers.Bootstrap;
using System.Diagnostics.Contracts;
using System.Text;
using HyperSlackers.Bootstrap.Core;
using HyperSlackers.Bootstrap.Extensions;

namespace HyperSlackers.Bootstrap.Controls
{
    public class LinkControl<TModel> : ControlBase<LinkControl<TModel>, TModel>
    {
        internal string linkText;
        internal string url;
        // TODO: internal bool disabled;
        internal Icon iconPrepend;
        internal Icon iconAppend;
        internal Tooltip tooltip;
        internal string modalId;

        internal LinkControl(HtmlHelper<TModel> html, string linkText, string url)
            : base(html)
        {
            Contract.Requires<ArgumentNullException>(html != null, "html");
            Contract.Requires<ArgumentException>(!linkText.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentException>(!url.IsNullOrWhiteSpace());

            this.linkText = linkText;
            this.url = url;
        }

        public LinkControl<TModel> PrependIcon(GlyphIcon icon)
        {
            Contract.Requires<ArgumentNullException>(icon != null, "icon");
            Contract.Ensures(Contract.Result<LinkControl<TModel>>() != null);

            iconPrepend = icon;

            return this;
        }

        public LinkControl<TModel> PrependIcon(GlyphIconType icon, bool isWhite = false)
        {
            Contract.Ensures(Contract.Result<LinkControl<TModel>>() != null);

            iconPrepend = new GlyphIcon(icon, isWhite);

            return this;
        }

        public LinkControl<TModel> PrependIcon(FontAwesomeIcon icon)
        {
            Contract.Requires<ArgumentNullException>(icon != null, "icon");
            Contract.Ensures(Contract.Result<LinkControl<TModel>>() != null);

            iconPrepend = icon;

            return this;
        }

        public LinkControl<TModel> PrependIcon(FontAwesomeIconType icon, bool isWhite = false)
        {
            Contract.Ensures(Contract.Result<LinkControl<TModel>>() != null);

            iconPrepend = new FontAwesomeIcon(icon, isWhite);

            return this;
        }

        public LinkControl<TModel> PrependIcon(string cssClass)
        {
            Contract.Requires<ArgumentException>(!cssClass.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<LinkControl<TModel>>() != null);

            iconPrepend = new GlyphIcon(cssClass);

            return this;
        }

        public LinkControl<TModel> AppendIcon(GlyphIconType icon, bool isWhite)
        {
            Contract.Ensures(Contract.Result<LinkControl<TModel>>() != null);

            iconAppend = new GlyphIcon(icon, isWhite);

            return this;
        }

        public LinkControl<TModel> AppendIcon(FontAwesomeIconType icon, bool isWhite)
        {
            Contract.Ensures(Contract.Result<LinkControl<TModel>>() != null);

            iconAppend = new FontAwesomeIcon(icon, isWhite);

            return this;
        }

        public LinkControl<TModel> AppendIcon(string cssClass)
        {
            Contract.Requires<ArgumentException>(!cssClass.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<LinkControl<TModel>>() != null);

            iconAppend = new GlyphIcon(cssClass);

            return this;
        }

        public LinkControl<TModel> AppendIcon(GlyphIcon icon)
        {
            Contract.Requires<ArgumentNullException>(icon != null, "icon");
            Contract.Ensures(Contract.Result<LinkControl<TModel>>() != null);

            iconAppend = icon;

            return this;
        }

        public LinkControl<TModel> AppendIcon(FontAwesomeIcon icon)
        {
            Contract.Requires<ArgumentNullException>(icon != null, "icon");
            Contract.Ensures(Contract.Result<LinkControl<TModel>>() != null);

            iconAppend = icon;

            return this;
        }

        //public LinkControl<TModel> Disabled(bool isDisabled = true)
        //{
        //    Contract.Ensures(Contract.Result<LinkControl<TModel>>() != null);

        //    this.disabled = isDisabled;

        //    return this;
        //}

        public LinkControl<TModel> TriggerModal(string modalId)
        {
            Contract.Requires<ArgumentException>(!modalId.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<LinkControl<TModel>>() != null);

            this.modalId = modalId;

            return this;
        }

        public LinkControl<TModel> Tooltip(Tooltip tooltip)
        {
            Contract.Requires<ArgumentNullException>(tooltip != null, "tooltip");
            Contract.Ensures(Contract.Result<LinkControl<TModel>>() != null);

            this.tooltip = tooltip;

            return this;
        }

        public LinkControl<TModel> Tooltip(string text)
        {
            Contract.Requires<ArgumentException>(!text.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<LinkControl<TModel>>() != null);

            tooltip = new Tooltip(text);

            return this;
        }

        public LinkControl<TModel> Tooltip(IHtmlString html)
        {
            Contract.Requires<ArgumentNullException>(html != null, "html");
            Contract.Ensures(Contract.Result<LinkControl<TModel>>() != null);

            tooltip = new Tooltip(html);

            return this;
        }

        internal LinkControl<TModel> AlertLink()
        {
            Contract.Ensures(Contract.Result<LinkControl<TModel>>() != null);

            ControlClass("alert-link");

            return this;
        }

        protected override string Render()
        {
            Contract.Ensures(!Contract.Result<string>().IsNullOrWhiteSpace());

            IDictionary<string, object> attributes = controlHtmlAttributes.FormatHtmlAttributes();

            if (tooltip != null)
            {
                attributes.AddOrReplaceHtmlAttributes(tooltip.ToDictionary());
            }

            if (!id.IsNullOrWhiteSpace())
            {
                attributes.AddOrReplaceHtmlAttribute("id", id);
            }

            TagBuilder tagBuilder = new TagBuilder("a");
            tagBuilder.MergeHtmlAttributes(attributes);

            if (!modalId.IsNullOrWhiteSpace())
            {
                tagBuilder.AddOrMergeAttribute("data-target", "#" + modalId);
                tagBuilder.AddOrMergeAttribute("data-toggle", "modal");

                if (!url.IsNullOrWhiteSpace())
                {
                    tagBuilder.AddOrMergeAttribute("data-remote", url);
                }
            }
            else
            {
                tagBuilder.MergeAttribute("href", url);
            }

            //if (this.disabled)
            //{
            //    tagBuilder.AddCssClass("disabled");
            //    tagBuilder.AddOrMergeAttribute("disabled", "true");
            //}

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

            StringBuilder text = new StringBuilder();
            text.Append(prepend);
            if (text.Length > 0 && !linkText.IsNullOrWhiteSpace())
            {
                text.Append(" ");
            }
            text.Append(linkText);
            if (text.Length > 0 && iconAppend != null)
            {
                text.Append(" ");
            }
            text.Append(append);

            tagBuilder.InnerHtml = text.ToString();

            string html = tagBuilder.ToString(TagRenderMode.Normal);

            html = WrapperTagFromatString().FormatWith(html);

            return MvcHtmlString.Create(html).ToString();
        }
    }
}