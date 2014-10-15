using HyperSlackers.Bootstrap.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using HyperSlackers.Bootstrap.Extensions;

namespace HyperSlackers.Bootstrap.Controls
{
    public class SectionBuilder<TModel> : DisposableHtmlElement
	{
        private string id;
        private bool doNotRender;
        private bool disposed = false;

        internal SectionBuilder(HtmlHelper<TModel> html, string id)
            : base(html.ViewContext.Writer)
		{
            Contract.Requires<ArgumentNullException>(html != null, "html");
            Contract.Requires<ArgumentException>(!id.IsNullOrWhiteSpace());

            this.id = id;
            this.doNotRender = html.ViewContext.RequestContext.HttpContext.Request.RequestType.ToLowerInvariant() == "post";
            if (!this.doNotRender)
            {
                this.textWriter.Write("<section id=\"{0}\">".FormatWith(id));
            }
		}

        public string GetId()
        {
            Contract.Ensures(!Contract.Result<string>().IsNullOrWhiteSpace());

            return this.id;
        }

        protected override void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    if (!this.doNotRender)
                    {
                        this.textWriter.Write("</section>");
                    }

                    this.disposed = true;
                }
            }

            base.Dispose(true);
        }
	}
}