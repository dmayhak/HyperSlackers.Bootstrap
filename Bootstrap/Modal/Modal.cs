using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Diagnostics.Contracts;
using HyperSlackers.Bootstrap.Core;
using HyperSlackers.Bootstrap.Extensions;

namespace HyperSlackers.Bootstrap
{
	public class Modal : HtmlElement<Modal>
	{
        internal bool closeable = true;
        internal ModalSize size = ModalSize.Default;

		public Modal() 
            : base("div")
		{
            this.AddOrMergeHtmlAttribute("tabindex", "-1", true);
            this.AddClass("modal fade");
		}

        public Modal(string id)
            : base("div")
        {
            Contract.Requires<ArgumentException>(!id.IsNullOrWhiteSpace());

            this.AddOrMergeHtmlAttribute("tabindex", "-1", true);
            this.AddClass("modal fade");
            this.id = id;
            this.AddOrMergeHtmlAttribute("id", this.id);
        }

        public Modal BackdropOff()
		{
            Contract.Ensures(Contract.Result<Modal>() != null);

            this.AddOrMergeHtmlAttribute("data-backdrop", "false", true);

			return this;
		}

		public Modal Closeable(bool closable = true)
		{
            Contract.Ensures(Contract.Result<Modal>() != null);

            this.closeable = closable;

			return this;
		}

		public Modal FadeOff()
		{
            Contract.Ensures(Contract.Result<Modal>() != null);

			base.RemoveClass("fade");

			return this;
		}

		public Modal KeyboardOff()
		{
            Contract.Ensures(Contract.Result<Modal>() != null);

			base.AddOrMergeHtmlAttribute("data-keyboard", "false", true);

			return this;
		}

		public Modal Remote(string path)
		{
            Contract.Requires<ArgumentException>(!path.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<Modal>() != null);

			base.AddOrMergeHtmlAttribute("data-remote", path, true);

			return this;
		}

		public Modal ShowOff()
		{
            Contract.Ensures(Contract.Result<Modal>() != null);

			base.AddOrMergeHtmlAttribute("data-show", "false", true);

			return this;
		}

        public Modal Size(ModalSize size)
        {
            Contract.Ensures(Contract.Result<Modal>() != null);

            this.size = size;

            return this;
        }

        public Modal ReloadPageOnClose()
        {
            Contract.Ensures(Contract.Result<Modal>() != null);

            this.AddOrMergeHtmlAttribute("reload-page", "true", true);

            return this;
        }

        public Modal ClearContentOnClose()
        {
            Contract.Ensures(Contract.Result<Modal>() != null);

            this.AddOrMergeHtmlAttribute("data-refresh", "true", true);

            return this;
        }
	}
}