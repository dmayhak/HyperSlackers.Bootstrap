using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Web;
using HyperSlackers.Bootstrap.Extensions;

namespace HyperSlackers.Bootstrap
{
    // TODO: //! see: http://getbootstrap.com/javascript/#tooltips for special cases in button groups, disabled elements, etc.
    public class Tooltip
    {
        readonly internal string text;
        internal bool? animation;
        internal bool? html;
        internal string placement;
        internal string selector;
        internal string trigger;
        internal int? delay;
        internal int? delayShow;
        internal int? delayHide;
        internal string container;
        internal CursorType cursor = CursorType.Help;

        public Tooltip(string text)
        {
            Contract.Requires<ArgumentException>(!text.IsNullOrWhiteSpace());

            this.text = text;
        }

        public Tooltip(IHtmlString html)
        {
            Contract.Requires<ArgumentNullException>(html != null, "html");

            this.html = true;
            text = html.ToString();
        }

        public Tooltip Animation(bool animation = true)
        {
            Contract.Ensures(Contract.Result<Tooltip>() != null);

            this.animation = animation;

            return this;
        }

        public Tooltip NoAnimation()
        {
            Contract.Ensures(Contract.Result<Tooltip>() != null);

            animation = false;

            return this;
        }

        public Tooltip Html(bool html = true)
        {
            Contract.Ensures(Contract.Result<Tooltip>() != null);

            this.html = html;

            return this;
        }

        public Tooltip Cursor(CursorType cursor)
        {
            Contract.Ensures(Contract.Result<Tooltip>() != null);

            this.cursor = cursor;

            return this;
        }

        public Tooltip Placement(Placement placement)
        {
            Contract.Ensures(Contract.Result<Tooltip>() != null);

            this.placement = Helpers.GetCssClass(placement);

            return this;
        }

        public Tooltip PlacementAuto(Placement preferredPlacement)
        {
            Contract.Ensures(Contract.Result<Tooltip>() != null);

            placement = "auto " + Helpers.GetCssClass(preferredPlacement);

            return this;
        }

        public Tooltip Selector(string selector)
        {
            //x Contract.Requires<ArgumentException>(!selector.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<Tooltip>() != null);

            this.selector = selector;

            return this;
        }

        public Tooltip Trigger(Trigger trigger)
        {
            Contract.Ensures(Contract.Result<Tooltip>() != null);

            if (this.trigger == null)
            {
                this.trigger = trigger.ToString().ToLowerInvariant();
            }
            else if (!this.trigger.Contains(trigger.ToString().ToLowerInvariant()))
            {
                this.trigger += " " + trigger.ToString().ToLowerInvariant();
            }

            return this;
        }

        public Tooltip Delay(int delay)
        {
            Contract.Requires<ArgumentOutOfRangeException>(delay >= 0);
            Contract.Ensures(Contract.Result<Tooltip>() != null);

            this.delay = delay;

            return this;
        }

        public Tooltip Delay(int delayShow, int delayHide)
        {
            Contract.Requires<ArgumentOutOfRangeException>(delayShow >= 0);
            Contract.Requires<ArgumentOutOfRangeException>(delayHide >= 0);
            Contract.Ensures(Contract.Result<Tooltip>() != null);

            this.delayShow = delayShow;
            this.delayHide = delayHide;

            return this;
        }

        public Tooltip Container(string container)
        {
            Contract.Requires<ArgumentException>(!container.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<Tooltip>() != null);

            this.container = container;

            return this;
        }

        public Tooltip ContainInBody()
        {
            Contract.Ensures(Contract.Result<Tooltip>() != null);

            container = "body";

            return this;
        }

        internal virtual Dictionary<string, object> ToDictionary()
        {
            Contract.Ensures(Contract.Result<Dictionary<string, object>>() != null);

            Dictionary<string, object> dictionary = new Dictionary<string, object>();

            dictionary.AddIfNotExist("data-toggle", "tooltip");
            dictionary.AddIfNotExist("data-title", text);

            if (animation.HasValue)
            {
                dictionary.AddIfNotExist("data-animation", animation.Value ? "true" : "false");
            }

            if (html.HasValue)
            {
                dictionary.AddIfNotExist("data-html", html.Value ? "true" : "false");
            }

            if (!placement.IsNullOrWhiteSpace())
            {
                dictionary.AddIfNotExist("data-placement", placement);
            }

            if (!selector.IsNullOrWhiteSpace())
            {
                dictionary.AddIfNotExist("data-selector", selector);
            }

            if (!trigger.IsNullOrWhiteSpace())
            {
                dictionary.AddIfNotExist("data-trigger", trigger);
            }

            if (delayShow.HasValue && delayHide.HasValue)
            {
                dictionary.AddIfNotExist("data-delay", "{" + " \"show\": {0}, \"hide\": {1} ".FormatWith(delayShow.Value, delayHide.Value) + "}");
            }
            else if (delay.HasValue)
            {
                dictionary.AddIfNotExist("data-delay", delay.Value.ToString());
            }

            if (!container.IsNullOrWhiteSpace())
            {
                dictionary.AddIfNotExist("data-container", container);
            }

            dictionary.AddIfNotExist("style", "cursor: {0};".FormatWith(Helpers.GetCssClass(cursor)));

            return dictionary;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToString()
        {
            return base.ToString();
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public new Type GetType()
        {
            return base.GetType();
        }
    }
}
