using HyperSlackers.Bootstrap.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using HyperSlackers.Bootstrap.Extensions;

namespace HyperSlackers.Bootstrap.Controls
{
    public class DisplayControl<TModel> : InputControlBase<DisplayControl<TModel>, TModel>
    {
        internal string templateName;
        internal string expression;
        internal object additionalViewData;

        internal DisplayControl(HtmlHelper<TModel> html, string expression, ModelMetadata metadata)
            : base(html, string.Empty, metadata)
		{
            Contract.Requires<ArgumentNullException>(html != null, "html");
            Contract.Requires<ArgumentException>(!expression.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentNullException>(metadata != null, "metadata");

			this.expression = expression;
		}

        public DisplayControl<TModel> AdditionalViewData(object additionalViewData)
        {
            Contract.Requires<ArgumentNullException>(additionalViewData != null, "additionalViewData");
            Contract.Ensures(Contract.Result<DisplayControl<TModel>>() != null);

            this.additionalViewData = additionalViewData;

            return this;
        }

        public DisplayControl<TModel> TemplateName(string templateName)
        {
            Contract.Requires<ArgumentException>(!templateName.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<DisplayControl<TModel>>() != null);

            this.templateName = templateName;

            return this;
        }

        protected override string RenderControl()
        {
            Contract.Ensures(!Contract.Result<string>().IsNullOrWhiteSpace());

            return "<div class='form-control-static'>{0}</div>".FormatWith(html.Display(expression, templateName, htmlFieldName, additionalViewData).ToHtmlString());
        }
    }
}
