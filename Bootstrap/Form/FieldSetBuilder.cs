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

            textWriter.Write(element.StartTag);

            if (!element.legend.IsNullOrWhiteSpace())
            {
                textWriter.Write("<legend{0}>{1}</legend>".FormatWith((element.disabled ? " disabled" : ""), element.legend));
            }
        }

        internal FieldSetBuilder(AjaxHelper<TModel> ajax, FieldSet fieldSet)
            : base(ajax, fieldSet)
        {
            Contract.Requires<ArgumentNullException>(ajax != null, "ajax");
            Contract.Requires<ArgumentNullException>(fieldSet != null, "fieldSet");

            textWriter.Write(element.StartTag);

            if (!element.legend.IsNullOrWhiteSpace())
            {
                textWriter.Write("<legend{0}>{1}</legend>".FormatWith((element.disabled ? " disabled" : ""), element.legend));
            }
        }
    }
}
