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
            AddOrReplaceHtmlAttribute("tabindex", "-1");
            AddClass("modal fade");
		}

        public Modal(string id)
            : base("div")
        {
            Contract.Requires<ArgumentException>(!id.IsNullOrWhiteSpace());

            AddOrReplaceHtmlAttribute("tabindex", "-1");
            AddClass("modal fade");
            this.id = id;
            AddOrReplaceHtmlAttribute("id", this.id);
        }

        public Modal BackdropOff()
		{
            Contract.Ensures(Contract.Result<Modal>() != null);

            AddOrReplaceHtmlAttribute("data-backdrop", "false");

			return this;
        }

        /// <summary>
        /// Backdrop will not close the modal when clicked.
        /// </summary>
        /// <returns></returns>
        public Modal BackdropStatic()
        {
            Contract.Ensures(Contract.Result<Modal>() != null);

            AddOrReplaceHtmlAttribute("data-backdrop", "static");

            return this;
        }

        public Modal Closeable(bool closable = true)
		{
            Contract.Ensures(Contract.Result<Modal>() != null);

            closeable = closable;

			return this;
		}

		public Modal FadeOff()
		{
            Contract.Ensures(Contract.Result<Modal>() != null);

            RemoveClass("fade");

			return this;
		}

        /// <summary>
        /// Modal will not close when the escape key is pressed.
        /// </summary>
        /// <returns></returns>
        public Modal KeyboardOff()
		{
            Contract.Ensures(Contract.Result<Modal>() != null);

            AddOrReplaceHtmlAttribute("data-keyboard", "false");

			return this;
		}

        /// <summary>
        /// Deprecated! loads remote content (one time) via jQuery's load method.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns></returns>
        public Modal Remote(string path)
		{
            Contract.Requires<ArgumentException>(!path.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<Modal>() != null);

            AddOrReplaceHtmlAttribute("data-remote", path);

			return this;
		}

        /// <summary>
        /// Modal will not show when initialized.
        /// </summary>
        /// <returns></returns>
        public Modal ShowOff()
		{
            Contract.Ensures(Contract.Result<Modal>() != null);

            AddOrReplaceHtmlAttribute("data-show", "false");

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

            AddOrReplaceHtmlAttribute("reload-page", "true");

            return this;
        }

        public Modal ClearContentOnClose()
        {
            Contract.Ensures(Contract.Result<Modal>() != null);

            AddOrReplaceHtmlAttribute("data-refresh", "true");

            return this;
        }
	}
}