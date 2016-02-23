using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Web.Mvc;
using System.Diagnostics.Contracts;
using HyperSlackers.Bootstrap.Core;
using HyperSlackers.Bootstrap.Extensions;

namespace HyperSlackers.Bootstrap
{
    /// <summary>
    /// Represents a Bootstrap Carousel (slideshow) object
    /// </summary>
	public class Carousel : HtmlElement<Carousel>
	{
        // TODO: add width/height to carousel? or just make user deal with it?
        internal uint indicators;
        internal uint interval;
        internal Icon nextIcon = new FontAwesomeIcon(FontAwesomeIconType.ChevronRight);
        internal Icon prevIcon = new FontAwesomeIcon(FontAwesomeIconType.ChevronLeft);
        internal bool pause;
        internal bool withJs;

        /// <summary>
        /// Initializes a new instance of the <see cref="Carousel"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
		public Carousel(string id)
            : base("div")
		{
            Contract.Requires<ArgumentException>(!id.IsNullOrWhiteSpace());

			this.id = HtmlHelper.GenerateIdFromName(id);
            interval = 3500;
            AddClass("carousel slide");
            MergeHtmlAttribute("data-ride", "carousel");
            AddOrReplaceHtmlAttribute("id", this.id);
		}

        /// <summary>
        /// Sets the icon to use for the next button.
        /// </summary>
        /// <param name="icon">The icon.</param>
        /// <returns>The current Carousel object.</returns>
		public Carousel NextIcon(GlyphIconType icon)
        {
            Contract.Ensures(Contract.Result<Carousel>() != null);

            nextIcon = new GlyphIcon(icon);

            return this;
        }

        /// <summary>
        /// Sets the icon to use for the next button.
        /// </summary>
        /// <param name="icon">The icon.</param>
        /// <returns>The current Carousel object.</returns>
        public Carousel NextIcon(FontAwesomeIconType icon)
        {
            Contract.Ensures(Contract.Result<Carousel>() != null);

            nextIcon = new FontAwesomeIcon(icon);

            return this;
        }

        /// <summary>
        /// Sets the icon to use for the next button.
        /// </summary>
        /// <param name="icon">The icon.</param>
        /// <returns>
        /// The current Carousel object.
        /// </returns>
        public Carousel NextIcon(Icon icon)
        {
            Contract.Requires<ArgumentNullException>(icon != null, "icon");
            Contract.Ensures(Contract.Result<Carousel>() != null);

            nextIcon = icon;

            return this;
        }

        /// <summary>
        /// Sets the icon to use for the next button.
        /// </summary>
        /// <param name="iconCssClass">The icon CSS class.</param>
        /// <returns>
        /// The current Carousel object.
        /// </returns>
        public Carousel NextIcon(string iconCssClass)
        {
            Contract.Requires<ArgumentException>(!iconCssClass.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<Carousel>() != null);

            nextIcon = new GlyphIcon(iconCssClass);

            return this;
        }

        /// <summary>
        /// Sets the icon to use for the previous button.
        /// </summary>
        /// <param name="icon">The icon.</param>
        /// <returns>
        /// The current Carousel object.
        /// </returns>
        public Carousel PrevIcon(GlyphIconType icon)
        {
            Contract.Ensures(Contract.Result<Carousel>() != null);

            prevIcon = new GlyphIcon(icon);

            return this;
        }

        /// <summary>
        /// Sets the icon to use for the previous button.
        /// </summary>
        /// <param name="icon">The icon.</param>
        /// <returns>
        /// The current Carousel object.
        /// </returns>
        public Carousel PrevIcon(FontAwesomeIconType icon)
        {
            Contract.Ensures(Contract.Result<Carousel>() != null);

            prevIcon = new FontAwesomeIcon(icon);

            return this;
        }

        /// <summary>
        /// Sets the icon to use for the previous button.
        /// </summary>
        /// <param name="icon">The icon.</param>
        /// <returns>
        /// The current Carousel object.
        /// </returns>
        public Carousel PrevIcon(Icon icon)
        {
            Contract.Requires<ArgumentNullException>(icon != null, "icon");
            Contract.Ensures(Contract.Result<Carousel>() != null);

            prevIcon = icon;

            return this;
        }

        /// <summary>
        /// Sets the icon to use for the previous button.
        /// </summary>
        /// <param name="iconCssClass">The icon CSS class.</param>
        /// <returns>
        /// The current Carousel object.
        /// </returns>
        public Carousel PrevIcon(string iconCssClass)
        {
            Contract.Requires<ArgumentException>(!iconCssClass.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<Carousel>() != null);

            prevIcon = new GlyphIcon(iconCssClass);

            return this;
        }

        /// <summary>
        /// Removes the sliding animation from the Carousel.
        /// </summary>
        /// <returns>The current carousel object.</returns>
        public Carousel DontSlide()
		{
            Contract.Ensures(Contract.Result<Carousel>() != null);

            RemoveClass("slide");

			return this;
		}


        /// <summary>
        /// Adds the specified number of indicator icons to the bottom of the Carousel.
        /// </summary>
        /// <param name="indicators">The number of indicators to display.</param>
        /// <returns>The current carousel object.</returns>
		public Carousel Indicators(uint indicators)
		{
            Contract.Ensures(Contract.Result<Carousel>() != null);

			this.indicators = indicators;

			return this;
		}

        /// <summary>
        /// Sets the interval (in milliseconds) between slide transitions.
        /// </summary>
        /// <param name="interval">The interval.</param>
        /// <returns>The current carousel object.</returns>
		public Carousel Interval(uint interval)
		{
            Contract.Requires<ArgumentOutOfRangeException>(interval > 0);
            Contract.Ensures(Contract.Result<Carousel>() != null);

			this.interval = interval;
            AddOrReplaceHtmlAttribute("data-interval", interval.ToString());

			return this;
		}

        /// <summary>
        /// Causes the Carousel to pause on mouse hover and resume animation on mouse exit.
        /// </summary>
        /// <returns>The current carousel object.</returns>
		public Carousel Pause()
		{
            Contract.Ensures(Contract.Result<Carousel>() != null);

            pause = true;
            AddOrReplaceHtmlAttribute("data-pause", "hover");

			return this;
		}

        /// <summary>
        /// Renders javascript to begin the carousel animation.
        /// </summary>
        /// <returns>The current carousel object.</returns>
		public Carousel WithJs()
		{
            Contract.Ensures(Contract.Result<Carousel>() != null);

            withJs = true;

			return this;
		}
	}
}