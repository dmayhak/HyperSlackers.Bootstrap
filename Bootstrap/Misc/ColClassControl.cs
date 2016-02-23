using System;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Text;
using System.Web;
using HyperSlackers.Bootstrap.Extensions;

namespace HyperSlackers.Bootstrap.Controls
{
	public class ColClassControl : IHtmlString
	{
		private int? widthLg;
		private int? widthMd;
		private int? widthSm;
		private int? widthXs;
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

		public ColClassControl()
		{
		}

        public ColClassControl WidthLg(int? width)
        {
            Contract.Requires<ArgumentOutOfRangeException>(width == null || (width > 0 && width <= 12));
            Contract.Ensures(Contract.Result<ColClassControl>() != null);

            widthLg = width;

            return this;
        }

        public ColClassControl WidthMd(int? width)
        {
            Contract.Requires<ArgumentOutOfRangeException>(width == null || (width > 0 && width <= 12));
            Contract.Ensures(Contract.Result<ColClassControl>() != null);

            widthMd = width;

            return this;
        }

        public ColClassControl WidthSm(int? width)
        {
            Contract.Requires<ArgumentOutOfRangeException>(width == null || (width > 0 && width <= 12));
            Contract.Ensures(Contract.Result<ColClassControl>() != null);

            widthSm = width;

            return this;
        }

        public ColClassControl WidthXs(int? width)
        {
            Contract.Requires<ArgumentOutOfRangeException>(width == null || (width > 0 && width <= 12));
            Contract.Ensures(Contract.Result<ColClassControl>() != null);

            widthXs = width;

            return this;
        }

        public ColClassControl OffsetLg(int? offset)
        {
            Contract.Requires<ArgumentOutOfRangeException>(offset == null || (offset > 0 && offset < 12));
            Contract.Ensures(Contract.Result<ColClassControl>() != null);

            offsetLg = offset;

            return this;
        }

        public ColClassControl OffsetMd(int? offset)
        {
            Contract.Requires<ArgumentOutOfRangeException>(offset == null || (offset > 0 && offset < 12));
            Contract.Ensures(Contract.Result<ColClassControl>() != null);

            offsetMd = offset;

            return this;
        }

        public ColClassControl OffsetSm(int? offset)
        {
            Contract.Requires<ArgumentOutOfRangeException>(offset == null || (offset > 0 && offset < 12));
            Contract.Ensures(Contract.Result<ColClassControl>() != null);

            offsetSm = offset;

            return this;
        }

        public ColClassControl OffsetXs(int? offset)
        {
            Contract.Requires<ArgumentOutOfRangeException>(offset == null || (offset > 0 && offset < 12));
            Contract.Ensures(Contract.Result<ColClassControl>() != null);

            offsetXs = offset;

            return this;
        }

        public ColClassControl PushLg(int? push)
        {
            Contract.Requires<ArgumentOutOfRangeException>(push == null || (push > 0 && push <= 12));
            Contract.Ensures(Contract.Result<ColClassControl>() != null);

            pushLg = push;

            return this;
        }

        public ColClassControl PushMd(int? push)
        {
            Contract.Requires<ArgumentOutOfRangeException>(push == null || (push > 0 && push <= 12));
            Contract.Ensures(Contract.Result<ColClassControl>() != null);

            pushMd = push;

            return this;
        }

        public ColClassControl PushSm(int? push)
        {
            Contract.Requires<ArgumentOutOfRangeException>(push == null || (push > 0 && push <= 12));
            Contract.Ensures(Contract.Result<ColClassControl>() != null);

            pushSm = push;

            return this;
        }

        public ColClassControl PushXs(int? push)
        {
            Contract.Requires<ArgumentOutOfRangeException>(push == null || (push > 0 && push <= 12));
            Contract.Ensures(Contract.Result<ColClassControl>() != null);

            pushXs = push;

            return this;
        }

        public ColClassControl PullLg(int? pull)
        {
            Contract.Requires<ArgumentOutOfRangeException>(pull == null || (pull > 0 && pull <= 12));
            Contract.Ensures(Contract.Result<ColClassControl>() != null);

            pullLg = pull;

            return this;
        }

        public ColClassControl PullMd(int? pull)
        {
            Contract.Requires<ArgumentOutOfRangeException>(pull == null || (pull > 0 && pull <= 12));
            Contract.Ensures(Contract.Result<ColClassControl>() != null);

            pullMd = pull;

            return this;
        }

        public ColClassControl PullSm(int? pull)
        {
            Contract.Requires<ArgumentOutOfRangeException>(pull == null || (pull > 0 && pull <= 12));
            Contract.Ensures(Contract.Result<ColClassControl>() != null);

            pullSm = pull;

            return this;
        }

        public ColClassControl PullXs(int? pull)
        {
            Contract.Requires<ArgumentOutOfRangeException>(pull == null || (pull > 0 && pull <= 12));
            Contract.Ensures(Contract.Result<ColClassControl>() != null);

            pullXs = pull;

            return this;
        }

        public ColClassControl HiddenLg()
        {
            Contract.Ensures(Contract.Result<ColClassControl>() != null);

            hiddenLg = true;

            return this;
        }

        public ColClassControl HiddenMd()
        {
            Contract.Ensures(Contract.Result<ColClassControl>() != null);

            hiddenMd = true;

            return this;
        }

        public ColClassControl HiddenSm()
        {
            Contract.Ensures(Contract.Result<ColClassControl>() != null);

            hiddenSm = true;

            return this;
        }

        public ColClassControl HiddenXs()
        {
            Contract.Ensures(Contract.Result<ColClassControl>() != null);

            hiddenXs = true;

            return this;
        }

        public ColClassControl VisibleLg()
        {
            Contract.Ensures(Contract.Result<ColClassControl>() != null);

            visibleLg = true;

            return this;
        }

        public ColClassControl VisibleMd()
        {
            Contract.Ensures(Contract.Result<ColClassControl>() != null);

            visibleMd = true;

            return this;
        }

        public ColClassControl VisibleSm()
        {
            Contract.Ensures(Contract.Result<ColClassControl>() != null);

            visibleSm = true;

            return this;
        }

        public ColClassControl VisibleXs()
        {
            Contract.Ensures(Contract.Result<ColClassControl>() != null);

            visibleXs = true;

            return this;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
		public string ToHtmlString()
		{
            Contract.Ensures(!Contract.Result<string>().IsNullOrWhiteSpace());

            StringBuilder cssClass = new StringBuilder();

			cssClass.Append(Helpers.CssColClassWidth(widthXs, widthSm, widthMd, widthLg));
            cssClass.Append(Helpers.CssColClassOffset(offsetXs, offsetSm, offsetMd, offsetLg));
            cssClass.Append(Helpers.CssColClassPush(pushXs, pushSm, pushMd, pushLg));
            cssClass.Append(Helpers.CssColClassPull(pullXs, pullSm, pullMd, pullLg));
            cssClass.Append(Helpers.CssColClassHidden(hiddenXs, hiddenSm, hiddenMd, hiddenLg));
            cssClass.Append(Helpers.CssColClassVisible(visibleXs, visibleSm, visibleMd, visibleLg));

            return cssClass.ToString();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public override string ToString()
		{
			return ToHtmlString();
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