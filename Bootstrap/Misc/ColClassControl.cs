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

            this.widthLg = width;

            return this;
        }

        public ColClassControl WidthMd(int? width)
        {
            Contract.Requires<ArgumentOutOfRangeException>(width == null || (width > 0 && width <= 12));
            Contract.Ensures(Contract.Result<ColClassControl>() != null);

            this.widthMd = width;

            return this;
        }

        public ColClassControl WidthSm(int? width)
        {
            Contract.Requires<ArgumentOutOfRangeException>(width == null || (width > 0 && width <= 12));
            Contract.Ensures(Contract.Result<ColClassControl>() != null);

            this.widthSm = width;

            return this;
        }

        public ColClassControl WidthXs(int? width)
        {
            Contract.Requires<ArgumentOutOfRangeException>(width == null || (width > 0 && width <= 12));
            Contract.Ensures(Contract.Result<ColClassControl>() != null);

            this.widthXs = width;

            return this;
        }

        public ColClassControl OffsetLg(int? offset)
        {
            Contract.Requires<ArgumentOutOfRangeException>(offset == null || (offset > 0 && offset < 12));
            Contract.Ensures(Contract.Result<ColClassControl>() != null);

            this.offsetLg = offset;

            return this;
        }

        public ColClassControl OffsetMd(int? offset)
        {
            Contract.Requires<ArgumentOutOfRangeException>(offset == null || (offset > 0 && offset < 12));
            Contract.Ensures(Contract.Result<ColClassControl>() != null);

            this.offsetMd = offset;

            return this;
        }

        public ColClassControl OffsetSm(int? offset)
        {
            Contract.Requires<ArgumentOutOfRangeException>(offset == null || (offset > 0 && offset < 12));
            Contract.Ensures(Contract.Result<ColClassControl>() != null);

            this.offsetSm = offset;

            return this;
        }

        public ColClassControl OffsetXs(int? offset)
        {
            Contract.Requires<ArgumentOutOfRangeException>(offset == null || (offset > 0 && offset < 12));
            Contract.Ensures(Contract.Result<ColClassControl>() != null);

            this.offsetXs = offset;

            return this;
        }

        public ColClassControl PushLg(int? push)
        {
            Contract.Requires<ArgumentOutOfRangeException>(push == null || (push > 0 && push <= 12));
            Contract.Ensures(Contract.Result<ColClassControl>() != null);

            this.pushLg = push;

            return this;
        }

        public ColClassControl PushMd(int? push)
        {
            Contract.Requires<ArgumentOutOfRangeException>(push == null || (push > 0 && push <= 12));
            Contract.Ensures(Contract.Result<ColClassControl>() != null);

            this.pushMd = push;

            return this;
        }

        public ColClassControl PushSm(int? push)
        {
            Contract.Requires<ArgumentOutOfRangeException>(push == null || (push > 0 && push <= 12));
            Contract.Ensures(Contract.Result<ColClassControl>() != null);

            this.pushSm = push;

            return this;
        }

        public ColClassControl PushXs(int? push)
        {
            Contract.Requires<ArgumentOutOfRangeException>(push == null || (push > 0 && push <= 12));
            Contract.Ensures(Contract.Result<ColClassControl>() != null);

            this.pushXs = push;

            return this;
        }

        public ColClassControl PullLg(int? pull)
        {
            Contract.Requires<ArgumentOutOfRangeException>(pull == null || (pull > 0 && pull <= 12));
            Contract.Ensures(Contract.Result<ColClassControl>() != null);

            this.pullLg = pull;

            return this;
        }

        public ColClassControl PullMd(int? pull)
        {
            Contract.Requires<ArgumentOutOfRangeException>(pull == null || (pull > 0 && pull <= 12));
            Contract.Ensures(Contract.Result<ColClassControl>() != null);

            this.pullMd = pull;

            return this;
        }

        public ColClassControl PullSm(int? pull)
        {
            Contract.Requires<ArgumentOutOfRangeException>(pull == null || (pull > 0 && pull <= 12));
            Contract.Ensures(Contract.Result<ColClassControl>() != null);

            this.pullSm = pull;

            return this;
        }

        public ColClassControl PullXs(int? pull)
        {
            Contract.Requires<ArgumentOutOfRangeException>(pull == null || (pull > 0 && pull <= 12));
            Contract.Ensures(Contract.Result<ColClassControl>() != null);

            this.pullXs = pull;

            return this;
        }

        public ColClassControl HiddenLg()
        {
            Contract.Ensures(Contract.Result<ColClassControl>() != null);

            this.hiddenLg = true;

            return this;
        }

        public ColClassControl HiddenMd()
        {
            Contract.Ensures(Contract.Result<ColClassControl>() != null);

            this.hiddenMd = true;

            return this;
        }

        public ColClassControl HiddenSm()
        {
            Contract.Ensures(Contract.Result<ColClassControl>() != null);

            this.hiddenSm = true;

            return this;
        }

        public ColClassControl HiddenXs()
        {
            Contract.Ensures(Contract.Result<ColClassControl>() != null);

            this.hiddenXs = true;

            return this;
        }

        public ColClassControl VisibleLg()
        {
            Contract.Ensures(Contract.Result<ColClassControl>() != null);

            this.visibleLg = true;

            return this;
        }

        public ColClassControl VisibleMd()
        {
            Contract.Ensures(Contract.Result<ColClassControl>() != null);

            this.visibleMd = true;

            return this;
        }

        public ColClassControl VisibleSm()
        {
            Contract.Ensures(Contract.Result<ColClassControl>() != null);

            this.visibleSm = true;

            return this;
        }

        public ColClassControl VisibleXs()
        {
            Contract.Ensures(Contract.Result<ColClassControl>() != null);

            this.visibleXs = true;

            return this;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
		public string ToHtmlString()
		{
            Contract.Ensures(!Contract.Result<string>().IsNullOrWhiteSpace());

            StringBuilder cssClass = new StringBuilder();

			cssClass.Append(Helpers.CssColClassWidth(this.widthXs, this.widthSm, this.widthMd, this.widthLg));
            cssClass.Append(Helpers.CssColClassOffset(this.offsetXs, this.offsetSm, this.offsetMd, this.offsetLg));
            cssClass.Append(Helpers.CssColClassPush(this.pushXs, this.pushSm, this.pushMd, this.pushLg));
            cssClass.Append(Helpers.CssColClassPull(this.pullXs, this.pullSm, this.pullMd, this.pullLg));
            cssClass.Append(Helpers.CssColClassHidden(this.hiddenXs, this.hiddenSm, this.hiddenMd, this.hiddenLg));
            cssClass.Append(Helpers.CssColClassVisible(this.visibleXs, this.visibleSm, this.visibleMd, this.visibleLg));

            return cssClass.ToString();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public override string ToString()
		{
			return this.ToHtmlString();
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