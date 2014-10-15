using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Web;
using HyperSlackers.Bootstrap;
using System.Diagnostics.Contracts;
using HyperSlackers.Bootstrap.Core;
using System.Web.Mvc;
using HyperSlackers.Bootstrap.Extensions;

namespace HyperSlackers.Bootstrap.Controls
{
    public class TabControl<TModel> : ControlBase<TabControl<TModel>, TModel>
	{
        internal Icon prependIcon;
        internal Icon appendIcon;
        internal string href;
        internal bool isActive;
        internal string labelText;

		internal TabControl(HtmlHelper<TModel> html, string labelText, string href, bool isActive)
            : base(html)
		{
            Contract.Requires<ArgumentNullException>(html != null, "html");
            Contract.Requires<ArgumentException>(!labelText.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentException>(!href.IsNullOrWhiteSpace());

            this.labelText = labelText;
            this.href = href;
            this.isActive = isActive;
		}

        public TabControl<TModel> PrependIcon(GlyphIcon icon)
        {
            Contract.Requires<ArgumentNullException>(icon != null, "icon");
            Contract.Ensures(Contract.Result<TabControl<TModel>>() != null);

            this.prependIcon = icon;

            return this;
        }

        public TabControl<TModel> PrependIcon(FontAwesomeIcon icon)
        {
            Contract.Requires<ArgumentNullException>(icon != null, "icon");
            Contract.Ensures(Contract.Result<TabControl<TModel>>() != null);

            this.prependIcon = icon;

            return this;
        }

        public TabControl<TModel> PrependIcon(GlyphIconType icon, bool isWhite = false)
        {
            Contract.Ensures(Contract.Result<TabControl<TModel>>() != null);

            this.prependIcon = new GlyphIcon(icon, isWhite);

            return this;
        }

        public TabControl<TModel> PrependIcon(FontAwesomeIconType icon, bool isWhite = false)
        {
            Contract.Ensures(Contract.Result<TabControl<TModel>>() != null);

            this.prependIcon = new FontAwesomeIcon(icon, isWhite);

            return this;
        }

        public TabControl<TModel> PrependIcon(string iconCssClass)
        {
            Contract.Requires<ArgumentException>(!iconCssClass.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<TabControl<TModel>>() != null);

            this.prependIcon = new GlyphIcon(iconCssClass);

            return this;
        }

        public TabControl<TModel> AppendIcon(GlyphIcon icon)
        {
            Contract.Requires<ArgumentNullException>(icon != null, "icon");
            Contract.Ensures(Contract.Result<TabControl<TModel>>() != null);

            this.appendIcon = icon;

            return this;
        }

        public TabControl<TModel> AppendIcon(FontAwesomeIcon icon)
        {
            Contract.Requires<ArgumentNullException>(icon != null, "icon");
            Contract.Ensures(Contract.Result<TabControl<TModel>>() != null);

            this.appendIcon = icon;

            return this;
        }

        public TabControl<TModel> AppendIcon(GlyphIconType icon, bool isWhite = false)
        {
            Contract.Ensures(Contract.Result<TabControl<TModel>>() != null);

            this.appendIcon = new GlyphIcon(icon, isWhite);

            return this;
        }

        public TabControl<TModel> AppendIcon(FontAwesomeIconType icon, bool isWhite = false)
        {
            Contract.Ensures(Contract.Result<TabControl<TModel>>() != null);

            this.appendIcon = new FontAwesomeIcon(icon, isWhite);

            return this;
        }

        public TabControl<TModel> AppendIcon(string iconCssClass)
        {
            Contract.Requires<ArgumentException>(!iconCssClass.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<TabControl<TModel>>() != null);

            this.appendIcon = new GlyphIcon(iconCssClass);

            return this;
        }

        protected override string RenderControl()
        {
            string liClass = (this.isActive ? " class=\"active\"" : string.Empty);
            string prepend = (this.prependIcon != null ? (this.prependIcon + " ") : string.Empty);
            string append = (this.appendIcon != null ? (" " + this.appendIcon) : string.Empty);

            return "<li{0}><a data-toggle=\"tab\" href=\"#{1}\">{3}{2}{4}</a></li>".FormatWith(liClass, this.href, this.labelText, prepend, append);
        }
    }
}