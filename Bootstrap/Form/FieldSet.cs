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
    public class FieldSet : HtmlElement<FieldSet>
    {
        internal string legend;
        internal bool disabled;

        public FieldSet()
            : base("fieldset")
        {
        }

        public FieldSet Legend(string legend)
        {
            Contract.Ensures(Contract.Result<FieldSet>() != null);

            this.legend = legend;

            return this;
        }

        public FieldSet Disabled(bool disabled = true)
        {
            Contract.Ensures(Contract.Result<FieldSet>() != null);

            this.disabled = disabled;

            return this;
        }
    }
}
