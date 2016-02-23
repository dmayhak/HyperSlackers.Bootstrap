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
    public class TableCellBase<T> : HtmlElement<T>
        where T : TableCellBase<T>
    {
        public TableCellBase()
            : this("td")
        {
        }

        public TableCellBase(string tag)
            : base(tag)
        {
        }

        public virtual T ColSpan(int span)
        {
            Contract.Requires<ArgumentOutOfRangeException>(span > 0);
            Contract.Ensures(Contract.Result<T>() != null);

            if (span == 1)
            {
                RemoveHtmlAttribute("colspan");
            }

            AddOrReplaceHtmlAttribute("colspan", span.ToString());

            return (T)this;
        }

        public virtual T Style(TableColor style)
        {
            Contract.Ensures(Contract.Result<T>() != null);

            if (style == TableColor.None)
            {
                // remove all the TableColor styles
                foreach (TableColor item in Enum.GetValues(typeof(TableColor)))
                {
                    if (item != TableColor.None && item != TableColor.Default)
                    {
                        RemoveClass(Helpers.GetCssClass(item));
                    }
                }
            }
            else if (style != TableColor.Default)
            {
                AddClass(Helpers.GetCssClass(style));
            }

            return (T)this;
        }

        public virtual T Align(TextAlign align)
        {
            Contract.Ensures(Contract.Result<T>() != null);

            if (align == TextAlign.None)
            {
                base.RemoveHtmlAttribute("align");
            }
            else
            {
                AddOrReplaceHtmlAttribute("align", align.ToString().ToLowerInvariant());
            }

            return (T)this;
        }

        public virtual T Width(TableCellWidth width)
        {
            Contract.Ensures(Contract.Result<T>() != null);

            AddClass(Helpers.GetCssClass(width));

            return (T)this;
        }

        public virtual T Width(string width)
        {
            Contract.Requires<ArgumentNullException>(width != null, "width");
            Contract.Requires<ArgumentException>(!width.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<T>() != null);

            HtmlAttribute("width", width);

            return (T)this;
        }
    }
}