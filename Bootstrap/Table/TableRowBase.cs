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
    public class TableRowBase<T> : HtmlElement<T>
        where T : TableRowBase<T>
    {
        internal TableRowBase()
            : this("tr")
        {
        }

        internal TableRowBase(string tag)
            : base(tag)
        {
        }

        public T Active()
        {
            Contract.Ensures(Contract.Result<T>() != null);

            AddClass("active");

            return (T)this;
        }

        public T Active(bool isActive = true)
        {
            Contract.Ensures(Contract.Result<T>() != null);

            if (isActive)
            {
                AddClass("active");
            }
            else
            {
                RemoveClass("active");
            }

            return (T)this;
        }

        public T Style(TableColor style)
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
    }
}