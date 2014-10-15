using HyperSlackers.Bootstrap.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using HyperSlackers.Bootstrap.Extensions;

namespace HyperSlackers.Bootstrap.Controls
{
    public class PanelBuilder<TModel> : DisposableHtmlElement<TModel, Panel>
	{
        private bool disposed = false;

        internal PanelBuilder(HtmlHelper<TModel> html, Panel panel) 
            : base(html, panel)
		{
            Contract.Requires<ArgumentNullException>(html != null, "html");
            Contract.Requires<ArgumentNullException>(panel != null, "panel");

            this.element.Class(Helpers.GetCssClass(this.element.style));
            if (this.element.collapsed)
            {
                this.element.Class("collapsed");
            }

            this.textWriter.Write(this.element.StartTag);
		}

        public PanelBodyBuilder BeginBody()
		{
            Contract.Ensures(Contract.Result<PanelBodyBuilder>() != null);

            return new PanelBodyBuilder(this.textWriter, this.element);
		}

        public PanelFooterBuilder BeginFooter()
		{
            Contract.Ensures(Contract.Result<PanelFooterBuilder>() != null);

            return new PanelFooterBuilder(this.textWriter);
		}

        public PanelHeaderBuilder BeginHeader()
		{
            Contract.Ensures(Contract.Result<PanelHeaderBuilder>() != null);

            return new PanelHeaderBuilder(this.textWriter, this.element);
		}

		public IHtmlString Header(string text)
		{
            StringBuilder header = new StringBuilder();

            if (this.element.collapsible)
            {
                header.Append("<div class=\"panel-heading{1}\" data-toggle=\"collapse\" data-target=\"{0}\" style=\"cursor:pointer;\">".FormatWith("#" + this.element.id + "Collapse", this.element.collapsed ? " collapsed" : string.Empty));
            }
            else
            {
                header.Append("<div class=\"panel-heading\">");
            }

            //if (this.element.collapsible)
            //{
            //    TagBuilder linkTagBuilder = new TagBuilder("a");
            //    linkTagBuilder.Attributes.Add("href", "#" + this.element.id);
            //    linkTagBuilder.InnerHtml = text;
            //    linkTagBuilder.MergeAttribute("data-toggle", "collapse");
            //    linkTagBuilder.MergeAttribute("data-target", "#" + this.element.id + "Collapse");
            //    //linkTagBuilder.MergeAttribute("data-parent", "#" + this.element.id);

            //    header.Append("<h4 class=\"panel-title\">{0}</h4>".FormatWith(linkTagBuilder.ToString()));
            //}
            //else
            //{
                header.Append("<h4 class=\"panel-title{1}\">{0}</h4>".FormatWith(text, this.element.collapsible ? " accordion-toggle" : string.Empty));
            //}

            header.Append("</div>");

            return MvcHtmlString.Create(header.ToString());
		}

        public IHtmlString Footer(string text)
        {
            StringBuilder footer = new StringBuilder();

            footer.Append("<div class=\"panel-footer\">");
            footer.Append(text);
            footer.Append("</div>");

            return MvcHtmlString.Create(footer.ToString());
        }

        protected override void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    if (this.element.collapsible)
                    {
                        this.textWriter.Write("</div>");
                    }

                    // element end tag handles in base class
                    //x this.textWriter.Write("</div>");

                    this.disposed = true;
                }
            }

            base.Dispose(disposing);
        }
	}
}