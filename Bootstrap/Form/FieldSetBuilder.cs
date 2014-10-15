using HyperSlackers.Bootstrap.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using HyperSlackers.Bootstrap.Extensions;

namespace HyperSlackers.Bootstrap
{
    public class FieldSetBuilder<TModel> : DisposableHtmlElement<TModel, FieldSet>
    {
        internal FieldSetBuilder(HtmlHelper<TModel> html, FieldSet fieldSet)
            : base(html, fieldSet)
        {
            Contract.Requires<ArgumentNullException>(html != null, "html");
            Contract.Requires<ArgumentNullException>(fieldSet != null, "fieldSet");

            this.textWriter.Write(this.element.StartTag);

            if (!this.element.legend.IsNullOrWhiteSpace())
            {
                this.textWriter.Write("<legend>{0}</legend>".FormatWith(this.element.legend));
            }
        }

        internal FieldSetBuilder(AjaxHelper<TModel> ajax, FieldSet fieldSet)
            : base(ajax, fieldSet)
        {
            Contract.Requires<ArgumentNullException>(ajax != null, "ajax");
            Contract.Requires<ArgumentNullException>(fieldSet != null, "fieldSet");

            this.textWriter.Write(this.element.StartTag);

            if (!this.element.legend.IsNullOrWhiteSpace())
            {
                this.textWriter.Write("<legend>{0}</legend>".FormatWith(this.element.legend));
            }
        }
    }
}
