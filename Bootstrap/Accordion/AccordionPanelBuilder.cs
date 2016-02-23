using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Mvc;
using System.Diagnostics.Contracts;
using System.ComponentModel;
using HyperSlackers.Bootstrap.Core;
using HyperSlackers.Bootstrap.Extensions;

namespace HyperSlackers.Bootstrap.Controls
{
    public class AccordionPanelBuilder<TModel> : DisposableHtmlElement
	{
        private bool disposed = false;

        internal AccordionPanelBuilder(TextWriter textWriter, AccordionPanel panel)
            : base(textWriter)
        {
            Contract.Requires<ArgumentNullException>(textWriter != null, "textWriter");
            Contract.Requires<ArgumentNullException>(panel != null, "panel");

            this.textWriter.Write("<div class=\"panel {0}\">".FormatWith(Helpers.GetCssClass(panel.style.Value)));

            TagBuilder panelTagBuilder = new TagBuilder("div");
            panelTagBuilder.AddCssClass("panel-heading");
            if (!panel.isActivePanel ?? false)
            {
                panelTagBuilder.AddCssClass("collapsed");
            }
            //panelTagBuilder.AddCssClass("accordion-toggle");
            panelTagBuilder.MergeAttribute("data-toggle", "collapse");
            panelTagBuilder.MergeAttribute("data-parent", "#" + panel.parentAccordionId);
            panelTagBuilder.MergeAttribute("data-target", "#" + panel.panelId);
            panelTagBuilder.MergeAttribute("style", "cursor:pointer;");

            TagBuilder linkTagBuilder = new TagBuilder("a");
            linkTagBuilder.Attributes.Add("role", "button");
            linkTagBuilder.Attributes.Add("href", "#" + panel.panelId);
            linkTagBuilder.AddCssClass("accordion-toggle");
            linkTagBuilder.InnerHtml = panel.title;
            linkTagBuilder.MergeAttribute("data-toggle", "collapse");
            linkTagBuilder.MergeAttribute("data-parent", "#" + panel.parentAccordionId);

            TagBuilder titleTagBuilder = new TagBuilder("h4");
            titleTagBuilder.AddCssClass("panel-title");
            titleTagBuilder.InnerHtml = linkTagBuilder.ToString();

            panelTagBuilder.InnerHtml = titleTagBuilder.ToString();

            this.textWriter.Write(panelTagBuilder.ToString());

            TagBuilder collapseTagBuilder = new TagBuilder("div");
            collapseTagBuilder.AddCssClass("panel-collapse collapse");
            if (panel.isActivePanel.Value)
            {
                collapseTagBuilder.AddCssClass("in");
            }
            collapseTagBuilder.MergeAttribute("id", panel.panelId);

            this.textWriter.Write(collapseTagBuilder.ToString(TagRenderMode.StartTag));
            this.textWriter.Write("<div class=\"panel-body\">");
        }

        protected override void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    textWriter.Write("</div></div></div>");

                    disposed = true;
                }
            }

            base.Dispose(disposing);
        }
	}
}