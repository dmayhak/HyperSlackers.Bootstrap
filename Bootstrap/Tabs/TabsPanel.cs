using HyperSlackers.Bootstrap.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.IO;
using System.Web.Mvc;
using HyperSlackers.Bootstrap.Extensions;

namespace HyperSlackers.Bootstrap.Controls
{
	public class TabsPanel : DisposableHtmlElement
	{
		internal readonly string tag;
        private bool disposed = false;

		internal TabsPanel(TextWriter writer, string tag, string id, bool isActive = false)
            : base(writer)
		{
            Contract.Requires<ArgumentNullException>(writer != null, "writer");
            Contract.Requires<ArgumentException>(!tag.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentException>(!id.IsNullOrWhiteSpace());

            this.tag = tag;

            TagBuilder tagBuilder = new TagBuilder(this.tag);
            tagBuilder.Attributes.Add("id", id);
            tagBuilder.AddCssClass("tab-pane");
            if (isActive)
            {
                tagBuilder.AddCssClass("active");
            }

            textWriter.Write(tagBuilder.ToString(TagRenderMode.StartTag));
		}

        protected override void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    textWriter.Write("</{0}>", tag);

                    disposed = true;
                }
            }

            base.Dispose(disposing);
        }
    }
}