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
            doNotRender = html.ViewContext.RequestContext.HttpContext.Request.RequestType.ToLowerInvariant() == "post";
            if (!doNotRender)
            {
                textWriter.Write("<section id=\"{0}\">".FormatWith(id));
            }
		}

        public string GetId()
        {
            Contract.Ensures(!Contract.Result<string>().IsNullOrWhiteSpace());

            return id;
        }

        protected override void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    if (!doNotRender)
                    {
                        textWriter.Write("</section>");
                    }

                    disposed = true;
                }
            }

            base.Dispose(true);
        }
	}
}