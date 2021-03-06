using System;
using System.ComponentModel;
using System.IO;
using System.Web;
using System.Web.Mvc;
using HyperSlackers.Bootstrap;
using System.Diagnostics.Contracts;
using System.Text;
using HyperSlackers.Bootstrap.Core;
using HyperSlackers.Bootstrap.Extensions;

namespace HyperSlackers.Bootstrap.Controls
{
	public class ModalBuilder<TModel> : DisposableHtmlElement<TModel, Modal>
	{
        private bool disposed = false;

		internal ModalBuilder(HtmlHelper<TModel> html, Modal modal, bool doNotRender = false) 
            : base(html, modal)
		{
            Contract.Requires<ArgumentNullException>(html != null, "html");
            Contract.Requires<ArgumentNullException>(modal != null, "modal");

            this.doNotRender = doNotRender;
            if (!this.doNotRender)
            {
                this.html.ViewContext.HttpContext.Items[ContextItemKey.HS_Bootstrap_Current_Modal.ToString()] = element;

                textWriter.Write(element.StartTag);

                string modalSize = string.Empty;
                switch (element.size)
                {
                    case ModalSize.Large:
                        modalSize = " modal-lg";
                        break;
                    case ModalSize.Small:
                        modalSize = " modal-sm";
                        break;
                    case ModalSize.Default:
                    default:
                        break;
                }

                textWriter.Write("<div class=\"modal-dialog{0}\"><div class=\"modal-content\">".FormatWith(modalSize));
            }
		}

        public ModalBodyBuilder BeginBody()
		{
            Contract.Ensures(Contract.Result<ModalBodyBuilder>() != null);

            return new ModalBodyBuilder(textWriter);
		}

        public ModalFooterBuilder BeginFooter()
		{
            Contract.Ensures(Contract.Result<ModalFooterBuilder>() != null);

            return new ModalFooterBuilder(textWriter);
		}

        public ModalHeaderBuilder BeginHeader()
		{
            Contract.Ensures(Contract.Result<ModalHeaderBuilder>() != null);

            return new ModalHeaderBuilder(textWriter, element.closeable);
		}

		public IHtmlString Header(string title)
		{
            StringBuilder header = new StringBuilder();

            header.Append("<div class=\"modal-header\">");
            if (element.closeable)
            {
                header.Append("<button type=\"button\" class=\"close\" data-dismiss=\"modal\" aria-hidden=\"true\">&times;</button>");
            }
            header.Append("<h4 class=\"modal-title\">{0}</h4>".FormatWith(title));
            header.Append("</div>");

            return MvcHtmlString.Create(header.ToString());
		}

        protected override void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    if (!doNotRender)
                    {
                        textWriter.Write("</div></div>");

                        html.ViewContext.HttpContext.Items[ContextItemKey.HS_Bootstrap_Current_Modal.ToString()] = null;
                    }

                    disposed = true;
                }
            }

            base.Dispose(disposing);
        }
	}
}