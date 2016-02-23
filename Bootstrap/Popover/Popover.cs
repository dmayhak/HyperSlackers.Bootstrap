using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using HyperSlackers.Bootstrap.Extensions;

namespace HyperSlackers.Bootstrap
{
    // TODO: //! see: http://getbootstrap.com/javascript/#popovers for special cases in button groups, disabled elements, etc.  also where else can popovers be used?
    public class Popover
    {
        readonly internal string title;
        readonly internal string content;
        internal bool? animation;
        internal bool? html;
        internal string placement;
        internal string selector;
        internal string trigger;
        internal int? delay;
        internal int? delayShow;
        internal int? delayHide;
        internal string container;
        internal bool closable;
        internal CursorType cursor = CursorType.Pointer;

        public Popover(string title, string content)
        {
            Contract.Requires<ArgumentException>(!title.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentException>(!content.IsNullOrWhiteSpace());

            this.title = title;
            this.content = content;
        }

        public Popover Animation(bool animation = true)
        {
            Contract.Ensures(Contract.Result<Popover>() != null);

            this.animation = animation;

            return this;
        }

        public Popover NoAnimation()
        {
            Contract.Ensures(Contract.Result<Popover>() != null);

            animation = false;

            return this;
        }

        public Popover Html(bool html = true)
        {
            Contract.Ensures(Contract.Result<Popover>() != null);

            this.html = html;

            return this;
        }

        public Popover Cursor(CursorType cursor)
        {
            Contract.Ensures(Contract.Result<Popover>() != null);

            this.cursor = cursor;

            return this;
        }

        public Popover Placement(Placement placement)
        {
            Contract.Ensures(Contract.Result<Popover>() != null);

            this.placement = Helpers.GetCssClass(placement);

            return this;
        }

        public Popover PlacementAuto(Placement preferredPlacement)
        {
            Contract.Ensures(Contract.Result<Popover>() != null);

            placement = "auto " + Helpers.GetCssClass(preferredPlacement);

            return this;
        }

        public Popover Selector(string selector)
        {
            //x Contract.Requires<ArgumentException>(!selector.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<Popover>() != null);

            this.selector = selector;

            return this;
        }

        public Popover Trigger(Trigger trigger)
        {
            Contract.Ensures(Contract.Result<Popover>() != null);

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

        public Popover Delay(int delay)
        {
            Contract.Requires<ArgumentOutOfRangeException>(delay >= 0);
            Contract.Ensures(Contract.Result<Popover>() != null);

            this.delay = delay;

            return this;
        }

        public Popover Delay(int delayShow, int delayHide)
        {
            Contract.Requires<ArgumentOutOfRangeException>(delayShow >= 0);
            Contract.Requires<ArgumentOutOfRangeException>(delayHide >= 0);
            Contract.Ensures(Contract.Result<Popover>() != null);

            this.delayShow = delayShow;
            this.delayHide = delayHide;

            return this;
        }

        public Popover Container(string element)
        {
            //x Contract.Requires<ArgumentException>(!element.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<Popover>() != null);

            container = element;

            return this;
        }

        public Popover Closeable(bool closable = true)
        {
            Contract.Ensures(Contract.Result<Popover>() != null);

            this.closable = closable;

            return this;
        }

        internal virtual Dictionary<string, object> ToDictionary()
        {
            Contract.Ensures(Contract.Result<Dictionary<string, object>>() != null);

            Dictionary<string, object> dictionary = new Dictionary<string, object>();

            dictionary.AddIfNotExist("data-toggle", "popover");
            dictionary.AddIfNotExist("data-title", title + (closable ? "<span class='pull-right close'>&times;</span>" : string.Empty));
            dictionary.AddIfNotExist("data-content", content);

            if (animation.HasValue)
            {
                dictionary.AddIfNotExist("data-animation", animation.Value ? "true" : "false");
            }

            if (closable)
            {
                dictionary.AddIfNotExist("data-html", "true");
            }
            else if (html.HasValue)
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
