using HyperSlackers.Bootstrap.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HyperSlackers.Bootstrap.Extensions;

namespace HyperSlackers.Bootstrap
{
    /// <summary>
    /// A Bootstrap Column
    /// </summary>
    public class Column : HtmlElement<Column>
    {
        internal int? widthLg;
        internal int? widthMd;
        internal int? widthSm;
        internal int? widthXs;
        internal int? offsetLg;
        internal int? offsetMd;
        internal int? offsetSm;
        internal int? offsetXs;
        internal int? pushLg;
        internal int? pushMd;
        internal int? pushSm;
        internal int? pushXs;
        internal int? pullLg;
        internal int? pullMd;
        internal int? pullSm;
        internal int? pullXs;
        internal bool hiddenLg;
        internal bool hiddenMd;
        internal bool hiddenSm;
        internal bool hiddenXs;
        internal bool visibleLg;
        internal bool visibleMd;
        internal bool visibleSm;
        internal bool visibleXs;
        internal bool clearfixLg;
        internal bool clearfixMd;
        internal bool clearfixSm;
        internal bool clearfixXs;
        internal ColumnVisibilityType visibilityTypeLg;
        internal ColumnVisibilityType visibilityTypeMd;
        internal ColumnVisibilityType visibilityTypeSm;
        internal ColumnVisibilityType visibilityTypeXs;
        // TODO: hidden/visible for print

        /// <summary>
        /// Initializes a new instance of the <see cref="Column"/> class.
        /// </summary>
        public Column()
            : base("div")
        {
        }

        /// <summary>
        /// Sets the column width for large screens.
        /// </summary>
        /// <param name="width">The width.</param>
        /// <returns></returns>
        public Column WidthLg(int? width)
        {
            Contract.Requires<ArgumentOutOfRangeException>(width == null || (width > 0 && width <= 12));
            Contract.Ensures(Contract.Result<Column>() != null);

            widthLg = width;

            return this;
        }

        /// <summary>
        /// Sets the column width for medium screens.
        /// </summary>
        /// <param name="width">The width.</param>
        /// <returns></returns>
        public Column WidthMd(int? width)
        {
            Contract.Requires<ArgumentOutOfRangeException>(width == null || (width > 0 && width <= 12));
            Contract.Ensures(Contract.Result<Column>() != null);

            widthMd = width;

            return this;
        }

        /// <summary>
        /// Sets the column width for small screens.
        /// </summary>
        /// <param name="width">The width.</param>
        /// <returns></returns>
        public Column WidthSm(int? width)
        {
            Contract.Requires<ArgumentOutOfRangeException>(width == null || (width > 0 && width <= 12));
            Contract.Ensures(Contract.Result<Column>() != null);

            widthSm = width;

            return this;
        }

        /// <summary>
        /// Sets the column width for extra-small screens.
        /// </summary>
        /// <param name="width">The width.</param>
        /// <returns></returns>
        public Column WidthXs(int? width)
        {
            Contract.Requires<ArgumentOutOfRangeException>(width == null || (width > 0 && width <= 12));
            Contract.Ensures(Contract.Result<Column>() != null);

            widthXs = width;

            return this;
        }

        /// <summary>
        /// Sets the column offset for large screens.
        /// </summary>
        /// <param name="offset">The offset.</param>
        /// <returns></returns>
        public Column OffsetLg(int? offset)
        {
            Contract.Requires<ArgumentOutOfRangeException>(offset == null || (offset > 0 && offset < 12));
            Contract.Ensures(Contract.Result<Column>() != null);

            offsetLg = offset;

            return this;
        }

        /// <summary>
        /// Sets the column offset for medium screens.
        /// </summary>
        /// <param name="offset">The offset.</param>
        /// <returns></returns>
        public Column OffsetMd(int? offset)
        {
            Contract.Requires<ArgumentOutOfRangeException>(offset == null || (offset > 0 && offset < 12));
            Contract.Ensures(Contract.Result<Column>() != null);

            offsetMd = offset;

            return this;
        }

