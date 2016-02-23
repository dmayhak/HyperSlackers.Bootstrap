using HyperSlackers.Bootstrap.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using HyperSlackers.Bootstrap.Extensions;

namespace HyperSlackers.Bootstrap.Controls
{
    public class EditorControl<TModel> : InputControlBase<EditorControl<TModel>, TModel>
    {
        internal string templateName;
        internal string expression;
        internal object additionalViewData;

        internal EditorControl(HtmlHelper<TModel> html, string expression, ModelMetadata metadata)
            : base(html, expression, metadata)
		{
            Contract.Requires<ArgumentNullException>(html != null, "html");
            Contract.Requires<ArgumentNullException>(expression != null, "expression");
            Contract.Requires<ArgumentException>(!expression.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentNullException>(metadata != null, "metadata");

            this.expression = expression;
		}

        public EditorControl<TModel> AdditionalViewData(object additionalViewData)
        {
            Contract.Requires<ArgumentNullException>(additionalViewData != null, "additionalViewData");
            Contract.Ensures(Contract.Result<EditorControl<TModel>>() != null);

            this.additionalViewData = additionalViewData;

            return this;
        }

        public EditorControl<TModel> HtmlFieldName(string htmlFieldName)
        {
            Contract.Requires<ArgumentException>(!htmlFieldName.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<EditorControl<TModel>>() != null);

            this.htmlFieldName = htmlFieldName;

            return this;
        }

        public EditorControl<TModel> TemplateName(string templateName)
        {
            Contract.Requires<ArgumentException>(!templateName.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<EditorControl<TModel>>() != null);

            this.templateName = templateName;

            return this;
        }

        protected override string RenderControl()
        {
            Contract.Ensures(!Contract.Result<string>().IsNullOrWhiteSpace());

            return html.Editor(expression, templateName, htmlFieldName, additionalViewData).ToHtmlString();
        }	
    }
}
