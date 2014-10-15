using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics.Contracts;
using HyperSlackers.Bootstrap.Extensions;

namespace HyperSlackers.Bootstrap
{
    public class FontAwesomeIconStack : IHtmlString
	{
        readonly internal IDictionary<string, object> htmlAttributes = new Dictionary<string, object>();
        readonly internal FontAwesomeIcon topIcon = null;
        readonly internal FontAwesomeIcon bottomIcon = null;
        internal FontAwesomeIconSize size = FontAwesomeIconSize.Default;
        internal bool pullRight = false;
        internal bool pullLeft = false;
        readonly internal bool topIconIsLarger = false;
        internal bool topIconInverse = false;
        internal bool bottomIconInverse = false;
        internal Tooltip tooltip;
        internal Popover popover;
        
        public FontAwesomeIconStack(FontAwesomeIconType topIcon, FontAwesomeIconType bottomIcon, bool topIconIsLarger = false)
        {
            this.topIcon = new FontAwesomeIcon(topIcon);
            this.bottomIcon = new FontAwesomeIcon(bottomIcon);
            this.topIconIsLarger = topIconIsLarger;
        }

        public FontAwesomeIconStack(FontAwesomeIcon topIcon, FontAwesomeIcon bottomIcon, bool topIconIsLarger = false)
        {
            this.topIcon = topIcon;
            this.bottomIcon = bottomIcon;
            this.topIconIsLarger = topIconIsLarger;
        }

        public FontAwesomeIconStack Class(string cssClass)
        {
            Contract.Requires<ArgumentException>(!cssClass.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<FontAwesomeIconStack>() != null);

            this.htmlAttributes.AddClass(cssClass);

            return this;
        }

        public FontAwesomeIconStack Data(object htmlDataAttributes)
        {
            Contract.Requires<ArgumentNullException>(htmlDataAttributes != null, "htmlDataAttributes");
            Contract.Ensures(Contract.Result<FontAwesomeIconStack>() != null);

            this.htmlAttributes.MergeHtmlAttributes(htmlDataAttributes.ToHtmlDataAttributes());

            return this;
        }

        public FontAwesomeIconStack HtmlAttribute(string key, string value)
        {
            Contract.Requires<ArgumentException>(!key.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<FontAwesomeIconStack>() != null);

            this.htmlAttributes.Add(key, value);

            return this;
        }

        public FontAwesomeIconStack HtmlAttributes(IDictionary<string, object> htmlAttributes)
        {
            Contract.Requires<ArgumentNullException>(htmlAttributes != null, "htmlAttributes");
            Contract.Ensures(Contract.Result<FontAwesomeIconStack>() != null);

            this.htmlAttributes.MergeHtmlAttributes(htmlAttributes);

            return this;
        }

        public FontAwesomeIconStack HtmlAttributes(object htmlAttributes)
        {
            Contract.Requires<ArgumentNullException>(htmlAttributes != null, "htmlAttributes");
            Contract.Ensures(Contract.Result<FontAwesomeIconStack>() != null);

            this.htmlAttributes.MergeHtmlAttributes(htmlAttributes.ToDictionary());

            return this;
        }

        public FontAwesomeIconStack Id(string id)
        {
            Contract.Requires<ArgumentException>(!id.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<FontAwesomeIconStack>() != null);

            this.htmlAttributes.AddOrReplace("id", id);

            return this;
        }

        public FontAwesomeIconStack Popover(Popover popover)
        {
            Contract.Requires<ArgumentNullException>(popover != null, "popover");
            Contract.Ensures(Contract.Result<FontAwesomeIconStack>() != null);

            this.popover = popover;

            return this;
        }

        public FontAwesomeIconStack Popover(string title, string content)
        {
            Contract.Requires<ArgumentException>(!title.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentException>(!content.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<FontAwesomeIconStack>() != null);

            this.popover = new Popover(title, content);

            return this;
        }

        public FontAwesomeIconStack Tooltip(Tooltip tooltip)
        {
            Contract.Requires<ArgumentNullException>(tooltip != null, "tooltip");
            Contract.Ensures(Contract.Result<FontAwesomeIconStack>() != null);

            this.tooltip = tooltip;

            return this;
        }

        public FontAwesomeIconStack Tooltip(string text)
        {
            Contract.Requires<ArgumentException>(!text.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<FontAwesomeIconStack>() != null);

            this.tooltip = new Tooltip(text);

            return this;
        }

        public FontAwesomeIconStack Tooltip(IHtmlString html)
        {
            Contract.Requires<ArgumentNullException>(html != null, "html");
            Contract.Ensures(Contract.Result<FontAwesomeIconStack>() != null);

            this.tooltip = new Tooltip(html);

            return this;
        }

        public FontAwesomeIconStack Size(FontAwesomeIconSize size)
        {
            Contract.Ensures(Contract.Result<FontAwesomeIconStack>() != null);

            this.size = size;

            return this;
        }

        public FontAwesomeIconStack TopIconInverse(bool inverse)
        {
            Contract.Ensures(Contract.Result<FontAwesomeIconStack>() != null);

            this.topIcon.Inverse(inverse);

            return this;
        }

        public FontAwesomeIconStack BottomIconInverse(bool inverse)
        {
            Contract.Ensures(Contract.Result<FontAwesomeIconStack>() != null);

            this.bottomIcon.Inverse(inverse);

            return this;
        }

        public FontAwesomeIconStack PullRight(bool pullRight = true)
        {
            Contract.Ensures(Contract.Result<FontAwesomeIconStack>() != null);

            this.pullRight = pullRight;

            if (pullRight)
            {
                pullLeft = false;
            }

            return this;
        }

        public FontAwesomeIconStack PullLeft(bool pullLeft = true)
        {
            Contract.Ensures(Contract.Result<FontAwesomeIconStack>() != null);

            this.pullLeft = pullLeft;

            if (pullLeft)
            {
                pullRight = false;
            }

            return this;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
		public virtual string ToHtmlString()
		{
            Contract.Ensures(!Contract.Result<string>().IsNullOrWhiteSpace());

            if (this.topIconIsLarger)
            {
                topIcon.Class("fa-stack-2x");
                bottomIcon.Class("fa-stack-1x");
            }
            else
            {
                topIcon.Class("fa-stack-1x");
                bottomIcon.Class("fa-stack-2x");
            }

			TagBuilder tagBuilder = new TagBuilder("span");
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

            // font awesome classes
            tagBuilder.AddCssClass("fa-stack");

            if (size != FontAwesomeIconSize.Default)
            {
                switch (size)
                {
                    case FontAwesomeIconSize.Default:
                        tagBuilder.AddCssClass("fa-lg"); // default to large....
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

            if (pullLeft)
            {
                tagBuilder.AddCssClass("pull-left");
            }
            else if (pullRight)
            {
                tagBuilder.AddCssClass("pull-right");
            }

            tagBuilder.InnerHtml = bottomIcon.ToHtmlString() + topIcon.ToHtmlString();

            return tagBuilder.ToString(TagRenderMode.Normal);
		}

        [EditorBrowsable(EditorBrowsableState.Never)]
		public override string ToString()
		{
			return this.ToHtmlString();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public override bool Equals(object obj)
		{
			return this.Equals(obj);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public override int GetHashCode()
		{
			return this.GetHashCode();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public new Type GetType()
		{
			return this.GetType();
		}
	}
}