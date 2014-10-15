using HyperSlackers.Bootstrap.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HyperSlackers.Bootstrap.Extensions;

namespace HyperSlackers.Bootstrap
{
    public class Table : HtmlElement<Table>
    {
        internal string caption;
        internal bool isResponsive;
        internal bool isHeaderTagOpen;
        internal bool wasHeaderTagRendered;
        internal bool isBodyTagOpen;
        internal bool wasBodyTagRendered;
        internal bool isFooterTagOpen;
        internal bool wasFooterTagRendered;
        internal Panel panel;
        internal string panelTitle;

        public Table()
            : base("table")
        {
            base.AddClass("table");
        }

        public Table Bordered()
        {
            Contract.Ensures(Contract.Result<Table>() != null);

            base.AddClass("table-bordered");

            return this;
        }

        public Table Caption(string caption)
        {
            Contract.Requires<ArgumentException>(!caption.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<Table>() != null);

            this.caption = caption;

            return this;
        }

        public Table Condensed()
        {
            Contract.Ensures(Contract.Result<Table>() != null);

            base.AddClass("table-condensed");

            return this;
        }

        public Table Hover()
        {
            Contract.Ensures(Contract.Result<Table>() != null);

            base.AddClass("table-hover");

            return this;
        }

        public Table Responsive()
        {
            Contract.Ensures(Contract.Result<Table>() != null);

            this.isResponsive = true;

            return this;
        }

        public Table Striped()
        {
            Contract.Ensures(Contract.Result<Table>() != null);

            base.AddClass("table-striped");

            return this;
        }

        public Table WrapInPanel(string title, PanelStyle style, bool collapsible, bool collapsed = false)
        {
            Contract.Requires<ArgumentException>(!title.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<Table>() != null);

            this.panel = new Panel(this.id + "Panel").Style(style).Collapsible(collapsible).Collapsed(collapsed);
            this.panelTitle = title;

            return this;
        }

        public Table WrapInPanel(string title, PanelStyle style)
        {
            Contract.Requires<ArgumentException>(!title.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<Table>() != null);

            this.panel = new Panel(this.id + "Panel").Style(style);
            this.panelTitle = title;

            return this;
        }

        public Table WrapInPanel(string title, bool collapsible, bool collapsed = false)
        {
            Contract.Requires<ArgumentException>(!title.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<Table>() != null);

            this.panel = new Panel(this.id + "Panel").Collapsible(collapsible).Collapsed(collapsed);
            this.panelTitle = title;

            return this;
        }

        public Table WrapInPanel(string title)
        {
            Contract.Requires<ArgumentException>(!title.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<Table>() != null);

            this.panel = new Panel(this.id + "Panel");
            this.panelTitle = title;

            return this;
        }

        internal override string StartTag
        {
            get
            {
                StringBuilder pre = new StringBuilder();

                if (this.panel != null)
                {
                    this.panel.Class(Helpers.GetCssClass(this.panel.style));
                    pre.Append(this.panel.StartTag);

                    if (this.panel.collapsible)
                    {
                        pre.Append("<div class=\"panel-heading{1}\" data-toggle=\"collapse\" data-target=\"{0}\" style=\"cursor:pointer;\">".FormatWith("#" + this.panel.id + "Collapse", this.panel.collapsed ? " collapsed" : string.Empty));
                    }
                    else
                    {
                        pre.Append("<div class=\"panel-heading\">");
                    }

                    pre.Append("<h4 class=\"panel-title{1}\">{0}</h4>".FormatWith(this.panelTitle, this.panel.collapsible ? " accordion-toggle" : string.Empty));
                    pre.Append("</div>");

                    if (this.panel.collapsible)
                    {
                        pre.Append("<div id=\"{0}Collapse\" class=\"panel-collapse collapse{1}\">".FormatWith(this.panel.id, this.panel.collapsed ? string.Empty : " in"));
                    }

                    pre.Append("<div class=\"panel-body\">");
                }

                if (this.isResponsive)
                {
                    pre.Append("<div class=\"table-responsive\">");
                }

                return pre.ToString() + base.StartTag;
            }
        }

        internal override string EndTag
        {
            get
            {
                StringBuilder post = new StringBuilder();

                if (this.isResponsive)
                {
                    post.Append("</div>");
                }

                if (this.panel != null)
                {
                    post.Append("</div>"); // panel body

                    if (this.panel.collapsible)
                    {
                        post.Append("</div>"); // collapse panel
                    }

                    post.Append("</div>"); // panel
                }

                return base.EndTag + post.ToString();
            }
        }
    }
}