        /// <summary>
        /// Sets the column offset for small screens.
        /// </summary>
        /// <param name="offset">The offset.</param>
        /// <returns></returns>
        public Column OffsetSm(int? offset)
        {
            Contract.Requires<ArgumentOutOfRangeException>(offset == null || (offset > 0 && offset < 12));
            Contract.Ensures(Contract.Result<Column>() != null);

            offsetSm = offset;

            return this;
        }

        /// <summary>
        /// Sets the column offset for extra-small screens.
        /// </summary>
        /// <param name="offset">The offset.</param>
        /// <returns></returns>
        public Column OffsetXs(int? offset)
        {
            Contract.Requires<ArgumentOutOfRangeException>(offset == null || (offset > 0 && offset < 12));
            Contract.Ensures(Contract.Result<Column>() != null);

            offsetXs = offset;

            return this;
        }

        /// <summary>
        /// Pushes the column right on large displays.
        /// </summary>
        /// <param name="push">The push.</param>
        /// <returns></returns>
        public Column PushLg(int? push)
        {
            Contract.Requires<ArgumentOutOfRangeException>(push == null || (push > 0 && push <= 12));
            Contract.Ensures(Contract.Result<Column>() != null);

            pushLg = push;

            return this;
        }

        /// <summary>
        /// Pushes the column right on medium displays.
        /// </summary>
        /// <param name="push">The push.</param>
        /// <returns></returns>
        public Column PushMd(int? push)
        {
            Contract.Requires<ArgumentOutOfRangeException>(push == null || (push > 0 && push <= 12));
            Contract.Ensures(Contract.Result<Column>() != null);

            pushMd = push;

            return this;
        }

        /// <summary>
        /// Pushes the column right on small displays.
        /// </summary>
        /// <param name="push">The push.</param>
        /// <returns></returns>
        public Column PushSm(int? push)
        {
            Contract.Requires<ArgumentOutOfRangeException>(push == null || (push > 0 && push <= 12));
            Contract.Ensures(Contract.Result<Column>() != null);

            pushSm = push;

            return this;
        }

        /// <summary>
        /// Pushes the column right on extra-small displays.
        /// </summary>
        /// <param name="push">The push.</param>
        /// <returns></returns>
        public Column PushXs(int? push)
        {
            Contract.Requires<ArgumentOutOfRangeException>(push == null || (push > 0 && push <= 12));
            Contract.Ensures(Contract.Result<Column>() != null);

            pushXs = push;

            return this;
        }

        /// <summary>
        /// Pulls the column left on large displays.
        /// </summary>
        /// <param name="pull">The pull.</param>
        /// <returns></returns>
        public Column PullLg(int? pull)
        {
            Contract.Requires<ArgumentOutOfRangeException>(pull == null || (pull > 0 && pull <= 12));
            Contract.Ensures(Contract.Result<Column>() != null);

            pullLg = pull;

            return this;
        }

        /// <summary>
        /// Pulls the column left on medium displays.
        /// </summary>
        /// <param name="pull">The pull.</param>
        /// <returns></returns>
        public Column PullMd(int? pull)
        {
            Contract.Requires<ArgumentOutOfRangeException>(pull == null || (pull > 0 && pull <= 12));
            Contract.Ensures(Contract.Result<Column>() != null);

            pullMd = pull;

            return this;
        }

        /// <summary>
        /// Pulls the column left on small displays.
        /// </summary>
        /// <param name="pull">The pull.</param>
        /// <returns></returns>
        public Column PullSm(int? pull)
        {
            Contract.Requires<ArgumentOutOfRangeException>(pull == null || (pull > 0 && pull <= 12));
            Contract.Ensures(Contract.Result<Column>() != null);

            pullSm = pull;

            return this;
        }

        /// <summary>
        /// Pulls the column left on extra-small displays.
        /// </summary>
        /// <param name="pull">The pull.</param>
        /// <returns></returns>
        public Column PullXs(int? pull)
        {
            Contract.Requires<ArgumentOutOfRangeException>(pull == null || (pull > 0 && pull <= 12));
            Contract.Ensures(Contract.Result<Column>() != null);

            pullXs = pull;

            return this;
        }

