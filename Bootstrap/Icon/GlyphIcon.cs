using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics.Contracts;
using HyperSlackers.Bootstrap.Extensions;

namespace HyperSlackers.Bootstrap
{
    public class GlyphIcon : Icon<GlyphIcon>
	{
        readonly internal GlyphIconType glyphIcon = GlyphIconType.Undefined;
        internal bool isWhite;
        
        public GlyphIcon(GlyphIconType icon)
        {
            this.glyphIcon = icon;
        }

        public GlyphIcon(GlyphIconType icon, bool isWhite)
        {
            this.glyphIcon = icon;
            this.isWhite = isWhite;
        }

        public GlyphIcon(string cssClass)
            : base(cssClass)
        {
            Contract.Requires<ArgumentException>(!cssClass.IsNullOrWhiteSpace());
        }

        public GlyphIcon(string cssClass, bool isWhite)
            : base(cssClass)
        {
            Contract.Requires<ArgumentException>(!cssClass.IsNullOrWhiteSpace());

            this.isWhite = isWhite;
        }

        public GlyphIcon White()
        {
            Contract.Ensures(Contract.Result<GlyphIcon>() != null);

            this.isWhite = true;

            return this;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
		public override string ToHtmlString()
		{
            Contract.Ensures(!Contract.Result<string>().IsNullOrWhiteSpace());

			TagBuilder tagBuilder = new TagBuilder("i");
			IDictionary<string, object> attributes = this.htmlAttributes.FormatHtmlAttributes();

			if (this.tooltip != null)
			{
				attributes.MergeHtmlAttributes(this.tooltip.ToDictionary());
			}

			if (this.popover != null)
			{
				attributes.MergeHtmlAttributes(this.popover.ToDictionary());
			}

			tagBuilder.MergeHtmlAttributes(attributes);

            if (this.glyphIcon != GlyphIconType.Undefined)
            {
                tagBuilder.AddCssClass("glyphicon");
                tagBuilder.AddCssClass(GetIconCssClass(this.glyphIcon));
            }

            if (!this.cssClass.IsNullOrWhiteSpace())
            {
                tagBuilder.AddCssClass(this.cssClass);
            }

            if (this.isWhite)
            {
                tagBuilder.AddCssClass("icon-white");
            }

            return tagBuilder.ToString(TagRenderMode.Normal);
		}

        private string GetIconCssClass(GlyphIconType icon)
        {
            Contract.Ensures(!Contract.Result<string>().IsNullOrWhiteSpace());

            return "glyphicon-" + icon.ToString().SpaceOnUpperCase().ToLowerInvariant().Replace(" ", "-");
        }
	}
}