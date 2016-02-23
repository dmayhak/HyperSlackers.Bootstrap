using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics.Contracts;
using HyperSlackers.Bootstrap.Extensions;

namespace HyperSlackers.Bootstrap
{
    public class FontAwesomeIcon : Icon<FontAwesomeIcon>
	{
        readonly internal FontAwesomeIconType fontAwesomeIcon = FontAwesomeIconType.Undefined;
        internal FontAwesomeIconSize size = FontAwesomeIconSize.Default;
        internal FontAwesomeIconRotate rotation = FontAwesomeIconRotate.Default;
        internal TextColor color = TextColor.Default;
        internal bool fixedWidth = false;
        internal bool spin = false;
        internal bool pulse = false;
        internal bool border = false;
        internal bool listIcon = false;
        internal bool pullRight = false;
        internal bool pullLeft = false;
        internal bool inverse = false;

        public FontAwesomeIcon(FontAwesomeIconType icon)
        {
            fontAwesomeIcon = icon;
        }

        public FontAwesomeIcon(FontAwesomeIconType icon, bool inverse)
        {
            fontAwesomeIcon = icon;
            this.inverse = inverse;
        }

        public FontAwesomeIcon Size(FontAwesomeIconSize size)
        {
            Contract.Ensures(Contract.Result<FontAwesomeIcon>() != null);

            this.size = size;

            return this;
        }

        public FontAwesomeIcon Rotate(FontAwesomeIconRotate rotation)
        {
            Contract.Ensures(Contract.Result<FontAwesomeIcon>() != null);

            this.rotation = rotation;

            return this;
        }

        public FontAwesomeIcon Color(TextColor color)
        {
            Contract.Ensures(Contract.Result<FontAwesomeIcon>() != null);

            this.color = color;

            return this;
        }

        public FontAwesomeIcon FixedWidth(bool fixedWidth = true)
        {
            Contract.Ensures(Contract.Result<FontAwesomeIcon>() != null);

            this.fixedWidth = fixedWidth;

            return this;
        }

        public FontAwesomeIcon Spin(bool spin = true)
        {
            Contract.Ensures(Contract.Result<FontAwesomeIcon>() != null);

            this.spin = spin;

            return this;
        }

        public FontAwesomeIcon Pulse(bool pulse = true)
        {
            Contract.Ensures(Contract.Result<FontAwesomeIcon>() != null);

            this.pulse = pulse;

            return this;
        }

        public FontAwesomeIcon Inverse(bool inverse = true)
        {
            Contract.Ensures(Contract.Result<FontAwesomeIcon>() != null);

            this.inverse = inverse;

            return this;
        }

        public FontAwesomeIcon Border(bool border = true)
        {
            Contract.Ensures(Contract.Result<FontAwesomeIcon>() != null);

            this.border = border;

            return this;
        }

        public FontAwesomeIcon PullRight(bool pullRight = true)
        {
            Contract.Ensures(Contract.Result<FontAwesomeIcon>() != null);

            this.pullRight = pullRight;

            if (pullRight)
            {
                pullLeft = false;
            }

            return this;
        }

        public FontAwesomeIcon PullLeft(bool pullLeft = true)
        {
            Contract.Ensures(Contract.Result<FontAwesomeIcon>() != null);

            this.pullLeft = pullLeft;

            if (pullLeft)
            {
                pullRight = false;
            }

            return this;
        }

        public FontAwesomeIcon ListIcon(bool listIcon = true)
        {
            Contract.Ensures(Contract.Result<FontAwesomeIcon>() != null);

            // TODO: the UL needs a "fa-ul" class applied...
            this.listIcon = listIcon;

            return this;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
		public override string ToHtmlString()
		{
            Contract.Ensures(!Contract.Result<string>().IsNullOrWhiteSpace());

			TagBuilder tagBuilder = new TagBuilder("i");
			IDictionary<string, object> attributes = htmlAttributes.FormatHtmlAttributes();

			if (tooltip != null)
			{
				attributes.AddOrReplaceHtmlAttributes(tooltip.ToDictionary());
			}

			if (popover != null)
			{
				attributes.AddOrReplaceHtmlAttributes(popover.ToDictionary());
			}

			tagBuilder.MergeHtmlAttributes(attributes);

            // font awesome classes
            tagBuilder.AddCssClass("fa");
            tagBuilder.AddCssClass("fa-" + fontAwesomeIcon.ToString().SpaceOnUpperCase().ToLowerInvariant().Replace(" ", "-"));

            if (size != FontAwesomeIconSize.Default)
            {
                switch (size)
                {
                    case FontAwesomeIconSize.Default:
                        break;
                    case FontAwesomeIconSize.Large:
                        tagBuilder.AddCssClass("fa-lg");
                        break;
                    case FontAwesomeIconSize.X2:
                        tagBuilder.AddCssClass("fa-2x");
                        break;
                    case FontAwesomeIconSize.X3:
                        tagBuilder.AddCssClass("fa-3x");
                        break;
                    case FontAwesomeIconSize.X4:
                        tagBuilder.AddCssClass("fa-4x");
                        break;
                    case FontAwesomeIconSize.X5:
                        tagBuilder.AddCssClass("fa-5x");
                        break;
                    default:
                        break;
                }
            }

            if (rotation != FontAwesomeIconRotate.Default)
            {
                switch (rotation)
                {
                    case FontAwesomeIconRotate.Default:
                        break;
                    case FontAwesomeIconRotate.Rotate90:
                        tagBuilder.AddCssClass("fa-rotate-90");
                        break;
                    case FontAwesomeIconRotate.Rotate180:
                        tagBuilder.AddCssClass("fa-rotate-180");
                        break;
                    case FontAwesomeIconRotate.Rotate270:
                        tagBuilder.AddCssClass("fa-rotate-270");
                        break;
                    case FontAwesomeIconRotate.FlipHorizontal:
                        tagBuilder.AddCssClass("fa-flip-horizontal");
                        break;
                    case FontAwesomeIconRotate.FlipVertical:
                        tagBuilder.AddCssClass("fa-flip-vertical");
                        break;
                    default:
                        break;
                }
            }

            if (color != TextColor.Default)
            {
                tagBuilder.AddCssClass(Helpers.GetCssClass(color));
            }

            if (fixedWidth)
            {
                tagBuilder.AddCssClass("fa-fw");
            }

            if (listIcon)
            {
                tagBuilder.AddCssClass("fa-li");
            }

            if (border)
            {
                tagBuilder.AddCssClass("fa-border");
            }

            if (spin)
            {
                tagBuilder.AddCssClass("fa-spin");
            }

            if (pulse)
            {
                tagBuilder.AddCssClass("fa-pulse");
            }

            if (inverse)
            {
                tagBuilder.AddCssClass("fa-inverse");
            }

            if (pullLeft)
            {
                tagBuilder.AddCssClass("pull-left");
            }
            else if (pullRight)
            {
                tagBuilder.AddCssClass("pull-right");
            }

            return tagBuilder.ToString(TagRenderMode.Normal);
		}

        [EditorBrowsable(EditorBrowsableState.Never)]
		public override string ToString()
		{
			return ToHtmlString();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public override bool Equals(object obj)
		{
			return Equals(obj);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public override int GetHashCode()
		{
			return GetHashCode();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public new Type GetType()
		{
			return GetType();
		}
	}
}