        /// <summary>
        /// Hides the column on large displays.
        /// </summary>
        /// <returns></returns>
        public Column HiddenLg()
        {
            Contract.Ensures(Contract.Result<Column>() != null);

            hiddenLg = true;

            return this;
        }

        /// <summary>
        /// Hides the column on medium displays.
        /// </summary>
        /// <returns></returns>
        public Column HiddenMd()
        {
            Contract.Ensures(Contract.Result<Column>() != null);

            hiddenMd = true;

            return this;
        }

        /// <summary>
        /// Hides the column on small displays.
        /// </summary>
        /// <returns></returns>
        public Column HiddenSm()
        {
            Contract.Ensures(Contract.Result<Column>() != null);

            hiddenSm = true;

            return this;
        }

        /// <summary>
        /// Hides the column on extra-small displays.
        /// </summary>
        /// <returns></returns>
        public Column HiddenXs()
        {
            Contract.Ensures(Contract.Result<Column>() != null);

            hiddenXs = true;

            return this;
        }

        /// <summary>
        /// Makes column visible on large screens.
        /// </summary>
        /// <param name="displayType">The display type.</param>
        /// <returns></returns>
        public Column VisibleLg(ColumnVisibilityType displayType = ColumnVisibilityType.Block)
        {
            Contract.Ensures(Contract.Result<Column>() != null);

            visibleLg = true;
            visibilityTypeLg = displayType;

            return this;
        }

        /// <summary>
        /// Makes column visible on medium screens.
        /// </summary>
        /// <returns></returns>
        public Column VisibleMd(ColumnVisibilityType displayType = ColumnVisibilityType.Block)
        {
            Contract.Ensures(Contract.Result<Column>() != null);

            visibleMd = true;
            visibilityTypeMd = displayType;

            return this;
        }

        /// <summary>
        /// Makes column visible on small screens.
        /// </summary>
        /// <returns></returns>
        public Column VisibleSm(ColumnVisibilityType displayType = ColumnVisibilityType.Block)
        {
            Contract.Ensures(Contract.Result<Column>() != null);

            visibleSm = true;
            visibilityTypeSm = displayType;

            return this;
        }

        /// <summary>
        /// Makes column visible on extra-small screens.
        /// </summary>
        /// <returns></returns>
        public Column VisibleXs(ColumnVisibilityType displayType = ColumnVisibilityType.Block)
        {
            Contract.Ensures(Contract.Result<Column>() != null);

            visibleXs = true;
            visibilityTypeXs = displayType;

            return this;
        }

        /// <summary>
        /// Adds a "clearfix" div after the column on large displays.
        /// </summary>
        /// <returns></returns>
        public Column ClearfixLg()
        {
            Contract.Ensures(Contract.Result<Column>() != null);

            clearfixLg = true;

            return this;
        }

        /// <summary>
        /// Adds a "clearfix" div after the column on medium displays.
        /// </summary>
        /// <returns></returns>
        public Column ClearfixMd()
        {
            Contract.Ensures(Contract.Result<Column>() != null);

            clearfixMd = true;

            return this;
        }

        /// <summary>
        /// Adds a "clearfix" div after the column on small displays.
        /// </summary>
        /// <returns></returns>
        public Column ClearfixSm()
        {
            Contract.Ensures(Contract.Result<Column>() != null);

            clearfixSm = true;

            return this;
        }

        /// <summary>
        /// Adds a "clearfix" div after the column on extra-small displays.
        /// </summary>
        /// <returns></returns>
        public Column ClearfixXs()
        {
            Contract.Ensures(Contract.Result<Column>() != null);

            clearfixXs = true;

            return this;
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToString()
        {
            return base.ToString();
        }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Gets the <see cref="T:System.Type" /> of the current instance.
        /// </summary>
        /// <returns>
        /// The exact runtime type of the current instance.
        /// </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new Type GetType()
        {
            return base.GetType();
        }
    }
}
